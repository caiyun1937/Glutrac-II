﻿namespace MySerialPort
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBaud2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPort2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxTestItem = new System.Windows.Forms.ComboBox();
            this.buttonOpenComm = new System.Windows.Forms.Button();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSN = new System.Windows.Forms.TextBox();
            this.buttonManualSN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMAC = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxBarCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelScope = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBoxShow = new System.Windows.Forms.PictureBox();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonCheckBarCode = new System.Windows.Forms.Button();
            this.btn_go = new System.Windows.Forms.Button();
            this.txt_output_excel = new System.Windows.Forms.TextBox();
            this.btn_again = new System.Windows.Forms.Button();
            this.btn_print_QRCode = new System.Windows.Forms.Button();
            this.btn_output_excel = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewSN = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Num_QRRotation = new System.Windows.Forms.NumericUpDown();
            this.Num_QRSize = new System.Windows.Forms.NumericUpDown();
            this.NumX_Distance = new System.Windows.Forms.NumericUpDown();
            this.Num_QRPosY = new System.Windows.Forms.NumericUpDown();
            this.Num_QRPosX = new System.Windows.Forms.NumericUpDown();
            this.lab_QR_Rotation = new System.Windows.Forms.Label();
            this.lab_QRSize = new System.Windows.Forms.Label();
            this.lab_PosDistance = new System.Windows.Forms.Label();
            this.lab_QRPosX = new System.Windows.Forms.Label();
            this.lab_QRPosY = new System.Windows.Forms.Label();
            this.Grp_Label = new System.Windows.Forms.GroupBox();
            this.Lbl_Page = new System.Windows.Forms.Label();
            this.Num_Page = new System.Windows.Forms.NumericUpDown();
            this.Num_Speed = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Speed = new System.Windows.Forms.Label();
            this.Lbl_Copy = new System.Windows.Forms.Label();
            this.Num_Copy = new System.Windows.Forms.NumericUpDown();
            this.Num_Dark = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Dark = new System.Windows.Forms.Label();
            this.Num_GapFeed = new System.Windows.Forms.NumericUpDown();
            this.Lbl_GapFeed = new System.Windows.Forms.Label();
            this.Lbl_PaperType = new System.Windows.Forms.Label();
            this.Lbl_Label_H = new System.Windows.Forms.Label();
            this.Num_Label_H = new System.Windows.Forms.NumericUpDown();
            this.Num_Label_W = new System.Windows.Forms.NumericUpDown();
            this.Cbo_PaperType = new System.Windows.Forms.ComboBox();
            this.Lbl_Label_W = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ReceiveTbox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SendTbox = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.checkbox_16send = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.checkbox_16show = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.signal_generator = new System.Windows.Forms.TabPage();
            this.m_elcTestTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSN)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_QRRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_QRSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumX_Distance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_QRPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_QRPosX)).BeginInit();
            this.Grp_Label.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Page)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Copy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Dark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_GapFeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Label_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Label_W)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBaud2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbPort2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxTestItem);
            this.groupBox1.Controls.Add(this.buttonOpenComm);
            this.groupBox1.Controls.Add(this.cmbBaud);
            this.groupBox1.Controls.Add(this.cmbPort);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(779, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // cmbBaud2
            // 
            this.cmbBaud2.FormattingEnabled = true;
            this.cmbBaud2.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cmbBaud2.Location = new System.Drawing.Point(239, 53);
            this.cmbBaud2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBaud2.Name = "cmbBaud2";
            this.cmbBaud2.Size = new System.Drawing.Size(112, 23);
            this.cmbBaud2.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(164, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 40;
            this.label9.Text = "波特率：";
            // 
            // cmbPort2
            // 
            this.cmbPort2.FormattingEnabled = true;
            this.cmbPort2.Location = new System.Drawing.Point(67, 53);
            this.cmbPort2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort2.Name = "cmbPort2";
            this.cmbPort2.Size = new System.Drawing.Size(69, 23);
            this.cmbPort2.TabIndex = 38;
            this.cmbPort2.DropDown += new System.EventHandler(this.cmbPort2_DropDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 37;
            this.label7.Text = "串口2：";
            // 
            // comboBoxTestItem
            // 
            this.comboBoxTestItem.FormattingEnabled = true;
            this.comboBoxTestItem.Items.AddRange(new object[] {
            "主板测试",
            "PPG PCBA测试",
            "PPG 半成品测试",
            "NIR PCBA测试",
            "整机测试",
            "整机PPG NIR测试",
            "条形码测试"});
            this.comboBoxTestItem.Location = new System.Drawing.Point(470, 39);
            this.comboBoxTestItem.Name = "comboBoxTestItem";
            this.comboBoxTestItem.Size = new System.Drawing.Size(158, 23);
            this.comboBoxTestItem.TabIndex = 36;
            this.comboBoxTestItem.SelectedIndexChanged += new System.EventHandler(this.comboBoxTestItem_SelectedIndexChanged);
            // 
            // buttonOpenComm
            // 
            this.buttonOpenComm.Location = new System.Drawing.Point(657, 38);
            this.buttonOpenComm.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenComm.Name = "buttonOpenComm";
            this.buttonOpenComm.Size = new System.Drawing.Size(100, 29);
            this.buttonOpenComm.TabIndex = 4;
            this.buttonOpenComm.Text = "打开串口";
            this.buttonOpenComm.UseVisualStyleBackColor = true;
            this.buttonOpenComm.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbBaud
            // 
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cmbBaud.Location = new System.Drawing.Point(239, 21);
            this.cmbBaud.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(112, 23);
            this.cmbBaud.TabIndex = 3;
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(67, 21);
            this.cmbPort.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(69, 23);
            this.cmbPort.TabIndex = 2;
            this.cmbPort.DropDown += new System.EventHandler(this.cmbPort_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "测试项目：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口1：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "SN：";
            // 
            // textBoxSN
            // 
            this.textBoxSN.Location = new System.Drawing.Point(52, 33);
            this.textBoxSN.Name = "textBoxSN";
            this.textBoxSN.Size = new System.Drawing.Size(97, 25);
            this.textBoxSN.TabIndex = 13;
            // 
            // buttonManualSN
            // 
            this.buttonManualSN.Location = new System.Drawing.Point(170, 33);
            this.buttonManualSN.Name = "buttonManualSN";
            this.buttonManualSN.Size = new System.Drawing.Size(124, 29);
            this.buttonManualSN.TabIndex = 35;
            this.buttonManualSN.Text = "自定义SN码";
            this.buttonManualSN.UseVisualStyleBackColor = true;
            this.buttonManualSN.Click += new System.EventHandler(this.buttonManual_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "MAC:";
            // 
            // textBoxMAC
            // 
            this.textBoxMAC.Location = new System.Drawing.Point(341, 35);
            this.textBoxMAC.Name = "textBoxMAC";
            this.textBoxMAC.ReadOnly = true;
            this.textBoxMAC.Size = new System.Drawing.Size(119, 25);
            this.textBoxMAC.TabIndex = 16;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "led_off.jpg");
            this.imageList1.Images.SetKeyName(1, "led_on.jpg");
            this.imageList1.Images.SetKeyName(2, "screen_white.jpg");
            this.imageList1.Images.SetKeyName(3, "ppg_red_green.jpg");
            this.imageList1.Images.SetKeyName(4, "ppg_green.jpg");
            this.imageList1.Images.SetKeyName(5, "ppg_ir.png");
            this.imageList1.Images.SetKeyName(6, "nir_green.jpg");
            this.imageList1.Images.SetKeyName(7, "nir_red.jpg");
            this.imageList1.Images.SetKeyName(8, "nir_ir.png");
            this.imageList1.Images.SetKeyName(9, "nir_810.png");
            this.imageList1.Images.SetKeyName(10, "nir_1050.png");
            this.imageList1.Images.SetKeyName(11, "nir_1450.png");
            this.imageList1.Images.SetKeyName(12, "nir_1550.png");
            this.imageList1.Images.SetKeyName(13, "ppg_green1_ok.jpg");
            this.imageList1.Images.SetKeyName(14, "ppg_green2_ok.jpg");
            this.imageList1.Images.SetKeyName(15, "ppg_ir_ok.jpg");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxBarCode);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.buttonManualSN);
            this.groupBox5.Controls.Add(this.textBoxSN);
            this.groupBox5.Controls.Add(this.textBoxMAC);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(799, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(632, 92);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "设备标识";
            // 
            // textBoxBarCode
            // 
            this.textBoxBarCode.Location = new System.Drawing.Point(528, 35);
            this.textBoxBarCode.Name = "textBoxBarCode";
            this.textBoxBarCode.Size = new System.Drawing.Size(97, 25);
            this.textBoxBarCode.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "条形码:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1443, 99);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1443, 481);
            this.panel2.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.signal_generator);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1443, 481);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1435, 452);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "主板测试";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelScope);
            this.panel4.Controls.Add(this.chart1);
            this.panel4.Controls.Add(this.pictureBoxShow);
            this.panel4.Controls.Add(this.dataGridViewMain);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1429, 409);
            this.panel4.TabIndex = 20;
            // 
            // labelScope
            // 
            this.labelScope.AutoSize = true;
            this.labelScope.Location = new System.Drawing.Point(1068, 6);
            this.labelScope.Name = "labelScope";
            this.labelScope.Size = new System.Drawing.Size(87, 15);
            this.labelScope.TabIndex = 18;
            this.labelScope.Text = "SignalShow";
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 100D;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            chartArea1.AxisX.Maximum = 1700D;
            chartArea1.AxisX.Minimum = 200D;
            chartArea1.AxisX.Title = "WaveLength [nm]";
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            chartArea1.AxisY.Maximum = 65535D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Scope [ADC Counts]";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(746, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(682, 415);
            this.chart1.TabIndex = 17;
            this.chart1.Text = "chart1";
            // 
            // pictureBoxShow
            // 
            this.pictureBoxShow.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxShow.Name = "pictureBoxShow";
            this.pictureBoxShow.Size = new System.Drawing.Size(320, 320);
            this.pictureBoxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxShow.TabIndex = 11;
            this.pictureBoxShow.TabStop = false;
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.RowHeadersWidth = 51;
            this.dataGridViewMain.RowTemplate.Height = 27;
            this.dataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMain.Size = new System.Drawing.Size(1429, 409);
            this.dataGridViewMain.TabIndex = 3;
            this.dataGridViewMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonCheckBarCode);
            this.panel3.Controls.Add(this.btn_go);
            this.panel3.Controls.Add(this.txt_output_excel);
            this.panel3.Controls.Add(this.btn_again);
            this.panel3.Controls.Add(this.btn_print_QRCode);
            this.panel3.Controls.Add(this.btn_output_excel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1429, 37);
            this.panel3.TabIndex = 19;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // buttonCheckBarCode
            // 
            this.buttonCheckBarCode.Location = new System.Drawing.Point(547, 5);
            this.buttonCheckBarCode.Name = "buttonCheckBarCode";
            this.buttonCheckBarCode.Size = new System.Drawing.Size(130, 25);
            this.buttonCheckBarCode.TabIndex = 38;
            this.buttonCheckBarCode.Text = "条形码校验";
            this.buttonCheckBarCode.UseVisualStyleBackColor = true;
            this.buttonCheckBarCode.Click += new System.EventHandler(this.buttonCheckBarCode_Click);
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(3, 5);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(130, 25);
            this.btn_go.TabIndex = 4;
            this.btn_go.Text = "开始测试";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // txt_output_excel
            // 
            this.txt_output_excel.Location = new System.Drawing.Point(683, 5);
            this.txt_output_excel.Name = "txt_output_excel";
            this.txt_output_excel.ReadOnly = true;
            this.txt_output_excel.Size = new System.Drawing.Size(741, 25);
            this.txt_output_excel.TabIndex = 5;
            // 
            // btn_again
            // 
            this.btn_again.Location = new System.Drawing.Point(411, 5);
            this.btn_again.Name = "btn_again";
            this.btn_again.Size = new System.Drawing.Size(130, 25);
            this.btn_again.TabIndex = 7;
            this.btn_again.Text = "复位";
            this.btn_again.UseVisualStyleBackColor = true;
            this.btn_again.Click += new System.EventHandler(this.btn_again_Click);
            // 
            // btn_print_QRCode
            // 
            this.btn_print_QRCode.Location = new System.Drawing.Point(275, 5);
            this.btn_print_QRCode.Name = "btn_print_QRCode";
            this.btn_print_QRCode.Size = new System.Drawing.Size(130, 25);
            this.btn_print_QRCode.TabIndex = 14;
            this.btn_print_QRCode.Text = "打印二维码";
            this.btn_print_QRCode.UseVisualStyleBackColor = true;
            this.btn_print_QRCode.Click += new System.EventHandler(this.btn_print_QRCode_Click);
            // 
            // btn_output_excel
            // 
            this.btn_output_excel.Location = new System.Drawing.Point(139, 5);
            this.btn_output_excel.Name = "btn_output_excel";
            this.btn_output_excel.Size = new System.Drawing.Size(130, 25);
            this.btn_output_excel.TabIndex = 6;
            this.btn_output_excel.Text = "保存测试报告";
            this.btn_output_excel.UseVisualStyleBackColor = true;
            this.btn_output_excel.Click += new System.EventHandler(this.btn_output_excel_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewSN);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1435, 452);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SN表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSN
            // 
            this.dataGridViewSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSN.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSN.Name = "dataGridViewSN";
            this.dataGridViewSN.RowHeadersWidth = 51;
            this.dataGridViewSN.RowTemplate.Height = 27;
            this.dataGridViewSN.Size = new System.Drawing.Size(1429, 446);
            this.dataGridViewSN.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.Grp_Label);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1435, 452);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "QRCode";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Num_QRRotation);
            this.groupBox4.Controls.Add(this.Num_QRSize);
            this.groupBox4.Controls.Add(this.NumX_Distance);
            this.groupBox4.Controls.Add(this.Num_QRPosY);
            this.groupBox4.Controls.Add(this.Num_QRPosX);
            this.groupBox4.Controls.Add(this.lab_QR_Rotation);
            this.groupBox4.Controls.Add(this.lab_QRSize);
            this.groupBox4.Controls.Add(this.lab_PosDistance);
            this.groupBox4.Controls.Add(this.lab_QRPosX);
            this.groupBox4.Controls.Add(this.lab_QRPosY);
            this.groupBox4.Location = new System.Drawing.Point(8, 192);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(600, 139);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "QRCode Setup";
            // 
            // Num_QRRotation
            // 
            this.Num_QRRotation.Location = new System.Drawing.Point(404, 60);
            this.Num_QRRotation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_QRRotation.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.Num_QRRotation.Name = "Num_QRRotation";
            this.Num_QRRotation.Size = new System.Drawing.Size(103, 25);
            this.Num_QRRotation.TabIndex = 39;
            // 
            // Num_QRSize
            // 
            this.Num_QRSize.Location = new System.Drawing.Point(404, 21);
            this.Num_QRSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_QRSize.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.Num_QRSize.Name = "Num_QRSize";
            this.Num_QRSize.Size = new System.Drawing.Size(103, 25);
            this.Num_QRSize.TabIndex = 38;
            this.Num_QRSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // NumX_Distance
            // 
            this.NumX_Distance.Location = new System.Drawing.Point(169, 97);
            this.NumX_Distance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NumX_Distance.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumX_Distance.Name = "NumX_Distance";
            this.NumX_Distance.Size = new System.Drawing.Size(103, 25);
            this.NumX_Distance.TabIndex = 37;
            this.NumX_Distance.Value = new decimal(new int[] {
            264,
            0,
            0,
            0});
            // 
            // Num_QRPosY
            // 
            this.Num_QRPosY.Location = new System.Drawing.Point(169, 60);
            this.Num_QRPosY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_QRPosY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.Num_QRPosY.Name = "Num_QRPosY";
            this.Num_QRPosY.Size = new System.Drawing.Size(103, 25);
            this.Num_QRPosY.TabIndex = 36;
            this.Num_QRPosY.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // Num_QRPosX
            // 
            this.Num_QRPosX.Location = new System.Drawing.Point(169, 21);
            this.Num_QRPosX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_QRPosX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Num_QRPosX.Name = "Num_QRPosX";
            this.Num_QRPosX.Size = new System.Drawing.Size(103, 25);
            this.Num_QRPosX.TabIndex = 35;
            this.Num_QRPosX.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // lab_QR_Rotation
            // 
            this.lab_QR_Rotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_QR_Rotation.AutoSize = true;
            this.lab_QR_Rotation.Location = new System.Drawing.Point(301, 65);
            this.lab_QR_Rotation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_QR_Rotation.Name = "lab_QR_Rotation";
            this.lab_QR_Rotation.Size = new System.Drawing.Size(95, 15);
            this.lab_QR_Rotation.TabIndex = 34;
            this.lab_QR_Rotation.Text = "QR Rotation";
            // 
            // lab_QRSize
            // 
            this.lab_QRSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_QRSize.AutoSize = true;
            this.lab_QRSize.Location = new System.Drawing.Point(301, 26);
            this.lab_QRSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_QRSize.Name = "lab_QRSize";
            this.lab_QRSize.Size = new System.Drawing.Size(55, 15);
            this.lab_QRSize.TabIndex = 33;
            this.lab_QRSize.Text = "QRSize";
            // 
            // lab_PosDistance
            // 
            this.lab_PosDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_PosDistance.AutoSize = true;
            this.lab_PosDistance.Location = new System.Drawing.Point(18, 102);
            this.lab_PosDistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_PosDistance.Name = "lab_PosDistance";
            this.lab_PosDistance.Size = new System.Drawing.Size(127, 15);
            this.lab_PosDistance.TabIndex = 32;
            this.lab_PosDistance.Text = "QRPosX Distance";
            // 
            // lab_QRPosX
            // 
            this.lab_QRPosX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_QRPosX.AutoSize = true;
            this.lab_QRPosX.Location = new System.Drawing.Point(18, 26);
            this.lab_QRPosX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_QRPosX.Name = "lab_QRPosX";
            this.lab_QRPosX.Size = new System.Drawing.Size(106, 15);
            this.lab_QRPosX.TabIndex = 30;
            this.lab_QRPosX.Text = "X轴坐标(左右)";
            // 
            // lab_QRPosY
            // 
            this.lab_QRPosY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_QRPosY.AutoSize = true;
            this.lab_QRPosY.Location = new System.Drawing.Point(18, 65);
            this.lab_QRPosY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_QRPosY.Name = "lab_QRPosY";
            this.lab_QRPosY.Size = new System.Drawing.Size(106, 15);
            this.lab_QRPosY.TabIndex = 31;
            this.lab_QRPosY.Text = "Y轴坐标(上下)";
            // 
            // Grp_Label
            // 
            this.Grp_Label.Controls.Add(this.Lbl_Page);
            this.Grp_Label.Controls.Add(this.Num_Page);
            this.Grp_Label.Controls.Add(this.Num_Speed);
            this.Grp_Label.Controls.Add(this.Lbl_Speed);
            this.Grp_Label.Controls.Add(this.Lbl_Copy);
            this.Grp_Label.Controls.Add(this.Num_Copy);
            this.Grp_Label.Controls.Add(this.Num_Dark);
            this.Grp_Label.Controls.Add(this.Lbl_Dark);
            this.Grp_Label.Controls.Add(this.Num_GapFeed);
            this.Grp_Label.Controls.Add(this.Lbl_GapFeed);
            this.Grp_Label.Controls.Add(this.Lbl_PaperType);
            this.Grp_Label.Controls.Add(this.Lbl_Label_H);
            this.Grp_Label.Controls.Add(this.Num_Label_H);
            this.Grp_Label.Controls.Add(this.Num_Label_W);
            this.Grp_Label.Controls.Add(this.Cbo_PaperType);
            this.Grp_Label.Controls.Add(this.Lbl_Label_W);
            this.Grp_Label.Location = new System.Drawing.Point(8, 6);
            this.Grp_Label.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Grp_Label.Name = "Grp_Label";
            this.Grp_Label.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Grp_Label.Size = new System.Drawing.Size(600, 180);
            this.Grp_Label.TabIndex = 20;
            this.Grp_Label.TabStop = false;
            this.Grp_Label.Text = " Label Setup ";
            // 
            // Lbl_Page
            // 
            this.Lbl_Page.AutoSize = true;
            this.Lbl_Page.Location = new System.Drawing.Point(301, 143);
            this.Lbl_Page.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Page.Name = "Lbl_Page";
            this.Lbl_Page.Size = new System.Drawing.Size(63, 15);
            this.Lbl_Page.TabIndex = 40;
            this.Lbl_Page.Text = "Page No";
            // 
            // Num_Page
            // 
            this.Num_Page.Location = new System.Drawing.Point(403, 138);
            this.Num_Page.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_Page.Name = "Num_Page";
            this.Num_Page.Size = new System.Drawing.Size(104, 25);
            this.Num_Page.TabIndex = 39;
            this.Num_Page.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Num_Speed
            // 
            this.Num_Speed.Location = new System.Drawing.Point(403, 31);
            this.Num_Speed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_Speed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.Num_Speed.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Num_Speed.Name = "Num_Speed";
            this.Num_Speed.Size = new System.Drawing.Size(104, 25);
            this.Num_Speed.TabIndex = 38;
            this.Num_Speed.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Lbl_Speed
            // 
            this.Lbl_Speed.AutoSize = true;
            this.Lbl_Speed.Location = new System.Drawing.Point(301, 36);
            this.Lbl_Speed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Speed.Name = "Lbl_Speed";
            this.Lbl_Speed.Size = new System.Drawing.Size(95, 15);
            this.Lbl_Speed.TabIndex = 37;
            this.Lbl_Speed.Text = "Speed (ips)";
            // 
            // Lbl_Copy
            // 
            this.Lbl_Copy.AutoSize = true;
            this.Lbl_Copy.Location = new System.Drawing.Point(301, 106);
            this.Lbl_Copy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Copy.Name = "Lbl_Copy";
            this.Lbl_Copy.Size = new System.Drawing.Size(63, 15);
            this.Lbl_Copy.TabIndex = 36;
            this.Lbl_Copy.Text = "Copy No";
            // 
            // Num_Copy
            // 
            this.Num_Copy.Location = new System.Drawing.Point(403, 101);
            this.Num_Copy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_Copy.Name = "Num_Copy";
            this.Num_Copy.Size = new System.Drawing.Size(104, 25);
            this.Num_Copy.TabIndex = 35;
            this.Num_Copy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Num_Dark
            // 
            this.Num_Dark.Location = new System.Drawing.Point(403, 67);
            this.Num_Dark.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_Dark.Maximum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.Num_Dark.Name = "Num_Dark";
            this.Num_Dark.Size = new System.Drawing.Size(104, 25);
            this.Num_Dark.TabIndex = 34;
            this.Num_Dark.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Lbl_Dark
            // 
            this.Lbl_Dark.AutoSize = true;
            this.Lbl_Dark.Location = new System.Drawing.Point(301, 72);
            this.Lbl_Dark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Dark.Name = "Lbl_Dark";
            this.Lbl_Dark.Size = new System.Drawing.Size(39, 15);
            this.Lbl_Dark.TabIndex = 33;
            this.Lbl_Dark.Text = "Dark";
            // 
            // Num_GapFeed
            // 
            this.Num_GapFeed.Location = new System.Drawing.Point(169, 67);
            this.Num_GapFeed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_GapFeed.Name = "Num_GapFeed";
            this.Num_GapFeed.Size = new System.Drawing.Size(104, 25);
            this.Num_GapFeed.TabIndex = 32;
            this.Num_GapFeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Lbl_GapFeed
            // 
            this.Lbl_GapFeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_GapFeed.AutoSize = true;
            this.Lbl_GapFeed.Location = new System.Drawing.Point(18, 72);
            this.Lbl_GapFeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_GapFeed.Name = "Lbl_GapFeed";
            this.Lbl_GapFeed.Size = new System.Drawing.Size(127, 15);
            this.Lbl_GapFeed.TabIndex = 31;
            this.Lbl_GapFeed.Text = "Gap Length (mm)";
            // 
            // Lbl_PaperType
            // 
            this.Lbl_PaperType.AutoSize = true;
            this.Lbl_PaperType.Location = new System.Drawing.Point(18, 36);
            this.Lbl_PaperType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_PaperType.Name = "Lbl_PaperType";
            this.Lbl_PaperType.Size = new System.Drawing.Size(87, 15);
            this.Lbl_PaperType.TabIndex = 30;
            this.Lbl_PaperType.Text = "Paper Type";
            // 
            // Lbl_Label_H
            // 
            this.Lbl_Label_H.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Label_H.AutoSize = true;
            this.Lbl_Label_H.Location = new System.Drawing.Point(18, 143);
            this.Lbl_Label_H.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Label_H.Name = "Lbl_Label_H";
            this.Lbl_Label_H.Size = new System.Drawing.Size(143, 15);
            this.Lbl_Label_H.TabIndex = 29;
            this.Lbl_Label_H.Text = "Label Height (mm)";
            // 
            // Num_Label_H
            // 
            this.Num_Label_H.Location = new System.Drawing.Point(169, 138);
            this.Num_Label_H.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_Label_H.Name = "Num_Label_H";
            this.Num_Label_H.Size = new System.Drawing.Size(104, 25);
            this.Num_Label_H.TabIndex = 28;
            this.Num_Label_H.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Num_Label_W
            // 
            this.Num_Label_W.Location = new System.Drawing.Point(169, 101);
            this.Num_Label_W.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Num_Label_W.Name = "Num_Label_W";
            this.Num_Label_W.Size = new System.Drawing.Size(104, 25);
            this.Num_Label_W.TabIndex = 27;
            this.Num_Label_W.Value = new decimal(new int[] {
            97,
            0,
            0,
            0});
            // 
            // Cbo_PaperType
            // 
            this.Cbo_PaperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_PaperType.FormattingEnabled = true;
            this.Cbo_PaperType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Cbo_PaperType.Items.AddRange(new object[] {
            "Gap",
            "Continue"});
            this.Cbo_PaperType.Location = new System.Drawing.Point(169, 32);
            this.Cbo_PaperType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Cbo_PaperType.Name = "Cbo_PaperType";
            this.Cbo_PaperType.Size = new System.Drawing.Size(101, 23);
            this.Cbo_PaperType.TabIndex = 26;
            // 
            // Lbl_Label_W
            // 
            this.Lbl_Label_W.AutoSize = true;
            this.Lbl_Label_W.Location = new System.Drawing.Point(18, 106);
            this.Lbl_Label_W.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Label_W.Name = "Lbl_Label_W";
            this.Lbl_Label_W.Size = new System.Drawing.Size(135, 15);
            this.Lbl_Label_W.TabIndex = 24;
            this.Lbl_Label_W.Text = "Label Width (mm)";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1435, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口通讯";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReceiveTbox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1429, 367);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收数据";
            // 
            // ReceiveTbox
            // 
            this.ReceiveTbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReceiveTbox.Location = new System.Drawing.Point(4, 22);
            this.ReceiveTbox.Margin = new System.Windows.Forms.Padding(4);
            this.ReceiveTbox.Multiline = true;
            this.ReceiveTbox.Name = "ReceiveTbox";
            this.ReceiveTbox.ReadOnly = true;
            this.ReceiveTbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ReceiveTbox.Size = new System.Drawing.Size(1421, 341);
            this.ReceiveTbox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SendTbox);
            this.groupBox3.Controls.Add(this.panel5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 370);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1429, 79);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送数据";
            // 
            // SendTbox
            // 
            this.SendTbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendTbox.Location = new System.Drawing.Point(4, 22);
            this.SendTbox.Margin = new System.Windows.Forms.Padding(4);
            this.SendTbox.Multiline = true;
            this.SendTbox.Name = "SendTbox";
            this.SendTbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SendTbox.Size = new System.Drawing.Size(1189, 53);
            this.SendTbox.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1193, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(232, 53);
            this.panel5.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.checkbox_16send);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(104, 25);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(128, 25);
            this.panel8.TabIndex = 2;
            // 
            // checkbox_16send
            // 
            this.checkbox_16send.AutoSize = true;
            this.checkbox_16send.Location = new System.Drawing.Point(3, 3);
            this.checkbox_16send.Name = "checkbox_16send";
            this.checkbox_16send.Size = new System.Drawing.Size(119, 19);
            this.checkbox_16send.TabIndex = 6;
            this.checkbox_16send.Text = "十六进制发送";
            this.checkbox_16send.UseVisualStyleBackColor = true;
            this.checkbox_16send.CheckedChanged += new System.EventHandler(this.checkbox_16send_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.checkbox_16show);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(104, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(128, 25);
            this.panel7.TabIndex = 1;
            // 
            // checkbox_16show
            // 
            this.checkbox_16show.AutoSize = true;
            this.checkbox_16show.Location = new System.Drawing.Point(3, 3);
            this.checkbox_16show.Name = "checkbox_16show";
            this.checkbox_16show.Size = new System.Drawing.Size(119, 19);
            this.checkbox_16show.TabIndex = 6;
            this.checkbox_16show.Text = "十六进制显示";
            this.checkbox_16show.UseVisualStyleBackColor = true;
            this.checkbox_16show.CheckedChanged += new System.EventHandler(this.checkbox_16show_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(104, 53);
            this.panel6.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 53);
            this.button2.TabIndex = 5;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // signal_generator
            // 
            this.signal_generator.Location = new System.Drawing.Point(4, 25);
            this.signal_generator.Name = "signal_generator";
            this.signal_generator.Padding = new System.Windows.Forms.Padding(3);
            this.signal_generator.Size = new System.Drawing.Size(1435, 452);
            this.signal_generator.TabIndex = 4;
            this.signal_generator.Text = "鲸杨信号发生器";
            this.signal_generator.UseVisualStyleBackColor = true;
            // 
            // m_elcTestTimer
            // 
            this.m_elcTestTimer.Interval = 30;
            this.m_elcTestTimer.Tick += new System.EventHandler(this.OnTestEleEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 580);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Glutrac上位机";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSN)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_QRRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_QRSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumX_Distance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_QRPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_QRPosX)).EndInit();
            this.Grp_Label.ResumeLayout(false);
            this.Grp_Label.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Page)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Copy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Dark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_GapFeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Label_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Label_W)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOpenComm;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMAC;
        private System.Windows.Forms.Button buttonManualSN;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBoxTestItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelScope;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox pictureBoxShow;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.TextBox txt_output_excel;
        private System.Windows.Forms.Button btn_again;
        private System.Windows.Forms.Button btn_print_QRCode;
        private System.Windows.Forms.Button btn_output_excel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewSN;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.NumericUpDown Num_QRRotation;
        public System.Windows.Forms.NumericUpDown Num_QRSize;
        public System.Windows.Forms.NumericUpDown NumX_Distance;
        public System.Windows.Forms.NumericUpDown Num_QRPosY;
        public System.Windows.Forms.NumericUpDown Num_QRPosX;
        private System.Windows.Forms.Label lab_QR_Rotation;
        private System.Windows.Forms.Label lab_QRSize;
        private System.Windows.Forms.Label lab_PosDistance;
        private System.Windows.Forms.Label lab_QRPosX;
        private System.Windows.Forms.Label lab_QRPosY;
        private System.Windows.Forms.GroupBox Grp_Label;
        private System.Windows.Forms.Label Lbl_Page;
        public System.Windows.Forms.NumericUpDown Num_Page;
        public System.Windows.Forms.NumericUpDown Num_Speed;
        private System.Windows.Forms.Label Lbl_Speed;
        private System.Windows.Forms.Label Lbl_Copy;
        public System.Windows.Forms.NumericUpDown Num_Copy;
        public System.Windows.Forms.NumericUpDown Num_Dark;
        private System.Windows.Forms.Label Lbl_Dark;
        public System.Windows.Forms.NumericUpDown Num_GapFeed;
        private System.Windows.Forms.Label Lbl_GapFeed;
        private System.Windows.Forms.Label Lbl_PaperType;
        private System.Windows.Forms.Label Lbl_Label_H;
        public System.Windows.Forms.NumericUpDown Num_Label_H;
        public System.Windows.Forms.NumericUpDown Num_Label_W;
        public System.Windows.Forms.ComboBox Cbo_PaperType;
        private System.Windows.Forms.Label Lbl_Label_W;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ReceiveTbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox SendTbox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox checkbox_16send;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox checkbox_16show;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage signal_generator;
        private System.Windows.Forms.TextBox textBoxBarCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCheckBarCode;
        private System.Windows.Forms.ComboBox cmbPort2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBaud2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer m_elcTestTimer;
    }
}

