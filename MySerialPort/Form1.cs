using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EzioDll;
using C_Sharp_Application;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using ThoughtWorks.QRCode.Codec;
using AECG100Demo;

enum UPPER_MODE
{
    SCAN_QRCODE = 0,
    PRINT_QRCODE,
}

enum SIGNAL_MODE
{
    SIGNAL_NONE = 0,
    PPG_GREEN,
    PPG_RED,
    PPG_IR,
    NIR_GREEN,
    NIR_RED,
    NIR_IR,
    NIR_1450,
    NIR_1600,
    NIR_1650,
}

namespace MySerialPort
{
    public partial class Form1 : Form
    {
        UPPER_MODE UpperMode = UPPER_MODE.SCAN_QRCODE;
        //UPPER_MODE UpperMode = UPPER_MODE.PRINT_QRCODE;
        SIGNAL_MODE SignalMode = SIGNAL_MODE.SIGNAL_NONE;

        GodexPrinter Printer = new GodexPrinter();

        public long m_DeviceHandle_8U2;
        public long m_DeviceHandle_9U2;
        ushort m_StartPixels_8U2;
        ushort m_StopPixels_8U2;
        ushort m_StartPixels_9U2;
        ushort m_StopPixels_9U2;
        ulong m_StartTicks;
        uint m_Measurements;
        uint m_Failures;
        public avaspec.PixelArrayType m_Lambda_8U2 = new avaspec.PixelArrayType();
        public avaspec.PixelArrayType m_Lambda_9U2 = new avaspec.PixelArrayType();
        public avaspec.PixelArrayType m_Spectrum_8U2 = new avaspec.PixelArrayType();
        public avaspec.PixelArrayType m_Spectrum_9U2 = new avaspec.PixelArrayType();
        ushort m_NrPixels_8U2;
        ushort m_NrPixels_9U2;
        uint m_PreviousTimeStamp_8U2;
        uint m_PreviousTimeStamp_9U2;

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

        }

        private string strSN = "";
        private string devSN = "";
        private string strMAC = "";
        private int rowSN = new int();
        private bool SNSave = true;
        private bool testError = true;
        private string ExpandedName = "";

        private myMsgBox myMessageBox = new myMsgBox();
        private ECGPage ecgPage = new ECGPage();

        private void GetNewSN()
        {
            if (File.Exists("backup" + ExpandedName))
            {
                try
                {
                    File.Delete("SN" + ExpandedName);
                    File.Move("backup" + ExpandedName, "SN" + ExpandedName);
                }
                catch
                {
                    myMessageBox.Show("请关闭\"SN.xlsx\"并重启软件!",Color.Red);
                    strSN = "";
                    return;
                }
            }

            this.dataGridViewSN.DataSource = bindData("SN" + ExpandedName);

            foreach (DataGridViewRow dgr in dataGridViewSN.Rows)        // 寻找空闲的SN码
            {
                Object input = dgr.Cells["已写入"].EditedFormattedValue;
                if (input.ToString() == "0")
                {
                    //帧头	序列号	产地	年	月	型号	已写入
                    rowSN = dgr.Index;
                    strSN = dgr.Cells["帧头"].Value.ToString() + dgr.Cells["序列号"].Value.ToString().PadLeft(4, '0') +
                            dgr.Cells["产地"].Value.ToString() + dgr.Cells["年"].Value.ToString() +
                            dgr.Cells["月"].Value.ToString() + dgr.Cells["型号"].Value.ToString();

                    if (comboBoxTestItem.Text.Equals("主板测试") && strSN.Length != 14)
                    {
                        myMessageBox.Show("主板SN码有误，请核实!!", Color.Red);
                    }
                    else if ((comboBoxTestItem.Text.Equals("PPG PCBA测试") || comboBoxTestItem.Text.Equals("PPG 半成品测试")) && strSN.Length != 13)
                    {
                        myMessageBox.Show("PPG SN码有误，请核实!!", Color.Red);
                    }
                    else
                    {
                        textBoxSN.Text = strSN;

                        string str = strSN;

                        if (str.IndexOf("\n") != -1)
                        {
                            str = str.Replace("\n", "");
                        }
                        if (str.IndexOf("\r") != -1)
                        {
                            str = str.Replace("\r", "");
                        }
                        str = asciiToHex(str);
                        str = str.Replace(" ", "");

                        foreach (DataGridViewRow dgrSN in dataGridViewMain.Rows)
                        {
                            //更新测试表
                            Object inputSN = dgrSN.Cells["输入命令"].EditedFormattedValue;
                            if (inputSN == null || inputSN.ToString() == "" || !inputSN.ToString().Substring(6, 2).Equals("23"))
                            {
                                continue;
                            }
                            String fins = "bc aa 23 " + str + " 0d";
                            dgrSN.Cells["输入命令"].Value = fins;
                        }
                        SNSave = true;
                    }

                    return;
                }
            }
            textBoxSN.Text = "请关闭SN码表或者增加新的SN码!!";
        }

        private void ConnectGui()
        {
            avaspec.DeviceConfigType l_pDeviceData_8U2 = new avaspec.DeviceConfigType();
            avaspec.DeviceConfigType l_pDeviceData_9U2 = new avaspec.DeviceConfigType();

            uint l_Size = 0;

            avaspec.AVS_GetNumPixels((IntPtr)m_DeviceHandle_8U2, ref m_NrPixels_8U2);
            avaspec.AVS_GetNumPixels((IntPtr)m_DeviceHandle_9U2, ref m_NrPixels_9U2);

            l_Size = (uint)Marshal.SizeOf(typeof(avaspec.DeviceConfigType));

            int l_Res_8U2 = (int)avaspec.AVS_GetParameter((IntPtr)m_DeviceHandle_8U2, l_Size, ref l_Size, ref l_pDeviceData_8U2);
            if (l_Res_8U2 != avaspec.ERR_SUCCESS)
                return;

            int l_Res_9U2 = (int)avaspec.AVS_GetParameter((IntPtr)m_DeviceHandle_9U2, l_Size, ref l_Size, ref l_pDeviceData_9U2);
            if (l_Res_9U2 != avaspec.ERR_SUCCESS)
                return;

            m_StartPixels_8U2 = l_pDeviceData_8U2.m_StandAlone.m_Meas.m_StartPixel;
            m_StopPixels_8U2 = l_pDeviceData_8U2.m_StandAlone.m_Meas.m_StopPixel;

            m_StartPixels_9U2 = l_pDeviceData_9U2.m_StandAlone.m_Meas.m_StartPixel;
            m_StopPixels_9U2 = l_pDeviceData_9U2.m_StandAlone.m_Meas.m_StopPixel;
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            if (spectrographEnable == true)
            {
                int l_Res_8U2 = (int)avaspec.AVS_StopMeasure((IntPtr)m_DeviceHandle_8U2);
                int l_Res_9U2 = (int)avaspec.AVS_StopMeasure((IntPtr)m_DeviceHandle_9U2);

                avaspec.AVS_Deactivate((IntPtr)m_DeviceHandle_8U2);
                m_DeviceHandle_8U2 = avaspec.INVALID_AVS_HANDLE_VALUE;

                avaspec.AVS_Deactivate((IntPtr)m_DeviceHandle_9U2);
                m_DeviceHandle_9U2 = avaspec.INVALID_AVS_HANDLE_VALUE;

                if (m_DeviceHandle_8U2 != avaspec.INVALID_AVS_HANDLE_VALUE)
                {
                    l_Res_8U2 = (int)avaspec.AVS_StopMeasure((IntPtr)m_DeviceHandle_8U2);
                }
                if (m_DeviceHandle_9U2 != avaspec.INVALID_AVS_HANDLE_VALUE)
                {
                    l_Res_9U2 = (int)avaspec.AVS_StopMeasure((IntPtr)m_DeviceHandle_9U2);
                }
                avaspec.AVS_Done();
                spectrographEnable = false;
            }
        }

