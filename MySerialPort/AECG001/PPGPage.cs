using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WhaleTeqSDK;

namespace AECG100Demo
{
    public partial class PPGPage: UserControl, IPageControl
    {
        private PPG_WAVEFORM channel1Waveform;
        private PPG_WAVEFORM channel2Waveform;
        private PPG_WAVEFORM channel1OutputWaveform;
        private PPG_WAVEFORM channel2OutputWaveform;

        private OutputSignalCallback outputChannel1CB;
        private OutputSignalCallback outputChannel2CB;

        public PPGPage ()
        {
            InitializeComponent ();

            channel1Waveform = UtilConfig.GetPPGChannel1WaveformDefault ();
            channel2Waveform = UtilConfig.GetPPGChannel2WaveformDefault ();

            outputChannel1CB = new OutputSignalCallback (AECGOutputChannel1Callback);
            outputChannel2CB = new OutputSignalCallback (AECGOutputChannel2Callback);

            SyncConfig ();
        }

        public void onConnected ()
        {
            groupChannel2.Enabled = MainForm.Instance.PPGChannel2Supported;

            groupChannel1.Text = UtilConfig.Channel1Text;
            groupChannel2.Text = UtilConfig.Channel2Text;
        }

        public void onStartOutput ()
        {
            channel1OutputWaveform = channel1Waveform;
            channel2OutputWaveform = channel2Waveform;

            MainForm.Instance.GraphSetYAxisScale (0, 0, 30);
            MainForm.Instance.GraphSetYAxisScale (1, 0, 30);
            OutputCounter = 0;

            bool result = false;
            if (MainForm.Instance.PPGChannel2Supported) {
                result = AECG100.OutputPPGEx (ref channel1OutputWaveform, ref channel2OutputWaveform, outputChannel1CB, outputChannel2CB);
            } else {
                result = AECG100.OutputPPG (PPGChannel.Channel1, ref channel1OutputWaveform, outputChannel1CB);
            }
            
            if (result) {
                MainForm.Instance.OutputStarted ();
            } else {
                MessageBox.Show ("Error: output waveform failed", "WhaleTeq", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AECGOutputChannel1Callback (double time, int ac, int dc)
        {
            if (ac == int.MinValue) {
                MainForm.Instance.BeginInvoke (new MethodInvoker (MainForm.Instance.OutputStopped));
                return;
            }

            if (MainForm.Instance.PPGChannel2Supported) {
                MainForm.Instance.GraphAddPoint (0, time, ac / 1000.0, false);
            } else {
                uint counter = OutputCounter++;
                MainForm.Instance.GraphAddPoint (0, time, ac / 1000.0, ((counter % 200) == 0));
            }
        }

        private void AECGOutputChannel2Callback (double time, int ac, int dc)
        {
            if (ac == int.MinValue) {
                MainForm.Instance.BeginInvoke (new MethodInvoker (MainForm.Instance.OutputStopped));
                return;
            }

            uint counter = OutputCounter++;
            MainForm.Instance.GraphAddPoint (1, time, ac / 1000.0, ((counter % 200) == 0));
        }
        
        private void SyncConfig ()
        {
            PPG_WAVEFORM ppg = channel1Waveform;
            comboChannel1Waveform.SelectedIndex = ppg.WaveformType;
            numChannel1PI.Value = (decimal)(ppg.VolSP / channel1Waveform.VolDC * 100);
            numChannel1VolDC.Value = (decimal)ppg.VolDC;
            numChannel1VolSP.Value = (decimal)ppg.VolSP;
            numChannel1VolDN.Value = (decimal)ppg.VolDN;
            numChannel1VolDP.Value = (decimal)ppg.VolDP;
            numChannel1TimeSP.Value = (decimal)ppg.TimeSP;
            numChannel1TimeDN.Value = (decimal)ppg.TimeDN;
            numChannel1TimeDP.Value = (decimal)ppg.TimeDP;

            ppg = channel2Waveform;
            comboChannel2Waveform.SelectedIndex = ppg.WaveformType;
            numChannel2PI.Value = (decimal)(ppg.VolSP / channel1Waveform.VolDC * 100);
            numChannel2VolDC.Value = (decimal)ppg.VolDC;
            numChannel2VolSP.Value = (decimal)ppg.VolSP;
            numChannel2VolDN.Value = (decimal)ppg.VolDN;
            numChannel2VolDP.Value = (decimal)ppg.VolDP;
            numChannel2TimeSP.Value = (decimal)ppg.TimeSP;
            numChannel2TimeDN.Value = (decimal)ppg.TimeDN;
            numChannel2TimeDP.Value = (decimal)ppg.TimeDP;
        }

        private uint OutputCounter
        {
            get;
            set;
        }

        private void onBPMValueChanged (object sender, EventArgs e)
        {
            int period = (int) (60000.0 / (double)numBPM.Value);
            bool update = period < channel1Waveform.TimePeriod;

            channel1Waveform.Frequency = (double)numBPM.Value / 60.0;
            channel1Waveform.TimePeriod = period;
            channel2Waveform.Frequency = (double)numBPM.Value / 60.0;
            channel2Waveform.TimePeriod = period;

            NumericUpDown[] timeCtrl = new NumericUpDown[] {
                numChannel1TimeSP, numChannel1TimeDN, numChannel1TimeDP,
                numChannel2TimeSP, numChannel2TimeDN, numChannel2TimeDP
            };

            foreach (NumericUpDown ctrl in timeCtrl) {
                ctrl.Maximum = period;
            }

            if (!update) {
                return;
            }

            foreach (NumericUpDown ctrl in timeCtrl) {
                if (ctrl.Value > period) {
                    ctrl.Value = period;
                }
            } 
        }

        private void onChannel1WaveformSelectedIndexChanged (object sender, EventArgs e)
        {
            channel1Waveform.WaveformType = comboChannel1Waveform.SelectedIndex;

            bool isPPGWaveform = (comboChannel1Waveform.SelectedIndex == (int)PPGWaveformType.PPG);
            Control[] ctrls = { _labelChannel1VolDN, _labelChannel1VolDP, numChannel1VolDN, numChannel1VolDP, groupChannel1Time };
            foreach (Control ctrl in ctrls) {
                ctrl.Enabled = isPPGWaveform;
            }
        }

        private void onChannel1PIValueChanged (object sender, EventArgs e)
        {
            try {
                numChannel1VolDC.Value = numChannel1VolSP.Value / numChannel1PI.Value * 100m;
            }
            catch {
                numChannel1PI.Value = numChannel1VolSP.Value / numChannel1VolDC.Value * 100m;
                return;
            }
        }

        private void onChannel1DCValueChanged (object sender, EventArgs e)
        {
            numChannel1PI.Value = numChannel1VolSP.Value / numChannel1VolDC.Value * 100;
            channel1Waveform.VolDC = (double)numChannel1VolDC.Value;
        }

        private void onChannel1VoltageValueChanged (object sender, EventArgs e)
        {
            numChannel1PI.Value = numChannel1VolSP.Value / numChannel1VolDC.Value * 100;

            channel1Waveform.VolSP = (double)numChannel1VolSP.Value;
            channel1Waveform.VolDN = (double)numChannel1VolDN.Value;
            channel1Waveform.VolDP = (double)numChannel1VolDP.Value;
        }

        private void onChannel1TimeValueChanged (object sender, EventArgs e)
        {
            if (numChannel1TimeDN.Value < numChannel1TimeSP.Value) {
                numChannel1TimeDN.Value = numChannel1TimeSP.Value;
            }

            if (numChannel1TimeDP.Value < numChannel1TimeDN.Value) {
                numChannel1TimeDP.Value = numChannel1TimeDN.Value;
            }

            channel1Waveform.TimeSP = (int)numChannel1TimeSP.Value;
            channel1Waveform.TimeDN = (int)numChannel1TimeDN.Value;
            channel1Waveform.TimeDP = (int)numChannel1TimeDP.Value;
        }

        private void onChannel2WaveformSelectedIndexChanged (object sender, EventArgs e)
        {
            channel2Waveform.WaveformType = comboChannel2Waveform.SelectedIndex;

            bool isPPGWaveform = (comboChannel2Waveform.SelectedIndex == (int)PPGWaveformType.PPG);
            Control[] ctrls = { _labelChannel2VolDN, _labelChannel2VolDP, numChannel2VolDN, numChannel2VolDP, groupChannel2Time };
            foreach (Control ctrl in ctrls) {
                ctrl.Enabled = isPPGWaveform;
            }
        }

        private void onChannel2PIValueChanged (object sender, EventArgs e)
        {
            try {
                numChannel2VolDC.Value = numChannel2VolSP.Value / numChannel2PI.Value * 200m;
            }
            catch {
                numChannel2PI.Value = numChannel2VolSP.Value / numChannel2VolDC.Value * 200m;
                return;
            }
        }

        private void onChannel2DCValueChanged (object sender, EventArgs e)
        {
            numChannel2PI.Value = numChannel2VolSP.Value / numChannel2VolDC.Value * 200;
            channel2Waveform.VolDC = (double)numChannel2VolDC.Value;
        }

        private void onChannel2VoltageValueChanged (object sender, EventArgs e)
        {
            numChannel2PI.Value = numChannel2VolSP.Value / numChannel2VolDC.Value * 200;

            channel2Waveform.VolSP = (double)numChannel2VolSP.Value;
            channel2Waveform.VolDN = (double)numChannel2VolDN.Value;
            channel2Waveform.VolDP = (double)numChannel2VolDP.Value;
        }

        private void onChannel2TimeValueChanged (object sender, EventArgs e)
        {
            channel2Waveform.TimeSP = (int)numChannel2TimeSP.Value;
            channel2Waveform.TimeDN = (int)numChannel2TimeDN.Value;
            channel2Waveform.TimeDP = (int)numChannel2TimeDP.Value;
        }

        private void onSyncCheckedChanged (object sender, EventArgs e)
        {
            channel1Waveform.SyncPulse = channel2Waveform.SyncPulse = checkSignalSyncPluse.Checked ? (int)SyncPulse.Sync : (int)SyncPulse.SyncOff;
        }
    }
}
