using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhaleTeqSDK;

namespace AECG100Demo
{
    public class UtilConfig
    {
        private static string[] ledText = { "Green", "Red", "IR", "" };
        private static string[] ledTextShort = { "G", "R", "IR", "" };

        public static string Channel1Text
        {
            get
            {
                return ledText[MainForm.Instance.PPGModelInfo.LEDType1];             
            }
        }

        public static string Channel1TextShort
        {
            get
            {
                return ledTextShort[MainForm.Instance.PPGModelInfo.LEDType1];                
            }
        }

        public static string Channel2Text
        {
            get
            {
                return ledText[MainForm.Instance.PPGModelInfo.LEDType2];
            }
        }

        public static string Channel2TextShort
        {
            get
            {
                return ledTextShort[MainForm.Instance.PPGModelInfo.LEDType2];
            }
        }

        public static ECG_WAVEFORM GetECGWaveformDefault ()
        {
            ECG_WAVEFORM waveform = new ECG_WAVEFORM ();
            waveform.Frequency = 1;
            waveform.Amplitude = 1.0;
            waveform.TWave = 0.2;
            waveform.PWave = 0.2;
            waveform.STSegment = 0;
            waveform.DCOffsetVariable = 0;
            waveform.DCOffset = 0;
            waveform.TimePeriod = 1000;
            waveform.PRInterval = 160;
            waveform.QRSDuration = 100;
            waveform.TDuration = 180;
            waveform.QTInterval = 350;
            waveform.Impedance = (int)ECGImpedanceEnable.Off;
            waveform.Electrode = (int)Electrode.RightArm;
            waveform.WaveformType = (int)ECGWaveformType.ECG;
            waveform.PulseWidth = 100;
            waveform.NoiseAmplitude = 0.1;
            waveform.NoiseFrequency = (int)ECGNoiseFrequency.Off;
            waveform.PacingEnabled = 0;
            waveform.PacingAmplitude = 2;
            waveform.PacingDuration = 2;
            waveform.RespirationEnabled = 0;
            waveform.RespirationAmplitude = 1;
            waveform.RespirationFrequency = 20;
            waveform.RespirationBaseline = 1000;
            waveform.RespirationRatio = 1;
            return waveform;
        }

        public static PPG_WAVEFORM GetPPGChannel1WaveformDefault ()
        {
            PPG_WAVEFORM waveform = new PPG_WAVEFORM ();
            waveform.WaveformType = (int)PPGWaveformType.PPG;
            waveform.Frequency = 1;
            waveform.VolDC = 625.0;
            waveform.VolSP = 12.5;
            waveform.VolDN = 7.0;
            waveform.VolDP = 8.0;
            waveform.TimePeriod = 1000;
            waveform.TimeSP = 150;
            waveform.TimeDN = 360;
            waveform.TimeDP = 460;
            waveform.SyncPulse = (int)SyncPulse.Sync;
            waveform.Inverted = 0;
            waveform.NoiseAmplitude = 0;
            waveform.NoiseFrequency = (int)PPGNoiseFrequency.Off;
            waveform.RespirationRate = 0.0;
            waveform.RespirationSize = 0.0;
            return waveform;
        }

        public static PPG_WAVEFORM GetPPGChannel2WaveformDefault ()
        {
            PPG_WAVEFORM waveform = new PPG_WAVEFORM ();
            waveform.WaveformType = (int)PPGWaveformType.PPG;
            waveform.Frequency = 1;
            waveform.VolDC = 625.0;
            waveform.VolSP = 25.0;
            waveform.VolDN = 14.0;
            waveform.VolDP = 16.0;
            waveform.TimePeriod = 1000;
            waveform.TimeSP = 150;
            waveform.TimeDN = 360;
            waveform.TimeDP = 460;
            waveform.SyncPulse = (int)SyncPulse.Sync;
            waveform.Inverted = 0;
            waveform.NoiseAmplitude = 0;
            waveform.NoiseFrequency = (int)PPGNoiseFrequency.Off;
            waveform.RespirationRate = 0.0;
            waveform.RespirationSize = 0.0;
            return waveform;
        }
    }
}
