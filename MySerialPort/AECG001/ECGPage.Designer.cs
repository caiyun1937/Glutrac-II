namespace AECG100Demo
{
    partial class ECGPage
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
            this._label31 = new System.Windows.Forms.Label();
            this.numVoltageRWave = new System.Windows.Forms.NumericUpDown();
            this.labelVolRWave = new System.Windows.Forms.Label();
            this._label6 = new System.Windows.Forms.Label();
            this.numVoltageSTSegment = new System.Windows.Forms.NumericUpDown();
            this.labelVolSTSegment = new System.Windows.Forms.Label();
            this._label4 = new System.Windows.Forms.Label();
            this.numVoltagePWave = new System.Windows.Forms.NumericUpDown();
            this.labelVolPWave = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this._label1 = new System.Windows.Forms.Label();
            this.numVoltageTWave = new System.Windows.Forms.NumericUpDown();
            this.numVoltageAmplitude = new System.Windows.Forms.NumericUpDown();
            this.labelVolTWave = new System.Windows.Forms.Label();
            this.labelVolAmplitude = new System.Windows.Forms.Label();
            this.numVoltageAmplitude2 = new System.Windows.Forms.NumericUpDown();
            this.groupVoltage = new System.Windows.Forms.GroupBox();
            this._radioElectrodeLeftArm = new System.Windows.Forms.RadioButton();
            this._radioElectrodeRightArm = new System.Windows.Forms.RadioButton();
            this._label23 = new System.Windows.Forms.Label();
            this.numWaveformPulseWidth = new System.Windows.Forms.NumericUpDown();
            this.comboWaveform = new System.Windows.Forms.ComboBox();
            this.labelPulseWidth = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numTimeQTInterval = new System.Windows.Forms.NumericUpDown();
            this.labelTimeQTInterval = new System.Windows.Forms.Label();
            this._label10 = new System.Windows.Forms.Label();
            this.numTimePRInterval = new System.Windows.Forms.NumericUpDown();
            this.labelTimePRInterval = new System.Windows.Forms.Label();
            this._label8 = new System.Windows.Forms.Label();
            this._label3 = new System.Windows.Forms.Label();
            this.labelTimeQRSDuration = new System.Windows.Forms.Label();
            this.numTimeQRSDuration = new System.Windows.Forms.NumericUpDown();
            this.groupTime = new System.Windows.Forms.GroupBox();
            this.checkDCOffsetVariable = new System.Windows.Forms.CheckBox();
            this._label16 = new System.Windows.Forms.Label();
            this.numDCOffset = new System.Windows.Forms.NumericUpDown();
            this.labelDCOffset = new System.Windows.Forms.Label();
            this.groupDCOffset = new System.Windows.Forms.GroupBox();
            this.checkImpedanceTest = new System.Windows.Forms.CheckBox();
            this.groupImpedance = new System.Windows.Forms.GroupBox();
            this.numBPM = new System.Windows.Forms.NumericUpDown();
            this.labelPreviewBPM = new System.Windows.Forms.Label();
            this.groupElectrode = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageRWave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageSTSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltagePWave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageTWave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageAmplitude2)).BeginInit();
            this.groupVoltage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWaveformPulseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeQTInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimePRInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeQRSDuration)).BeginInit();
            this.groupTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDCOffset)).BeginInit();
            this.groupDCOffset.SuspendLayout();
            this.groupImpedance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBPM)).BeginInit();
            this.groupElectrode.SuspendLayout();
            this.SuspendLayout();
            // 
            // _label31
            // 
            this._label31.Location = new System.Drawing.Point(199, 49);
            this._label31.Name = "_label31";
            this._label31.Size = new System.Drawing.Size(27, 23);
            this._label31.TabIndex = 44;
            this._label31.Text = "mV";
            this._label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numVoltageRWave
            // 
            this.numVoltageRWave.DecimalPlaces = 2;
            this.numVoltageRWave.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numVoltageRWave.Location = new System.Drawing.Point(113, 49);
            this.numVoltageRWave.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            65536});
            this.numVoltageRWave.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147418112});
            this.numVoltageRWave.Name = "numVoltageRWave";
            this.numVoltageRWave.Size = new System.Drawing.Size(80, 27);
            this.numVoltageRWave.TabIndex = 43;
            this.numVoltageRWave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numVoltageRWave.Value = new decimal(new int[] {
            875,
            0,
            0,
            196608});
            this.numVoltageRWave.ValueChanged += new System.EventHandler(this.onVoltageRWaveValueChanged);
            // 
            // labelVolRWave
            // 
            this.labelVolRWave.Location = new System.Drawing.Point(17, 49);
            this.labelVolRWave.Name = "labelVolRWave";
            this.labelVolRWave.Size = new System.Drawing.Size(90, 23);
            this.labelVolRWave.TabIndex = 42;
            this.labelVolRWave.Text = "R Wave";
            this.labelVolRWave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _label6
            // 
            this._label6.Location = new System.Drawing.Point(199, 139);
            this._label6.Name = "_label6";
            this._label6.Size = new System.Drawing.Size(27, 23);
            this._label6.TabIndex = 41;
            this._label6.Text = "mV";
            this._label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numVoltageSTSegment
            // 
            this.numVoltageSTSegment.DecimalPlaces = 2;
            this.numVoltageSTSegment.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numVoltageSTSegment.Location = new System.Drawing.Point(113, 139);
            this.numVoltageSTSegment.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVoltageSTSegment.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numVoltageSTSegment.Name = "numVoltageSTSegment";
            this.numVoltageSTSegment.Size = new System.Drawing.Size(80, 27);
            this.numVoltageSTSegment.TabIndex = 40;
            this.numVoltageSTSegment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numVoltageSTSegment.ValueChanged += new System.EventHandler(this.onVoltageSTSegmentValueChanged);
            // 
            // labelVolSTSegment
            // 
            this.labelVolSTSegment.Location = new System.Drawing.Point(17, 139);
            this.labelVolSTSegment.Name = "labelVolSTSegment";
            this.labelVolSTSegment.Size = new System.Drawing.Size(90, 23);
            this.labelVolSTSegment.TabIndex = 39;
            this.labelVolSTSegment.Text = "ST Segment";
            this.labelVolSTSegment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _label4
            // 
            this._label4.Location = new System.Drawing.Point(199, 109);
            this._label4.Name = "_label4";
            this._label4.Size = new System.Drawing.Size(27, 23);
            this._label4.TabIndex = 38;
            this._label4.Text = "mV";
            this._label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numVoltagePWave
            // 
            this.numVoltagePWave.DecimalPlaces = 2;
            this.numVoltagePWave.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numVoltagePWave.Location = new System.Drawing.Point(113, 109);
            this.numVoltagePWave.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVoltagePWave.Name = "numVoltagePWave";
            this.numVoltagePWave.Size = new System.Drawing.Size(80, 27);
            this.numVoltagePWave.TabIndex = 37;
            this.numVoltagePWave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numVoltagePWave.Value = new decimal(new int[] {
            20,
            0,
            0,
            131072});
            this.numVoltagePWave.ValueChanged += new System.EventHandler(this.onVoltagePWaveValueChanged);
            // 
            // labelVolPWave
            // 
            this.labelVolPWave.Location = new System.Drawing.Point(17, 109);
            this.labelVolPWave.Name = "labelVolPWave";
            this.labelVolPWave.Size = new System.Drawing.Size(90, 23);
            this.labelVolPWave.TabIndex = 36;
            this.labelVolPWave.Text = "P Wave";
            this.labelVolPWave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _label2
            // 
            this._label2.Location = new System.Drawing.Point(199, 79);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(27, 23);
            this._label2.TabIndex = 35;
            this._label2.Text = "mV";
            this._label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label1
            // 
            this._label1.Location = new System.Drawing.Point(199, 19);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(27, 23);
            this._label1.TabIndex = 32;
            this._label1.Text = "mV";
            this._label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numVoltageTWave
            // 
            this.numVoltageTWave.DecimalPlaces = 2;
            this.numVoltageTWave.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numVoltageTWave.Location = new System.Drawing.Point(113, 79);
            this.numVoltageTWave.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numVoltageTWave.Name = "numVoltageTWave";
            this.numVoltageTWave.Size = new System.Drawing.Size(80, 27);
            this.numVoltageTWave.TabIndex = 34;
            this.numVoltageTWave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numVoltageTWave.Value = new decimal(new int[] {
            20,
            0,
            0,
            131072});
            this.numVoltageTWave.ValueChanged += new System.EventHandler(this.onVoltageTWaveValueChanged);
            // 
            // numVoltageAmplitude
            // 
            this.numVoltageAmplitude.DecimalPlaces = 2;
            this.numVoltageAmplitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numVoltageAmplitude.Location = new System.Drawing.Point(113, 19);
            this.numVoltageAmplitude.Maximum = new decimal(new int[] {
            571,
            0,
            0,
            131072});
            this.numVoltageAmplitude.Minimum = new decimal(new int[] {
            571,
            0,
            0,
            -2147352576});
            this.numVoltageAmplitude.Name = "numVoltageAmplitude";
            this.numVoltageAmplitude.Size = new System.Drawing.Size(80, 27);
            this.numVoltageAmplitude.TabIndex = 31;
            this.numVoltageAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numVoltageAmplitude.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.numVoltageAmplitude.ValueChanged += new System.EventHandler(this.onVoltageAmplitudeValueChanged);
            // 
            // labelVolTWave
            // 
            this.labelVolTWave.Location = new System.Drawing.Point(17, 79);
            this.labelVolTWave.Name = "labelVolTWave";
            this.labelVolTWave.Size = new System.Drawing.Size(90, 23);
            this.labelVolTWave.TabIndex = 33;
            this.labelVolTWave.Text = "T Wave";
            this.labelVolTWave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVolAmplitude
            // 
            this.labelVolAmplitude.Location = new System.Drawing.Point(17, 19);
            this.labelVolAmplitude.Name = "labelVolAmplitude";
            this.labelVolAmplitude.Size = new System.Drawing.Size(90, 23);
            this.labelVolAmplitude.TabIndex = 30;
            this.labelVolAmplitude.Text = "Amplitude";
            this.labelVolAmplitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numVoltageAmplitude2
            // 
            this.numVoltageAmplitude2.DecimalPlaces = 2;
            this.numVoltageAmplitude2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numVoltageAmplitude2.Location = new System.Drawing.Point(113, 19);
            this.numVoltageAmplitude2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numVoltageAmplitude2.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numVoltageAmplitude2.Name = "numVoltageAmplitude2";
            this.numVoltageAmplitude2.Size = new System.Drawing.Size(80, 27);
            this.numVoltageAmplitude2.TabIndex = 45;
            this.numVoltageAmplitude2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numVoltageAmplitude2.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.numVoltageAmplitude2.Visible = false;
            this.numVoltageAmplitude2.ValueChanged += new System.EventHandler(this.onVoltageAmplitude2ValueChanged);
            // 
            // groupVoltage
            // 
            this.groupVoltage.Controls.Add(this.numVoltageAmplitude2);
            this.groupVoltage.Controls.Add(this.labelVolAmplitude);
            this.groupVoltage.Controls.Add(this._label31);
            this.groupVoltage.Controls.Add(this.numVoltageRWave);
            this.groupVoltage.Controls.Add(this.labelVolTWave);
            this.groupVoltage.Controls.Add(this.labelVolRWave);
            this.groupVoltage.Controls.Add(this.numVoltageAmplitude);
            this.groupVoltage.Controls.Add(this._label6);
            this.groupVoltage.Controls.Add(this.numVoltageTWave);
            this.groupVoltage.Controls.Add(this.numVoltageSTSegment);
            this.groupVoltage.Controls.Add(this._label1);
            this.groupVoltage.Controls.Add(this.labelVolSTSegment);
            this.groupVoltage.Controls.Add(this._label2);
            this.groupVoltage.Controls.Add(this._label4);
            this.groupVoltage.Controls.Add(this.labelVolPWave);
            this.groupVoltage.Controls.Add(this.numVoltagePWave);
            this.groupVoltage.Location = new System.Drawing.Point(20, 112);
            this.groupVoltage.Name = "groupVoltage";
            this.groupVoltage.Size = new System.Drawing.Size(243, 178);
            this.groupVoltage.TabIndex = 46;
            this.groupVoltage.TabStop = false;
            this.groupVoltage.Text = "Voltage";
            // 
            // _radioElectrodeLeftArm
            // 
            this._radioElectrodeLeftArm.AutoSize = true;
            this._radioElectrodeLeftArm.Location = new System.Drawing.Point(31, 47);
            this._radioElectrodeLeftArm.Name = "_radioElectrodeLeftArm";
            this._radioElectrodeLeftArm.Size = new System.Drawing.Size(60, 24);
            this._radioElectrodeLeftArm.TabIndex = 52;
            this._radioElectrodeLeftArm.Text = "LA/L";
            this._radioElectrodeLeftArm.UseVisualStyleBackColor = true;
            // 
            // _radioElectrodeRightArm
            // 
            this._radioElectrodeRightArm.AutoSize = true;
            this._radioElectrodeRightArm.Location = new System.Drawing.Point(31, 19);
            this._radioElectrodeRightArm.Name = "_radioElectrodeRightArm";
            this._radioElectrodeRightArm.Size = new System.Drawing.Size(64, 24);
            this._radioElectrodeRightArm.TabIndex = 53;
            this._radioElectrodeRightArm.Text = "RA/R";
            this._radioElectrodeRightArm.UseVisualStyleBackColor = true;
            this._radioElectrodeRightArm.CheckedChanged += new System.EventHandler(this.onElectrodeCheckedChanged);
            // 
            // _label23
            // 
            this._label23.Location = new System.Drawing.Point(541, 5);
            this._label23.Name = "_label23";
            this._label23.Size = new System.Drawing.Size(27, 23);
            this._label23.TabIndex = 51;
            this._label23.Text = "ms";
            this._label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numWaveformPulseWidth
            // 
            this.numWaveformPulseWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWaveformPulseWidth.Location = new System.Drawing.Point(455, 5);
            this.numWaveformPulseWidth.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numWaveformPulseWidth.Name = "numWaveformPulseWidth";
            this.numWaveformPulseWidth.Size = new System.Drawing.Size(80, 27);
            this.numWaveformPulseWidth.TabIndex = 50;
            this.numWaveformPulseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWaveformPulseWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // comboWaveform
            // 
            this.comboWaveform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWaveform.DropDownWidth = 100;
            this.comboWaveform.FormattingEnabled = true;
            this.comboWaveform.Items.AddRange(new object[] {
            "Sine",
            "Triangle",
            "Square",
            "Rectangle Pulse",
            "Triangle Pulse",
            "Exponential",
            "ECG"});
            this.comboWaveform.Location = new System.Drawing.Point(269, 5);
            this.comboWaveform.Name = "comboWaveform";
            this.comboWaveform.Size = new System.Drawing.Size(93, 28);
            this.comboWaveform.TabIndex = 47;
            this.comboWaveform.SelectedIndexChanged += new System.EventHandler(this.onWaveformSelectedIndexChanged);
            // 
            // labelPulseWidth
            // 
            this.labelPulseWidth.Location = new System.Drawing.Point(379, 5);
            this.labelPulseWidth.Name = "labelPulseWidth";
            this.labelPulseWidth.Size = new System.Drawing.Size(70, 23);
            this.labelPulseWidth.TabIndex = 49;
            this.labelPulseWidth.Text = "Pulse Width";
            this.labelPulseWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(185, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 54;
            this.label1.Text = "Waveform";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numTimeQTInterval
            // 
            this.numTimeQTInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTimeQTInterval.Location = new System.Drawing.Point(112, 104);
            this.numTimeQTInterval.Maximum = new decimal(new int[] {
            450,
            0,
            0,
            0});
            this.numTimeQTInterval.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTimeQTInterval.Name = "numTimeQTInterval";
            this.numTimeQTInterval.Size = new System.Drawing.Size(80, 27);
            this.numTimeQTInterval.TabIndex = 63;
            this.numTimeQTInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTimeQTInterval.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numTimeQTInterval.ValueChanged += new System.EventHandler(this.onTimeQTValueChanged);
            // 
            // labelTimeQTInterval
            // 
            this.labelTimeQTInterval.Location = new System.Drawing.Point(17, 104);
            this.labelTimeQTInterval.Name = "labelTimeQTInterval";
            this.labelTimeQTInterval.Size = new System.Drawing.Size(89, 23);
            this.labelTimeQTInterval.TabIndex = 62;
            this.labelTimeQTInterval.Text = "QT Interval";
            this.labelTimeQTInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _label10
            // 
            this._label10.Location = new System.Drawing.Point(198, 104);
            this._label10.Name = "_label10";
            this._label10.Size = new System.Drawing.Size(27, 23);
            this._label10.TabIndex = 61;
            this._label10.Text = "ms";
            this._label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTimePRInterval
            // 
            this.numTimePRInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTimePRInterval.Location = new System.Drawing.Point(112, 19);
            this.numTimePRInterval.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numTimePRInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTimePRInterval.Name = "numTimePRInterval";
            this.numTimePRInterval.Size = new System.Drawing.Size(80, 27);
            this.numTimePRInterval.TabIndex = 60;
            this.numTimePRInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTimePRInterval.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.numTimePRInterval.ValueChanged += new System.EventHandler(this.onTimePRValueChanged);
            // 
            // labelTimePRInterval
            // 
            this.labelTimePRInterval.Location = new System.Drawing.Point(17, 19);
            this.labelTimePRInterval.Name = "labelTimePRInterval";
            this.labelTimePRInterval.Size = new System.Drawing.Size(89, 23);
            this.labelTimePRInterval.TabIndex = 59;
            this.labelTimePRInterval.Text = "PR Interval";
            this.labelTimePRInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _label8
            // 
            this._label8.Location = new System.Drawing.Point(198, 59);
            this._label8.Name = "_label8";
            this._label8.Size = new System.Drawing.Size(27, 23);
            this._label8.TabIndex = 58;
            this._label8.Text = "ms";
            this._label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label3
            // 
            this._label3.Location = new System.Drawing.Point(198, 19);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(27, 23);
            this._label3.TabIndex = 57;
            this._label3.Text = "ms";
            this._label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTimeQRSDuration
            // 
            this.labelTimeQRSDuration.Location = new System.Drawing.Point(17, 59);
            this.labelTimeQRSDuration.Name = "labelTimeQRSDuration";
            this.labelTimeQRSDuration.Size = new System.Drawing.Size(89, 23);
            this.labelTimeQRSDuration.TabIndex = 55;
            this.labelTimeQRSDuration.Text = "QRS Duration";
            this.labelTimeQRSDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numTimeQRSDuration
            // 
            this.numTimeQRSDuration.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTimeQRSDuration.Location = new System.Drawing.Point(112, 59);
            this.numTimeQRSDuration.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numTimeQRSDuration.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTimeQRSDuration.Name = "numTimeQRSDuration";
            this.numTimeQRSDuration.Size = new System.Drawing.Size(80, 27);
            this.numTimeQRSDuration.TabIndex = 56;
            this.numTimeQRSDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTimeQRSDuration.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTimeQRSDuration.ValueChanged += new System.EventHandler(this.onTimeQRSValueChanged);
            // 
            // groupTime
            // 
            this.groupTime.Controls.Add(this.labelTimePRInterval);
            this.groupTime.Controls.Add(this.numTimeQTInterval);
            this.groupTime.Controls.Add(this.numTimeQRSDuration);
            this.groupTime.Controls.Add(this.labelTimeQTInterval);
            this.groupTime.Controls.Add(this.labelTimeQRSDuration);
            this.groupTime.Controls.Add(this._label10);
            this.groupTime.Controls.Add(this._label3);
            this.groupTime.Controls.Add(this.numTimePRInterval);
            this.groupTime.Controls.Add(this._label8);
            this.groupTime.Location = new System.Drawing.Point(266, 112);
            this.groupTime.Name = "groupTime";
            this.groupTime.Size = new System.Drawing.Size(243, 147);
            this.groupTime.TabIndex = 64;
            this.groupTime.TabStop = false;
            this.groupTime.Text = "Time";
            // 
            // checkDCOffsetVariable
            // 
            this.checkDCOffsetVariable.AutoSize = true;
            this.checkDCOffsetVariable.Location = new System.Drawing.Point(30, 52);
            this.checkDCOffsetVariable.Name = "checkDCOffsetVariable";
            this.checkDCOffsetVariable.Size = new System.Drawing.Size(85, 24);
            this.checkDCOffsetVariable.TabIndex = 69;
            this.checkDCOffsetVariable.Text = "Variable";
            this.checkDCOffsetVariable.UseVisualStyleBackColor = true;
            // 
            // _label16
            // 
            this._label16.Location = new System.Drawing.Point(149, 19);
            this._label16.Name = "_label16";
            this._label16.Size = new System.Drawing.Size(25, 23);
            this._label16.TabIndex = 68;
            this._label16.Text = "mV";
            this._label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numDCOffset
            // 
            this.numDCOffset.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDCOffset.Location = new System.Drawing.Point(63, 19);
            this.numDCOffset.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDCOffset.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numDCOffset.Name = "numDCOffset";
            this.numDCOffset.Size = new System.Drawing.Size(80, 27);
            this.numDCOffset.TabIndex = 67;
            this.numDCOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDCOffset.ValueChanged += new System.EventHandler(this.onDCOffsetValueChanged);
            // 
            // labelDCOffset
            // 
            this.labelDCOffset.Location = new System.Drawing.Point(17, 19);
            this.labelDCOffset.Name = "labelDCOffset";
            this.labelDCOffset.Size = new System.Drawing.Size(40, 23);
            this.labelDCOffset.TabIndex = 66;
            this.labelDCOffset.Text = "Offset";
            this.labelDCOffset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupDCOffset
            // 
            this.groupDCOffset.Controls.Add(this.labelDCOffset);
            this.groupDCOffset.Controls.Add(this.checkDCOffsetVariable);
            this.groupDCOffset.Controls.Add(this.numDCOffset);
            this.groupDCOffset.Controls.Add(this._label16);
            this.groupDCOffset.Location = new System.Drawing.Point(266, 30);
            this.groupDCOffset.Name = "groupDCOffset";
            this.groupDCOffset.Size = new System.Drawing.Size(243, 80);
            this.groupDCOffset.TabIndex = 70;
            this.groupDCOffset.TabStop = false;
            this.groupDCOffset.Text = "DC Offset";
            // 
            // checkImpedanceTest
            // 
            this.checkImpedanceTest.AutoSize = true;
            this.checkImpedanceTest.Location = new System.Drawing.Point(17, 19);
            this.checkImpedanceTest.Name = "checkImpedanceTest";
            this.checkImpedanceTest.Size = new System.Drawing.Size(204, 24);
            this.checkImpedanceTest.TabIndex = 71;
            this.checkImpedanceTest.Text = "620kΩ/4.7nF (on=shorted)";
            this.checkImpedanceTest.UseVisualStyleBackColor = true;
            this.checkImpedanceTest.CheckedChanged += new System.EventHandler(this.onImpedanceTestCheckedChanged);
            // 
            // groupImpedance
            // 
            this.groupImpedance.Controls.Add(this.checkImpedanceTest);
            this.groupImpedance.Location = new System.Drawing.Point(511, 30);
            this.groupImpedance.Name = "groupImpedance";
            this.groupImpedance.Size = new System.Drawing.Size(200, 43);
            this.groupImpedance.TabIndex = 72;
            this.groupImpedance.TabStop = false;
            this.groupImpedance.Text = "Input Impedance";
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
            30000,
            0,
            0,
            0});
            this.numBPM.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numBPM.Name = "numBPM";
            this.numBPM.Size = new System.Drawing.Size(70, 27);
            this.numBPM.TabIndex = 74;
            this.numBPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBPM.Value = new decimal(new int[] {
            80,
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
            // groupElectrode
            // 
            this.groupElectrode.Controls.Add(this._radioElectrodeRightArm);
            this.groupElectrode.Controls.Add(this._radioElectrodeLeftArm);
            this.groupElectrode.Location = new System.Drawing.Point(20, 30);
            this.groupElectrode.Name = "groupElectrode";
            this.groupElectrode.Size = new System.Drawing.Size(244, 81);
            this.groupElectrode.TabIndex = 75;
            this.groupElectrode.TabStop = false;
            this.groupElectrode.Text = "Electrode";
            // 
            // ECGPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupElectrode);
            this.Controls.Add(this.numBPM);
            this.Controls.Add(this.labelPreviewBPM);
            this.Controls.Add(this.groupImpedance);
            this.Controls.Add(this.groupDCOffset);
            this.Controls.Add(this.groupTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._label23);
            this.Controls.Add(this.numWaveformPulseWidth);
            this.Controls.Add(this.comboWaveform);
            this.Controls.Add(this.labelPulseWidth);
            this.Controls.Add(this.groupVoltage);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ECGPage";
            this.Size = new System.Drawing.Size(720, 380);
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageRWave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageSTSegment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltagePWave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageTWave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVoltageAmplitude2)).EndInit();
            this.groupVoltage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWaveformPulseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeQTInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimePRInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeQRSDuration)).EndInit();
            this.groupTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDCOffset)).EndInit();
            this.groupDCOffset.ResumeLayout(false);
            this.groupDCOffset.PerformLayout();
            this.groupImpedance.ResumeLayout(false);
            this.groupImpedance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBPM)).EndInit();
            this.groupElectrode.ResumeLayout(false);
            this.groupElectrode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _label31;
        private System.Windows.Forms.NumericUpDown numVoltageRWave;
        private System.Windows.Forms.Label labelVolRWave;
        private System.Windows.Forms.Label _label6;
        private System.Windows.Forms.NumericUpDown numVoltageSTSegment;
        private System.Windows.Forms.Label labelVolSTSegment;
        private System.Windows.Forms.Label _label4;
        private System.Windows.Forms.NumericUpDown numVoltagePWave;
        private System.Windows.Forms.Label labelVolPWave;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.NumericUpDown numVoltageTWave;
        private System.Windows.Forms.NumericUpDown numVoltageAmplitude;
        private System.Windows.Forms.Label labelVolTWave;
        private System.Windows.Forms.Label labelVolAmplitude;
        private System.Windows.Forms.NumericUpDown numVoltageAmplitude2;
        private System.Windows.Forms.GroupBox groupVoltage;
        private System.Windows.Forms.RadioButton _radioElectrodeLeftArm;
        private System.Windows.Forms.RadioButton _radioElectrodeRightArm;
        private System.Windows.Forms.Label _label23;
        private System.Windows.Forms.NumericUpDown numWaveformPulseWidth;
        private System.Windows.Forms.ComboBox comboWaveform;
        private System.Windows.Forms.Label labelPulseWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numTimeQTInterval;
        private System.Windows.Forms.Label labelTimeQTInterval;
        private System.Windows.Forms.Label _label10;
        private System.Windows.Forms.NumericUpDown numTimePRInterval;
        private System.Windows.Forms.Label labelTimePRInterval;
        private System.Windows.Forms.Label _label8;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.Label labelTimeQRSDuration;
        private System.Windows.Forms.NumericUpDown numTimeQRSDuration;
        private System.Windows.Forms.GroupBox groupTime;
        private System.Windows.Forms.CheckBox checkDCOffsetVariable;
        private System.Windows.Forms.Label _label16;
        private System.Windows.Forms.NumericUpDown numDCOffset;
        private System.Windows.Forms.Label labelDCOffset;
        private System.Windows.Forms.GroupBox groupDCOffset;
        private System.Windows.Forms.CheckBox checkImpedanceTest;
        private System.Windows.Forms.GroupBox groupImpedance;
        private System.Windows.Forms.Label labelPreviewBPM;
        private System.Windows.Forms.GroupBox groupElectrode;
        public System.Windows.Forms.NumericUpDown numBPM;
    }
}
