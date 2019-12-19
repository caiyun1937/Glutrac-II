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
    public partial class PWVPage: UserControl, IPageControl
    {
        private ECG_WAVEFORM ecgWaveform;
        private PPG_WAVEFORM ppgWaveform;
        private ECG_WAVEFORM ecgOutputWaveform;
        private PPG_WAVEFORM ppgOutputWaveform;

        private OutputSignalCallback outputECGCB;
        private OutputSignalCallback outputPPGCB;

        public PWVPage ()
        {
            InitializeComponent ();

            ecgWaveform = UtilConfig.GetECGWaveformDefault ();
            ppgWaveform = UtilConfig.GetPPGChannel1WaveformDefault ();

            outputECGCB = new OutputSignalCallback (AECGOutputECGCallback);
            outputPPGCB = new OutputSignalCallback (AECGOutputPPGCallback);

            checkPPGLockAC.Checked = true;
        }

        public void onConnected ()
        {

        }

        public void onStartOutput ()
        {
            ecgOutputWaveform = ecgWaveform;
            ppgOutputWaveform = ppgWaveform;

            MainForm.Instance.GraphSetYAxisScale (0, -5, 5);
            MainForm.Instance.GraphSetYAxisScale (1, 0, 30);
            OutputCounter = 0;

            bool result = AECG100.OutputECGAndPPG ((int)numTimeDiffP.Value, ref ecgOutputWaveform, ref ppgOutputWaveform, outputECGCB, outputPPGCB);

            if (result) {
                MainForm.Instance.OutputStarted ();
            } else {
                MessageBox.Show ("Error: output waveform failed", "WhaleTeq", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AECGOutputECGCallback (double time, int ac, int dc)
        {
            if (ac == int.MinValue) {
                MainForm.Instance.BeginInvoke (new MethodInvoker (MainForm.Instance.OutputStopped));
                return;
            }

            MainForm.Instance.GraphAddPoint (0, time, ac / 1000.0, false);
        }

        private void AECGOutputPPGCallback (double time, int ac, int dc)
        {
            if (ac == int.MinValue) {
                MainForm.Instance.BeginInvoke (new MethodInvoker (MainForm.Instance.OutputStopped));
                return;
            }

            uint counter = OutputCounter++;
            MainForm.Instance.GraphAddPoint (1, time, ac / 1000.0, ((counter % 200) == 0));
        }

        private void SyncTimeDiffP2F (bool preview = true)
        {
            int period = ecgWaveform.TimePeriod;
            if ((PPGWaveformType)ppgWaveform.WaveformType == PPGWaveformType.PPG) {
                numTimeDiffF.Value = ((int)numTimeDiffP.Value - ppgWaveform.TimeSP + period) % period;
            } else {
                numTimeDiffF.Value = (int)((int)numTimeDiffP.Value + ppgWaveform.TimePeriod * 0.5) % period;
            }
        }

        private void SyncTimeDiffF2P ()
        {
            int period = ecgWaveform.TimePeriod;
            if ((PPGWaveformType)ppgWaveform.WaveformType == PPGWaveformType.PPG) {
                numTimeDiffP.Value = ((int)numTimeDiffF.Value + ppgWaveform.TimeSP) % period;
            } else {
                numTimeDiffP.Value = (int)((int)numTimeDiffF.Value + ppgWaveform.TimePeriod * 0.5) % period;
            }
        }

        private uint OutputCounter
        {
            get;
            set;
        }

        private void onECGBPMValueChanged (object sender, EventArgs e)
        {
            numPPGBPM.Value = numECGBPM.Value;

            ecgWaveform.Frequency = (double)numECGBPM.Value / 60.0;
            ecgWaveform.TimePeriod = (int)(60000m / numECGBPM.Value);
            numTimeDiffF.Maximum = numTimeDiffP.Maximum = ecgWaveform.TimePeriod;

            SyncTimeDiffP2F ();
        }

        private void onECGValueChanged (object sender, EventArgs e)
        {
            ecgWaveform.Amplitude = (double)numECGAmplitude.Value;
            ecgWaveform.TWave = (double)numECGTWave.Value;
            ecgWaveform.QRSDuration = (int)numECGQRSDuration.Value;
        }

        private void onPPGBPMValueChanged (object sender, EventArgs e)
        {
            numECGBPM.Value = numPPGBPM.Value;

            int period = (int)(60000m / numPPGBPM.Value);

            ppgWaveform.TimeSP = (int)(period * 0.15);
            ppgWaveform.TimeDN = (int)(period * 0.36);
            ppgWaveform.TimeDP = (int)(period * 0.46);
            ppgWaveform.TimePeriod = period;
            ppgWaveform.Frequency = (double)numPPGBPM.Value / 60.0;

            SyncTimeDiffP2F ();
        }

        private void onPPGLockDCCheckedChanged (object sender, EventArgs e)
        {
            numPPGDC.Enabled = !checkPPGLockDC.Checked;
            checkPPGLockAC.Checked = !checkPPGLockDC.Checked;
        }

        private void onPPGLockACCheckedChanged (object sender, EventArgs e)
        {
            numPPGAC.Enabled = !checkPPGLockAC.Checked;
            checkPPGLockDC.Checked = !checkPPGLockAC.Checked;
        }

        private void onPPGPIValueChanged (object sender, EventArgs e)
        {
            try {
                if (checkPPGLockAC.Checked) {
                    numPPGDC.Value = numPPGAC.Value / (numPPGPI.Value / 100m);
                } else {
                    numPPGAC.Value = numPPGDC.Value * (numPPGPI.Value / 100m);
                }
            }
            catch {
                numPPGPI.Value = numPPGAC.Value / numPPGDC.Value * 100m;
                return;
            }

            ppgWaveform.VolDC = (double)numPPGDC.Value;
            ppgWaveform.VolSP = (double)numPPGAC.Value;
        }

        private void onPPGDCValueChanged (object sender, EventArgs e)
        {
            numPPGPI.Value = numPPGAC.Value / numPPGDC.Value * 100m;

            ppgWaveform.VolDC = (double)numPPGDC.Value;
        }

        private void onPPGACValueChanged (object sender, EventArgs e)
        {
            numPPGPI.Value = numPPGAC.Value / numPPGDC.Value * 100m;

            ppgWaveform.VolSP = (double)numPPGAC.Value;
            ppgWaveform.VolDN = ppgWaveform.VolSP * 7.0 / 12.5;
            ppgWaveform.VolDP = ppgWaveform.VolSP * 8.0 / 12.5;
        }

        private void onSyncCheckedChanged (object sender, EventArgs e)
        {
            ppgWaveform.SyncPulse = checkSignalSynPluse.Checked ? (int)SyncPulse.Sync : (int)SyncPulse.SyncOff;
        }

        private void onTimeDiffPValueChanged (object sender, EventArgs e)
        {
            SyncTimeDiffP2F ();
        }

        private void onTimeDiffFValueChanged (object sender, EventArgs e)
        {
            SyncTimeDiffF2P ();
        }


    }
}
