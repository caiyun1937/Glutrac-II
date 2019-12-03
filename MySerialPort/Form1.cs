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

namespace MySerialPort
{
    public partial class Form1 : Form
    {
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
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false

        }

        private string strSN = "";
        private int rowSN = new int();
        private bool testError = true;
        private string ExpandedName = "";

        private myMsgBox myMessageBox = new myMsgBox();

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

            DateTime dateTime = DateTime.Now;

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

                    if (strSN == "")
                        textBoxSN.Text = "SN获取失败!!";
                    else
                        textBoxSN.Text = strSN;

                    return ;
                }
            }
            textBoxSN.Text = "已无可用SN码!!";
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
            if (this.tabPage2.Text != "PPG测试" && this.tabPage2.Text != "NIR测试")
                return;

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBoxShow.Visible = false;
            btn_go.Enabled = true;
            btn_again.Enabled = false;
            btn_output_excel.Enabled = false;

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

            if (Directory.GetFiles(Application.StartupPath.ToString(), "*.xls").Length > 0)
                ExpandedName = ".xls";
            else
                ExpandedName = ".xlsx";

            // 读取SN号

            GetNewSN();

            if (File.Exists("主板测试" + ExpandedName))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("主板测试" + ExpandedName);
                this.tabPage2.Text = "主板测试";
            }
            else if(File.Exists("PPG测试" + ExpandedName))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("PPG测试" + ExpandedName);
                this.tabPage2.Text = "PPG测试";
            }
            else if (File.Exists("NIR测试" + ExpandedName))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("NIR测试" + ExpandedName);
                this.tabPage2.Text = "NIR测试";
            }

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
            foreach (DataGridViewRow dgr in dataGridViewMainBoardTest.Rows)
            {
                //判断关键列是否是空，空就跳过
                Object input = dgr.Cells["名字"].EditedFormattedValue;
                if (input == null || input.ToString() == "" || !"机器码写入".Equals(input.ToString()))
                {
                    continue;
                }
                String fins = "bc aa 23 " + str + " 0d";
                dgr.Cells["输入命令"].Value = fins;
            }

            // 二维码
            Cbo_PaperType.SelectedIndex = 1;

            // 光谱仪
            chart1.SendToBack();
            chart1.Visible = false;

            if (this.tabPage2.Text != "PPG测试" && this.tabPage2.Text != "NIR测试")
                return;

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
                myMessageBox.Show("PPG和NIR测试请链接光谱仪，重启软件!!", Color.Red);
                System.Environment.Exit(0);
            }

            m_DeviceHandle_9U2 = hDevice_9U2;
            if (avaspec.AVS_UseHighResAdc((IntPtr)m_DeviceHandle_9U2, true) != avaspec.ERR_SUCCESS)
            {
                myMessageBox.Show("PPG和NIR测试请链接光谱仪，重启软件!!", Color.Red);
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

        private const int WM_APP = 0x8000;
        private const int WM_MEAS_READY = WM_APP + 1;
        private const int WM_DBG_INFOAs = WM_APP + 2;
        private const int WM_DEVICE_RESET = WM_APP + 3;

        protected override void WndProc(ref Message a_WinMess)
        {
            ulong l_Ticks = 0;

            if (a_WinMess.Msg == WM_MEAS_READY)
            {
                if ((int)a_WinMess.WParam >= avaspec.ERR_SUCCESS)
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

        bool isOpened = false;//串口状态标志
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isOpened)
            {
                serialPort.PortName = cmbPort.Text;
                serialPort.BaudRate = Convert.ToInt32(cmbBaud.Text, 10);
                try
                {
                    serialPort.Open();     //打开串口
                    button1.Text = "关闭串口";
                    cmbPort.Enabled = false;//关闭使能
                    cmbBaud.Enabled = false;
                    isOpened = true;
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(post_DataReceived);//串口接收处理函数
                }
                catch
                {
                    myMessageBox.Show("串口被占用!", Color.Black);
                }
            }
            else
            {
                try
                {
                    serialPort.Close();     //关闭串口
                    button1.Text = "打开串口";
                    cmbPort.Enabled = true;//打开使能
                    cmbBaud.Enabled = true;
                    isOpened = false;
                }
                catch
                {
                    myMessageBox.Show("串口关闭失败!", Color.Black);
                }
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
            if (str.Substring(4, 2).Equals("0E"))   //背灯关
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[0];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("0D"))   //背灯开
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[1];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("0F"))   //白场
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[2];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("30"))   //nir 绿灯
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[6];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("31"))   //nir 红灯
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[7];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("32"))   //nir ir
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[8];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("33"))   //nir 810
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[9];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("34"))   //nir 1050
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[10];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("35"))   //nir 1450
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[11];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("36"))   //nir 1550
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[12];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("37"))   //ppg 绿灯
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[4];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("38"))   //ppg 红灯
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[3];
                pictureBoxShow.Visible = true;
            }
            else if (str.Substring(4, 2).Equals("39"))   //ppg ir
            {
                pictureBoxShow.BackgroundImage = imageList1.Images[5];
                pictureBoxShow.Visible = true;
            }
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                myMessageBox.Show("串口未打开", Color.Black);
                return;
            }
            if (dataGridViewMainBoardTest.DataSource == null)
            {
                myMessageBox.Show("目标数据源为空,请确认目录下存在测试表!", Color.Black);
                return;
            }

            testError = true;

            serialPort.DataReceived -= new SerialDataReceivedEventHandler(post_DataReceived);
            receive = 0; //解除绑定函数
            try
            {
                foreach (DataGridViewRow dgr in dataGridViewMainBoardTest.Rows)
                {
                    //判断关键列是否是空，空就跳过
                    Object input = dgr.Cells["输入命令"].EditedFormattedValue;
                    if (input == null || input.ToString() == "")
                    {
                        continue;
                    }
                    //SendTbox.Text=input.ToString();

                    //发送数据

                    if ("充电电流" == dgr.Cells["名字"].Value.ToString())
                    {
                        myMessageBox.Show("请观察万用表" + dgr.Cells["名字"].EditedFormattedValue.ToString() + "是否在100~450mA之间？", Color.Black);
                        if (myMessageBox.DialogResult == DialogResult.Yes)
                        {
                            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgr.Cells["是否通过"].Value = "✔";
                            dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                        }
                        else if(myMessageBox.DialogResult == DialogResult.No)
                        {
                            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgr.Cells["是否通过"].Value = "✘";
                            dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                            testError = false;
                        }

                        continue;
                    }

                    byte[] temps = strToToHexByte(input.ToString());

                    //接受发送
                    byte[] temp = ReadPort(temps, input.ToString());
                    string str = byteToHexStr(temp);
                    dgr.Cells["返回参数"].Value = str;
                    String result = str.Substring(6, 2);

                    //判断是否需要弹出框

                    if (result != null && "00".Equals(result))
                    {
                        dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                        dgr.Cells["是否通过"].Value = "✔";
                        dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                        dgr.Cells["数值显示"].Value = getResultInRecve(str);
                        //判断温湿度命令
                        if (str.Substring(4, 2).Equals("17") && str.Substring(8, 2).Equals("01"))  //判断hdtc2是否通过
                        {
                            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgr.Cells["是否通过"].Value = "✘";
                            dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                            testError = false;
                        }
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
                        sampleImageShow(str);

                        if (str.Substring(4, 2).Equals("19"))   //蓝牙不提醒
                            myMessageBox.DialogResult = DialogResult.Yes;

                        else if (str.Substring(4, 2).Equals("24"))   //sn不提醒
                            myMessageBox.DialogResult = DialogResult.Yes;

                        else if (str.Substring(4, 2).Equals("39"))   // ppg_ir
                        {
                            chart1.Visible = true;
                            chart1.BringToFront();
                            myMessageBox.Show("光谱仪探头对准示例图所示位置,请观察" + dgr.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", Color.Black);
                        }

                        else if (str.Substring(4, 2).Equals("32") || str.Substring(4, 2).Equals("33")
                                || str.Substring(4, 2).Equals("34") || str.Substring(4, 2).Equals("35") || str.Substring(4, 2).Equals("36"))   // nir
                        {
                            chart1.Visible = true;
                            chart1.BringToFront();
                            myMessageBox.Show("光谱仪探头对准示例图所示位置,请观察" + dgr.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", Color.Black);
                        }

                        else
                            myMessageBox.Show("对比示例图,请观察" + dgr.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", Color.Black);

                        pictureBoxShow.Visible = false;
                        chart1.Visible = false;
                        chart1.SendToBack();

                        if (myMessageBox.DialogResult == DialogResult.Yes)
                        {
                            yesResult(dgr, str);
                        }
                        else if(myMessageBox.DialogResult == DialogResult.No)
                        {
                            failResult(dgr, str.Substring(4, 2));
                        }
                    }
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
                testError = false;
            }
            if (true == testError)
            {
                if(File.Exists("主板测试" + ExpandedName))
                    myMessageBox.Show("主板测试成功,请保存测试报告!", Color.Green);

                else if(File.Exists("PPG测试" + ExpandedName))
                    myMessageBox.Show("PPG测试成功,请保存测试报告!", Color.Green);

                else if(File.Exists("NIR测试" + ExpandedName))
                    myMessageBox.Show("NIR测试成功,请保存测试报告!", Color.Green);

                else
                    myMessageBox.Show("测试成功,请保存测试报告!", Color.Green);
            }
            else
                myMessageBox.Show("测试失败,请检查环境重新测试!", Color.Red);

            btn_go.Enabled = false;
            btn_again.Enabled = false;
            btn_output_excel.Enabled = true;
        }

        public static object _lock = new object();
        //同步读取数据并返回
        private byte[] ReadPort(byte[] sendData,String stt)
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                serialPort.ReadBufferSize = 1024;
                serialPort.WriteBufferSize = 1024;
            }

            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }

            //发送数据
            serialPort.Write(sendData, 0, sendData.Length);
            // serialPort.WriteLine(sendData);

            //读取返回数据
            DateTime dt = DateTime.Now;
            int noresponse = 0;

            if (sendData[2] == 0x22)
                noresponse = 30;
            else
                noresponse = Convert.ToInt32(noUpDown.Value);

            while (serialPort.BytesToRead == 0)
            {
                Thread.Sleep(1);
                if (DateTime.Now.Subtract(dt).TotalMilliseconds > (noresponse * 1000)) //如果30秒后仍然无数据返回，则视为超时
                {
                    throw new Exception("执行"+ stt + "命令时主版无响应");
                }
            }
            Thread.Sleep(50); //50毫秒内数据接收完毕，可根据实际情况调整
            byte[] recData = new byte[serialPort.BytesToRead];
            serialPort.Read(recData, 0, recData.Length);

            return recData;
        }

        private void btn_inupt_excel_Click(object sender, EventArgs e)
        {
            if (File.Exists("主板测试" + ExpandedName))
                this.dataGridViewMainBoardTest.DataSource = bindData("主板测试" + ExpandedName);

            else if(File.Exists("PPG测试" + ExpandedName))
                this.dataGridViewMainBoardTest.DataSource = bindData("PPG测试" + ExpandedName);

            else if (File.Exists("NIR测试" + ExpandedName))
                this.dataGridViewMainBoardTest.DataSource = bindData("NIR测试" + ExpandedName);

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
            foreach (DataGridViewRow dgr in dataGridViewMainBoardTest.Rows)
            {

                //判断关键列是否是空，空就跳过
                Object input = dgr.Cells["名字"].EditedFormattedValue;
                if (input == null || input.ToString() == "" ||  !"机器码写入".Equals(input.ToString()))
                {
                    continue;
                }
                String fins = "bc aa 23 " + str + " 0d";
                dgr.Cells["输入命令"].Value = fins;
            }
         }

        private void btn_output_excel_Click(object sender, EventArgs e)
        {
            // 保存测试报告
            DateTime dt = DateTime.Now;
            String commandFile = "";

            btn_go.Enabled = false;
            btn_again.Enabled = true;
            btn_output_excel.Enabled = false;

            if (File.Exists("主板测试" + ExpandedName))
            {
                if(textBoxMAC.Text.ToString().Length != 12)
                    commandFile = "Main_" + strSN.ToString() + "_" + "###########" + "_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;
                else
                    commandFile = "Main_" + strSN.ToString() + "_" + textBoxMAC.Text.ToString() + "_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;
            }
            else if (File.Exists("PPG测试" + ExpandedName))
                commandFile = "PPG_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;

            else if (File.Exists("NIR测试" + ExpandedName))
                commandFile = "NIR_" + dt.ToString("yy_MM_dd_HH_mm_ss") + ExpandedName;

            if (dataGridViewMainBoardTest.DataSource == null)
            {
                myMessageBox.Show("目标数据源为空!", Color.Black);
                return;
            }
            DataTable table = (DataTable)dataGridViewMainBoardTest.DataSource;
            //File.Create(commandFile);

            ExcelHelper excelHelper = new ExcelHelper(commandFile);
            int count = excelHelper.DataTableToExcel(table, "Sheet1", true);
            if (count > 0)
            {
                txt_output_excel.Text = commandFile;
            }

            if (!File.Exists("主板测试" + ExpandedName))        // 非主板测试不用保存SN码
                return;

            if (!File.Exists("SN" + ExpandedName))              // 目录没有SN码表不用保存
                return;

            // 保存SN码
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
                //MessageBox.Show("\"SN.xlsx\"文件被打开,另存到backup!!");
                File.Delete("backup" + ExpandedName);
                excelHelper = new ExcelHelper("backup" + ExpandedName);
                excelHelper.DataTableToExcel(table, "Sheet1", true);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                myMessageBox.Show("请先打开串口!", Color.Red);
                return;
            }
            DataGridViewSelectedRowCollection drc= dataGridViewMainBoardTest.SelectedRows;
            if (drc.Count == 0)
            {
                myMessageBox.Show("无效行!", Color.Red);
                return;
            }
            
            try
            {
                serialPort.DataReceived -= new SerialDataReceivedEventHandler(post_DataReceived);
                receive = 0; //解除绑定函数

                DataGridViewRow dgv = dataGridViewMainBoardTest.SelectedRows[0];
                String sts = dgv.Cells["输入命令"].EditedFormattedValue.ToString();
                dgv.Cells["返回参数"].Value = "";
                dgv.Cells["是否通过"].Value = "";

                /*checkbox_16send.Checked = true;
                SendTbox.Text = sts; **/
                byte[] temps = strToToHexByte(sts);

                if ("充电电流" == dgv.Cells["名字"].Value.ToString())
                {
                    myMessageBox.Show("请观察万用表" + dgv.Cells["名字"].EditedFormattedValue.ToString() + "是否在200~600mA之间？", Color.Black);
                    if (myMessageBox.DialogResult == DialogResult.Yes)
                    {
                        dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                        dgv.Cells["是否通过"].Value = "✔";
                        dgv.Cells["是否通过"].Style.ForeColor = Color.Green;
                    }
                    else if(myMessageBox.DialogResult == DialogResult.No)
                    {
                        dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                        dgv.Cells["是否通过"].Value = "✘";
                        dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                        testError = false;
                    }
                    return;
                }

                //接受发送
                byte[] temp = ReadPort(temps, sts);
                string str = byteToHexStr(temp);
                dgv.Cells["返回参数"].Value = str;
                String result = str.Substring(6, 2);
                if (result != null && "00".Equals(result))
                {
                    dgv.Cells["是否通过"].Value = "✔";
                    dgv.Cells["是否通过"].Style.ForeColor = Color.Green;
                    dgv.Cells["数值显示"].Value = getResultInRecve(str);
                    //判断温湿度命令
                    if (str.Substring(4, 2).Equals("17") && str.Substring(8, 2).Equals("01"))  //判断hdtc2是否通过
                    {
                        dgv.Cells["是否通过"].Value = "✘";
                        dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                        testError = false;
                    }
                }
                else if ("01".Equals(result))
                {
                    dgv.Cells["是否通过"].Value = "✘";
                    dgv.Cells["是否通过"].Style.ForeColor = Color.Red;
                    testError = false;
                }
                else if ("02".Equals(result))
                {
                    sampleImageShow(str);

                    if (str.Substring(4, 2).Equals("19"))   //蓝牙不提醒
                        myMessageBox.DialogResult = DialogResult.Yes;

                    else if (str.Substring(4, 2).Equals("24"))   //sn不提醒
                        myMessageBox.DialogResult = DialogResult.Yes;

                    else if (str.Substring(4, 2).Equals("39"))   // ppg_ir
                    {
                        chart1.Visible = true;
                        chart1.BringToFront();
                        myMessageBox.Show("光谱仪探头对准示例图所示位置,请观察" + dgv.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", Color.Black);
                    }

                    else if (str.Substring(4, 2).Equals("32") || str.Substring(4, 2).Equals("33")
                            || str.Substring(4, 2).Equals("34") || str.Substring(4, 2).Equals("35") || str.Substring(4, 2).Equals("36"))   // nir
                    {
                        chart1.Visible = true;
                        chart1.BringToFront();
                        myMessageBox.Show("光谱仪探头对准示例图所示位置,请观察" + dgv.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", Color.Black);
                    }

                    else
                        myMessageBox.Show("对比示例图,请观察" + dgv.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", Color.Black);

                    pictureBoxShow.Visible = false;
                    chart1.Visible = false;
                    chart1.SendToBack();

                    if (myMessageBox.DialogResult == DialogResult.Yes)
                    {
                        yesResult(dgv, str);
                    }
                    else if(myMessageBox.DialogResult == DialogResult.No)
                    {
                        failResult(dgv, str.Substring(4, 2));
                    }
                }
                dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
            }
        }

        private void btn_again_Click(object sender, EventArgs e)
        {
            //初始化dataCommond
            if (File.Exists("主板测试" + ExpandedName))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("主板测试" + ExpandedName);
                this.tabPage2.Text = "主板测试";
            }
            else if (File.Exists("PPG测试" + ExpandedName))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("PPG测试" + ExpandedName);
                this.tabPage2.Text = "PPG测试";
            }
            else if (File.Exists("NIR测试" + ExpandedName))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("NIR测试" + ExpandedName);
                this.tabPage2.Text = "NIR测试";
            }

            //手动输入机器码
            GetNewSN();

            textBoxMAC.Text = "";
            txt_output_excel.Text = "";

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
            foreach (DataGridViewRow dgr in dataGridViewMainBoardTest.Rows)
            {
                //判断关键列是否是空，空就跳过
                Object input = dgr.Cells["名字"].EditedFormattedValue;
                if (input == null || input.ToString() == "" || !"机器码写入".Equals(input.ToString()))
                {
                    continue;
                }
                String fins = "bc aa 23 " + str + " 0d";
                dgr.Cells["输入命令"].Value = fins;
            }

            //将buffer清空
            if (serialPort.IsOpen)
            {
                byte[] recData = new byte[serialPort.BytesToRead];
                serialPort.Read(recData, 0, recData.Length);
            }

            btn_go.Enabled = true;
            btn_again.Enabled = false;
            btn_output_excel.Enabled = false;
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
                // result = "12345678910";
                
                result= res.Substring(8);
                

                byte[] temps = strToToHexByte(result);
                result = Encoding.ASCII.GetString(temps);
                //if (result.IndexOf("\n") != -1)
                //{
                //    result = result.Replace("\n", "");
                //}
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


        public void yesResult(DataGridViewRow dgr,String str)
        {
            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
            dgr.Cells["是否通过"].Value = "✔";
            dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
            if (str.Substring(4, 2).Equals("24"))           // SN
            {
                String currentCode = getResultInRecve(str);
                if (currentCode.Equals(strSN))
                {
                }
                else
                {
                    failResult(dgr, str.Substring(4, 2));
                }
               
            }
            else if (str.Substring(4, 2).Equals("19"))//蓝牙
            {
                String finaltypes = str.Substring(8, 12);

                textBoxMAC.Text = finaltypes;

                if (textBoxMAC.Text != "")
                {
                    foreach (DataGridViewRow dgr_MAC in dataGridViewSN.Rows)
                    {
                        //检验该设备是否已经经过测试
                        Object input = dgr_MAC.Cells["MAC"].EditedFormattedValue;
                        if (textBoxMAC.Text.Equals(input.ToString()))
                        {
                            rowSN = dgr_MAC.Index;
                            strSN = dgr_MAC.Cells["帧头"].Value.ToString() + dgr_MAC.Cells["序列号"].Value.ToString().PadLeft(4, '0') +
                                    dgr_MAC.Cells["产地"].Value.ToString() + dgr_MAC.Cells["年"].Value.ToString() +
                                    dgr_MAC.Cells["月"].Value.ToString() + dgr_MAC.Cells["型号"].Value.ToString();

                            if (strSN == "")
                                textBoxSN.Text = "SN获取失败!!";
                            else
                                textBoxSN.Text = strSN;

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

                            foreach (DataGridViewRow dgrSN in dataGridViewMainBoardTest.Rows)
                            {
                                //判断关键列是否是空，空就跳过
                                Object inputSN = dgrSN.Cells["名字"].EditedFormattedValue;
                                if (inputSN == null || inputSN.ToString() == "" || !"机器码写入".Equals(inputSN.ToString()))
                                {
                                    continue;
                                }
                                String fins = "bc aa 23 " + strTemp + " 0d";
                                dgrSN.Cells["输入命令"].Value = fins;
                            }

                            myMessageBox.Show("该主板已有测试报告,已经使用原来的SN码", Color.Red);
                            break;
                        }
                    }
                    dataGridViewSN.Rows[rowSN].Cells["MAC"].Value = textBoxMAC.Text.ToString();
                }
            }
        }
        public void failResult(DataGridViewRow dgr, String type)
        {
            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
            dgr.Cells["是否通过"].Value = "✘";
            dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
            testError = false;
            if (type.Equals("24"))
            {
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxMAC.Text != "" && textBoxSN.Text != "")
            {
                ConnectPrinter();
                LabelSetup();
                Printer.Command.Start();

                int RowGap = 140;
                int LineGap = 25;

                DateTime dateTime = DateTime.Now;
                
                // First & Second page Print QR Code
                Printer.Command.PrintQRCode((int)Num_QRPosX.Value, (int)Num_QRPosY.Value, 5, 2, "M", 8, (int)Num_QRSize.Value, (int)Num_QRRotation.Value, textBoxMAC.Text);
                Printer.Command.PrintQRCode((int)Num_QRPosX.Value + RowGap, (int)Num_QRPosY.Value, 5, 2, "M", 8, (int)Num_QRSize.Value, (int)Num_QRRotation.Value, textBoxMAC.Text);

                // Third page Print SN
                Printer.Command.PrintText_Unicode((int)Num_QRPosX.Value + RowGap * 2, (int)Num_QRPosY.Value, 25, "Arial", "SN:");
                Printer.Command.PrintText_Unicode((int)Num_QRPosX.Value + RowGap * 2, (int)Num_QRPosY.Value + LineGap, 25, "Arial", textBoxSN.Text.Substring(0, 7));
                Printer.Command.PrintText_Unicode((int)Num_QRPosX.Value + RowGap * 2, (int)Num_QRPosY.Value + LineGap * 2, 25, "Arial", textBoxSN.Text.Substring(7, 7));

                // Fourth page Print MAC
                Printer.Command.PrintText_Unicode((int)Num_QRPosX.Value + RowGap * 3, (int)Num_QRPosY.Value, LineGap, "Arial", "MAC:");
                Printer.Command.PrintText_Unicode((int)Num_QRPosX.Value + RowGap * 3, (int)Num_QRPosY.Value + LineGap, 25, "Arial", textBoxMAC.Text.Substring(0, 6));
                Printer.Command.PrintText_Unicode((int)Num_QRPosX.Value + RowGap * 3, (int)Num_QRPosY.Value + LineGap * 2, 25, "Arial", textBoxMAC.Text.Substring(6, 6));

                // Last page Print Time
                Printer.Command.PrintText_Unicode((int)Num_QRPosX.Value + RowGap * 4, (int)Num_QRPosY.Value, 25, "Arial", "DATE:");
                Printer.Command.PrintText_Unicode((int)Num_QRPosX.Value + RowGap * 4, (int)Num_QRPosY.Value + LineGap, 25, "Arial", "Year:" + dateTime.ToString("yyyy"));
                Printer.Command.PrintText_Unicode((int)Num_QRPosX.Value + RowGap * 4, (int)Num_QRPosY.Value + LineGap * 2, 25, "Arial", "Date:" + dateTime.ToString("MMdd"));

                Printer.Command.End();
                DisconnectPrinter();
            }
            else
            {
                myMessageBox.Show("无法获取蓝牙MAC地址!!", Color.Red);
            }
        }

        private bool Manual_MAC_SN = false;
        private void buttonManual_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                myMessageBox.Show("请先打开串口!", Color.Red);
                return;
            }

            string str = textBoxSN.Text.ToString();

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
            foreach (DataGridViewRow dgr in dataGridViewMainBoardTest.Rows)
            {
                //判断关键列是否是空，空就跳过
                Object input = dgr.Cells["名字"].EditedFormattedValue;
                if (input == null || input.ToString() == "" || !"机器码写入".Equals(input.ToString()))
                {
                    continue;
                }
                String fins = "bc aa 23 " + str + " 0d";
                dgr.Cells["输入命令"].Value = fins;
            }

            //修改后的SN码同步到SN码表            未完成
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int pixel;
            double axisyMax = 0.0;
            timer1.Stop();
            chart1.Series["Series1"].Points.Clear();
            chart1.Series.SuspendUpdates();

            for (pixel = 0; pixel <= 1550 - 1; pixel++)
            {
                chart1.Series["Series1"].Points.AddXY(m_Lambda_8U2.Value[pixel], m_Spectrum_8U2.Value[pixel]);
                if (m_Spectrum_8U2.Value[pixel] > axisyMax)
                    axisyMax = m_Spectrum_8U2.Value[pixel];
            }

            for (pixel = 0; pixel <= m_NrPixels_9U2 - 1; pixel++)
            {
                chart1.Series["Series1"].Points.AddXY(m_Lambda_9U2.Value[pixel], m_Spectrum_9U2.Value[pixel]);
                if (m_Spectrum_9U2.Value[pixel] > axisyMax)
                    axisyMax = m_Spectrum_9U2.Value[pixel];
            }

            chart1.ChartAreas[0].AxisY.Maximum = axisyMax;

            chart1.Series.ResumeUpdates();
            chart1.Series.Invalidate();
            chart1.Update();
        }
    }
}
