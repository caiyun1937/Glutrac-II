namespace MySerialPort
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxTestItem = new System.Windows.Forms.ComboBox();
            this.buttonOpenComm = new System.Windows.Forms.Button();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSN = new System.Windows.Forms.TextBox();
            this.btn_print_QRCode = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewSN = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelScope = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBoxShow = new System.Windows.Forms.PictureBox();
            this.dataGridViewMainBoardTest = new System.Windows.Forms.DataGridView();
            this.btn_output_excel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.noUpDown = new System.Windows.Forms.NumericUpDown();
            this.btn_again = new System.Windows.Forms.Button();
            this.txt_output_excel = new System.Windows.Forms.TextBox();
            this.btn_go = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ReceiveTbox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkbox_16show = new System.Windows.Forms.CheckBox();
            this.checkbox_16send = new System.Windows.Forms.CheckBox();
            this.SendTbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.buttonManual = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMAC = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSN)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMainBoardTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noUpDown)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxTestItem);
            this.groupBox1.Controls.Add(this.buttonOpenComm);
            this.groupBox1.Controls.Add(this.cmbBaud);
            this.groupBox1.Controls.Add(this.cmbPort);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(712, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // comboBoxTestItem
            // 
            this.comboBoxTestItem.FormattingEnabled = true;
            this.comboBoxTestItem.Items.AddRange(new object[] {
            "主板测试",
            "PPG PCBA测试",
            "PPG 底座测试",
            "NIR红率IR测试",
            "NIR大波长测试"});
            this.comboBoxTestItem.Location = new System.Drawing.Point(419, 17);
            this.comboBoxTestItem.Name = "comboBoxTestItem";
            this.comboBoxTestItem.Size = new System.Drawing.Size(173, 23);
            this.comboBoxTestItem.TabIndex = 36;
            // 
            // buttonOpenComm
            // 
            this.buttonOpenComm.Location = new System.Drawing.Point(600, 14);
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
            this.cmbBaud.Location = new System.Drawing.Point(235, 17);
            this.cmbBaud.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(86, 23);
            this.cmbBaud.TabIndex = 3;
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(83, 17);
            this.cmbPort.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(69, 23);
            this.cmbPort.TabIndex = 2;
            this.cmbPort.DropDown += new System.EventHandler(this.cmbPort_DropDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "测试项目：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "SN：";
            // 
            // textBoxSN
            // 
            this.textBoxSN.Location = new System.Drawing.Point(61, 17);
            this.textBoxSN.Name = "textBoxSN";
            this.textBoxSN.Size = new System.Drawing.Size(147, 25);
            this.textBoxSN.TabIndex = 13;
            // 
            // btn_print_QRCode
            // 
            this.btn_print_QRCode.Location = new System.Drawing.Point(278, 8);
            this.btn_print_QRCode.Name = "btn_print_QRCode";
            this.btn_print_QRCode.Size = new System.Drawing.Size(130, 25);
            this.btn_print_QRCode.TabIndex = 14;
            this.btn_print_QRCode.Text = "打印二维码";
            this.btn_print_QRCode.UseVisualStyleBackColor = true;
            this.btn_print_QRCode.Click += new System.EventHandler(this.btn_print_QRCode_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewSN);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1239, 460);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SN表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSN
            // 
            this.dataGridViewSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSN.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewSN.Name = "dataGridViewSN";
            this.dataGridViewSN.RowTemplate.Height = 27;
            this.dataGridViewSN.Size = new System.Drawing.Size(1227, 448);
            this.dataGridViewSN.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelScope);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Controls.Add(this.pictureBoxShow);
            this.tabPage2.Controls.Add(this.btn_print_QRCode);
            this.tabPage2.Controls.Add(this.dataGridViewMainBoardTest);
            this.tabPage2.Controls.Add(this.btn_output_excel);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.noUpDown);
            this.tabPage2.Controls.Add(this.btn_again);
            this.tabPage2.Controls.Add(this.txt_output_excel);
            this.tabPage2.Controls.Add(this.btn_go);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1239, 460);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "主板测试";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelScope
            // 
            this.labelScope.AutoSize = true;
            this.labelScope.Location = new System.Drawing.Point(889, 39);
            this.labelScope.Name = "labelScope";
            this.labelScope.Size = new System.Drawing.Size(87, 15);
            this.labelScope.TabIndex = 18;
            this.labelScope.Text = "SignalShow";
            // 
            // chart1
            // 
            chartArea3.AxisX.Maximum = 1100D;
            chartArea3.AxisX.Minimum = 400D;
            chartArea3.AxisX.Title = "WaveLength [nm]";
            chartArea3.AxisY.Maximum = 0D;
            chartArea3.AxisY.Minimum = -1000D;
            chartArea3.AxisY.Title = "Scope [ADC Counts]";
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            legend3.TitleFont = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(554, 39);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(682, 415);
            this.chart1.TabIndex = 17;
            this.chart1.Text = "chart1";
            // 
            // pictureBoxShow
            // 
            this.pictureBoxShow.Location = new System.Drawing.Point(6, 39);
            this.pictureBoxShow.Name = "pictureBoxShow";
            this.pictureBoxShow.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxShow.TabIndex = 11;
            this.pictureBoxShow.TabStop = false;
            // 
            // dataGridViewMainBoardTest
            // 
            this.dataGridViewMainBoardTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMainBoardTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMainBoardTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMainBoardTest.Location = new System.Drawing.Point(6, 39);
            this.dataGridViewMainBoardTest.Name = "dataGridViewMainBoardTest";
            this.dataGridViewMainBoardTest.ReadOnly = true;
            this.dataGridViewMainBoardTest.RowTemplate.Height = 27;
            this.dataGridViewMainBoardTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMainBoardTest.Size = new System.Drawing.Size(1227, 415);
            this.dataGridViewMainBoardTest.TabIndex = 3;
            this.dataGridViewMainBoardTest.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // btn_output_excel
            // 
            this.btn_output_excel.Location = new System.Drawing.Point(142, 8);
            this.btn_output_excel.Name = "btn_output_excel";
            this.btn_output_excel.Size = new System.Drawing.Size(130, 25);
            this.btn_output_excel.TabIndex = 6;
            this.btn_output_excel.Text = "保存测试报告";
            this.btn_output_excel.UseVisualStyleBackColor = true;
            this.btn_output_excel.Click += new System.EventHandler(this.btn_output_excel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1021, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "超时时间(S):";
            // 
            // noUpDown
            // 
            this.noUpDown.Location = new System.Drawing.Point(1126, 8);
            this.noUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.noUpDown.Name = "noUpDown";
            this.noUpDown.Size = new System.Drawing.Size(84, 25);
            this.noUpDown.TabIndex = 9;
            this.noUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btn_again
            // 
            this.btn_again.Location = new System.Drawing.Point(414, 8);
            this.btn_again.Name = "btn_again";
            this.btn_again.Size = new System.Drawing.Size(130, 25);
            this.btn_again.TabIndex = 7;
            this.btn_again.Text = "复位";
            this.btn_again.UseVisualStyleBackColor = true;
            this.btn_again.Click += new System.EventHandler(this.btn_again_Click);
            // 
            // txt_output_excel
            // 
            this.txt_output_excel.Location = new System.Drawing.Point(554, 8);
            this.txt_output_excel.Name = "txt_output_excel";
            this.txt_output_excel.ReadOnly = true;
            this.txt_output_excel.Size = new System.Drawing.Size(461, 25);
            this.txt_output_excel.TabIndex = 5;
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(6, 8);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(130, 25);
            this.btn_go.TabIndex = 4;
            this.btn_go.Text = "一键测试";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1239, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口通讯";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReceiveTbox);
            this.groupBox2.Location = new System.Drawing.Point(8, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1224, 360);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收数据";
            // 
            // ReceiveTbox
            // 
            this.ReceiveTbox.Location = new System.Drawing.Point(8, 26);
            this.ReceiveTbox.Margin = new System.Windows.Forms.Padding(4);
            this.ReceiveTbox.Multiline = true;
            this.ReceiveTbox.Name = "ReceiveTbox";
            this.ReceiveTbox.ReadOnly = true;
            this.ReceiveTbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ReceiveTbox.Size = new System.Drawing.Size(1208, 326);
            this.ReceiveTbox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkbox_16show);
            this.groupBox3.Controls.Add(this.checkbox_16send);
            this.groupBox3.Controls.Add(this.SendTbox);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(7, 375);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1225, 78);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送数据";
            // 
            // checkbox_16show
            // 
            this.checkbox_16show.AutoSize = true;
            this.checkbox_16show.Location = new System.Drawing.Point(1098, 25);
            this.checkbox_16show.Name = "checkbox_16show";
            this.checkbox_16show.Size = new System.Drawing.Size(119, 19);
            this.checkbox_16show.TabIndex = 6;
            this.checkbox_16show.Text = "十六进制显示";
            this.checkbox_16show.UseVisualStyleBackColor = true;
            this.checkbox_16show.CheckedChanged += new System.EventHandler(this.checkbox_16show_CheckedChanged);
            // 
            // checkbox_16send
            // 
            this.checkbox_16send.AutoSize = true;
            this.checkbox_16send.Location = new System.Drawing.Point(1098, 50);
            this.checkbox_16send.Name = "checkbox_16send";
            this.checkbox_16send.Size = new System.Drawing.Size(119, 19);
            this.checkbox_16send.TabIndex = 6;
            this.checkbox_16send.Text = "十六进制发送";
            this.checkbox_16send.UseVisualStyleBackColor = true;
            this.checkbox_16send.CheckedChanged += new System.EventHandler(this.checkbox_16send_CheckedChanged);
            // 
            // SendTbox
            // 
            this.SendTbox.Location = new System.Drawing.Point(8, 26);
            this.SendTbox.Margin = new System.Windows.Forms.Padding(4);
            this.SendTbox.Multiline = true;
            this.SendTbox.Name = "SendTbox";
            this.SendTbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SendTbox.Size = new System.Drawing.Size(975, 43);
            this.SendTbox.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(991, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 43);
            this.button2.TabIndex = 5;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1247, 489);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.Grp_Label);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1239, 460);
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
            this.groupBox4.Size = new System.Drawing.Size(548, 139);
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
            this.Grp_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Grp_Label.Size = new System.Drawing.Size(548, 180);
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
            // buttonManual
            // 
            this.buttonManual.Location = new System.Drawing.Point(394, 14);
            this.buttonManual.Name = "buttonManual";
            this.buttonManual.Size = new System.Drawing.Size(124, 29);
            this.buttonManual.TabIndex = 35;
            this.buttonManual.Text = "手动输入SN码";
            this.buttonManual.UseVisualStyleBackColor = true;
            this.buttonManual.Click += new System.EventHandler(this.buttonManual_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "MAC:";
            // 
            // textBoxMAC
            // 
            this.textBoxMAC.Location = new System.Drawing.Point(261, 17);
            this.textBoxMAC.Name = "textBoxMAC";
            this.textBoxMAC.ReadOnly = true;
            this.textBoxMAC.Size = new System.Drawing.Size(126, 25);
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
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.buttonManual);
            this.groupBox5.Controls.Add(this.textBoxSN);
            this.groupBox5.Controls.Add(this.textBoxMAC);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(732, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(527, 54);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "设备标识";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 575);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "串口测试工具";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSN)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMainBoardTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noUpDown)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOpenComm;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSN;
        private System.Windows.Forms.Button btn_print_QRCode;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewSN;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewMainBoardTest;
        private System.Windows.Forms.Button btn_output_excel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown noUpDown;
        private System.Windows.Forms.TextBox txt_output_excel;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Button btn_again;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ReceiveTbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkbox_16show;
        private System.Windows.Forms.CheckBox checkbox_16send;
        private System.Windows.Forms.TextBox SendTbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMAC;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.NumericUpDown Num_QRRotation;
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
        public System.Windows.Forms.NumericUpDown Num_QRSize;
        private System.Windows.Forms.Button buttonManual;
        private System.Windows.Forms.PictureBox pictureBoxShow;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBoxTestItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelScope;
    }
}

