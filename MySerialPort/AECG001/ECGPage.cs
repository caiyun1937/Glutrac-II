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
    public partial class ECGPage: UserControl, IPageControl
    {
        private ECG_WAVEFORM ecgWaveform;
        private ECG_WAVEFORM ecgOutputWaveform;

        private OutputSignalCallback outputCB;

        public ECGPage ()
        {
            InitializeComponent ();

            ecgWaveform = UtilConfig.GetECGWaveformDefault ();

            outputCB = new OutputSignalCallback (AECGOutputSignal);

            comboWaveform.SelectedIndex = (int)ECGWaveformType.ECG;
            _radioElectrodeRightArm.Checked = (ecgWaveform.Electrode == (int)Electrode.RightArm);
            _radioElectrodeLeftArm.Checked = (ecgWaveform.Electrode == (int)Electrode.LeftArm);
            checkImpedanceTest.Checked = (ecgWaveform.Impedance == (int)ECGImpedanceEnable.Off);
            numDCOffset.Value = ecgWaveform.DCOffset;
            checkDCOffsetVariable.Checked = (ecgWaveform.DCOffsetVariable != 0);
            numDCOffset.Increment = checkDCOffsetVariable.Checked ? 5 : 300;
            ecgWaveform.Frequency = (double)numBPM.Value / 60.0;
            ecgWaveform.TimePeriod = (int)(60000m / numBPM.Value);

        }

        public void onConnected ()
        {

        }

        public void onStartOutput ()
        {
            ecgOutputWaveform = ecgWaveform;

            MainForm.Instance.GraphSetYAxisScale (0, -5, 5);
            MainForm.Instance.GraphSetYAxisScale (1, -5, 5);
            OutputCounter = 0;

            bool result = AECG100.OutputECG (ref ecgOutputWaveform, outputCB);
            if (result) {
                MainForm.Instance.OutputStarted ();
            } else {
                MessageBox.Show ("Error: output waveform failed", "WhaleTeq", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AECGOutputSignal (double time, int ac, int dc)
        {
            if (ac == int.MinValue) {
                MainForm.Instance.BeginInvoke (new MethodInvoker (MainForm.Instance.OutputStopped));
                return;
            }

            uint counter = OutputCounter++;
            MainForm.Instance.GraphAddPoint (0, time, ac / 1000.0, (counter % 200) == 0);
        }

        private uint OutputCounter
        {
            get;
            set;
        }

        private bool IsECGWaveType
        {
            get
            {
                return (comboWaveform.SelectedIndex == (int)ECGWaveformType.ECG);
            }
        }

        private void onBPMValueChanged (object sender, EventArgs e)
        {
            if ((ecgWaveform.WaveformType > (int)ECGWaveformType.Square) && (numBPM.Value > 300)) {
                numBPM.Value = 300;
                return;
            }

            if ((ecgWaveform.WaveformType > (int)ECGWaveformType.Square) && (numBPM.Value < 30)) {
                numBPM.Value = 30;
                return;
            }

            ecgWaveform.Frequency = (double)numBPM.Value / 60.0;
            ecgWaveform.TimePeriod = (int)(60000m / numBPM.Value);
        }

        private void onElectrodeCheckedChanged (object sender, EventArgs e)
        {
            ecgWaveform.Electrode = _radioElectrodeRightArm.Checked ? (int)Electrode.RightArm : (int)Electrode.LeftArm;
            AECG100.DeviceSetElectrode ((Electrode)ecgWaveform.Electrode);
        }

        private void onWaveformSelectedIndexChanged (object sender, EventArgs e)
        {
            ecgWaveform.WaveformType = comboWaveform.SelectedIndex;
            numWaveformPulseWidth.Enabled = (comboWaveform.SelectedIndex == (int)ECGWaveformType.RectanglePulse
                || comboWaveform.SelectedIndex == (int)ECGWaveformType.TrianglePluse
                || comboWaveform.SelectedIndex == (int)ECGWaveformType.Exponential);

            Control[] ctrlECG = { numVoltageRWave, numVoltageTWave, numVoltagePWave, numVoltageSTSegment, groupTime };

            foreach (Control ctrl in ctrlECG) {
                ctrl.Enabled = IsECGWaveType;
            }

            numVoltageAmplitude.Visible = IsECGWaveType;
            numVoltageAmplitude2.Visible = !IsECGWaveType;

            if (IsECGWaveType) {
                ecgWaveform.Amplitude = (double)numVoltageAmplitude.Value;
            } else {
                ecgWaveform.Amplitude = (double)numVoltageAmplitude2.Value;
            }

            if ((ecgWaveform.WaveformType > (int)ECGWaveformType.Square) && (numBPM.Value > 300)) {
                numBPM.Value = 300;
            }

            if ((ecgWaveform.WaveformType > (int)ECGWaveformType.Square) && (numBPM.Value < 30)) {
                numBPM.Value = 30;
            }
        }

        private void onVoltageAmplitudeValueChanged (object sender, EventArgs e)
        {
            numVoltageAmplitude.Value = decimal.Round (numVoltageAmplitude.Value, numVoltageAmplitude.DecimalPlaces, MidpointRounding.AwayFromZero);
            ecgWaveform.Amplitude = (double)numVoltageAmplitude.Value;
            numVoltageRWave.ValueChanged -= onVoltageRWaveValueChanged;
            numVoltageRWave.Value = numVoltageAmplitude.Value * 0.875m;
            numVoltageRWave.ValueChanged += onVoltageRWaveValueChanged;
        }

        private void onVoltageAmplitude2ValueChanged (object sender, EventArgs e)
        {
            numVoltageAmplitude2.Value = decimal.Round (numVoltageAmplitude2.Value, numVoltageAmplitude2.DecimalPlaces, MidpointRounding.AwayFromZero);
            ecgWaveform.Amplitude = (double)numVoltageAmplitude2.Value;            
        }

        private void onVoltageRWaveValueChanged (object sender, EventArgs e)
        {            
            numVoltageAmplitude.Value = Math.Max (Math.Min (numVoltageRWave.Value / 0.875m, numVoltageAmplitude.Maximum), numVoltageAmplitude.Minimum);
        }

        private void onVoltageTWaveValueChanged (object sender, EventArgs e)
        {
            ecgWaveform.TWave = (double)numVoltageTWave.Value;
        }

        private void onVoltagePWaveValueChanged (object sender, EventArgs e)
        {
            ecgWaveform.PWave = (double)numVoltagePWave.Value;
        }

        private void onVoltageSTSegmentValueChanged (object sender, EventArgs e)
        {
            ecgWaveform.STSegment = (double)numVoltageSTSegment.Value;
        }

        private void onTimePRValueChanged (object sender, EventArgs e)
        {
            ecgWaveform.PRInterval = (int)numTimePRInterval.Value;
        }

        private void onTimeQTValueChanged (object sender, EventArgs e)
        {
            ecgWaveform.QTInterval = (int)numTimeQTInterval.Value;
            numTimeQRSDuration.Value = numTimeQTInterval.Value - 250m;
        }

        private void onTimeQRSValueChanged (object sender, EventArgs e)
        {
            ecgWaveform.QRSDuration = (int)numTimeQRSDuration.Value;
            numTimeQTInterval.Value = numTimeQRSDuration.Value + 250m;
        }

        private void onDCOffsetValueChanged (object sender, EventArgs e)
        {
            if (!checkDCOffsetVariable.Checked) {
                int dc = (int)numDCOffset.Value;
                if (dc > 0) {
                    numDCOffset.Value = 300;
                } else if (dc < 0) {
                    numDCOffset.Value = -300;
                } else {
                    numDCOffset.Value = 0;
                }
            }
            ecgWaveform.DCOffset = (int)numDCOffset.Value;

            if (!checkDCOffsetVariable.Checked) {
                AECG100.DeviceSetDCOffset (ecgWaveform.DCOffset);
            }
        }

        private void onDCOffsetVariableCheckedChanged (object sender, EventArgs e)
        {
            if (checkDCOffsetVariable.Checked) {
                numDCOffset.Increment = 5;
            } else {
                int dc = (int)numDCOffset.Value;
                if (dc >= 150) {
                    numDCOffset.Value = 300;
                } else if (dc <= -150) {
                    numDCOffset.Value = -300;
                } else {
                    numDCOffset.Value = 0;
                }
                numDCOffset.Increment = 300;
            }
            ecgWaveform.DCOffsetVariable = Convert.ToInt32 (checkDCOffsetVariable.Checked);
        }

        private void onImpedanceTestCheckedChanged (object sender, EventArgs e)
        {
            ecgWaveform.Impedance = checkImpedanceTest.Checked ? (int)ECGImpedanceEnable.Off : (int)ECGImpedanceEnable.On;
            AECG100.DeviceEnableImpedance ((ECGImpedanceEnable)ecgWaveform.Impedance);
        }
    }
}
