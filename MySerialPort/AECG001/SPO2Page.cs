using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WhaleTeqSDK;

namespace AECG100Demo
{
    public partial class SPO2Page: UserControl, IPageControl
    {
        private PPG_WAVEFORM channel1Waveform;
        private PPG_WAVEFORM channel2Waveform;
        private PPG_WAVEFORM channel1OutputWaveform;
        private PPG_WAVEFORM channel2OutputWaveform;

        private OutputSignalCallback outputChannel1CB;
        private OutputSignalCallback outputChannel2CB;

        public SPO2Page ()
        {
            InitializeComponent ();

            channel1Waveform = UtilConfig.GetPPGChannel1WaveformDefault ();
            channel2Waveform = UtilConfig.GetPPGChannel2WaveformDefault ();

            outputChannel1CB = new OutputSignalCallback (AECGOutputChannel1Callback);
            outputChannel2CB = new OutputSignalCallback (AECGOutputChannel2Callback);

            comboWaveform.SelectedIndex = channel1Waveform.WaveformType;
            checkChannel1LockAC.Checked = true;
            checkChannel2LockAC.Checked = true;

            SyncConfig ();
        }

        public void onConnected ()
        {
            this.Enabled = MainForm.Instance.PPGChannel2Supported; 
        }

        public void onStartOutput ()
        {
            if (!this.Enabled) {
                return;
            }

            channel1OutputWaveform = channel1Waveform;
            channel2OutputWaveform = channel2Waveform;

            MainForm.Instance.GraphSetYAxisScale (0, 0, 30);
            MainForm.Instance.GraphSetYAxisScale (1, 0, 30);
            OutputCounter = 0;

            bool result = AECG100.OutputPPGEx (ref channel1OutputWaveform, ref channel2OutputWaveform, outputChannel1CB, outputChannel2CB);
            if (result) {
                MainForm.Instance.OutputStarted ();
            } else {
                MessageBox.Show ("Error: output waveform failed", "WhaleTeq", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AECGOutputChannel1Callback (double time, int ac, int dc)
        {
            if (ac == int.MinValue) {
                MainForm.Instance.BeginInvoke (new MethodInvoker (MainForm.Instance.OutputStopped));
                return;
            }

            MainForm.Instance.GraphAddPoint (0, time, ac / 1000.0, false);
        }

        private void AECGOutputChannel2Callback (double time, int ac, int dc)
        {
            if (ac == int.MinValue) {
                MainForm.Instance.BeginInvoke (new MethodInvoker (MainForm.Instance.OutputStopped));
                return;
            }

            uint counter = OutputCounter++;
            MainForm.Instance.GraphAddPoint (1, time, ac / 1000.0, ((counter % 200) == 0));
        }

        private void SyncConfig ()
        {
            numChannel1AC.Value = (decimal)channel1Waveform.VolSP;
            numChannel1DC.Value = (decimal)channel1Waveform.VolDC;
            numChannel1PI.Value = numChannel1AC.Value / numChannel1DC.Value * 100m;

            numChannel2AC.Value = (decimal)channel2Waveform.VolSP;
            numChannel2DC.Value = (decimal)channel2Waveform.VolDC;
            numChannel2PI.Value = numChannel2AC.Value / numChannel2DC.Value * 100m;

            checkSignalSyncPluse.Checked = (channel1Waveform.SyncPulse == (int)SyncPulse.Sync);
        }

        private uint OutputCounter
        {
            get;
            set;
        }

        private void onBPMValueChanged (object sender, EventArgs e)
        {
            int period = (int)(60000m / numBPM.Value);

            channel1Waveform.TimeSP = (int)(period * 0.15);
            channel1Waveform.TimeDN = (int)(period * 0.36);
            channel1Waveform.TimeDP = (int)(period * 0.46);
            channel1Waveform.Frequency = (double)numBPM.Value / 60.0;
            channel1Waveform.TimePeriod = (int)period;

            channel2Waveform.TimeSP = (int)(period * 0.15);
            channel2Waveform.TimeDN = (int)(period * 0.36);
            channel2Waveform.TimeDP = (int)(period * 0.46);
            channel2Waveform.Frequency = (double)numBPM.Value / 60.0;
            channel2Waveform.TimePeriod = period;
        }

        private void onChannel1LockACCheckedChanged (object sender, EventArgs e)
        {
            numChannel1AC.Enabled = !checkChannel1LockAC.Checked;
            checkChannel1LockDC.Checked = !checkChannel1LockAC.Checked;
        }

        private void onChannel1LockDCCheckedChanged (object sender, EventArgs e)
        {
            numChannel1DC.Enabled = !checkChannel1LockDC.Checked;
            checkChannel1LockAC.Checked = !checkChannel1LockDC.Checked;
        }

        private void onChannel1PIValueChanged (object sender, EventArgs e)
        {
            try {
                if (checkChannel1LockAC.Checked) {
                    numChannel1DC.Value = numChannel1AC.Value / (numChannel1PI.Value / 100m);
                } else {
                    numChannel1AC.Value = numChannel1DC.Value * (numChannel1PI.Value / 100m);
                }
            }
            catch {
                numChannel1PI.Value = numChannel1AC.Value / numChannel1DC.Value * 100m;
                return;
            }
        }

        private void onChannel1ACValueChanged (object sender, EventArgs e)
        {
            numChannel1PI.Value = numChannel1AC.Value / numChannel1DC.Value * 100m;

            channel1Waveform.VolSP = (double)numChannel1AC.Value;
            channel1Waveform.VolDN = channel1Waveform.VolSP * 7.0 / 12.5;
            channel1Waveform.VolDP = channel1Waveform.VolSP * 8.0 / 12.5;
        }

        private void onChannel1DCValueChanged (object sender, EventArgs e)
        {
            numChannel1DC.Value = decimal.Round (numChannel1DC.Value, 0, MidpointRounding.AwayFromZero);
            numChannel1PI.Value = numChannel1AC.Value / numChannel1DC.Value * 100m;
            channel1Waveform.VolDC = (double)numChannel1DC.Value;
        }

        private void onChannel2LockACCheckedChanged (object sender, EventArgs e)
        {
            numChannel2AC.Enabled = !checkChannel2LockAC.Checked;
            checkChannel2LockDC.Checked = !checkChannel2LockAC.Checked;
        }

        private void onChannel2LockDCCheckedChanged (object sender, EventArgs e)
        {
            numChannel2DC.Enabled = !checkChannel2LockDC.Checked;
            checkChannel2LockAC.Checked = !checkChannel2LockDC.Checked;
        }

        private void onChannel2PIValueChanged (object sender, EventArgs e)
        {
            try {
                if (checkChannel2LockAC.Checked) {
                    numChannel2DC.Value = numChannel2AC.Value / (numChannel2PI.Value / 100m);
                } else {
                    numChannel2AC.Value = numChannel2DC.Value * (numChannel2PI.Value / 100m);
                }
            }
            catch {
                numChannel2PI.Value = numChannel2AC.Value / numChannel2DC.Value * 100m;
                return;
            }
        }

        private void onChannel2ACValueChanged (object sender, EventArgs e)
        {
            numChannel2PI.Value = numChannel2AC.Value / numChannel2DC.Value * 100m;

            channel2Waveform.VolSP = (double)numChannel2AC.Value;
            channel2Waveform.VolDN = channel2Waveform.VolSP * 7.0 / 12.5;
            channel2Waveform.VolDP = channel2Waveform.VolSP * 8.0 / 12.5;
        }

        private void onChannel2DCValueChanged (object sender, EventArgs e)
        {
            numChannel2DC.Value = decimal.Round (numChannel2DC.Value, 0, MidpointRounding.AwayFromZero);
            numChannel2PI.Value = numChannel2AC.Value / numChannel2DC.Value * 100m;
            channel2Waveform.VolDC = (double)numChannel2DC.Value;
        }

        private void onSyncCheckedChanged (object sender, EventArgs e)
        {
            channel1Waveform.SyncPulse = channel2Waveform.SyncPulse = checkSignalSyncPluse.Checked ? (int)SyncPulse.Sync : (int)SyncPulse.SyncOff;
        }
    }
}
