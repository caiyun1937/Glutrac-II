namespace AECG100Demo
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageECG = new System.Windows.Forms.TabPage();
            this.tabPagePWV = new System.Windows.Forms.TabPage();
            this.tabPageSPO2 = new System.Windows.Forms.TabPage();
            this.tabPagePPG = new System.Windows.Forms.TabPage();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.panelControl = new System.Windows.Forms.Panel();
            this.btnOutput = new System.Windows.Forms.Button();
            this.ecgPage = new AECG100Demo.ECGPage();
            this.pwvPage1 = new AECG100Demo.PWVPage();
            this.spo2Page = new AECG100Demo.SPO2Page();
            this.ppgPage = new AECG100Demo.PPGPage();
            this.tabMain.SuspendLayout();
            this.tabPageECG.SuspendLayout();
            this.tabPagePWV.SuspendLayout();
            this.tabPageSPO2.SuspendLayout();
            this.tabPagePPG.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageECG);
            this.tabMain.Controls.Add(this.tabPagePWV);
            this.tabMain.Controls.Add(this.tabPageSPO2);
            this.tabMain.Controls.Add(this.tabPagePPG);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(729, 412);
            this.tabMain.TabIndex = 0;
            // 
            // tabPageECG
            // 
            this.tabPageECG.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageECG.Controls.Add(this.ecgPage);
            this.tabPageECG.Location = new System.Drawing.Point(4, 24);
            this.tabPageECG.Name = "tabPageECG";
            this.tabPageECG.Size = new System.Drawing.Size(721, 384);
            this.tabPageECG.TabIndex = 2;
            this.tabPageECG.Text = "ECG";
            // 
            // tabPagePWV
            // 
            this.tabPagePWV.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagePWV.Controls.Add(this.pwvPage1);
            this.tabPagePWV.Location = new System.Drawing.Point(4, 24);
            this.tabPagePWV.Name = "tabPagePWV";
            this.tabPagePWV.Size = new System.Drawing.Size(721, 384);
            this.tabPagePWV.TabIndex = 3;
            this.tabPagePWV.Text = "PWV";
            // 
            // tabPageSPO2
            // 
            this.tabPageSPO2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSPO2.Controls.Add(this.spo2Page);
            this.tabPageSPO2.Location = new System.Drawing.Point(4, 24);
            this.tabPageSPO2.Name = "tabPageSPO2";
            this.tabPageSPO2.Size = new System.Drawing.Size(721, 384);
            this.tabPageSPO2.TabIndex = 0;
            this.tabPageSPO2.Text = "SPO2";
            // 
            // tabPagePPG
            // 
            this.tabPagePPG.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagePPG.Controls.Add(this.ppgPage);
            this.tabPagePPG.Location = new System.Drawing.Point(4, 24);
            this.tabPagePPG.Name = "tabPagePPG";
            this.tabPagePPG.Size = new System.Drawing.Size(721, 384);
            this.tabPagePPG.TabIndex = 1;
            this.tabPagePPG.Text = "PPG";
            // 
            // panelGraph
            // 
            this.panelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraph.Location = new System.Drawing.Point(0, 441);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(729, 150);
            this.panelGraph.TabIndex = 1;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.btnOutput);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(0, 412);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(729, 29);
            this.panelControl.TabIndex = 2;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(3, 3);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 0;
            this.btnOutput.Text = "Output";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.onOutputClick);
            // 
            // ecgPage
            // 
            this.ecgPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ecgPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ecgPage.Location = new System.Drawing.Point(0, 0);
            this.ecgPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ecgPage.Name = "ecgPage";
            this.ecgPage.Size = new System.Drawing.Size(721, 384);
            this.ecgPage.TabIndex = 0;
            // 
            // pwvPage1
            // 
            this.pwvPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pwvPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwvPage1.Location = new System.Drawing.Point(0, 0);
            this.pwvPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pwvPage1.Name = "pwvPage1";
            this.pwvPage1.Size = new System.Drawing.Size(721, 386);
            this.pwvPage1.TabIndex = 0;
            // 
            // spo2Page
            // 
            this.spo2Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spo2Page.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spo2Page.Location = new System.Drawing.Point(0, 0);
            this.spo2Page.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spo2Page.Name = "spo2Page";
            this.spo2Page.Size = new System.Drawing.Size(721, 386);
            this.spo2Page.TabIndex = 0;
            // 
            // ppgPage
            // 
            this.ppgPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppgPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppgPage.Location = new System.Drawing.Point(0, 0);
            this.ppgPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ppgPage.Name = "ppgPage";
            this.ppgPage.Size = new System.Drawing.Size(721, 386);
            this.ppgPage.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 591);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WhaleTeq HRS300";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            this.tabMain.ResumeLayout(false);
            this.tabPageECG.ResumeLayout(false);
            this.tabPagePWV.ResumeLayout(false);
            this.tabPageSPO2.ResumeLayout(false);
            this.tabPagePPG.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageSPO2;
        private System.Windows.Forms.TabPage tabPagePPG;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button btnOutput;
        private PPGPage ppgPage;
        private SPO2Page spo2Page;
        private System.Windows.Forms.TabPage tabPageECG;
        private System.Windows.Forms.TabPage tabPagePWV;
        private ECGPage ecgPage;
        private PWVPage pwvPage1;
    }
}