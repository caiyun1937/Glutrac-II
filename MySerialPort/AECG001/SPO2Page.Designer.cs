namespace AECG100Demo
{
    partial class SPO2Page
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.labelWaveformType = new System.Windows.Forms.Label();
            this.comboWaveform = new System.Windows.Forms.ComboBox();
            this._label16 = new System.Windows.Forms.Label();
            this._label13 = new System.Windows.Forms.Label();
            this._label11 = new System.Windows.Forms.Label();
            this.numChannel1DC = new System.Windows.Forms.NumericUpDown();
            this._labelChannel1DC = new System.Windows.Forms.Label();
            this._label4 = new System.Windows.Forms.Label();
            this.numChannel1AC = new System.Windows.Forms.NumericUpDown();
            this._labelChannel1AC = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this.numChannel1PI = new System.Windows.Forms.NumericUpDown();
            this._labelREDPI = new System.Windows.Forms.Label();
            this.checkChannel1LockDC = new System.Windows.Forms.CheckBox();
            this.checkChannel1LockAC = new System.Windows.Forms.CheckBox();
            this.groupChannel1 = new System.Windows.Forms.GroupBox();
            this._label15 = new System.Windows.Forms.Label();
            this._label14 = new System.Windows.Forms.Label();
            this._label12 = new System.Windows.Forms.Label();
            this.numChannel2DC = new System.Windows.Forms.NumericUpDown();
            this._labelChannel2DC = new System.Windows.Forms.Label();
            this._label7 = new System.Windows.Forms.Label();
            this.numChannel2AC = new System.Windows.Forms.NumericUpDown();
            this._labelChannel2AC = new System.Windows.Forms.Label();
            this._label9 = new System.Windows.Forms.Label();
            this.numChannel2PI = new System.Windows.Forms.NumericUpDown();
            this._labelChannel2PI = new System.Windows.Forms.Label();
            this.checkChannel2LockDC = new System.Windows.Forms.CheckBox();
            this.checkChannel2LockAC = new System.Windows.Forms.CheckBox();
            this.groupChannel2 = new System.Windows.Forms.GroupBox();
            this.checkSignalSyncPluse = new System.Windows.Forms.CheckBox();
            this.numBPM = new System.Windows.Forms.NumericUpDown();
            this.labelPreviewBPM = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel1DC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel1AC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel1PI)).BeginInit();
            this.groupChannel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel2DC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel2AC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel2PI)).BeginInit();
            this.groupChannel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBPM)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWaveformType
            // 
            this.labelWaveformType.Location = new System.Drawing.Point(185, 5);
            this.labelWaveformType.Name = "labelWaveformType";
            this.labelWaveformType.Size = new System.Drawing.Size(72, 23);
            this.labelWaveformType.TabIndex = 43;
            this.labelWaveformType.Text = "Waveform";
            this.labelWaveformType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboWaveform
            // 
            this.comboWaveform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWaveform.DropDownWidth = 100;
            this.comboWaveform.FormattingEnabled = true;
            this.comboWaveform.Items.AddRange(new object[] {
            "Sine",
            "Triangle",
            "PPG"});
            this.comboWaveform.Location = new System.Drawing.Point(269, 5);
            this.comboWaveform.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboWaveform.Name = "comboWaveform";
            this.comboWaveform.Size = new System.Drawing.Size(93, 23);
            this.comboWaveform.TabIndex = 42;
            // 
            // _label16
            // 
            this._label16.Location = new System.Drawing.Point(483, 63);
            this._label16.Name = "_label16";
            this._label16.Size = new System.Drawing.Size(27, 23);
            this._label16.TabIndex = 56;
            this._label16.Text = "mV";
            this._label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label13
            // 
            this._label13.Location = new System.Drawing.Point(307, 63);
            this._label13.Name = "_label13";
            this._label13.Size = new System.Drawing.Size(27, 23);
            this._label13.TabIndex = 55;
            this._label13.Text = "mV";
            this._label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label11
            // 
            this._label11.Location = new System.Drawing.Point(139, 63);
            this._label11.Name = "_label11";
            this._label11.Size = new System.Drawing.Size(27, 23);
            this._label11.TabIndex = 54;
            this._label11.Text = "%";
            this._label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numChannel1DC
            // 
            this.numChannel1DC.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numChannel1DC.Location = new System.Drawing.Point(408, 63);
            this.numChannel1DC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numChannel1DC.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numChannel1DC.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numChannel1DC.Name = "numChannel1DC";
            this.numChannel1DC.Size = new System.Drawing.Size(69, 23);
            this.numChannel1DC.TabIndex = 53;
            this.numChannel1DC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChannel1DC.Value = new decimal(new int[] {
            625,
            0,
            0,
            0});
            this.numChannel1DC.ValueChanged += new System.EventHandler(this.onChannel1DCValueChanged);
            // 
            // _labelChannel1DC
            // 
            this._labelChannel1DC.Location = new System.Drawing.Point(374, 63);
            this._labelChannel1DC.Name = "_labelChannel1DC";
            this._labelChannel1DC.Size = new System.Drawing.Size(28, 23);
            this._labelChannel1DC.TabIndex = 52;
            this._labelChannel1DC.Text = "DC";
            this._labelChannel1DC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label4
            // 
            this._label4.Location = new System.Drawing.Point(345, 63);
            this._label4.Name = "_label4";
            this._label4.Size = new System.Drawing.Size(23, 23);
            this._label4.TabIndex = 51;
            this._label4.Text = "/";
            this._label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numChannel1AC
            // 
            this.numChannel1AC.DecimalPlaces = 2;
            this.numChannel1AC.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numChannel1AC.Location = new System.Drawing.Point(232, 63);
            this.numChannel1AC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numChannel1AC.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numChannel1AC.Minimum = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            this.numChannel1AC.Name = "numChannel1AC";
            this.numChannel1AC.Size = new System.Drawing.Size(69, 23);
            this.numChannel1AC.TabIndex = 50;
            this.numChannel1AC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChannel1AC.Value = new decimal(new int[] {
            125,
            0,
            0,
            65536});
            this.numChannel1AC.ValueChanged += new System.EventHandler(this.onChannel1ACValueChanged);
            // 
            // _labelChannel1AC
            // 
            this._labelChannel1AC.Location = new System.Drawing.Point(198, 63);
            this._labelChannel1AC.Name = "_labelChannel1AC";
            this._labelChannel1AC.Size = new System.Drawing.Size(28, 23);
            this._labelChannel1AC.TabIndex = 49;
            this._labelChannel1AC.Text = "AC";
            this._labelChannel1AC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label2
            // 
            this._label2.Location = new System.Drawing.Point(163, 63);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(29, 23);
            this._label2.TabIndex = 48;
            this._label2.Text = "=";
            this._label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numChannel1PI
            // 
            this.numChannel1PI.DecimalPlaces = 3;
            this.numChannel1PI.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numChannel1PI.Location = new System.Drawing.Point(64, 63);
            this.numChannel1PI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numChannel1PI.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numChannel1PI.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            this.numChannel1PI.Name = "numChannel1PI";
            this.numChannel1PI.Size = new System.Drawing.Size(69, 23);
            this.numChannel1PI.TabIndex = 47;
            this.numChannel1PI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChannel1PI.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numChannel1PI.ValueChanged += new System.EventHandler(this.onChannel1PIValueChanged);
            // 
            // _labelREDPI
            // 
            this._labelREDPI.Location = new System.Drawing.Point(27, 63);
            this._labelREDPI.Name = "_labelREDPI";
            this._labelREDPI.Size = new System.Drawing.Size(31, 23);
            this._labelREDPI.TabIndex = 46;
            this._labelREDPI.Text = "PI";
            this._labelREDPI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkChannel1LockDC
            // 
            this.checkChannel1LockDC.AutoSize = true;
            this.checkChannel1LockDC.Location = new System.Drawing.Point(379, 24);
            this.checkChannel1LockDC.Name = "checkChannel1LockDC";
            this.checkChannel1LockDC.Size = new System.Drawing.Size(70, 19);
            this.checkChannel1LockDC.TabIndex = 45;
            this.checkChannel1LockDC.Text = "Lock DC";
            this.checkChannel1LockDC.UseVisualStyleBackColor = true;
            this.checkChannel1LockDC.CheckedChanged += new System.EventHandler(this.onChannel1LockDCCheckedChanged);
            // 
            // checkChannel1LockAC
            // 
            this.checkChannel1LockAC.AutoSize = true;
            this.checkChannel1LockAC.Location = new System.Drawing.Point(203, 24);
            this.checkChannel1LockAC.Name = "checkChannel1LockAC";
            this.checkChannel1LockAC.Size = new System.Drawing.Size(70, 19);
            this.checkChannel1LockAC.TabIndex = 44;
            this.checkChannel1LockAC.Text = "Lock AC";
            this.checkChannel1LockAC.UseVisualStyleBackColor = true;
            this.checkChannel1LockAC.CheckedChanged += new System.EventHandler(this.onChannel1LockACCheckedChanged);
            // 
            // groupChannel1
            // 
            this.groupChannel1.Controls.Add(this._label16);
            this.groupChannel1.Controls.Add(this._label13);
            this.groupChannel1.Controls.Add(this._label11);
            this.groupChannel1.Controls.Add(this.numChannel1DC);
            this.groupChannel1.Controls.Add(this._labelChannel1DC);
            this.groupChannel1.Controls.Add(this._label4);
            this.groupChannel1.Controls.Add(this.numChannel1AC);
            this.groupChannel1.Controls.Add(this._labelChannel1AC);
            this.groupChannel1.Controls.Add(this._label2);
            this.groupChannel1.Controls.Add(this.numChannel1PI);
            this.groupChannel1.Controls.Add(this._labelREDPI);
            this.groupChannel1.Controls.Add(this.checkChannel1LockDC);
            this.groupChannel1.Controls.Add(this.checkChannel1LockAC);
            this.groupChannel1.Location = new System.Drawing.Point(32, 30);
            this.groupChannel1.Name = "groupChannel1";
            this.groupChannel1.Size = new System.Drawing.Size(566, 105);
            this.groupChannel1.TabIndex = 57;
            this.groupChannel1.TabStop = false;
            this.groupChannel1.Text = "RED";
            // 
            // _label15
            // 
            this._label15.Location = new System.Drawing.Point(483, 63);
            this._label15.Name = "_label15";
            this._label15.Size = new System.Drawing.Size(27, 23);
            this._label15.TabIndex = 70;
            this._label15.Text = "mV";
            this._label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label14
            // 
            this._label14.Location = new System.Drawing.Point(307, 63);
            this._label14.Name = "_label14";
            this._label14.Size = new System.Drawing.Size(27, 23);
            this._label14.TabIndex = 69;
            this._label14.Text = "mV";
            this._label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label12
            // 
            this._label12.Location = new System.Drawing.Point(139, 63);
            this._label12.Name = "_label12";
            this._label12.Size = new System.Drawing.Size(27, 23);
            this._label12.TabIndex = 68;
            this._label12.Text = "%";
            this._label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numChannel2DC
            // 
            this.numChannel2DC.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numChannel2DC.Location = new System.Drawing.Point(408, 63);
            this.numChannel2DC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numChannel2DC.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numChannel2DC.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numChannel2DC.Name = "numChannel2DC";
            this.numChannel2DC.Size = new System.Drawing.Size(69, 23);
            this.numChannel2DC.TabIndex = 67;
            this.numChannel2DC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChannel2DC.Value = new decimal(new int[] {
            625,
            0,
            0,
            0});
            this.numChannel2DC.ValueChanged += new System.EventHandler(this.onChannel2DCValueChanged);
            // 
            // _labelChannel2DC
            // 
            this._labelChannel2DC.Location = new System.Drawing.Point(374, 63);
            this._labelChannel2DC.Name = "_labelChannel2DC";
            this._labelChannel2DC.Size = new System.Drawing.Size(28, 23);
            this._labelChannel2DC.TabIndex = 66;
            this._labelChannel2DC.Text = "DC";
            this._labelChannel2DC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label7
            // 
            this._label7.Location = new System.Drawing.Point(345, 63);
            this._label7.Name = "_label7";
            this._label7.Size = new System.Drawing.Size(29, 23);
            this._label7.TabIndex = 65;
            this._label7.Text = "/";
            this._label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numChannel2AC
            // 
            this.numChannel2AC.DecimalPlaces = 2;
            this.numChannel2AC.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numChannel2AC.Location = new System.Drawing.Point(232, 63);
            this.numChannel2AC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numChannel2AC.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numChannel2AC.Minimum = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            this.numChannel2AC.Name = "numChannel2AC";
            this.numChannel2AC.Size = new System.Drawing.Size(69, 23);
            this.numChannel2AC.TabIndex = 64;
            this.numChannel2AC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChannel2AC.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numChannel2AC.ValueChanged += new System.EventHandler(this.onChannel2ACValueChanged);
            // 
            // _labelChannel2AC
            // 
            this._labelChannel2AC.Location = new System.Drawing.Point(198, 63);
            this._labelChannel2AC.Name = "_labelChannel2AC";
            this._labelChannel2AC.Size = new System.Drawing.Size(28, 23);
            this._labelChannel2AC.TabIndex = 63;
            this._labelChannel2AC.Text = "AC";
            this._labelChannel2AC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label9
            // 
            this._label9.Location = new System.Drawing.Point(163, 63);
            this._label9.Name = "_label9";
            this._label9.Size = new System.Drawing.Size(29, 23);
            this._label9.TabIndex = 62;
            this._label9.Text = "=";
            this._label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numChannel2PI
            // 
            this.numChannel2PI.DecimalPlaces = 3;
            this.numChannel2PI.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numChannel2PI.Location = new System.Drawing.Point(64, 63);
            this.numChannel2PI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numChannel2PI.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numChannel2PI.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            this.numChannel2PI.Name = "numChannel2PI";
            this.numChannel2PI.Size = new System.Drawing.Size(69, 23);
            this.numChannel2PI.TabIndex = 61;
            this.numChannel2PI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numChannel2PI.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numChannel2PI.ValueChanged += new System.EventHandler(this.onChannel2PIValueChanged);
            // 
            // _labelChannel2PI
            // 
            this._labelChannel2PI.Location = new System.Drawing.Point(27, 63);
            this._labelChannel2PI.Name = "_labelChannel2PI";
            this._labelChannel2PI.Size = new System.Drawing.Size(31, 23);
            this._labelChannel2PI.TabIndex = 60;
            this._labelChannel2PI.Text = "PI";
            this._labelChannel2PI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkChannel2LockDC
            // 
            this.checkChannel2LockDC.AutoSize = true;
            this.checkChannel2LockDC.Location = new System.Drawing.Point(379, 24);
            this.checkChannel2LockDC.Name = "checkChannel2LockDC";
            this.checkChannel2LockDC.Size = new System.Drawing.Size(70, 19);
            this.checkChannel2LockDC.TabIndex = 59;
            this.checkChannel2LockDC.Text = "Lock DC";
            this.checkChannel2LockDC.UseVisualStyleBackColor = true;
            this.checkChannel2LockDC.CheckedChanged += new System.EventHandler(this.onChannel2LockDCCheckedChanged);
            // 
            // checkChannel2LockAC
            // 
            this.checkChannel2LockAC.AutoSize = true;
            this.checkChannel2LockAC.Location = new System.Drawing.Point(203, 24);
            this.checkChannel2LockAC.Name = "checkChannel2LockAC";
            this.checkChannel2LockAC.Size = new System.Drawing.Size(70, 19);
            this.checkChannel2LockAC.TabIndex = 58;
            this.checkChannel2LockAC.Text = "Lock AC";
            this.checkChannel2LockAC.UseVisualStyleBackColor = true;
            this.checkChannel2LockAC.CheckedChanged += new System.EventHandler(this.onChannel2LockACCheckedChanged);
            // 
            // groupChannel2
            // 
            this.groupChannel2.Controls.Add(this._label15);
            this.groupChannel2.Controls.Add(this.checkChannel2LockAC);
            this.groupChannel2.Controls.Add(this._label9);
            this.groupChannel2.Controls.Add(this._label14);
            this.groupChannel2.Controls.Add(this.numChannel2PI);
            this.groupChannel2.Controls.Add(this._labelChannel2AC);
            this.groupChannel2.Controls.Add(this._label12);
            this.groupChannel2.Controls.Add(this._labelChannel2PI);
            this.groupChannel2.Controls.Add(this.numChannel2AC);
            this.groupChannel2.Controls.Add(this.numChannel2DC);
            this.groupChannel2.Controls.Add(this.checkChannel2LockDC);
            this.groupChannel2.Controls.Add(this._label7);
            this.groupChannel2.Controls.Add(this._labelChannel2DC);
            this.groupChannel2.Location = new System.Drawing.Point(32, 158);
            this.groupChannel2.Name = "groupChannel2";
            this.groupChannel2.Size = new System.Drawing.Size(566, 105);
            this.groupChannel2.TabIndex = 71;
            this.groupChannel2.TabStop = false;
            this.groupChannel2.Text = "Infrared";
            // 
            // checkSignalSyncPluse
            // 
            this.checkSignalSyncPluse.Location = new System.Drawing.Point(388, 3);
            this.checkSignalSyncPluse.Name = "checkSignalSyncPluse";
            this.checkSignalSyncPluse.Size = new System.Drawing.Size(132, 27);
            this.checkSignalSyncPluse.TabIndex = 72;
            this.checkSignalSyncPluse.Text = "Synchronized Pulse";
            this.checkSignalSyncPluse.UseVisualStyleBackColor = true;
            this.checkSignalSyncPluse.CheckedChanged += new System.EventHandler(this.onSyncCheckedChanged);
            // 
            // numBPM
            // 
            this.numBPM.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBPM.Location = new System.Drawing.Point(88, 5);
            this.numBPM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numBPM.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numBPM.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numBPM.Name = "numBPM";
            this.numBPM.Size = new System.Drawing.Size(70, 23);
            this.numBPM.TabIndex = 74;
            this.numBPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBPM.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numBPM.ValueChanged += new System.EventHandler(this.onBPMValueChanged);
            // 
            // labelPreviewBPM
            // 
            this.labelPreviewBPM.Location = new System.Drawing.Point(29, 5);
            this.labelPreviewBPM.Name = "labelPreviewBPM";
            this.labelPreviewBPM.Size = new System.Drawing.Size(54, 23);
            this.labelPreviewBPM.TabIndex = 73;
            this.labelPreviewBPM.Text = "BPM";
            this.labelPreviewBPM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SPO2Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numBPM);
            this.Controls.Add(this.labelPreviewBPM);
            this.Controls.Add(this.checkSignalSyncPluse);
            this.Controls.Add(this.groupChannel2);
            this.Controls.Add(this.groupChannel1);
            this.Controls.Add(this.labelWaveformType);
            this.Controls.Add(this.comboWaveform);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SPO2Page";
            this.Size = new System.Drawing.Size(647, 320);
            ((System.ComponentModel.ISupportInitialize)(this.numChannel1DC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel1AC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel1PI)).EndInit();
            this.groupChannel1.ResumeLayout(false);
            this.groupChannel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel2DC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel2AC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannel2PI)).EndInit();
            this.groupChannel2.ResumeLayout(false);
            this.groupChannel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBPM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWaveformType;
        private System.Windows.Forms.ComboBox comboWaveform;
        private System.Windows.Forms.Label _label16;
        private System.Windows.Forms.Label _label13;
        private System.Windows.Forms.Label _label11;
        private System.Windows.Forms.NumericUpDown numChannel1DC;
        private System.Windows.Forms.Label _labelChannel1DC;
        private System.Windows.Forms.Label _label4;
        private System.Windows.Forms.NumericUpDown numChannel1AC;
        private System.Windows.Forms.Label _labelChannel1AC;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.NumericUpDown numChannel1PI;
        private System.Windows.Forms.Label _labelREDPI;
        private System.Windows.Forms.CheckBox checkChannel1LockDC;
        private System.Windows.Forms.CheckBox checkChannel1LockAC;
        private System.Windows.Forms.GroupBox groupChannel1;
        private System.Windows.Forms.Label _label15;
        private System.Windows.Forms.Label _label14;
        private System.Windows.Forms.Label _label12;
        private System.Windows.Forms.NumericUpDown numChannel2DC;
        private System.Windows.Forms.Label _labelChannel2DC;
        private System.Windows.Forms.Label _label7;
        private System.Windows.Forms.NumericUpDown numChannel2AC;
        private System.Windows.Forms.Label _labelChannel2AC;
        private System.Windows.Forms.Label _label9;
        private System.Windows.Forms.NumericUpDown numChannel2PI;
        private System.Windows.Forms.Label _labelChannel2PI;
        private System.Windows.Forms.CheckBox checkChannel2LockDC;
        private System.Windows.Forms.CheckBox checkChannel2LockAC;
        private System.Windows.Forms.GroupBox groupChannel2;
        private System.Windows.Forms.CheckBox checkSignalSyncPluse;
        private System.Windows.Forms.NumericUpDown numBPM;
        private System.Windows.Forms.Label labelPreviewBPM;
    }
}