        public void QRCode(string enCodeString)
        {
            string QRCodeSting = "";
            if (enCodeString.Equals(""))
            {
                myMessageBox.Show("MAC地址为空", Color.Red);
                myMessageBox.DialogResult = DialogResult.No;
                return;
            }
            else
            {
                myMessageBox.DialogResult = DialogResult.Yes;
            }

            System.Drawing.Bitmap bt;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;//编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            qrCodeEncoder.QRCodeScale = 14;//大小(值越大生成的二维码图片像素越高)
            qrCodeEncoder.QRCodeVersion = 0;//版本(注意：设置为0主要是防止编码的字符串太长时发生错误)
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;//错误效验、错误更正(有4个等级)
            qrCodeEncoder.QRCodeBackgroundColor = Color.White;//背景色
            qrCodeEncoder.QRCodeForegroundColor = Color.Black;//前景色

            QRCodeSting = enCodeString.Substring(0, 2) + ":" + enCodeString.Substring(2, 2) + ":" +
                enCodeString.Substring(4, 2) + ":" + enCodeString.Substring(6, 2) + ":" +
                enCodeString.Substring(8, 2) + ":" + enCodeString.Substring(10, 2);

            bt = qrCodeEncoder.Encode(QRCodeSting, Encoding.UTF8);
            pictureBoxShow.Image = Image.FromHbitmap(bt.GetHbitmap());
            pictureBoxShow.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.TopLevel = false;
            mainForm.FormBorderStyle = FormBorderStyle.None;
            this.signal_generator.Controls.Add(mainForm);
            mainForm.Show();

            pictureBoxShow.Visible = false;
            btn_go.Enabled = false;
            btn_output_excel.Enabled = false;
            btn_print_QRCode.Enabled = false;
            btn_again.Enabled = false;
            buttonCheckBarCode.Enabled = false;

            chart1.Visible = false;
            chart1.SendToBack();
            labelScope.Visible = false;
            labelScope.SendToBack();
            
            this.Location = new Point(0, 0);

            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                cmbPort.Items.Clear();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    cmbPort.Items.Add(sValue);
                }
                if (cmbPort.Items.Count > 0)
                    cmbPort.SelectedIndex = 0;
            }
          
            cmbBaud.Text = "115200";
        }

        private const int WM_APP = 0x8000;
        private const int WM_MEAS_READY = WM_APP + 1;
        private const int WM_DBG_INFOAs = WM_APP + 2;
        private const int WM_DEVICE_RESET = WM_APP + 3;

        protected override void WndProc(ref Message a_WinMess)
        {
            ulong l_Ticks = 0;

            if (a_WinMess.Msg == WM_MEAS_READY)
            {
                if ((long)a_WinMess.WParam >= avaspec.ERR_SUCCESS)
                {
                    if (avaspec.ERR_SUCCESS == (int)a_WinMess.WParam) // normal measurements
                    {
                        if (m_NrPixels_8U2 > 0 && m_NrPixels_9U2 > 0)
                        {
                            uint l_Time_8U2 = 0, l_Time_9U2 = 0;
                            if (avaspec.ERR_SUCCESS == (int)avaspec.AVS_GetScopeData((IntPtr)m_DeviceHandle_8U2, ref l_Time_8U2, ref m_Spectrum_8U2))
                            {
                                m_PreviousTimeStamp_8U2 = l_Time_8U2;
                            }
                            if (avaspec.ERR_SUCCESS == (int)avaspec.AVS_GetScopeData((IntPtr)m_DeviceHandle_9U2, ref l_Time_9U2, ref m_Spectrum_9U2))
                            {
                                m_PreviousTimeStamp_9U2 = l_Time_9U2;
                            }
                            chart1.Series["Series1"].Points.Clear();
                            chart1.Series.SuspendUpdates();
                            timer1.Start();
                        }
                        m_Measurements++;
                        l_Ticks = (ulong)Environment.TickCount;
                    }
                    else
                    {
                        for (int j = 1; j <= a_WinMess.WParam.ToInt32(); j++)
                        {
                            avaspec.PixelArrayType l_pSpectrum = new avaspec.PixelArrayType();
                            uint l_Time = 0;
                            if (avaspec.ERR_SUCCESS == avaspec.AVS_GetScopeData((IntPtr)m_DeviceHandle_8U2, ref l_Time, ref l_pSpectrum))
                            {
                                double l_Dif = l_Time - m_PreviousTimeStamp_8U2;  //l_Time in 10 us ticks
                                m_PreviousTimeStamp_8U2 = l_Time;
                            }
                            l_Ticks = (ulong)Environment.TickCount;
                        }
                    }
                }
                else // message.WParam < 0 indicates error 
                {
                    m_Failures++;
                }
            }
            else
            {
                base.WndProc(ref a_WinMess);
            }
        }

        bool isOpened = false;                      //串口状态标志
        bool spectrographEnable = false;            //是否需要连接光谱仪

        private bool getTestCase()
        {
            if (Directory.GetFiles(Application.StartupPath.ToString(), "*.xls").Length > 0)
                ExpandedName = ".xls";
            else if (Directory.GetFiles(Application.StartupPath.ToString(), "*.xlsx").Length > 0)
                ExpandedName = ".xlsx";
            else
                myMessageBox.Show("请在根目录下添加测试表", Color.Red);

            if (comboBoxTestItem.Text.Equals("主板测试") && File.Exists("主板测试" + ExpandedName))
            {
                this.dataGridViewMain.DataSource = bindData("主板测试" + ExpandedName);
                this.tabPage2.Text = "主板测试";

                btn_go.Enabled = true;
                textBoxSN.Focus();
            }
            else if (comboBoxTestItem.Text.Equals("PPG PCBA测试") && File.Exists("PPG测试" + ExpandedName))
            {
                this.dataGridViewMain.DataSource = bindData("PPG测试" + ExpandedName);
                this.tabPage2.Text = "PPG PCBA测试";

                btn_go.Enabled = true;
                textBoxSN.Focus();
                spectrographEnable = true;
            }
            else if (comboBoxTestItem.Text.Equals("PPG 半成品测试") && File.Exists("PPG测试" + ExpandedName))
            {
                this.dataGridViewMain.DataSource = bindData("PPG测试" + ExpandedName);
                this.tabPage2.Text = "PPG 半成品测试";

                btn_go.Enabled = true;
                textBoxSN.Focus();
            }
            else if (comboBoxTestItem.Text.Equals("NIR PCBA测试") && File.Exists("NIR测试" + ExpandedName))
            {
                this.dataGridViewMain.DataSource = bindData("NIR测试" + ExpandedName);
                this.tabPage2.Text = "NIR测试";

                btn_go.Enabled = true;
                textBoxSN.Focus();
                spectrographEnable = true;
            }
            else if (comboBoxTestItem.Text.Equals("整机测试") && File.Exists("主板测试" + ExpandedName))
            {
                this.dataGridViewMain.DataSource = bindData("整机测试" + ExpandedName);
                this.tabPage2.Text = "整机测试";

                btn_go.Enabled = true;
                textBoxMAC.Focus();
                textBoxMAC.ReadOnly = false;
                textBoxSN.ReadOnly = true;
            }
            else if (comboBoxTestItem.Text.Equals("整机PPG NIR测试") && File.Exists("整机PPG NIR测试" + ExpandedName))
            {
                this.dataGridViewMain.DataSource = bindData("整机PPG NIR测试" + ExpandedName);
                this.tabPage2.Text = "整机PPG NIR测试";

                btn_go.Enabled = true;
                textBoxMAC.Focus();
                textBoxMAC.ReadOnly = false;
                textBoxSN.ReadOnly = true;
            }
            else if (comboBoxTestItem.Text.Equals("条形码测试") && File.Exists("条形码测试" + ExpandedName))
            {
                this.dataGridViewMain.DataSource = bindData("条形码测试" + ExpandedName);
                this.tabPage2.Text = "条形码检测";

                btn_go.Enabled = true;
                textBoxMAC.Focus();
                textBoxSN.ReadOnly = true;
                textBoxMAC.ReadOnly = false;
            }
            else
            {
                myMessageBox.Show("请选择测试项目", Color.Red);
                comboBoxTestItem.Focus();
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbPort.Text == "")
            {
                myMessageBox.Show("检测不到串口!!", Color.Red);
                return;
            }

            pictureBoxShow.Visible = false;
            chart1.Visible = false;
            labelScope.Visible = false;

            if (false == getTestCase())
            {
                return;
            }

            if (!isOpened)
            {
                serialPort.PortName = cmbPort.Text;
                serialPort.BaudRate = Convert.ToInt32(cmbBaud.Text, 10);
                try
                {
                    serialPort.Open();     //打开串口
                    buttonOpenComm.Text = "关闭串口";
                    cmbPort.Enabled = false;//关闭使能
                    cmbBaud.Enabled = false;
                    isOpened = true;
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(post_DataReceived);//串口接收处理函数
                    comboBoxTestItem.Enabled = false;
                }
                catch
                {
                    myMessageBox.Show("串口打开失败,请点亮屏幕再继续操作!", Color.Red);
                    return;
                }
            }
            else
            {
                try
                {
                    serialPort.Close();     //关闭串口
                    buttonOpenComm.Text = "打开串口";
                    cmbPort.Enabled = true;//打开使能
                    cmbBaud.Enabled = true;
                    isOpened = false;
                    comboBoxTestItem.Enabled = true;

                    if (spectrographEnable == true)
                    {
                        int l_Res_8U2 = (int)avaspec.AVS_StopMeasure((IntPtr)m_DeviceHandle_8U2);
                        int l_Res_9U2 = (int)avaspec.AVS_StopMeasure((IntPtr)m_DeviceHandle_9U2);

                        avaspec.AVS_Deactivate((IntPtr)m_DeviceHandle_8U2);
                        m_DeviceHandle_8U2 = avaspec.INVALID_AVS_HANDLE_VALUE;

                        avaspec.AVS_Deactivate((IntPtr)m_DeviceHandle_9U2);
                        m_DeviceHandle_9U2 = avaspec.INVALID_AVS_HANDLE_VALUE;

                        if (m_DeviceHandle_8U2 != avaspec.INVALID_AVS_HANDLE_VALUE)
                        {
                            l_Res_8U2 = (int)avaspec.AVS_StopMeasure((IntPtr)m_DeviceHandle_8U2);
                        }
                        if (m_DeviceHandle_9U2 != avaspec.INVALID_AVS_HANDLE_VALUE)
                        {
                            l_Res_9U2 = (int)avaspec.AVS_StopMeasure((IntPtr)m_DeviceHandle_9U2);
                        }
                        avaspec.AVS_Done();
                        spectrographEnable = false;
                    }
                    
                    return;
                }
                catch
                {
                    myMessageBox.Show("串口关闭失败,请点亮屏幕再继续操作!", Color.Red);
                    return;
                }
            }

            // 读取SN号
            if (UpperMode == UPPER_MODE.PRINT_QRCODE)
            {
                GetNewSN();
            }
            else
            {
                //textBoxSN.Text = "";
            }

            // 二维码
            Cbo_PaperType.SelectedIndex = 1;

            // 光谱仪
            if(spectrographEnable == true)
            {
                int l_Port = avaspec.AVS_Init(0);
                avaspec.AVS_Register(this.Handle);

                if (l_Port == avaspec.ERR_DEVICE_NOT_FOUND)
                {
                    avaspec.AVS_Done();
                }

                avaspec.AvsIdentityType channel_8U2 = new avaspec.AvsIdentityType();
                avaspec.AvsIdentityType channel_9U2 = new avaspec.AvsIdentityType();

                long hDevice_8U2 = 0, hDevice_9U2 = 0;

                channel_8U2.m_SerialNumber = "1703018U2";
                channel_9U2.m_SerialNumber = "1703019U2";

                hDevice_8U2 = (long)avaspec.AVS_Activate(ref channel_8U2);
                hDevice_9U2 = (long)avaspec.AVS_Activate(ref channel_9U2);

                m_DeviceHandle_8U2 = hDevice_8U2;
                if (avaspec.AVS_UseHighResAdc((IntPtr)m_DeviceHandle_8U2, true) != avaspec.ERR_SUCCESS)
                {
                    myMessageBox.Show("PPG和NIR的PCBA测试请连接光谱仪，或者重启光谱仪，重启软件!!", Color.Red);
                    System.Environment.Exit(0);
                }

                m_DeviceHandle_9U2 = hDevice_9U2;
                if (avaspec.AVS_UseHighResAdc((IntPtr)m_DeviceHandle_9U2, true) != avaspec.ERR_SUCCESS)
                {
                    myMessageBox.Show("PPG和NIR的PCBA测试请连接光谱仪，或者重启光谱仪，重启软件!!", Color.Red);
                    System.Environment.Exit(0);
                }

                ConnectGui();

                //Prepare Measurement
                avaspec.MeasConfigType l_PrepareMeasData_8U2 = new avaspec.MeasConfigType();
                avaspec.MeasConfigType l_PrepareMeasData_9U2 = new avaspec.MeasConfigType();

                l_PrepareMeasData_9U2.m_StartPixel = l_PrepareMeasData_8U2.m_StartPixel = 0;
                l_PrepareMeasData_8U2.m_StopPixel = 2047;
                l_PrepareMeasData_9U2.m_StopPixel = 511;

                l_PrepareMeasData_9U2.m_IntegrationTime = l_PrepareMeasData_8U2.m_IntegrationTime = 100;
                double l_NanoSec = 20;
                uint l_FPGAClkCycles = (uint)(6.0 * (l_NanoSec + 20.84) / 125.0);
                l_PrepareMeasData_9U2.m_IntegrationDelay = l_PrepareMeasData_8U2.m_IntegrationDelay = l_FPGAClkCycles;
                l_PrepareMeasData_9U2.m_NrAverages = l_PrepareMeasData_8U2.m_NrAverages = 1;

                l_FPGAClkCycles = (uint)(6.0 * l_NanoSec / 125.0);
                l_PrepareMeasData_9U2.m_Control.m_LaserDelay = l_PrepareMeasData_8U2.m_Control.m_LaserDelay = l_FPGAClkCycles;
                l_FPGAClkCycles = (uint)(6.0 * l_NanoSec / 125.0);
                l_PrepareMeasData_9U2.m_Control.m_LaserWidth = l_PrepareMeasData_8U2.m_Control.m_LaserWidth = l_FPGAClkCycles;

                int l_Res_8U2 = (int)avaspec.AVS_PrepareMeasure((IntPtr)m_DeviceHandle_8U2, ref l_PrepareMeasData_8U2);
                int l_Res_9U2 = (int)avaspec.AVS_PrepareMeasure((IntPtr)m_DeviceHandle_9U2, ref l_PrepareMeasData_9U2);
                //Get Nr Of Scans

                short l_NrOfScans = -1;
                if ((l_PrepareMeasData_8U2.m_Control.m_StoreToRam > 0) && (l_PrepareMeasData_9U2.m_Control.m_StoreToRam > 0) && (l_NrOfScans != 1))
                {
                    l_NrOfScans = 1;
                }
                //Start Measurement

                m_StartTicks = (ulong)Environment.TickCount;
                m_Measurements = 0;
                m_Failures = 0;
                m_StartPixels_8U2 = l_PrepareMeasData_8U2.m_StartPixel;
                m_StopPixels_8U2 = l_PrepareMeasData_8U2.m_StopPixel;
                m_StartPixels_9U2 = l_PrepareMeasData_9U2.m_StartPixel;
                m_StopPixels_9U2 = l_PrepareMeasData_9U2.m_StopPixel;

                if (avaspec.ERR_SUCCESS == (int)avaspec.AVS_GetLambda((IntPtr)m_DeviceHandle_8U2, ref m_Lambda_8U2))
                {
                }
                if (avaspec.ERR_SUCCESS == (int)avaspec.AVS_GetLambda((IntPtr)m_DeviceHandle_9U2, ref m_Lambda_9U2))
                {
                }
                chart1.ChartAreas[0].AxisX.Minimum = 200;
                chart1.ChartAreas[0].AxisX.Maximum = 1700;
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0.0}";

                l_Res_8U2 = (int)avaspec.AVS_Measure((IntPtr)m_DeviceHandle_8U2, this.Handle, l_NrOfScans);
                l_Res_9U2 = (int)avaspec.AVS_Measure((IntPtr)m_DeviceHandle_9U2, this.Handle, l_NrOfScans);

            }
        }

        //接收
        private void post_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bool isCheck = checkbox_16show.Checked;

            string str = "";

            if (isCheck)
            {
                byte[] temp = new byte[serialPort.BytesToRead];
                serialPort.Read(temp, 0, temp.Length);
                str = byteToHexStr(temp);
            }
            else
            {
                str = serialPort.ReadExisting();//字符串方式读
            }

            ReceiveTbox.Text = "";//先清除上一次的数据
            ReceiveTbox.Text += str;
        }

        public static int receive = 1;

        private void button2_Click(object sender, EventArgs e)
        {
            //获取16进制是否选中
            bool isCheck=checkbox_16send.Checked;

            if (receive == 0)
            {
                serialPort.DataReceived += new SerialDataReceivedEventHandler(post_DataReceived);//串口接收处理函数
                receive = 1;
            }
            

            //发送数据
            if (serialPort.IsOpen)
            {//如果串口开启
                if (SendTbox.Text.Trim() != "")//如果框内不为空则
                {
                    //根据16进制判断是否需要转码
                    String sendStr= SendTbox.Text.Trim();
                    if (isCheck)
                    {

                        byte[] temps=strToToHexByte(sendStr);
                        serialPort.Write(temps, 0, temps.Length);
                      
                        return;
                       // sendStr = Encoding.ASCII.GetString(temps);
                    }
                    serialPort.Write(sendStr.Trim());//写数据
                }
                else
                {
                    myMessageBox.Show("发送框没有数据", Color.Black);
                }
            }
            else
            {
                myMessageBox.Show("串口未打开", Color.Black);
            }
        }
        
        private void checkbox_16show_CheckedChanged(object sender, EventArgs e)
        {
            string str = "";
            Console.WriteLine(str);
            if (checkbox_16show.Checked)
            {
                str = ReceiveTbox.Text;
                if (str.IndexOf("\n") != -1)
                {
                    str = str.Replace("\n", "");
                }
                if (str.IndexOf("\r") != -1)
                {
                    str = str.Replace("\r", "");
                }
                str = asciiToHex(str);
            }
            else
            {
                byte[] temps = strToToHexByte(ReceiveTbox.Text);
                str = Encoding.ASCII.GetString(temps);
            }
            Console.WriteLine(str);
            ReceiveTbox.Text = str;
        }

        private void checkbox_16send_CheckedChanged(object sender, EventArgs e)
        {
            string str = "";
            Console.WriteLine(str);
            if (checkbox_16send.Checked)
            {
                str = SendTbox.Text;
                if (str.IndexOf("\n") != -1)
                {
                    str = str.Replace("\n", "");
                }
                if (str.IndexOf("\r") != -1)
                {
                    str = str.Replace("\r", "");
                }
                str=asciiToHex(str);
            }
            else
            {
                byte[] temps=  strToToHexByte(SendTbox.Text);
                str = Encoding.ASCII.GetString(temps);
            }
            Console.WriteLine(str);
            SendTbox.Text = str;
        }

        //将字符串转换成16进制
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        public static string ByteToString(byte[] data)
        {
            string returnStr = "";
            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    returnStr += data[i].ToString("X2");
                }
            }
            return returnStr;
        }


        public static string asciiToHex(string str)
        {
            byte[] ba = System.Text.ASCIIEncoding.Default.GetBytes(str);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in ba)
            {
                sb.Append(b.ToString("x") + " ");
            }
            return sb.ToString();
        }
        public static string asciiToTen(string str)
        {
            string d = "";
            for (int i = 0; i < str.Length; i++)
            {
                int ii = (int)Convert.ToChar(str.Substring(i, 1));
                d = d + " " + ii.ToString();
            }
            return d;
        }
        public static string HexStringToString(string hs, Encoding encode)
        {
            string strTemp = "";
            byte[] b = new byte[hs.Length / 2];
            for (int i = 0; i < hs.Length / 2; i++)
            {
                strTemp = hs.Substring(i * 2, 2);
                b[i] = Convert.ToByte(strTemp, 16);
            }
            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }

        //进行数据绑定
        public DataTable bindData(String commandFile)
        {
            ExcelHelper excelHelper = new ExcelHelper(commandFile);
            DataTable dt = excelHelper.ExcelToDataTable("Sheet1", true);
            
            return dt;
        }

        private void cmbPort_DropDown(object sender, EventArgs e)
        {
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                cmbPort.Items.Clear();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    cmbPort.Items.Add(sValue);
                }
                if (cmbPort.Items.Count > 0)
                    cmbPort.SelectedIndex = 0;
            }
        }
        private void sampleImageShow(String str)            //显示示例图
        {
            if (str.Equals("0E"))   //背灯关
            {
                pictureBoxShow.Image = imageList1.Images[0];
                pictureBoxShow.Visible = true;
            }
            else if (str.Equals("0D"))   //背灯开
            {
                pictureBoxShow.Image = imageList1.Images[1];
                pictureBoxShow.Visible = true;
            }
            else if (str.Equals("0F"))   //白场
            {
                pictureBoxShow.Image = imageList1.Images[2];
                pictureBoxShow.Visible = true;
            }
            else if (str.Equals("30"))   //nir 绿灯
            {
                pictureBoxShow.Image = imageList1.Images[6];
                pictureBoxShow.Visible = true;
                SignalMode = SIGNAL_MODE.NIR_GREEN;
            }
            else if (str.Equals("31"))   //nir 红灯
            {
                pictureBoxShow.Image = imageList1.Images[7];
                pictureBoxShow.Visible = true;
                SignalMode = SIGNAL_MODE.NIR_RED;
            }
            else if (str.Equals("32"))   //nir ir
            {
                pictureBoxShow.Image = imageList1.Images[8];
                pictureBoxShow.Visible = true;
                SignalMode = SIGNAL_MODE.NIR_IR;
            }
            else if (str.Equals("33"))   //nir 1650
            {
                pictureBoxShow.Image = imageList1.Images[9];
                pictureBoxShow.Visible = true;
                //SignalMode = SIGNAL_MODE.NIR_1600;
                SignalMode = SIGNAL_MODE.NIR_1650;
            }
            else if (str.Equals("34"))   //nir 1050
            {
                pictureBoxShow.Image = imageList1.Images[10];
                pictureBoxShow.Visible = true;
                SignalMode = SIGNAL_MODE.NIR_1450;
            }
            else if (str.Equals("35"))   //nir 1450
            {
                pictureBoxShow.Image = imageList1.Images[11];
                pictureBoxShow.Visible = true;
                SignalMode = SIGNAL_MODE.NIR_1450;
            }
            else if (str.Equals("36"))   //nir 1550
            {
                pictureBoxShow.Image = imageList1.Images[12];
                pictureBoxShow.Visible = true;
                //SignalMode = SIGNAL_MODE.NIR_1600;
                SignalMode = SIGNAL_MODE.NIR_1650;
            }
            else if (str.Equals("37"))   //ppg 绿灯1
            {
                if(spectrographEnable == true)
                {
                    pictureBoxShow.Image = imageList1.Images[16];
                    pictureBoxShow.Visible = true;
                    SignalMode = SIGNAL_MODE.PPG_GREEN;
                }
                else
                {
                    pictureBoxShow.Image = imageList1.Images[13];         // ok or fail
                    pictureBoxShow.Visible = true;
                }
            }
            else if (str.Equals("38"))   //ppg 红灯 or 绿灯2
            {
                if (spectrographEnable == true)
                {
                    pictureBoxShow.Image = imageList1.Images[17];
                    pictureBoxShow.Visible = true;
                    SignalMode = SIGNAL_MODE.PPG_GREEN;
                }
                else
                {
                    pictureBoxShow.Image = imageList1.Images[14];         // ok or fail
                    pictureBoxShow.Visible = true;
                }
            }
            else if (str.Equals("39"))   //ppg ir
            {
                if (spectrographEnable == true)
                {
                    pictureBoxShow.Image = imageList1.Images[18];
                    pictureBoxShow.Visible = true;
                    SignalMode = SIGNAL_MODE.PPG_IR;
                }
                else
                {
                    //pictureBoxShow.Image = imageList1.Images[15];         // ok or fail
                    pictureBoxShow.Image = imageList1.Images[18];         // ok or fail
                    pictureBoxShow.Visible = true;
                }
            }
        }

        private void CheckECGHR()
        {
            DateTime dt = DateTime.Now;

            while (serialPort.BytesToRead == 0)
            {
                Thread.Sleep(1);
            }
            Thread.Sleep(50); //50毫秒内数据接收完毕，可根据实际情况调整
            byte[] recData = new byte[serialPort.BytesToRead];
            serialPort.Read(recData, 0, recData.Length);

            byte[] temp = recData;
            string str = byteToHexStr(temp);

            if(ecgPage.numBPM.Value.Equals(str.Substring(4, 2)))
            {
                myMessageBox.DialogResult = DialogResult.Yes;
                myMessageBox.Close();
            }
        }

        bool gBTLinkStatus = false;

        private void btn_go_Click(object sender, EventArgs e)
        {
            ecgPage.Show();
            
            if (dataGridViewMain.DataSource == null)
            {
                myMessageBox.Show("目标数据源为空,请确认目录下存在测试表!", Color.Black);
                return;
            }

            if (UpperMode == UPPER_MODE.SCAN_QRCODE)
            {
                if (textBoxSN.Text != "" && ((comboBoxTestItem.Text.Equals("主板测试") && textBoxSN.Text.Length == 14 && textBoxSN.Text.Substring(0, 3).Equals("BBF")) ||                                           // 主板测试
                    ((comboBoxTestItem.Text.Equals("PPG PCBA测试") || comboBoxTestItem.Text.Equals("PPG 半成品测试")) && textBoxSN.Text.Length == 13 && textBoxSN.Text.Substring(0, 3).Equals("PPG")) ||           // PPG_PCBA || PPG半成品测试
                    (comboBoxTestItem.Text.Equals("NIR PCBA测试") && textBoxSN.Text.Length == 13 && textBoxSN.Text.Substring(0, 3).Equals("NIR"))))                                                               // NIR_PCBA
                {
                    strSN = textBoxSN.Text;
                }
                else if ((comboBoxTestItem.Text.Equals("条形码测试") && textBoxMAC.Text.Length == 17) || ((comboBoxTestItem.Text.Equals("整机测试") || comboBoxTestItem.Text.Equals("整机PPG NIR测试")) && textBoxMAC.Text.Length == 12))
                {
                    strMAC = textBoxMAC.Text;
                }
                else
                {
                    textBoxSN.Text = "";
                    textBoxMAC.Text = "";
                    textBoxBarCode.Text = "";

                    if (comboBoxTestItem.Text.Equals("条形码测试")  || comboBoxTestItem.Text.Equals("整机测试") || comboBoxTestItem.Text.Equals("整机PPG NIR测试"))
                    {
                        myMessageBox.Show("切换到英文输入法,并在\"MAC:\"文本框英中使用扫码枪扫描手环二维码!!", Color.Red);
                        textBoxMAC.Focus();
                    }
                    else
                    {
                        myMessageBox.Show("请在英文输入法环境下使用扫码枪扫描二维码!!", Color.Red);
                        textBoxSN.Focus();
                    }
                    return;
                }
            }

            testError = true;

            serialPort.DataReceived -= new SerialDataReceivedEventHandler(post_DataReceived);
            receive = 0; //解除绑定函数
            try
            {
                foreach (DataGridViewRow dgr in dataGridViewMain.Rows)
                {
                    String inputName = dgr.Cells["名字"].EditedFormattedValue.ToString();
                    String inputCommand = dgr.Cells["输入命令"].EditedFormattedValue.ToString();

                    if (inputName == "")
                        continue;

                    byte[] recData = new byte[serialPort.BytesToRead];
                    serialPort.Read(recData, 0, recData.Length);

                    if (comboBoxTestItem.Text.Equals("条形码测试") && inputName != "测试开始" && inputName != "MAC地址读出" && inputName != "SN码读出" && inputName != "测试结束")
                    {
                        continue;
                    }

                    //发送数据
                    if ("充电电流" == inputName)             //  没有输入命令的测试项
                    {
                        myMessageBox.Show("请观察万用表" + inputName + "是否在100~450mA之间？", Color.Black);
                        if (myMessageBox.DialogResult == DialogResult.Yes)
                        {
                            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgr.Cells["是否通过"].Value = "✔";
                            dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                        }
                        else if (myMessageBox.DialogResult == DialogResult.No)
                        {
                            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgr.Cells["是否通过"].Value = "✘";
                            dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                            testError = false;
                        }
                        continue;
                    }
                    else if (("SN码写入" == inputName || "SN码读出" == inputName || "SN码校验" == inputName) && comboBoxTestItem.Text.Equals("整机测试"))               // 实际是MAC地址
                    {
                        continue;
                    }
                    else if ("蓝牙连接测试" == inputName)
                    {
                        myMessageBox.Show("是否需要测试蓝牙连接+ECG心率", Color.Red);
                        if (myMessageBox.DialogResult == DialogResult.Yes)
                        {
                            QRCode(textBoxMAC.Text);
                            myMessageBox.Show("请用APP点击【主板蓝牙连接 + ECG功能测试】扫描二维码进行测试", Color.Black);

                            myMessageBox.Show("蓝牙连接是否成功", Color.Black);
                            if (myMessageBox.DialogResult == DialogResult.Yes)
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✔";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                                pictureBoxShow.Visible = false;
                                gBTLinkStatus = true;
                            }
                            else if (myMessageBox.DialogResult == DialogResult.No)
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✘";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                                pictureBoxShow.Visible = false;
                                testError = false;
                                gBTLinkStatus = false;
                            }
                            continue;
                        }
                        else
                        {
                            gBTLinkStatus = false;
                            continue;
                        }
                    }
                    else if ("ECG心率测试" == inputName)
                    {
                        if (gBTLinkStatus == true)
                        {
                            myMessageBox.Show("请观察APP的ECG心率测试是否通过", Color.Black);
                            if (myMessageBox.DialogResult == DialogResult.Yes)
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✔";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                            }
                            else if (myMessageBox.DialogResult == DialogResult.No)
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✘";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                                testError = false;
                            }
                        }
                        continue;
                    }
                    else if ("ADPD105测试" == inputName || "SI1171测试" == inputName || "SFH7050测试" == inputName)           // 传感器自检
                    {
                        sampleImageShow(inputCommand.Substring(6, 2));

                        chart1.Visible = true;
                        chart1.BringToFront();

                        labelScope.Visible = true;
                        labelScope.BringToFront();

                        myMessageBox.Show("请用白色纸板遮住示例图所示位置", Color.Black);

                        pictureBoxShow.Visible = false;
                        chart1.Visible = false;
                        chart1.SendToBack();
                        labelScope.Visible = false;
                        labelScope.SendToBack();
                    }

                    byte[] temps = strToToHexByte(inputCommand);
                    byte[] temp;
                    string str;

                    //接受发送
                    WritePort(temps);

                    if (comboBoxTestItem.Text.Equals("PPG PCBA测试") || comboBoxTestItem.Text.Equals("NIR PCBA测试"))       // ggp nir pcba测试以光谱仪为准
                    {
                        if ((inputCommand.Substring(6, 2).Equals("30") || inputCommand.Substring(6, 2).Equals("31") ||
                            inputCommand.Substring(6, 2).Equals("32") || inputCommand.Substring(6, 2).Equals("33") ||
                            inputCommand.Substring(6, 2).Equals("34") || inputCommand.Substring(6, 2).Equals("35") ||
                            inputCommand.Substring(6, 2).Equals("36") || inputCommand.Substring(6, 2).Equals("37") ||
                            inputCommand.Substring(6, 2).Equals("38") || inputCommand.Substring(6, 2).Equals("39")) &&
                            "SI1171测试" != inputName && "ADPD105测试" != inputName && "SFH7050测试" != inputName)                             // SI1171 || ADPD105测试
                        {
                            sampleImageShow(inputCommand.Substring(6, 2));
                            signalCnt = 0;

                            chart1.Visible = true;
                            chart1.BringToFront();

                            labelScope.Visible = true;
                            labelScope.BringToFront();

                            myMessageBox.Show("请将光谱仪探头对准示例图所示位置,请观察" + dgr.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", Color.Black);

                            pictureBoxShow.Visible = false;
                            chart1.Visible = false;
                            chart1.SendToBack();
                            labelScope.Visible = false;
                            labelScope.SendToBack();

                            if (myMessageBox.DialogResult == DialogResult.Yes)
                            {
                                yesResult(dgr, inputCommand);
                            }
                            else if (myMessageBox.DialogResult == DialogResult.No)
                            {
                                failResult(dgr, inputCommand.Substring(4, 2));
                            }

                            if (serialPort.BytesToRead != 0)
                            {
                                temp = ReadPort(temps);
                                str = byteToHexStr(temp);
                                dgr.Cells["返回参数"].Value = str;
                            }

                            continue;
                        }
                    }

                    temp = ReadPort(temps);
                    str = byteToHexStr(temp);
                    dgr.Cells["返回参数"].Value = str;
                    String result = str.Substring(6, 2);

                    //判断温湿度命令
                    if (str.Substring(4, 2).Equals("17"))  //判断PPG温湿度是否通过
                    {
                        if ((comboBoxTestItem.Text.Equals("PPG PCBA测试") || comboBoxTestItem.Text.Equals("PPG 半成品测试")))
                        {
                            if (str.Substring(6, 2).Equals("00"))
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✔";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                                dgr.Cells["数值显示"].Value = getResultInRecve(str);
                            }
                            else
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✘";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                                testError = false;
                            }
                        }
                        else if (comboBoxTestItem.Text.Equals("NIR PCBA测试"))
                        {
                            if (str.Substring(8, 2).Equals("00"))  //判断NIR温湿度是否通过
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✔";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                                dgr.Cells["数值显示"].Value = getResultInRecve(str);
                            }
                            else
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✘";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                                testError = false;
                            }
                        }
                        else if (comboBoxTestItem.Text.Equals("主板测试") || comboBoxTestItem.Text.Equals("整机测试"))
                        {
                            if (str.Substring(6, 2).Equals("00") && str.Substring(8, 2).Equals("00"))
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✔";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                                dgr.Cells["数值显示"].Value = getResultInRecve(str);
                            }
                            else
                            {
                                dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                                dgr.Cells["是否通过"].Value = "✘";
                                dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                                testError = false;
                            }
                        }

                        continue;
                    }

                    //判断是否需要弹出框
                    if (result != null && "00".Equals(result))
                    {
                        dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                        dgr.Cells["是否通过"].Value = "✔";
                        dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                        dgr.Cells["数值显示"].Value = getResultInRecve(str);
                    }
                    else if ("01".Equals(result))
                    {
                        dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                        dgr.Cells["是否通过"].Value = "✘"; 
                        dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                        testError = false;
                    }
                    else if ("02".Equals(result))
                    {
                        sampleImageShow(str.Substring(4, 2));
                        signalCnt = 0;

                        if (str.Substring(4, 2).Equals("19"))   //蓝牙不提醒
                        {
                            CheckMAC(str);
                        }
                        else if (str.Substring(4, 2).Equals("24"))   //sn不提醒
                        {
                            CheckSN(str);
                        }
                        else
                            myMessageBox.Show("对比示例图,请观察" + dgr.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", Color.Black);

                        pictureBoxShow.Visible = false;
                        chart1.Visible = false;
                        chart1.SendToBack();
                        labelScope.Visible = false;
                        labelScope.SendToBack();

                        if (myMessageBox.DialogResult == DialogResult.Yes)
                        {
                            yesResult(dgr, str);
                        }
                        else if(myMessageBox.DialogResult == DialogResult.No)
                        {
                            failResult(dgr, str.Substring(4, 2));
                        }
                    }

                    Thread.Sleep(200);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
                myMessageBox.Show("检测不到模块或者熄屏导致通信异常,请检测环境重新测试！！", Color.Red);
                return;
            }

            if (comboBoxTestItem.Text.Equals("条形码测试"))
            {
                myMessageBox.Show("SN:" + textBoxSN.Text + "\r\n请先找到对应的条形码,然后切换到英文输入法,并在\"条形码:\"文本框中使用扫码枪扫描条形码!!", Color.Green);
            }
            else if (true == testError)
            {
                myMessageBox.Show("测试通过,请保存测试报告!", Color.Green);
            }
            else
            {
                myMessageBox.Show("测试未通过,请保存测试报告,或者检查环境后重新测试!", Color.Red);
            }
            
            btn_go.Enabled = false;
            if (comboBoxTestItem.Text.Equals("条形码测试"))
            {
                buttonCheckBarCode.Enabled = true;
                textBoxBarCode.Focus();
            }
            else
                btn_output_excel.Enabled = true;
            btn_print_QRCode.Enabled = false;
            btn_again.Enabled = false;
        }

        public static object _lock = new object();

        private void WritePort(byte[] sendData)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }

            //发送数据
            serialPort.Write(sendData, 0, sendData.Length);
        }
        //同步读取数据并返回
        private byte[] ReadPort(byte[] sendData)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }

            //读取返回数据
            DateTime dt = DateTime.Now;
            int noresponse = 0;

            if (sendData[2] == 0x22)            // nir时钟矫正需要等待反馈
            {
                noresponse = 30;
            }
            else if (sendData[2] == 0x50)       // ECG心率
            {
                noresponse = 40;
            }
            else if (sendData[2] == 0x39)       // SI1171测试 PPG IR
            {
                noresponse = 30;
            }
            else if (sendData[2] == 0x32)       // SFH7050测试 NIR IR
            {
                noresponse = 30;
            }
            else if (sendData[2] == 0x33)       // ADPD105测试 NIR CR4 1650
            {
                noresponse = 30;
            }
            else
                noresponse = 6;

            while (serialPort.BytesToRead == 0)
            {
                Thread.Sleep(1);
                if (DateTime.Now.Subtract(dt).TotalMilliseconds > (noresponse * 1000)) //如果30秒后仍然无数据返回，则视为超时
                {
                    //myMessageBox.Show("通讯超时,请检查环境重新测试", Color.Red);
                    break;
                }
            }
            Thread.Sleep(50); //50毫秒内数据接收完毕，可根据实际情况调整
            byte[] recData = new byte[serialPort.BytesToRead];
            serialPort.Read(recData, 0, recData.Length);

            return recData;
        }

        private void btn_output_excel_Click(object sender, EventArgs e)
        {
            // 保存测试报告
            DateTime dt = DateTime.Now;
            String commandFile = "";

            if (dataGridViewMain.DataSource == null)
            {
                myMessageBox.Show("测试表格没有数据,无法保存,请关闭测试表重新测试!", Color.Red);
                return;
            }

            btn_go.Enabled = false;
            btn_output_excel.Enabled = false;
            //btn_print_QRCode.Enabled = true;
            btn_print_QRCode.Enabled = false;
            btn_again.Enabled = true;

            Directory.CreateDirectory(@"D:\TestReport\Local");
            Directory.CreateDirectory(@"D:\TestReport\Server");

            if (comboBoxTestItem.Text.Equals("主板测试"))
            {
                if (textBoxMAC.Text.ToString().Length != 12)
                    commandFile = @"D:\TestReport\Local\" + strSN.ToString() + "_" + "###########" + "_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;
                else
                    commandFile = @"D:\TestReport\Local\" + strSN.ToString() + "_" + textBoxMAC.Text.ToString() + "_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;
            }
            else if (comboBoxTestItem.Text.Equals("PPG PCBA测试"))
            {
                commandFile = @"D:\TestReport\Local\" + strSN.ToString() + "_PCBA_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;
            }
            else if (comboBoxTestItem.Text.Equals("PPG 半成品测试"))
            {
                commandFile = @"D:\TestReport\Local\" + strSN.ToString() + "_SHELL_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;
            }
            else if (comboBoxTestItem.Text.Equals("整机测试"))
            {
                commandFile = @"D:\TestReport\Local\" + textBoxMAC.Text.ToString() + "_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;
            }
            else if (comboBoxTestItem.Text.Equals("NIR PCBA测试"))
            {
                commandFile = @"D:\TestReport\Local\" + strSN.ToString() + "_PCBA_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;
            }

            DataTable table = (DataTable)dataGridViewMain.DataSource;

            ExcelHelper excelHelper = new ExcelHelper(commandFile);
            int count = excelHelper.DataTableToExcel(table, "Sheet1", true);
            if (count > 0)
            {
                txt_output_excel.Text = commandFile;
            }

            // 保存SN码
            if (UpperMode == UPPER_MODE.PRINT_QRCODE)
            {
                if (SNSave == true)
                {
                    dataGridViewSN.Rows[rowSN].Cells["已写入"].Value = 1;

                    table = (DataTable)dataGridViewSN.DataSource;

                    try
                    {
                        File.Delete("SN" + ExpandedName);
                        excelHelper = new ExcelHelper("SN" + ExpandedName);
                        if (0 == excelHelper.DataTableToExcel(table, "Sheet1", true))
                        {
                            myMessageBox.Show("写入失败!!", Color.Red);
                        }
                    }
                    catch
                    {
                        File.Delete("backup" + ExpandedName);
                        excelHelper = new ExcelHelper("backup" + ExpandedName);
                        excelHelper.DataTableToExcel(table, "Sheet1", true);
                        myMessageBox.Show("请勿打开目录下的表格,关闭表格和软件,然后重新启动软件!!", Color.Green);
                    }
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                myMessageBox.Show("请先打开串口!", Color.Red);
                return;
            }
            DataGridViewSelectedRowCollection drc= dataGridViewMain.SelectedRows;
            if (drc.Count == 0)
            {
                myMessageBox.Show("无效行!", Color.Red);
                return;
            }

            serialPort.DataReceived -= new SerialDataReceivedEventHandler(post_DataReceived);
            receive = 0; //解除绑定函数

            try
            {
                DataGridViewRow dgv = dataGridViewMain.SelectedRows[0];

                String inputName = dgv.Cells["名字"].EditedFormattedValue.ToString();
                String inputCommand = dgv.Cells["输入命令"].EditedFormattedValue.ToString();

                dgv.Cells["返回参数"].Value = "";
                dgv.Cells["是否通过"].Value = "";

                byte[] recData = new byte[serialPort.BytesToRead];
                serialPort.Read(recData, 0, recData.Length);

                if ("充电电流" == inputName)             //  没有输入命令的测试项
                {
                    myMessageBox.Show("请观察万用表" + inputName + "是否在100~450mA之间？", Color.Black);
                    if (myMessageBox.DialogResult == DialogResult.Yes)
                    {
                        dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                        dgv.Cells["是否通过"].Value = "✔";
                        dgv.Cells["是否通过"].Style.ForeColor = Color.Green;
                    }
                    else if (myMessageBox.DialogResult == DialogResult.No)
                    {
                        dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                        dgv.Cells["是否通过"].Value = "✘";
                        dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                        testError = false;
                    }
                    return;
                }
                else if (("SN码写入" == inputName || "SN码读出" == inputName || "SN码校验" == inputName) && comboBoxTestItem.Text.Equals("整机测试"))               // 实际是MAC地址
                {
                    return;
                }
                else if ("蓝牙连接测试" == inputName)
                {
                    QRCode(textBoxMAC.Text);
                    if (myMessageBox.DialogResult == DialogResult.No)
                    {
                        return;
                    }
                    myMessageBox.Show("请用APP击【主板蓝牙连接 + ECG功能测试】扫描二维码进行测试", Color.Black);

                    myMessageBox.Show("蓝牙测试是否通过", Color.Black);
                    if (myMessageBox.DialogResult == DialogResult.Yes)
                    {
                        dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                        dgv.Cells["是否通过"].Value = "✔";
                        dgv.Cells["是否通过"].Style.ForeColor = Color.Green;
                        pictureBoxShow.Visible = false;
                        gBTLinkStatus = true;
                    }
                    else
                    {
                        dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                        dgv.Cells["是否通过"].Value = "✘";
                        dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                        pictureBoxShow.Visible = false;
                        testError = false;
                        gBTLinkStatus = false;
                    }
                    return;
                }
                else if ("ECG心率测试" == inputName)
                {
                    if (gBTLinkStatus == true)
                    {
                        myMessageBox.Show("请对比APP和仪器的心率值是否一致", Color.Black);
                        if (myMessageBox.DialogResult == DialogResult.Yes)
                        {
                            dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgv.Cells["是否通过"].Value = "✔";
                            dgv.Cells["是否通过"].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgv.Cells["是否通过"].Value = "✘";
                            dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                            testError = false;
                        }
                    }
                    return;
                }

                if ("ADPD105测试" == inputName || "SI1171测试" == inputName || "SFH7050测试" == inputName)           // 传感器自检
                {
                    sampleImageShow(inputCommand.Substring(6, 2));

                    chart1.Visible = true;
                    chart1.BringToFront();

                    labelScope.Visible = true;
                    labelScope.BringToFront();

                    myMessageBox.Show("请用白色纸板遮住示例图所示位置", Color.Black);

                    pictureBoxShow.Visible = false;
                    chart1.Visible = false;
                    chart1.SendToBack();
                    labelScope.Visible = false;
                    labelScope.SendToBack();
                }

                byte[] temps = strToToHexByte(inputCommand);
                byte[] temp;
                string str;

                //接受发送
                WritePort(temps);

                if (comboBoxTestItem.Text.Equals("PPG PCBA测试") || comboBoxTestItem.Text.Equals("NIR PCBA测试"))       // ggp nir pcba测试以光谱仪为准
                {
                    if ((inputCommand.Substring(6, 2).Equals("30") || inputCommand.Substring(6, 2).Equals("31") ||
                        inputCommand.Substring(6, 2).Equals("32") || inputCommand.Substring(6, 2).Equals("33") ||
                        inputCommand.Substring(6, 2).Equals("34") || inputCommand.Substring(6, 2).Equals("35") ||
                        inputCommand.Substring(6, 2).Equals("36") || inputCommand.Substring(6, 2).Equals("37") ||
                        inputCommand.Substring(6, 2).Equals("38") || inputCommand.Substring(6, 2).Equals("39")) &&
                        "SI1171测试" != inputName && "ADPD105测试" != inputName && "SFH7050测试" != inputName)                             // SI1171 || ADPD105测试
                    {
                        sampleImageShow(inputCommand.Substring(6, 2));
                        signalCnt = 0;

                        chart1.Visible = true;
                        chart1.BringToFront();

                        labelScope.Visible = true;
                        labelScope.BringToFront();
                        
                        myMessageBox.Show("光谱仪探头对准示例图所示位置,请观察" +inputName + "是否正常？", Color.Black);

                        pictureBoxShow.Visible = false;
                        chart1.Visible = false;
                        chart1.SendToBack();
                        labelScope.Visible = false;
                        labelScope.SendToBack();

                        if (myMessageBox.DialogResult == DialogResult.Yes)
                        {
                            yesResult(dgv, inputCommand);
                        }
                        else if (myMessageBox.DialogResult == DialogResult.No)
                        {
                            failResult(dgv, inputCommand.Substring(4, 2));
                        }

                        if (serialPort.BytesToRead != 0)
                        {
                            temp = ReadPort(temps);
                            str = byteToHexStr(temp);
                            dgv.Cells["返回参数"].Value = str;
                        }

                        return ;
                    }
                }

                temp = ReadPort(temps);
                str = byteToHexStr(temp);
                dgv.Cells["返回参数"].Value = str;
                String result = str.Substring(6, 2);

                //判断温湿度命令
                if (str.Substring(4, 2).Equals("17"))  //判断PPG温湿度是否通过
                {
                    if (comboBoxTestItem.Text.Equals("PPG PCBA测试") || comboBoxTestItem.Text.Equals("PPG 半成品测试"))
                    {
                        if (str.Substring(6, 2).Equals("00"))
                        {
                            dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgv.Cells["是否通过"].Value = "✔";
                            dgv.Cells["是否通过"].Style.ForeColor = Color.Green;
                            dgv.Cells["数值显示"].Value = getResultInRecve(str);
                        }
                        else
                        {
                            dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgv.Cells["是否通过"].Value = "✘";
                            dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                            testError = false;
                        }
                    }
                    else if (comboBoxTestItem.Text.Equals("NIR PCBA测试"))
                    {
                        if (str.Substring(8, 2).Equals("00"))  //判断NIR温湿度是否通过
                        {
                            dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgv.Cells["是否通过"].Value = "✔";
                            dgv.Cells["是否通过"].Style.ForeColor = Color.Green;
                            dgv.Cells["数值显示"].Value = getResultInRecve(str);
                        }
                        else
                        {
                            dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgv.Cells["是否通过"].Value = "✘";
                            dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                            testError = false;
                        }
                    }
                    else if (comboBoxTestItem.Text.Equals("主板测试") || comboBoxTestItem.Text.Equals("整机测试"))
                    {
                        if (str.Substring(6, 2).Equals("00") && str.Substring(8, 2).Equals("00"))
                        {
                            dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgv.Cells["是否通过"].Value = "✔";
                            dgv.Cells["是否通过"].Style.ForeColor = Color.Green;
                            dgv.Cells["数值显示"].Value = getResultInRecve(str);
                        }
                        else
                        {
                            dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgv.Cells["是否通过"].Value = "✘";
                            dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                            testError = false;
                        }
                    }

                    return;
                }

                if (result != null && "00".Equals(result))
                {
                    dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                    dgv.Cells["是否通过"].Value = "✔";
                    dgv.Cells["是否通过"].Style.ForeColor = Color.Green;
                    dgv.Cells["数值显示"].Value = getResultInRecve(str);
                }
                else if ("01".Equals(result))
                {
                    dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                    dgv.Cells["是否通过"].Value = "✘";
                    dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                    testError = false;
                }
                else if ("02".Equals(result))
                {
                    sampleImageShow(str.Substring(4, 2));
                    signalCnt = 0;

                    if (str.Substring(4, 2).Equals("19"))   //蓝牙不提醒
                    {
                        CheckMAC(str);
                    }
                    else if (str.Substring(4, 2).Equals("24"))   //sn不提醒
                    {
                        CheckSN(str);
                    }
                    else
                        myMessageBox.Show("对比示例图,请观察" + dgv.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", Color.Black);

                    pictureBoxShow.Visible = false;
                    chart1.Visible = false;
                    chart1.SendToBack();
                    labelScope.Visible = false;
                    labelScope.SendToBack();

                    if (myMessageBox.DialogResult == DialogResult.Yes)
                    {
                        yesResult(dgv, str);
                    }
                    else if(myMessageBox.DialogResult == DialogResult.No)
                    {
                        failResult(dgv, str.Substring(4, 2));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
            }
        }

        private void btn_again_Click(object sender, EventArgs e)
        {
            // 读取SN号
            if (UpperMode == UPPER_MODE.PRINT_QRCODE)
            {
                GetNewSN();
            }
            else
            {
                textBoxSN.Text = "";
            }

            textBoxMAC.Text = "";
            txt_output_excel.Text = "";

            strSN = "";
            devSN = "";

            if (false == getTestCase())
            {
                return;
            }

            //将buffer清空
            if (serialPort.IsOpen)
            {
                byte[] recData = new byte[serialPort.BytesToRead];
                serialPort.Read(recData, 0, recData.Length);
            }

            btn_go.Enabled = true;
            btn_again.Enabled = false;
            btn_print_QRCode.Enabled = false;
            btn_output_excel.Enabled = false;
            myMessageBox.DialogResult = DialogResult.None;
        }

        //将参数获取出来然后判断是否存在参数
        public String getResultInRecve(String res)
        {
            String types = res.Substring(4, 2);
            String result = "";
            if ("16".Equals(types))  //压力
            {
                String finaltypes = res.Substring(8, 8);
                string[] finalResult = splitAvg(finaltypes, 4);
                result = "压力1：" + finalResult[0] + "；压力2：" + finalResult[1];
            }
            else if ("17".Equals(types)) //温湿度
            {
                String finaltypes = res.Substring(10, 16);
                String hdcp1 = res.Substring(6, 2).Equals("00") ? "成功" : "失败";
                String hdcp2 = res.Substring(8, 2).Equals("00") ? "成功" : "失败";
                
                string[] finalResult = splitAvg(finaltypes, 4);
                result = "HDCP1:" + hdcp1 + "；HDPC2:" + hdcp2 + "；温度1：" + finalResult[0] + "；湿度1：" + finalResult[1] + "；温度2：" + finalResult[2] + "；湿度2：" + finalResult[3];
            }
            /** else if ("18".Equals(types)) //气压
             {
                 String finaltypes = res.Substring(8, 16);
                 string[] finalResult = splitAvg(finaltypes, 16);
                 result = "气压：" + finalResult[0];
             } */
            else if ("19".Equals(types))//蓝牙
            {
                String finaltypes = res.Substring(8, 12);

                result = "蓝牙地址：" + finaltypes;

                textBoxMAC.Text = finaltypes;

                if (textBoxMAC.Text != "")
                    dataGridViewSN.Rows[rowSN].Cells["MAC"].Value = textBoxMAC.Text.ToString();
            }
            else if ("24".Equals(types))//读出机器码
            {
                result= res.Substring(8);
                byte[] temps = strToToHexByte(result);
                result = Encoding.ASCII.GetString(temps);

                if (result.IndexOf("\r") != -1)
                {
                    result = result.Replace("\r", "");
                }
            }
            return result;
        }

        public string[] splitAvg(String oriStr,int size)
        {
            string[] splitStr = new string[oriStr.Length / size];
            for(int i = 0; i < splitStr.Length; i++)
            {
               String temp= oriStr.Substring(i * size, size);
               char[] cs= temp.ToArray();  //分解成字符
               
                String newStr= strConvert(temp);
                long final= System.Int64.Parse(newStr, System.Globalization.NumberStyles.HexNumber);
                splitStr[i] = final+"";
            }
            return splitStr;
        }

        private static string strConvert(string strValue)
        {
            int intLength = strValue.Length;
            string res = string.Empty;
            for (int i = 0; i < intLength / 2; i++)
            {
                res += strValue.Substring(intLength - 2 * (i + 1), 2);
            }
            return res;
        }
        private void CheckSN(String str)
        {
            devSN = getResultInRecve(str);
            if (!(devSN.Substring(0, 3).Equals("BBF")) || devSN.Equals(strSN))          // 正常流程或者生产返修
            {
                SNSave = true;
                devSN = strSN;
                myMessageBox.DialogResult = DialogResult.Yes;
            }
            else if (strSN == "")
            {
                SNSave = false;
                strSN = devSN;
                myMessageBox.DialogResult = DialogResult.Yes;
            }
            else
            {
                // 无法在表格中找到设备对应的SN码和MAC地址，不保存SN码表
                SNSave = false;
                strSN = devSN;
                myMessageBox.Show("设备SN与记录不一致,以设备为主,如需要修改设备SN,请修改SN文本框后点击'手动输入SN码'按钮,在点击\"SN码写入\"测试行!!", Color.Red);
                myMessageBox.DialogResult = DialogResult.No;
            }

            textBoxSN.Text = strSN;

            // 更新测试表SN码
            string strTemp = strSN;

            if (strTemp.IndexOf("\n") != -1)
            {
                strTemp = strTemp.Replace("\n", "");
            }
            if (strTemp.IndexOf("\r") != -1)
            {
                strTemp = strTemp.Replace("\r", "");
            }
            strTemp = asciiToHex(strTemp);
            strTemp = strTemp.Replace(" ", "");

            foreach (DataGridViewRow dgrSN in dataGridViewMain.Rows)
            {
                // 更新测试表
                Object inputSN = dgrSN.Cells["输入命令"].EditedFormattedValue;
                if (inputSN == null || inputSN.ToString() == "" || !inputSN.ToString().Substring(6, 2).Equals("23"))
                {
                    continue;
                }
                String fins = "bc aa 23 " + strTemp + " 0d";
                dgrSN.Cells["输入命令"].Value = fins;
            }

            // 更新SN码表            待完善
        }

        private void CheckMAC(String str)
        {
            String finaltypes = str.Substring(8, 12);

            if (textBoxMAC.Text == "")
                textBoxMAC.Text = finaltypes;
            else if (textBoxMAC.Text.Length.Equals(17))
            {
                if (finaltypes != textBoxMAC.Text.Substring(0, 2) + textBoxMAC.Text.Substring(3, 2) + textBoxMAC.Text.Substring(6, 2) + textBoxMAC.Text.Substring(9, 2) + textBoxMAC.Text.Substring(12, 2) + textBoxMAC.Text.Substring(15, 2))
                {
                    myMessageBox.Show("扫描的MAC地址与机器MAC地址不一致,请使用其他扫描枪确认", Color.Red);
                    myMessageBox.DialogResult = DialogResult.No;
                    return;
                }
                else
                    textBoxMAC.Text = finaltypes;
            }

            if (textBoxMAC.Text.Length == 12)
            {
                if (UpperMode == UPPER_MODE.PRINT_QRCODE)
                {
                    foreach (DataGridViewRow dgr_MAC in dataGridViewSN.Rows)
                    {
                        Object input = dgr_MAC.Cells["MAC"].EditedFormattedValue;
                        if (textBoxMAC.Text.Equals(input.ToString()))           //  从SN码表中检测到MAC地址
                        {
                            SNSave = true;
                            rowSN = dgr_MAC.Index;
                            strSN = dgr_MAC.Cells["帧头"].Value.ToString() + dgr_MAC.Cells["序列号"].Value.ToString().PadLeft(4, '0') +
                                    dgr_MAC.Cells["产地"].Value.ToString() + dgr_MAC.Cells["年"].Value.ToString() +
                                    dgr_MAC.Cells["月"].Value.ToString() + dgr_MAC.Cells["型号"].Value.ToString();

                            textBoxSN.Text = strSN;

                            myMessageBox.Show("从SN表中找到了MAC对应的SN码", Color.Green);
                            myMessageBox.DialogResult = DialogResult.Yes;

                            return;
                        }
                    }
                    myMessageBox.DialogResult = DialogResult.No;
                }
                else
                {
                    myMessageBox.DialogResult = DialogResult.Yes;
                }
            }
            else
            {
                myMessageBox.DialogResult = DialogResult.No;
                myMessageBox.Show("蓝牙地址不合法，请检查蓝牙模块！", Color.Red);
            }
        }

        public void yesResult(DataGridViewRow dgr,String str)
        {
            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
            dgr.Cells["是否通过"].Value = "✔";
            dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
        }

        public void failResult(DataGridViewRow dgr, String type)
        {
            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
            dgr.Cells["是否通过"].Value = "✘";
            dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
            testError = false;
        }

        private void ConnectPrinter()
        {
            Printer.Open(PortType.USB);
        }

        private void DisconnectPrinter()
        {
            Printer.Close();
        }

        private int calLabelHValue = 0;

        private void LabelSetup()
        {
            if (calLabelHValue >= 4)
            {
                Printer.Config.LabelMode((PaperMode)Cbo_PaperType.SelectedIndex, (int)Num_Label_H.Value, (int)Num_GapFeed.Value);
                calLabelHValue = 0;
            }
            else
            {
                Printer.Config.LabelMode((PaperMode)Cbo_PaperType.SelectedIndex, (int)Num_Label_H.Value + 1, (int)Num_GapFeed.Value);
                calLabelHValue++;
            }

            Printer.Config.LabelWidth((int)Num_Label_W.Value);
            Printer.Config.Dark((int)Num_Dark.Value);
            Printer.Config.Speed((int)Num_Speed.Value);
            Printer.Config.PageNo((int)Num_Page.Value);
            Printer.Config.CopyNo((int)Num_Copy.Value);
        }

        private void btn_print_QRCode_Click(object sender, EventArgs e)
        {
            if ((tabPage2.Text == "主板测试" && strSN.Length == 14) || ((tabPage2.Text == "PPG测试" || tabPage2.Text == "NIR测试") && strSN.Length == 13))
            {
                ConnectPrinter();
                LabelSetup();
                Printer.Command.Start();

                int RowGap = 142;
                //int LineGap = 25;

                int PrintLineIndex = -1, PrintRowIndex = -1;

                // 获取记录
                string strSetting;
                StreamReader fileReader = new StreamReader("setting.ini");

                while (true)
                {
                    strSetting = fileReader.ReadLine();

                    if (strSetting == null)
                    {
                        fileReader.Close();
                        break;
                    }

                    if (strSetting.Substring(0, "PrintLineIndex".Length).Equals("PrintLineIndex"))
                    {
                        PrintLineIndex = Convert.ToInt32(Regex.Replace(strSetting, @"[^0-9]+", ""));
                    }
                    else if (strSetting.Substring(0, "PrintRowIndex".Length).Equals("PrintRowIndex"))
                    {
                        PrintRowIndex = Convert.ToInt32(Regex.Replace(strSetting, @"[^0-9]+", ""));
                    }
                    else
                    {
                        myMessageBox.Show("请关闭\"setting.ini\"文件重新打印二维码", Color.Red);
                        fileReader.Close();
                        return;
                    }
                }

                if (PrintLineIndex == -1 || PrintRowIndex == -1)
                {
                    myMessageBox.Show("目录下缺少\"setting.ini\"文件,请核实", Color.Red);
                    return;
                }
                
                if (PrintLineIndex >= 5)
                {
                    PrintLineIndex = 0;
                }
                else
                {
                    EZioApi.sendcommand("^B12");

                    //if (PrintRowIndex == 0)           // 调整打印机
                    //{
                    //    PrintRowIndex = 1;
                    //    EZioApi.sendcommand("^B12");
                    //}
                    //else if (PrintRowIndex >= 1)
                    //{
                    //    PrintRowIndex = 0;Nirvana19CG
                    //    EZioApi.sendcommand("^B14");
                    //}
                }
                Printer.Command.PrintQRCode((int)Num_QRPosX.Value + RowGap * PrintLineIndex, (int)Num_QRPosY.Value, 5, 2, "M", 8, (int)Num_QRSize.Value, (int)Num_QRRotation.Value, textBoxSN.Text);
                PrintLineIndex++;

                string[] content = File.ReadAllText("setting.ini").Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                content[0] = "PrintLineIndex = " + PrintLineIndex;
                content[1] = "PrintRowIndex = " + PrintRowIndex;
                File.WriteAllText("setting.ini", string.Join("\r\n", content));

                Printer.Command.End();
                DisconnectPrinter();
            }
            else
            {
                myMessageBox.Show("SN码有误,请核实!!", Color.Red);
            }

            btn_go.Enabled = false;
            btn_output_excel.Enabled = false;
            btn_print_QRCode.Enabled = false;
            btn_again.Enabled = true;
        }
        
        private void buttonManual_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                myMessageBox.Show("请先打开串口!", Color.Red);
                return;
            }

            string str = textBoxSN.Text;
            strSN = textBoxSN.Text;

            if (str.IndexOf("\n") != -1)
            {
                str = str.Replace("\n", "");
            }
            if (str.IndexOf("\r") != -1)
            {
                str = str.Replace("\r", "");
            }
            str = asciiToHex(str);
            str = str.Replace(" ", "");

            foreach (DataGridViewRow dgrSN in dataGridViewMain.Rows)
            {
                // 更新测试表
                Object inputSN = dgrSN.Cells["输入命令"].EditedFormattedValue;
                if (inputSN == null || inputSN.ToString() == "" || !inputSN.ToString().Substring(6, 2).Equals("23"))
                {
                    continue;
                }
                String fins = "bc aa 23 " + str + " 0d";
                dgrSN.Cells["输入命令"].Value = fins;
            }
            myMessageBox.Show("已完成SN码编辑，请点击\"SN码写入\"测试行完成设置", Color.Green);
            // 更新SN码表            待完善
        }

        public double axisyMax = 0.0;
        public int waveLength = 0;
        public int signalCnt = 0;

        //1450，波长范围 1420±50nm
        //1600，波长范围,1560±20nm
        //1650，波长范围,1600±20nm

        private void timer1_Tick(object sender, EventArgs e)
        {
            int pixel;
            int maxPixel = 0;

            timer1.Stop();
            chart1.Series["Series1"].Points.Clear();
            chart1.Series.SuspendUpdates();
            axisyMax = 0;
            waveLength = 0;

            for (pixel = 0; pixel <= 1520 - 1; pixel++)
            {
                chart1.Series["Series1"].Points.AddXY(m_Lambda_8U2.Value[pixel], m_Spectrum_8U2.Value[pixel]);
                if (m_Spectrum_8U2.Value[pixel] > axisyMax)
                {
                    axisyMax = m_Spectrum_8U2.Value[pixel];
                    waveLength = Convert.ToInt32(m_Lambda_8U2.Value[pixel]);
                    maxPixel = pixel;
                }
            }

            for (pixel = 0; pixel <= m_NrPixels_9U2 - 1; pixel++)
            {
                chart1.Series["Series1"].Points.AddXY(m_Lambda_9U2.Value[pixel], m_Spectrum_9U2.Value[pixel]);
                if (m_Spectrum_9U2.Value[pixel] > axisyMax)
                {
                    axisyMax = m_Spectrum_9U2.Value[pixel];
                    waveLength = Convert.ToInt32(m_Lambda_9U2.Value[pixel]);
                    maxPixel = pixel;
                }
            }
            
            chart1.ChartAreas[0].AxisY.Maximum = axisyMax;
            labelScope.Text = '(' + waveLength.ToString() + ", " + axisyMax.ToString() + ')';


            switch (SignalMode)
            {
                case SIGNAL_MODE.PPG_GREEN:
                    if ((waveLength >= 534 - 50) && (waveLength <= 534 + 50))
                        signalCnt++;
                    break;

                case SIGNAL_MODE.PPG_RED:
                    if ((waveLength >= 660 - 50) && (waveLength <= 660 + 50))
                        signalCnt++;
                    break;

                case SIGNAL_MODE.PPG_IR:
                    if ((waveLength >= 950 - 50) && (waveLength <= 950 + 50))
                        signalCnt++;
                    break;

                case SIGNAL_MODE.NIR_GREEN:
                    if ((waveLength >= 534 - 50) && (waveLength <= 534 + 50))
                        signalCnt++;
                    break;

                case SIGNAL_MODE.NIR_RED:
                    if ((waveLength >= 660 - 50) && (waveLength <= 660 + 50))
                        signalCnt++;
                    break;

                case SIGNAL_MODE.NIR_IR:
                    if ((waveLength >= 950 - 50) && (waveLength <= 950 + 50))
                        signalCnt++;
                    break;

                case SIGNAL_MODE.NIR_1450:
                    if ((waveLength >= 1420 - 50) && (waveLength <= 1420 + 50))
                        signalCnt++;
                    break;

                case SIGNAL_MODE.NIR_1600:
                    if ((waveLength >= 1560 - 20) && (waveLength <= 1560 + 20))
                        signalCnt++;
                    break;

                case SIGNAL_MODE.NIR_1650:
                    if ((waveLength >= 1600 - 20) && (waveLength <= 1600 + 20))
                        signalCnt++;
                    break;

                default:
                    signalCnt = 0;
                    break;
            }

            if (signalCnt >= 10 && chart1.Visible == true && spectrographEnable == true)
            {
                signalCnt = 0;
                SignalMode = SIGNAL_MODE.SIGNAL_NONE;
                myMessageBox.DialogResult = DialogResult.Yes;
                myMessageBox.Close();
            }

            chart1.Series.ResumeUpdates();
            chart1.Series.Invalidate();
            chart1.Update();
        }

        private void buttonCheckBarCode_Click(object sender, EventArgs e)
        {
            if (!textBoxBarCode.Text.Length.Equals(14))
            {
                myMessageBox.Show("SN:" + textBoxSN.Text + "\r\n请先找到对应的条形码,然后切换到英文输入法,并在\"条形码:\"文本框中使用扫码枪扫描条形码!!", Color.Red);
                return;
            }
            else if (textBoxBarCode.Text == textBoxSN.Text)
            {
                myMessageBox.Show("条形码与手环SN一致,检测通过", Color.Green);
                textBoxMAC.Text = "";
                textBoxSN.Text = "";
                textBoxBarCode.Text = "";
                textBoxMAC.Focus();

                btn_go.Enabled = true;
                buttonCheckBarCode.Enabled = false;
            }
            else
            {
                myMessageBox.Show("条形码与手环SN码不一致,请检查条形码", Color.Red);
                textBoxBarCode.Focus();
                return;
            }

        }
    }
}