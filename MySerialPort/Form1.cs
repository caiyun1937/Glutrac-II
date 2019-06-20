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

namespace MySerialPort
{
    public partial class Form1 : Form
    {
        GodexPrinter Printer = new GodexPrinter();

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false

        }

        private string strSN = "";
        private int rowSN = new int();
        private bool testError = true;

        private void GetNewSN()
        {
            if (File.Exists("backup.xlsx"))
            {
                try
                {
                    File.Delete("SN.xlsx");
                    File.Move("backup.xlsx", "SN.xlsx");
                }
                catch
                {
                    MessageBox.Show("请关闭\"SN.xlsx\"并重启软件");
                    strSN = "";
                    return;
                }
            }

            this.dataGridViewSN.DataSource = bindData("SN.xlsx");

            DateTime dateTime = DateTime.Now;

            foreach (DataGridViewRow dgr in dataGridViewSN.Rows)        // 寻找空闲的SN码
            {
                Object input = dgr.Cells["已写入"].EditedFormattedValue;
                if (input.ToString() == "0")
                {
                    //帧头	序列号	产地	年	月	型号	已写入

                    rowSN = dgr.Index;
                    strSN = dgr.Cells["帧头"].Value.ToString() + dgr.Cells["序列号"].Value.ToString() +
                            dgr.Cells["产地"].Value.ToString() + dgr.Cells["年"].Value.ToString() +
                            dgr.Cells["月"].Value.ToString() + dgr.Cells["型号"].Value.ToString();
                    return ;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
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
          
            cmbBaud.Text = "115200";

            // 读取SN号

            GetNewSN();

            if (strSN == "")
                textBoxSN.Text = "SN获取失败!!";
            else
                textBoxSN.Text = strSN;

            if (File.Exists("主板测试.xlsx"))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("主板测试.xlsx");
                this.tabPage2.Text = "主板测试";
            }
            else if(File.Exists("PPG测试.xlsx"))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("PPG测试.xlsx");
                this.tabPage2.Text = "PPG测试";
            }
            else if (File.Exists("NIR测试.xlsx"))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("NIR测试.xlsx");
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
                     MessageBox.Show("串口被占用");
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
                    MessageBox.Show("串口关闭失败！");
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
                    MessageBox.Show("发送框没有数据");
                }
            }
            else
            {
                MessageBox.Show("串口未打开");
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

        private void btn_go_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("串口未打开");
                return;
            }
            if (dataGridViewMainBoardTest.DataSource == null)
            {
                MessageBox.Show("目标数据源为空,请导入数据");
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
                        DialogResult dr = MessageBox.Show("请观察" + dgr.Cells["名字"].EditedFormattedValue.ToString() + "是否在100~450mA之间？", "提示", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                            dgr.Cells["是否通过"].Value = "✔";
                            dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                        }
                        else
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
                        dgr.Cells["是否通过"].Value = "✔";
                        dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
                        dgr.Cells["数值显示"].Value = getResultInRecve(str);
                        //判断温湿度命令
                        if (str.Substring(4, 2).Equals("17") && str.Substring(8, 2).Equals("01"))  //判断hdtc2是否通过
                        {
                            dgr.Cells["是否通过"].Value = "✘";
                            dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                            testError = false;
                        }
                       
                    }
                    else if ("01".Equals(result))
                    {
                        dgr.Cells["是否通过"].Value = "✘";
                        dgr.Cells["是否通过"].Style.ForeColor = Color.Red;
                        testError = false;
                    }
                    else if ("02".Equals(result))
                    {
                       
                        DialogResult dr = MessageBox.Show("请观察" + dgr.Cells["名字"].EditedFormattedValue.ToString() + "是否正常？", "提示", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            yesResult(dgr, str);
                        }
                        else
                        {
                            failResult(dgr, str.Substring(4, 2));
                        }
                    }
                    dgr.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
                MessageBox.Show(ex.GetBaseException().ToString());
            }
            if (true == testError)
            {
                if(File.Exists("主板测试.xlsx"))
                    MessageBox.Show("主板测试成功,请使用APP链接蓝牙继续整机测试！");
                else if(File.Exists("PPG测试.xlsx"))
                    MessageBox.Show("PPG测试成功！");
                else if(File.Exists("NIR测试.xlsx"))
                    MessageBox.Show("NIR测试成功！");
                else
                    MessageBox.Show("测试成功！");
            }
            else
                MessageBox.Show("测试失败,请检查环境重新测试！");
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
            int noresponse = Convert.ToInt32(noUpDown.Value);
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
            if (File.Exists("主板测试.xlsx"))
                this.dataGridViewMainBoardTest.DataSource = bindData("主板测试.xlsx");
            else if(File.Exists("PPG测试.xlsx"))
                this.dataGridViewMainBoardTest.DataSource = bindData("PPG测试.xlsx");
            else if (File.Exists("NIR测试.xlsx"))
                this.dataGridViewMainBoardTest.DataSource = bindData("NIR测试.xlsx");

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

            if (File.Exists("主板测试.xlsx"))
                commandFile = "主板检测报告" + dt.ToString("yyyyMMdd_HHmmssffff") + ".xlsx";
            else if (File.Exists("PPG测试.xlsx"))
                commandFile = "PPG检测报告" + dt.ToString("yyyyMMdd_HHmmssffff") + ".xlsx";
            else if (File.Exists("NIR测试.xlsx"))
                commandFile = "NIR检测报告" + dt.ToString("yyyyMMdd_HHmmssffff") + ".xlsx";

            if (dataGridViewMainBoardTest.DataSource == null)
            {
                MessageBox.Show("目标数据源为空");
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

            if (!File.Exists("主板测试.xlsx"))      // 非主板测试不用保存SN码
                return;


            // 保存SN码
            dataGridViewSN.Rows[rowSN].Cells["已写入"].Value = 1;

            table = (DataTable)dataGridViewSN.DataSource;

            try
            {
                File.Delete("SN.xlsx");
                excelHelper = new ExcelHelper("SN.xlsx");
                if (0 == excelHelper.DataTableToExcel(table, "Sheet1", true))
                {
                    MessageBox.Show("写入失败!!");
                }
            }
            catch
            {
                //MessageBox.Show("\"SN.xlsx\"文件被打开,另存到backup!!");
                File.Delete("backup.xlsx");
                excelHelper = new ExcelHelper("backup.xlsx");
                excelHelper.DataTableToExcel(table, "Sheet1", true);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (!serialPort.IsOpen)
            {
                MessageBox.Show("串口未打开");
                return;
            }
            DataGridViewSelectedRowCollection drc= dataGridViewMainBoardTest.SelectedRows;
            if (drc.Count == 0)
            {
                MessageBox.Show("无选中行！！！");
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
                    DialogResult dr = MessageBox.Show("请观察" + dgv.Cells["名字"].EditedFormattedValue.ToString() + "是否在200~600mA之间？", "提示", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
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
                    DialogResult dr = MessageBox.Show("请观察"+ dgv.Cells["名字"].EditedFormattedValue.ToString()+"是否正常？", "提示", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        yesResult(dgv, str);
                    }
                    else
                    {
                        failResult(dgv, str.Substring(4, 2));
                    }
                }
                dgv.Cells["是否通过"].Style.Font = new Font("Tahoma", 24);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
                MessageBox.Show(ex.GetBaseException().ToString());
            }
        }

        private void btn_again_Click(object sender, EventArgs e)
        {
            //初始化dataCommond
            if (File.Exists("主板测试.xlsx"))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("主板测试.xlsx");
                this.tabPage2.Text = "主板测试";
            }
            else if (File.Exists("PPG测试.xlsx"))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("PPG测试.xlsx");
                this.tabPage2.Text = "PPG测试";
            }
            else if (File.Exists("NIR测试.xlsx"))
            {
                this.dataGridViewMainBoardTest.DataSource = bindData("NIR测试.xlsx");
                this.tabPage2.Text = "NIR测试";
            }

            //手动输入机器码
            //string str = Interaction.InputBox("请输入本次测试的机器码", "输入框", "", -1, -1);
            GetNewSN();
            textBoxSN.Text = strSN.ToString();
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
            byte[] recData = new byte[serialPort.BytesToRead];
            serialPort.Read(recData, 0, recData.Length);
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
            }
            else if ("24".Equals(types))//写入机器码
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
            dgr.Cells["是否通过"].Value = "✔";
            dgr.Cells["是否通过"].Style.ForeColor = Color.Green;
            if (str.Substring(4, 2).Equals("24"))
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
            }
        }
        public void failResult(DataGridViewRow dgr, String type)
        {
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
                MessageBox.Show("无法获取蓝牙MAC地址!!");
            }
        }

        private void buttonManual_Click(object sender, EventArgs e)
        {
            if (textBoxSN.ReadOnly == true && textBoxMAC.ReadOnly == true)
            {
                buttonManual.Text = "关闭手动输入";
                textBoxSN.ReadOnly = false;
                textBoxMAC.ReadOnly = false;
            }
            else
            {
                buttonManual.Text = "启动手动输入";
                textBoxSN.ReadOnly = true;
                textBoxMAC.ReadOnly = true;
            }
        }
    }
}
