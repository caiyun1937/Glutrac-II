namespace GlutracUpper
{
    partial class FrmConnectDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPortProps = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cboStopBit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDataBit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboStreamCtl = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSpeed = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPortProps.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPortProps);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(549, 252);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPortProps
            // 
            this.tabPortProps.Controls.Add(this.btnClose);
            this.tabPortProps.Controls.Add(this.btnCancel);
            this.tabPortProps.Controls.Add(this.btnOK);
            this.tabPortProps.Controls.Add(this.cboStopBit);
            this.tabPortProps.Controls.Add(this.label6);
            this.tabPortProps.Controls.Add(this.cboParity);
            this.tabPortProps.Controls.Add(this.label5);
            this.tabPortProps.Controls.Add(this.cboDataBit);
            this.tabPortProps.Controls.Add(this.label4);
            this.tabPortProps.Controls.Add(this.cboStreamCtl);
            this.tabPortProps.Controls.Add(this.label3);
            this.tabPortProps.Controls.Add(this.cboSpeed);
            this.tabPortProps.Controls.Add(this.label2);
            this.tabPortProps.Controls.Add(this.cboPort);
            this.tabPortProps.Controls.Add(this.label1);
            this.tabPortProps.Location = new System.Drawing.Point(4, 25);
            this.tabPortProps.Name = "tabPortProps";
            this.tabPortProps.Size = new System.Drawing.Size(541, 223);
            this.tabPortProps.TabIndex = 0;
            this.tabPortProps.Text = "端口属性";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(384, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 34);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(240, 165);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 34);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "打开";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboStopBit
            // 
            this.cboStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBit.Items.AddRange(new object[] {
            "1 bit",
            "1.5 bits",
            "2 bits"});
            this.cboStopBit.Location = new System.Drawing.Point(357, 113);
            this.cboStopBit.Name = "cboStopBit";
            this.cboStopBit.Size = new System.Drawing.Size(150, 23);
            this.cboStopBit.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(267, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "停止位:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboParity
            // 
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None",
            "Mark",
            "Space"});
            this.cboParity.Location = new System.Drawing.Point(357, 68);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(150, 23);
            this.cboParity.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(267, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "奇偶位:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDataBit
            // 
            this.cboDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBit.Items.AddRange(new object[] {
            "4 ",
            "5 ",
            "6 ",
            "7 ",
            "8 "});
            this.cboDataBit.Location = new System.Drawing.Point(357, 21);
            this.cboDataBit.Name = "cboDataBit";
            this.cboDataBit.Size = new System.Drawing.Size(150, 23);
            this.cboDataBit.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(267, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "数据位:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboStreamCtl
            // 
            this.cboStreamCtl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStreamCtl.Items.AddRange(new object[] {
            "None",
            "Xon/Xoff",
            "RTS",
            "Xon/RTS"});
            this.cboStreamCtl.Location = new System.Drawing.Point(107, 113);
            this.cboStreamCtl.Name = "cboStreamCtl";
            this.cboStreamCtl.Size = new System.Drawing.Size(149, 23);
            this.cboStreamCtl.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "流控制:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSpeed
            // 
            this.cboSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpeed.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "23040",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.cboSpeed.Location = new System.Drawing.Point(107, 68);
            this.cboSpeed.Name = "cboSpeed";
            this.cboSpeed.Size = new System.Drawing.Size(149, 23);
            this.cboSpeed.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "速度:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboPort
            // 
            this.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5"});
            this.cboPort.Location = new System.Drawing.Point(107, 21);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(149, 23);
            this.cboPort.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(89, 165);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 34);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.OnCloseSio);
            // 
            // FrmConnectDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 266);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmConnectDlg";
            this.Text = "FrmConnectDlg";
            this.tabControl1.ResumeLayout(false);
            this.tabPortProps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPortProps;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboStopBit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDataBit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboStreamCtl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}