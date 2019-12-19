using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WhaleTeqSDK
{
    public enum HRSStatus
    {
        OK,
        DeviceNotConnected,
        DeviceError,
        InvalidParameter,
        InvalidModeType
    }

    public enum SamplingStatus
    {
        Channel1PacketLost = 0x10,
        Channel2PacketLost = 0x11
    }

    public enum PPGChannel
    {
        Channel1 = 1,
        Channel2 = 2
    };

    public enum Mode
    {
        ModeA = 1,
        ModeB,
        ModeC,
        ModeMax
    };

    public enum ModeType
    {
        ECG = 1,
        PWV,
        SPO2,
        PPG1,
        PPG2,
        Max
    };

    public enum PPGSampling
    {
        Channel1PD,
        Channel2PD,
        Channel1Switch,
        Channel2Switch,
        Max
    };

    public enum ECGWaveformType
    {
        Sine,
        Triangle,
        Square,
        RectanglePulse,
        TrianglePluse,
        Exponential,
        ECG,
    };

    public enum Electrode
    {
        RightArm,
        LeftArm = 0xff
    }

    public enum ECGImpedanceEnable
    {
        Off,
        On = 0xff
    };

    public enum ECGPacingEnable
    {
        Off,
        On = 0xff
    };

    public enum ECGRespirationEnable
    {
        Off,
        On = 0xff
    };

    public enum PPGWaveformType
    {
        Sine,
        Triangle,
        PPG
    };

    public enum ECGNoiseFrequency
    {
        Off,
        _50Hz,
        _60Hz
    };

    public enum PPGNoiseFrequency
    {
        Off,
        _50Hz,
        _60Hz,
        _1KHz,
        _5KHz
    };

    public enum LEDMode
    {
        Off,
        On
    }

    public enum LEDType
    {
        Green,
        Red,
        IR,
        None
    };

    public enum SyncPulse
    {
        LEDOff,
        Sync,
        SyncOff
    }

    public enum PPGInverted
    {
        Off,
        On
    };

    [StructLayout (LayoutKind.Sequential)]
    public struct MODEL_INFORMATION
    {
        [MarshalAs (UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] ProductName;
        public byte GenerationNumber;
        public byte ModelNumber;
        public int SerialNumber;
        public int Year;
        public int LEDType1;
        public int LEDType2;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct ECG_WAVEFORM
    {
        public int WaveformType; // enum ECGWaveformType
        public double Frequency;
        public double Amplitude;
        public double TWave;
        public double PWave;
        public double STSegment;
        public int DCOffsetVariable;
        public int DCOffset;
        public int TimePeriod;
        public int PRInterval;
        public int QRSDuration;
        public int TDuration;
        public int QTInterval;
        public int Impedance; // enum ECGImpedance
        public int Electrode; // enum Electrode        
        public int PulseWidth;
        public double NoiseAmplitude;
        public int NoiseFrequency;
        public int PacingEnabled;
        public double PacingAmplitude;
        public double PacingDuration;
        public int RespirationEnabled;
        public int RespirationAmplitude;
        public int RespirationFrequency;
        public int RespirationRatio;
        public int RespirationBaseline;
        public int RespirationApnea;
        [MarshalAs (UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] Reserved;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct PPG_WAVEFORM
    {
        public int WaveformType;
        public double Frequency;
        public double VolDC;
        public double VolSP;
        public double VolDN;
        public double VolDP;
        public int TimeSP;
        public int TimeDN;
        public int TimeDP;
        public int TimePeriod;
        public int SyncPulse;
        public int Inverted;
        public double NoiseAmplitude;
        public int NoiseFrequency;
        public double RespirationRate;
        public double RespirationSize;
        [MarshalAs (UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] Reserved;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct FREQUENCY_SCAN
    {
        public double Amplitude;
        public double FrequencyStart;
        public double FrequencyFinish;
        public int Duration;
    };

    [StructLayout (LayoutKind.Sequential)]
    public struct PLAY_RAW_DATA
    {
        public double SampleRate;
        public int Size;
        public int SyncPulse;
        public IntPtr AC;
        public IntPtr DC;
        public OutputSignalCallback cb;

        public PLAY_RAW_DATA (double sampleRate, int size, SyncPulse syncPulse, IntPtr ac, IntPtr dc, OutputSignalCallback cb)
        {
            this.SampleRate = sampleRate;
            this.Size = size;
            this.SyncPulse = (int)syncPulse;
            this.AC = ac;
            this.DC = dc;
            this.cb = cb;
        }
    };

    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void ConnectedCallback (bool connected);

    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void OutputSignalCallback (double time, int ac, int dc);

    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void SamplingCallback (int data, int number);

    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void SamplingErrorCallback (int error);

    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    public delegate void ScanCallback (int data, double frequency, bool cont);

    public class AECG100
    {
#if (_WIN64)
        private const string DllFilePath = @"AECG100x64.dll";
#else
        private const string DllFilePath = @"AECG100x86.dll";
#endif

        [DllImport (DllFilePath, EntryPoint = "WTQInit", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool Init ([MarshalAs (UnmanagedType.FunctionPtr)] ConnectedCallback cb);

        [DllImport (DllFilePath, EntryPoint = "WTQFree", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Free ();

        [DllImport (DllFilePath, EntryPoint = "WTQGetDeviceInformation", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool GetDeviceInformation (out MODEL_INFORMATION modelInfo);

        [DllImport (DllFilePath, EntryPoint = "WTQGetPPGDeviceInformation", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool GetPPGDeviceInformation (out MODEL_INFORMATION modelInfo);

        [DllImport (DllFilePath, EntryPoint = "WTQSetProductName", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool SetProductName (char a, char b);

        [DllImport (DllFilePath, EntryPoint = "WTQSetSerialNumber", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool SetSerialNumber (int year, int serial);

        [DllImport (DllFilePath, EntryPoint = "WTQSetPPGModuleSerialNumber", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool SetPPGModuleSerialNumber (int year, int serial);

        [DllImport (DllFilePath, EntryPoint = "WTQSetPPGModuleType", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool SetPPGModuleType (UInt16 nPPGModuleType);

        [DllImport (DllFilePath, EntryPoint = "WTQEnableSampling", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool EnableSampling (PPGSampling mode, SamplingCallback cbSamplingData);

        [DllImport (DllFilePath, EntryPoint = "WTQStartSampling", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool StartSampling (SamplingErrorCallback cbError);

        [DllImport (DllFilePath, EntryPoint = "WTQStartSamplingEx", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool StartSamplingEx (int skipPacketCount, SamplingErrorCallback cbError);

        [DllImport (DllFilePath, EntryPoint = "WTQDisableSampling", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisableSampling ();

        [DllImport (DllFilePath, EntryPoint = "WTQEnableRLD", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool EnableRLD (bool enable);

        [DllImport (DllFilePath, EntryPoint = "WTQReadRLD", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool ReadRLD (ref double N1, ref double N2);

        [DllImport (DllFilePath, EntryPoint = "WTQDeviceEnableImpedance", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool DeviceEnableImpedance (ECGImpedanceEnable impedance);

        [DllImport (DllFilePath, EntryPoint = "WTQDeviceSetElectrode", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool DeviceSetElectrode (Electrode electrode);

        [DllImport (DllFilePath, EntryPoint = "WTQDeviceEnablePacing", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool DeviceEnablePacing (ECGPacingEnable enable);

        [DllImport (DllFilePath, EntryPoint = "WTQDeviceSetDCOffset", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool DeviceSetDCOffset (int dcOffset);

        [DllImport (DllFilePath, EntryPoint = "WTQOutputECG", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool OutputECG (ref ECG_WAVEFORM waveform, OutputSignalCallback cb);

        [DllImport (DllFilePath, EntryPoint = "WTQOutputECGAndPPG", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool OutputECGAndPPG (int timeDiffPTTPeak, ref ECG_WAVEFORM ecgWaveform, ref PPG_WAVEFORM ppgWaveform, OutputSignalCallback cbECG, OutputSignalCallback cbPPG);

        [DllImport (DllFilePath, EntryPoint = "WTQOutputECGAndPPGEx", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool OutputECGAndPPGEx (int timeDiffPTTPeak, ref ECG_WAVEFORM ecgWaveform, ref PPG_WAVEFORM ppgChannel1Waveform, ref PPG_WAVEFORM ppgChannel2Waveform,
            OutputSignalCallback cbECG, OutputSignalCallback cbPPGChannel1, OutputSignalCallback cbPPGChannel2);

        [DllImport (DllFilePath, EntryPoint = "WTQOutputPPG", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool OutputPPG (PPGChannel channelNo, ref PPG_WAVEFORM waveform, OutputSignalCallback cb);

        [DllImport (DllFilePath, EntryPoint = "WTQOutputPPGEx", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool OutputPPGEx (ref PPG_WAVEFORM channe1Waveform, ref PPG_WAVEFORM channe2Waveform, OutputSignalCallback cbChannel1, OutputSignalCallback cbChannel2);

        [DllImport (DllFilePath, EntryPoint = "WTQOutputFrequencyScan", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool OutputFrequencyScan (ref FREQUENCY_SCAN scan, OutputSignalCallback cb);

        [DllImport (DllFilePath, EntryPoint = "WTQWaveformPlayerOutputECG", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool WaveformPlayerOutputECG (ref PLAY_RAW_DATA data);

        [DllImport (DllFilePath, EntryPoint = "WTQWaveformPlayerOutputECGAndPPG", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool WaveformPlayerOutputECGAndPPG (ref PLAY_RAW_DATA ecgData, PPGChannel channelNo, ref PLAY_RAW_DATA ppgData);

        [DllImport (DllFilePath, EntryPoint = "WTQWaveformPlayerOutputECGAndPPGEx", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool WaveformPlayerOutputECGAndPPGEx (ref PLAY_RAW_DATA ecgData, ref PLAY_RAW_DATA ppgChanel1Data, ref PLAY_RAW_DATA ppgChanel2Data);

        [DllImport (DllFilePath, EntryPoint = "WTQWaveformPlayerOutputPPG", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool WaveformPlayerOutputPPG (PPGChannel channelNo, ref PLAY_RAW_DATA ppgData);

        [DllImport (DllFilePath, EntryPoint = "WTQWaveformPlayerOutputPPGEx", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs (UnmanagedType.I1)]
        public static extern bool WaveformPlayerOutputPPGEx (ref PLAY_RAW_DATA ppgChanel1Data, ref PLAY_RAW_DATA ppgChanel2Data);

        [DllImport (DllFilePath, EntryPoint = "WTQWaveformPlayerLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern void WaveformPlayerLoop (bool loop);

        [DllImport (DllFilePath, EntryPoint = "WTQStopOutputWaveform", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopOutputWaveform ();

        [DllImport (DllFilePath, EntryPoint = "WTQStopPlayRawData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopPlayRawData ();

        [DllImport (DllFilePath, EntryPoint = "WTQReadStandaloneModeType", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadStandaloneModeType (int mode);

        [DllImport (DllFilePath, EntryPoint = "WTQReadECGModeFromStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus ReadECGModeFromStandaloneMode (int mode, ref ECG_WAVEFORM waveform);

        [DllImport (DllFilePath, EntryPoint = "WTQWriteECGModeToStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus WriteECGModeToStandaloneMode (int mode, ref ECG_WAVEFORM waveform);

        [DllImport (DllFilePath, EntryPoint = "WTQReadPWVModeFromStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus ReadPWVModeFromStandaloneMode (int mode, ref int timeDiffPTTPeak, ref ECG_WAVEFORM ecgWaveform, ref PPG_WAVEFORM ppgWaveform);

        [DllImport (DllFilePath, EntryPoint = "WTQWritePWVModeToStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus WritePWVModeToStandaloneMode (int mode, int timeDiffPTTPeak, ref ECG_WAVEFORM ecgWaveform, ref PPG_WAVEFORM ppgWaveform);

        [DllImport (DllFilePath, EntryPoint = "WTQReadPWVModeExFromStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus ReadPWVModeExFromStandaloneMode (int mode, ref int timeDiffPTTPeak, ref ECG_WAVEFORM ecgWaveform, ref PPG_WAVEFORM ppgChannel1Waveform, ref PPG_WAVEFORM ppgChannel2Waveform);

        [DllImport (DllFilePath, EntryPoint = "WTQWritePWVModeExToStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus WritePWVModeExToStandaloneMode (int mode, int timeDiffPTTPeak, ref ECG_WAVEFORM ecgWaveform, ref PPG_WAVEFORM ppgChannel1Waveform, ref PPG_WAVEFORM ppgChannel2Waveform);

        [DllImport (DllFilePath, EntryPoint = "WTQReadSPO2ModeFromStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus ReadSPO2ModeFromStandaloneMode (int mode, ref PPG_WAVEFORM channe1Waveform, ref PPG_WAVEFORM channe2Waveform);

        [DllImport (DllFilePath, EntryPoint = "WTQWriteSPO2ModeToStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus WriteSPO2ModeToStandaloneMode (int mode, ref PPG_WAVEFORM channe1Waveform, ref PPG_WAVEFORM channe2Waveform);

        [DllImport (DllFilePath, EntryPoint = "WTQReadPPGModeFromStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus ReadPPGModeFromStandaloneMode (int mode, ref PPG_WAVEFORM ppgWaveform);

        [DllImport (DllFilePath, EntryPoint = "WTQWritePPGModeToStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus WritePPGModeToStandaloneMode (int mode, ref PPG_WAVEFORM ppgWaveform);

        [DllImport (DllFilePath, EntryPoint = "WTQReadPPGModeExFromStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus ReadPPGModeExFromStandaloneMode (int mode, ref PPG_WAVEFORM channe1Waveform, ref PPG_WAVEFORM channe2Waveform);

        [DllImport (DllFilePath, EntryPoint = "WTQWritePPGModeExToStandaloneMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern HRSStatus WritePPGModeExToStandaloneMode (int mode, ref PPG_WAVEFORM channe1Waveform, ref PPG_WAVEFORM channe2Waveform);

    }
}
