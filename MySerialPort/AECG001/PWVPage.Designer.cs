namespace AECG100Demo
{
    partial class PWVPage
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
            this.numECGBPM = new System.Windows.Forms.NumericUpDown();
            this.labelECGBPM = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this._label1 = new System.Windows.Forms.Label();
            this.numECGTWave = new System.Windows.Forms.NumericUpDown();
            this.numECGAmplitude = new System.Windows.Forms.NumericUpDown();
            this.labelECGTWave = new System.Windows.Forms.Label();
            this.labelECGAmplitude = new System.Windows.Forms.Label();
            this._label3 = new System.Windows.Forms.Label();
            this.numECGQRSDuration = new System.Windows.Forms.NumericUpDown();
            this.labelECGQRSDuration = new System.Windows.Forms.Label();
            this.groupECG = new System.Windows.Forms.GroupBox();
            this.checkPPGLockAC = new System.Windows.Forms.CheckBox();
            this.checkPPGLockDC = new System.Windows.Forms.CheckBox();
            this._label6 = new System.Windows.Forms.Label();
            this._label5 = new System.Windows.Forms.Label();
            this.numPPGAC = new System.Windows.Forms.NumericUpDown();
            this.labelPPGVolAC = new System.Windows.Forms.Label();
            this._label11 = new System.Windows.Forms.Label();
            this.numPPGDC = new System.Windows.Forms.NumericUpDown();
            this.labelPPGDC = new System.Windows.Forms.Label();
            this.numPPGBPM = new System.Windows.Forms.NumericUpDown();
            this.numPPGPI = new System.Windows.Forms.NumericUpDown();
            this.labelPPGPI = new System.Windows.Forms.Label();
            this.labelPPGBPM = new System.Windows.Forms.Label();
            this.groupPPG = new System.Windows.Forms.GroupBox();
            this._label10 = new System.Windows.Forms.Label();
            this.numTimeDiffF = new System.Windows.Forms.NumericUpDown();
            this.labelTimeDiffF = new System.Windows.Forms.Label();
            this._label8 = new System.Windows.Forms.Label();
            this.numTimeDiffP = new System.Windows.Forms.NumericUpDown();
            this.labelTimeDiffP = new System.Windows.Forms.Label();
            this.groupTimeDifference = new System.Windows.Forms.GroupBox();
            this.checkSignalSynPluse = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numECGBPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numECGTWave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numECGAmplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numECGQRSDuration)).BeginInit();
            this.groupECG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPPGAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPPGDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPPGBPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPPGPI)).BeginInit();
            this.groupPPG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeDiffF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeDiffP)).BeginInit();
            this.groupTimeDifference.SuspendLayout();
            this.SuspendLayout();
            // 
            // numECGBPM
            // 
            this.numECGBPM.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numECGBPM.Location = new System.Drawing.Point(108, 19);
            this.numECGBPM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numECGBPM.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numECGBPM.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numECGBPM.Name = "numECGBPM";
            this.numECGBPM.Size = new System.Drawing.Size(80, 23);
            this.numECGBPM.TabIndex = 14;
            this.numECGBPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numECGBPM.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numECGBPM.ValueChanged += new System.EventHandler(this.onECGBPMValueChanged);
            // 
            // labelECGBPM
            // 
            this.labelECGBPM.Location = new System.Drawing.Point(49, 19);
            this.labelECGBPM.Name = "labelECGBPM";
            this.labelECGBPM.Size = new System.Drawing.Size(54, 23);
            this.labelECGBPM.TabIndex = 13;
            this.labelECGBPM.Text = "BPM";
            this.labelECGBPM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _label2
            // 
            this._label2.Location = new System.Drawing.Point(194, 79);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(27, 23);
            this._label2.TabIndex = 20;
            this._label2.Text = "mV";
            this._label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label1
            // 
            this._label1.Location = new System.Drawing.Point(194, 49);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(27, 23);
            this._label1.TabIndex = 17;
            this._label1.Text = "mV";
            this._label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numECGTWave
            // 
            this.numECGTWave.DecimalPlaces = 2;
            this.numECGTWave.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numECGTWave.Location = new System.Drawing.Point(108, 79);
            this.numECGTWave.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numECGTWave.Name = "numECGTWave";
            this.numECGTWave.Size = new System.Drawing.Size(80, 23);
            this.numECGTWave.TabIndex = 19;
            this.numECGTWave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numECGTWave.Value = new decimal(new int[] {
            20,
            0,
            0,
            131072});
            this.numECGTWave.ValueChanged += new System.EventHandler(this.onECGValueChanged);
            // 
            // numECGAmplitude
            // 
            this.numECGAmplitude.DecimalPlaces = 2;
            this.numECGAmplitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numECGAmplitude.Location = new System.Drawing.Point(108, 49);
            this.numECGAmplitude.Maximum = new decimal(new int[] {
            571429,
            0,
            0,
            327680});
            this.numECGAmplitude.Name = "numECGAmplitude";
            this.numECGAmplitude.Size = new System.Drawing.Size(80, 23);
            this.numECGAmplitude.TabIndex = 16;
            this.numECGAmplitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numECGAmplitude.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.numECGAmplitude.ValueChanged += new System.EventHandler(this.onECGValueChanged);
            // 
            // labelECGTWave
            // 
            this.labelECGTWave.Location = new System.Drawing.Point(17, 79);
            this.labelECGTWave.Name = "labelECGTWave";
            this.labelECGTWave.Size = new System.Drawing.Size(85, 23);
            this.labelECGTWave.TabIndex = 18;
            this.labelECGTWave.Text = "T Wave";
            this.labelECGTWave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelECGAmplitude
            // 
            this.labelECGAmplitude.Location = new System.Drawing.Point(17, 49);
            this.labelECGAmplitude.Name = "labelECGAmplitude";
            this.labelECGAmplitude.Size = new System.Drawing.Size(85, 23);
            this.labelECGAmplitude.TabIndex = 15;
            this.labelECGAmplitude.Text = "Amplitude";
            this.labelECGAmplitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _label3
            // 
            this._label3.Location = new System.Drawing.Point(194, 109);
            this._label3.Name = "_label3";
            this._label3.Size = new System.Drawing.Size(27, 23);
            this._label3.TabIndex = 24;
            this._label3.Text = "ms";
            this._label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numECGQRSDuration
            // 
            this.numECGQRSDuration.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numECGQRSDuration.Location = new System.Drawing.Point(108, 109);
            this.numECGQRSDuration.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numECGQRSDuration.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numECGQRSDuration.Name = "numECGQRSDuration";
            this.numECGQRSDuration.Size = new System.Drawing.Size(80, 23);
            this.numECGQRSDuration.TabIndex = 23;
            this.numECGQRSDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numECGQRSDuration.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numECGQRSDuration.ValueChanged += new System.EventHandler(this.onECGValueChanged);
            // 
            // labelECGQRSDuration
            // 
            this.labelECGQRSDuration.Location = new System.Drawing.Point(17, 109);
            this.labelECGQRSDuration.Name = "labelECGQRSDuration";
            this.labelECGQRSDuration.Size = new System.Drawing.Size(85, 23);
            this.labelECGQRSDuration.TabIndex = 22;
            this.labelECGQRSDuration.Text = "QRS Duration";
            this.labelECGQRSDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupECG
            // 
            this.groupECG.Controls.Add(this.labelECGAmplitude);
            this.groupECG.Controls.Add(this.labelECGQRSDuration);
            this.groupECG.Controls.Add(this._label2);
            this.groupECG.Controls.Add(this._label3);
            this.groupECG.Controls.Add(this.labelECGTWave);
            this.groupECG.Controls.Add(this.numECGQRSDuration);
            this.groupECG.Controls.Add(this._label1);
            this.groupECG.Controls.Add(this.numECGAmplitude);
            this.groupECG.Controls.Add(this.numECGTWave);
            this.groupECG.Controls.Add(this.numECGBPM);
            this.groupECG.Controls.Add(this.labelECGBPM);
            this.groupECG.Location = new System.Drawing.Point(20, 30);
            this.groupECG.Name = "groupECG";
            this.groupECG.Size = new System.Drawing.Size(243, 143);
            this.groupECG.TabIndex = 25;
            this.groupECG.TabStop = false;
            this.groupECG.Text = "ECG Time";
            // 
            // checkPPGLockAC
            // 
            this.checkPPGLockAC.AutoSize = true;
            this.checkPPGLockAC.Location = new System.Drawing.Point(227, 113);
            this.checkPPGLockAC.Name = "checkPPGLockAC";
            this.checkPPGLockAC.Size = new System.Drawing.Size(70, 19);
            this.checkPPGLockAC.TabIndex = 40;
            this.checkPPGLockAC.Text = "Lock AC";
            this.checkPPGLockAC.UseVisualStyleBackColor = true;
            this.checkPPGLockAC.CheckedChanged += new System.EventHandler(this.onPPGLockACCheckedChanged);
            // 
            // checkPPGLockDC
            // 
            this.checkPPGLockDC.AutoSize = true;
            this.checkPPGLockDC.Location = new System.Drawing.Point(227, 83);
            this.checkPPGLockDC.Name = "checkPPGLockDC";
            this.checkPPGLockDC.Size = new System.Drawing.Size(70, 19);
            this.checkPPGLockDC.TabIndex = 39;
            this.checkPPGLockDC.Text = "Lock DC";
            this.checkPPGLockDC.UseVisualStyleBackColor = true;
            this.checkPPGLockDC.CheckedChanged += new System.EventHandler(this.onPPGLockDCCheckedChanged);
            // 
            // _label6
            // 
            this._label6.Location = new System.Drawing.Point(194, 109);
            this._label6.Name = "_label6";
            this._label6.Size = new System.Drawing.Size(27, 23);
            this._label6.TabIndex = 38;
            this._label6.Text = "mV";
            this._label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _label5
            // 
            this._label5.Location = new System.Drawing.Point(194, 79);
            this._label5.Name = "_label5";
            this._label5.Size = new System.Drawing.Size(27, 23);
            this._label5.TabIndex = 26;
            this._label5.Text = "mV";
            this._label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPPGAC
            // 
            this.numPPGAC.DecimalPlaces = 2;
            this.numPPGAC.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numPPGAC.Location = new System.Drawing.Point(108, 109);
            this.numPPGAC.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numPPGAC.Minimum = new decimal(new int[] {
            75,
            0,
            0,
            131072});
            this.numPPGAC.Name = "numPPGAC";
            this.numPPGAC.Size = new System.Drawing.Size(80, 23);
            this.numPPGAC.TabIndex = 33;
            this.numPPGAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPPGAC.Value = new decimal(new int[] {
            125,
            0,
            0,
            65536});
            this.numPPGAC.ValueChanged += new System.EventHandler(this.onPPGACValueChanged);
            // 
            // labelPPGVolAC
            // 
            this.labelPPGVolAC.Location = new System.Drawing.Point(41, 109);
            this.labelPPGVolAC.Name = "labelPPGVolAC";
            this.labelPPGVolAC.Size = new System.Drawing.Size(59, 23);
            this.labelPPGVolAC.TabIndex = 31;
            this.labelPPGVolAC.Text = "AC";
            this.labelPPGVolAC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _label11
            // 
            this._label11.Location = new System.Drawing.Point(194, 49);
            this._label11.Name = "_label11";
            this._label11.Size = new System.Drawing.Size(27, 23);
            this._label11.TabIndex = 36;
            this._label11.Text = "%";
            this._label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPPGDC
            // 
            this.numPPGDC.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPPGDC.Location = new System.Drawing.Point(108, 79);
            this.numPPGDC.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numPPGDC.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPPGDC.Name = "numPPGDC";
            this.numPPGDC.Size = new System.Drawing.Size(80, 23);
            this.numPPGDC.TabIndex = 32;
            this.numPPGDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPPGDC.Value = new decimal(new int[] {
            625,
            0,
            0,
            0});
            this.numPPGDC.ValueChanged += new System.EventHandler(this.onPPGDCValueChanged);
            // 
            // labelPPGDC
            // 
            this.labelPPGDC.Location = new System.Drawing.Point(60, 79);
            this.labelPPGDC.Name = "labelPPGDC";
            this.labelPPGDC.Size = new System.Drawing.Size(40, 23);
            this.labelPPGDC.TabIndex = 29;
            this.labelPPGDC.Text = "DC";
            this.labelPPGDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numPPGBPM
            // 
            this.numPPGBPM.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPPGBPM.Location = new System.Drawing.Point(108, 19);
            this.numPPGBPM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numPPGBPM.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numPPGBPM.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numPPGBPM.Name = "numPPGBPM";
            this.numPPGBPM.Size = new System.Drawing.Size(80, 23);
            this.numPPGBPM.TabIndex = 30;
            this.numPPGBPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPPGBPM.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numPPGBPM.ValueChanged += new System.EventHandler(this.onPPGBPMValueChanged);
            // 
            // numPPGPI
            // 
            this.numPPGPI.DecimalPlaces = 3;
            this.numPPGPI.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numPPGPI.Location = new System.Drawing.Point(108, 49);
            this.numPPGPI.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numPPGPI.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            196608});
            this.numPPGPI.Name = "numPPGPI";
            this.numPPGPI.Size = new System.Drawing.Size(80, 23);
            this.numPPGPI.TabIndex = 35;
            this.numPPGPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPPGPI.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPPGPI.ValueChanged += new System.EventHandler(this.onPPGPIValueChanged);
            // 
            // labelPPGPI
            // 
            this.labelPPGPI.Location = new System.Drawing.Point(60, 49);
            this.labelPPGPI.Name = "labelPPGPI";
            this.labelPPGPI.Size = new System.Drawing.Size(40, 23);
            this.labelPPGPI.TabIndex = 34;
            this.labelPPGPI.Text = "PI";
            this.labelPPGPI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPPGBPM
            // 
            this.labelPPGBPM.Location = new System.Drawing.Point(57, 19);
            this.labelPPGBPM.Name = "labelPPGBPM";
            this.labelPPGBPM.Size = new System.Drawing.Size(43, 23);
            this.labelPPGBPM.TabIndex = 27;
            this.labelPPGBPM.Text = "BPM";
            this.labelPPGBPM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupPPG
            // 
            this.groupPPG.Controls.Add(this.checkSignalSynPluse);
            this.groupPPG.Controls.Add(this.numPPGBPM);
            this.groupPPG.Controls.Add(this.checkPPGLockAC);
            this.groupPPG.Controls.Add(this.labelPPGBPM);
            this.groupPPG.Controls.Add(this.checkPPGLockDC);
            this.groupPPG.Controls.Add(this.labelPPGPI);
            this.groupPPG.Controls.Add(this._label6);
            this.groupPPG.Controls.Add(this.numPPGPI);
            this.groupPPG.Controls.Add(this._label5);
            this.groupPPG.Controls.Add(this.labelPPGDC);
            this.groupPPG.Controls.Add(this.numPPGAC);
            this.groupPPG.Controls.Add(this.numPPGDC);
            this.groupPPG.Controls.Add(this.labelPPGVolAC);
            this.groupPPG.Controls.Add(this._label11);
            this.groupPPG.Location = new System.Drawing.Point(269, 30);
            this.groupPPG.Name = "groupPPG";
            this.groupPPG.Size = new System.Drawing.Size(318, 176);
            this.groupPPG.TabIndex = 41;
            this.groupPPG.TabStop = false;
            this.groupPPG.Text = "PPG";
            // 
            // _label10
            // 
            this._label10.Location = new System.Drawing.Point(194, 49);
            this._label10.Name = "_label10";
            this._label10.Size = new System.Drawing.Size(27, 23);
            this._label10.TabIndex = 47;
            this._label10.Text = "ms";
            this._label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTimeDiffF
            // 
            this.numTimeDiffF.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTimeDiffF.Location = new System.Drawing.Point(108, 49);
            this.numTimeDiffF.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTimeDiffF.Name = "numTimeDiffF";
            this.numTimeDiffF.Size = new System.Drawing.Size(80, 23);
            this.numTimeDiffF.TabIndex = 46;
            this.numTimeDiffF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTimeDiffF.Value = new decimal(new int[] {
            950,
            0,
            0,
            0});
            this.numTimeDiffF.ValueChanged += new System.EventHandler(this.onTimeDiffFValueChanged);
            // 
            // labelTimeDiffF
            // 
            this.labelTimeDiffF.Location = new System.Drawing.Point(52, 49);
            this.labelTimeDiffF.Name = "labelTimeDiffF";
            this.labelTimeDiffF.Size = new System.Drawing.Size(48, 23);
            this.labelTimeDiffF.TabIndex = 45;
            this.labelTimeDiffF.Text = "PTTf";
            this.labelTimeDiffF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _label8
            // 
            this._label8.Location = new System.Drawing.Point(194, 19);
            this._label8.Name = "_label8";
            this._label8.Size = new System.Drawing.Size(27, 23);
            this._label8.TabIndex = 44;
            this._label8.Text = "ms";
            this._label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numTimeDiffP
            // 
            this.numTimeDiffP.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTimeDiffP.Location = new System.Drawing.Point(108, 19);
            this.numTimeDiffP.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTimeDiffP.Name = "numTimeDiffP";
            this.numTimeDiffP.Size = new System.Drawing.Size(80, 23);
            this.numTimeDiffP.TabIndex = 43;
            this.numTimeDiffP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTimeDiffP.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTimeDiffP.ValueChanged += new System.EventHandler(this.onTimeDiffPValueChanged);
            // 
            // labelTimeDiffP
            // 
            this.labelTimeDiffP.Location = new System.Drawing.Point(55, 19);
            this.labelTimeDiffP.Name = "labelTimeDiffP";
            this.labelTimeDiffP.Size = new System.Drawing.Size(45, 23);
            this.labelTimeDiffP.TabIndex = 42;
            this.labelTimeDiffP.Text = "PTTp";
            this.labelTimeDiffP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupTimeDifference
            // 
            this.groupTimeDifference.Controls.Add(this.numTimeDiffP);
            this.groupTimeDifference.Controls.Add(this._label10);
            this.groupTimeDifference.Controls.Add(this.labelTimeDiffP);
            this.groupTimeDifference.Controls.Add(this.numTimeDiffF);
            this.groupTimeDifference.Controls.Add(this._label8);
            this.groupTimeDifference.Controls.Add(this.labelTimeDiffF);
            this.groupTimeDifference.Location = new System.Drawing.Point(20, 179);
            this.groupTimeDifference.Name = "groupTimeDifference";
            this.groupTimeDifference.Size = new System.Drawing.Size(243, 83);
            this.groupTimeDifference.TabIndex = 48;
            this.groupTimeDifference.TabStop = false;
            this.groupTimeDifference.Text = "Time Difference";
            // 
            // checkSignalSynPluse
            // 
            this.checkSignalSynPluse.Location = new System.Drawing.Point(108, 139);
            this.checkSignalSynPluse.Name = "checkSignalSynPluse";
            this.checkSignalSynPluse.Size = new System.Drawing.Size(132, 27);
            this.checkSignalSynPluse.TabIndex = 41;
            this.checkSignalSynPluse.Text = "Synchronized Pulse";
            this.checkSignalSynPluse.UseVisualStyleBackColor = true;
            this.checkSignalSynPluse.CheckedChanged += new System.EventHandler(this.onSyncCheckedChanged);
            // 
            // PWVPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupTimeDifference);
            this.Controls.Add(this.groupPPG);
            this.Controls.Add(this.groupECG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PWVPage";
            this.Size = new System.Drawing.Size(624, 318);
            ((System.ComponentModel.ISupportInitialize)(this.numECGBPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numECGTWave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numECGAmplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numECGQRSDuration)).EndInit();
            this.groupECG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPPGAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPPGDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPPGBPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPPGPI)).EndInit();
            this.groupPPG.ResumeLayout(false);
            this.groupPPG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeDiffF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeDiffP)).EndInit();
            this.groupTimeDifference.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numECGBPM;
        private System.Windows.Forms.Label labelECGBPM;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.NumericUpDown numECGTWave;
        private System.Windows.Forms.NumericUpDown numECGAmplitude;
        private System.Windows.Forms.Label labelECGTWave;
        private System.Windows.Forms.Label labelECGAmplitude;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.NumericUpDown numECGQRSDuration;
        private System.Windows.Forms.Label labelECGQRSDuration;
        private System.Windows.Forms.GroupBox groupECG;
        private System.Windows.Forms.CheckBox checkPPGLockAC;
        private System.Windows.Forms.CheckBox checkPPGLockDC;
        private System.Windows.Forms.Label _label6;
        private System.Windows.Forms.Label _label5;
        private System.Windows.Forms.NumericUpDown numPPGAC;
        private System.Windows.Forms.Label labelPPGVolAC;
        private System.Windows.Forms.Label _label11;
        private System.Windows.Forms.NumericUpDown numPPGDC;
        private System.Windows.Forms.Label labelPPGDC;
        private System.Windows.Forms.NumericUpDown numPPGBPM;
        private System.Windows.Forms.NumericUpDown numPPGPI;
        private System.Windows.Forms.Label labelPPGPI;
        private System.Windows.Forms.Label labelPPGBPM;
        private System.Windows.Forms.GroupBox groupPPG;
        private System.Windows.Forms.Label _label10;
        private System.Windows.Forms.NumericUpDown numTimeDiffF;
        private System.Windows.Forms.Label labelTimeDiffF;
        private System.Windows.Forms.Label _label8;
        private System.Windows.Forms.NumericUpDown numTimeDiffP;
        private System.Windows.Forms.Label labelTimeDiffP;
        private System.Windows.Forms.GroupBox groupTimeDifference;
        private System.Windows.Forms.CheckBox checkSignalSynPluse;
    }
}
