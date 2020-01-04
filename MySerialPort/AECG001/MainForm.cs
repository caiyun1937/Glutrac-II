using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WhaleTeqSDK;
using ZedGraph;

namespace AECG100Demo
{
    public partial class MainForm: Form
    {
        static MainForm mainForm = null;

        private ConnectedCallback connectedCB;
        private ZedGraphControl graphControl;
        private MODEL_INFORMATION ppgModelInfo;

        private double[] timeCurrent = new double[2] { 0, 0 };
        private double[] lastTime = new double[2] { 0, 0 };
        private double[] lastData = new double[2] { 0, 0 };

        static public MainForm Instance
        {
            get
            {
                if (mainForm == null) {
                    mainForm = new MainForm ();
                }
                return mainForm;
            }
        }

        public MainForm ()
        {
            InitializeComponent ();

            InitGraph ();
            this.Text = Title;
            connectedCB = new ConnectedCallback (DeviceConnectedHandler);
            ReconnectUSB ();
            
#if (DEBUG)
            //tabMain.SelectedIndex = 1;
#endif
        }

        public void OutputStarted ()
        {
            Outputting = true;
            btnOutput.Text = "Stop";

        }

        public void OutputStopped ()
        {
            Outputting = false;
            btnOutput.Text = "Start";
            graphControl.Invalidate ();
        }

        public void GraphSetYAxisScale (int curve, double min, double max)
        {
            if (curve == 0) {
                graphControl.GraphPane.YAxis.Scale.Max = max;
                graphControl.GraphPane.YAxis.Scale.Min = min;
            } else {
                graphControl.GraphPane.Y2Axis.Scale.Max = max;
                graphControl.GraphPane.Y2Axis.Scale.Min = min;
            }
            graphControl.AxisChange ();
        }

        public void GraphReset ()
        {
            graphControl.GraphPane.CurveList[0].Clear ();
            graphControl.GraphPane.CurveList[1].Clear ();
            timeCurrent = new double[2] { 0, 0 };
            lastTime = new double[2] { 0, 0 };
            lastData = new double[2] { 0, 0 };
        }

        public void GraphAddPoint (int curve, double time, double value, bool redraw = false)
        {
            if (IsFormClosing) {
                return;
            }

            bool force = false;
            double timeMax = (int)graphControl.GraphPane.XAxis.Scale.Max;

            if (timeCurrent[curve] == 0) {
                graphControl.GraphPane.CurveList[curve].Clear ();
                redraw = true;
                force = true;
            }

            graphControl.GraphPane.CurveList[curve].AddPoint (timeCurrent[curve], value);

            if (timeCurrent[curve] == 0 && time != 0) {
                graphControl.GraphPane.CurveList[curve].AddPoint (timeCurrent[curve], lastData[curve]);

                timeCurrent[curve] += 0.001;
                graphControl.GraphPane.CurveList[curve].AddPoint (timeCurrent[curve], value);
            }

            timeCurrent[curve] += 0.001;

            if (timeCurrent[curve] >= timeMax) {
                redraw = true;
                force = true;
            }

            if (timeCurrent[curve] > timeMax) {
                timeCurrent[curve] = 0;
            }

            if (redraw) {
                graphControl.Invalidate ();
            }

            if (force) {
                GraphForceRedraw ();
            }

            lastTime[curve] = time;
            lastData[curve] = value;
        }

        public void ResetUSB ()
        {
            AECG100.Free ();
        }

        public void ReconnectUSB ()
        {
            AECG100.Init (connectedCB);
        }

        public MODEL_INFORMATION PPGModelInfo
        {
            get
            {
                return ppgModelInfo;
            }
        }

        public bool PPGChannel2Supported
        {
            get
            {
                return (ppgModelInfo.LEDType2 != (int)LEDType.None);
            }
        }

        private void InitGraph ()
        {
            graphControl = new ZedGraphControl ();
            panelGraph.Controls.Add (graphControl);
            graphControl.Dock = DockStyle.Fill;

            graphControl.ScrollGrace = 0;
            graphControl.ScrollMaxX = 0;
            graphControl.ScrollMaxY = 0;
            graphControl.ScrollMaxY2 = 0;
            graphControl.ScrollMinX = 0;
            graphControl.ScrollMinY = 0;
            graphControl.ScrollMinY2 = 0;

            GraphPane GP = graphControl.GraphPane;
            Axis X = GP.XAxis;
            Axis Y1 = GP.YAxis;
            Axis Y2 = GP.Y2Axis;

            GP.Title.IsVisible = false;
            X.Title.IsVisible = false;
            Y1.Title.IsVisible = false;
            Y2.Title.IsVisible = false;

            X.Scale.IsVisible = true;
            X.Scale.Max = 5;
            X.Scale.Min = 0;
            X.Scale.FontSpec.Size = 10;
            X.Scale.MajorStep = 5;
            X.Scale.MinorStep = 1;
            X.MinorGrid.IsVisible = false;
            X.MinorGrid.DashOff = 1;
            X.MinorGrid.DashOn = 5;
            X.MinorGrid.Color = Color.Pink;
            X.MajorGrid.IsVisible = false;
            X.MajorGrid.DashOff = 0;
            X.MajorGrid.DashOn = 10;
            X.MajorGrid.Color = Color.Pink;

            Y1.IsVisible = true;
            Y1.IsAxisSegmentVisible = false;
            Y1.Scale.IsVisible = true;
            Y1.Scale.FontSpec.Size = 10;
            Y1.Scale.Max = 30;
            Y1.Scale.Min = 0;
            Y1.Scale.MajorStep = 30;
            Y1.Scale.MinorStep = 6;
            Y1.MajorGrid.IsZeroLine = false;
            Y1.MajorGrid.IsVisible = false;
            Y1.MinorGrid.IsVisible = false;            

            Y2.IsVisible = true;
            Y2.IsAxisSegmentVisible = false;
            Y2.Scale.IsVisible = true;
            Y2.Scale.FontSpec.Size = 10;
            Y2.Scale.Max = 30;
            Y2.Scale.Min = 0;
            Y2.Scale.MajorStep = 30;
            Y2.Scale.MinorStep = 6;
            Y2.MajorGrid.IsZeroLine = false;
            Y2.MajorGrid.IsVisible = false;
            Y2.MinorGrid.IsVisible = false;

            Color[] crCurve = new Color[] { Color.DarkOrange, Color.DodgerBlue };
            for (int i = 0; i < 2; i++) {
                GP.AddCurve ("", new PointPairList (), crCurve[i], SymbolType.None);
                (GP.CurveList[i] as LineItem).Line.IsSmooth = true;
                (GP.CurveList[i] as LineItem).Line.SmoothTension = 0f;
            }

            (GP.CurveList[1] as LineItem).IsY2Axis = true;
        }        

        private delegate void DeviceConnectedHandlerCallback (bool connected);
        private void DeviceConnectedHandler (bool connected)
        {
            if (this.InvokeRequired) {
                DeviceConnectedHandlerCallback cb = new DeviceConnectedHandlerCallback (DeviceConnectedHandler);
                this.BeginInvoke (cb, connected);
                return;
            }

            Connected = connected;

            if (connected) {
                AECG100.GetPPGDeviceInformation (out ppgModelInfo);

                UpdateFormTitle (Title + " (Device CONNECT)");
                NotifyConnected ();
            } else {
                UpdateFormTitle (Title + " (Device NOT FOUND)");
            }
        }

        private delegate void UpdateFormTitleCallback (string title);
        private void UpdateFormTitle (string title)
        {
            if (this.InvokeRequired) {
                UpdateFormTitleCallback update = new UpdateFormTitleCallback (UpdateFormTitle);
                this.BeginInvoke (update, title);
                return;
            }

            this.Text = title;
        }

        private void NotifyConnected ()
        {
            foreach (TabPage page in tabMain.TabPages) {
                IPageControl ctrl = page.Controls[0] as IPageControl;
                if (ctrl == null) {
                    continue;
                }

                ctrl.onConnected ();
            }
        }

        private void GraphForceRedraw ()
        {
            if (this.InvokeRequired) {
                this.BeginInvoke (new MethodInvoker (() => graphControl.Refresh ()));
                System.Threading.Thread.Sleep (1);
                return;
            }

            graphControl.Refresh ();
        }

        private bool Connected
        {
            get;
            set;
        }

        private string Title
        {
            get { return "WhaleTeq AECG100 Test System (DEMO)"; }
        }

        private bool Outputting
        {
            get;
            set;
        }

        private bool IsFormClosing
        {
            get;
            set;
        }

        private void onOutputClick (object sender, EventArgs e)
        {
            if (Outputting) {
                //(tabMain.TabPages[tabMain.SelectedIndex].Controls[0] as IPageControl).onStopOutput ();
                AECG100.StopOutputWaveform ();
            } else {
                GraphReset ();
                (tabMain.TabPages[tabMain.SelectedIndex].Controls[0] as IPageControl).onStartOutput ();
            }
            btnOutput.Enabled = false;
        }

        private void onFormClosing (object sender, FormClosingEventArgs e)
        {
            IsFormClosing = true;
            AECG100.StopOutputWaveform ();
        }
    }
}
