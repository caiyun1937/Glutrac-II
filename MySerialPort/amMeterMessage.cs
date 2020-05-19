using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlutracUpper
{
    static public class  amMeterMessage
    {

        #region RangeInformation
        public const byte RANGE_1KHZ =0x7D;
        public const byte RANGE_10KHZ =0x7E;
        public const byte RANGE_100KHZ	=0x7F;
        public const byte RANGE_2MOhm	=0xA8;
        public const byte RANGE_200KOhm =0xA9;
        public const byte RANGE_20KOhm	=0xAA;
        public const byte RANGE_2KOhm	=0xAB;
        public const byte RANGE_200Ohm	=0xAC;
        public const byte RANGE_1000A	=0xAD;
        public const byte RANGE_900A=0xAE;
        public const byte RANGE_800A=0xAF;
        public const byte RANGE_700A=0xB0;
        public const byte RANGE_600A=0xB1;
        public const byte RANGE_500A=0xB2;
        public const byte RANGE_400A=0xB3;
        public const byte RANGE_300A=0xB4;
        public const byte RANGE_100A=0xB5;
        public const byte RANGE_10A =0xB6;
        public const byte RANGE_30A =0xB7;
        public const byte RANGE_40A =0xB8;
        public const byte RANGE_50A =0xB9;
        public const byte RANGE_60A =0xBA;
        public const byte RANGE_70A =0xBB;
        public const byte RANGE_80A =0xBC;
        public const byte RANGE_90A =0xBD;
        public const byte RANGE_20A =0xBE;
        public const byte RANGE_200A=0xBF;
        public const byte RANGE_2V  =0xC1;
        public const byte RANGE_20V =0xC2;
        public const byte RANGE_20mV=0xC3;
        public const byte RANGE_200V=0xC4;
        public const byte RANGE_200mV=0xC5;
        public const byte RANGE_4V  =0xC6;
        public const byte RANGE_40V =0xC7;
        public const byte RANGE_40mV=0xC8;
        public const byte RANGE_400V=0xC9;
        public const byte RANGE_400mV=0xCA;
        public const byte RANGE_5V  =0xCB;
        public const byte RANGE_50V =0xCC;
        public const byte RANGE_50mV=0xCD;
        public const byte RANGE_500V=0xCE;
        public const byte RANGE_500mV=0xCF;
        public const byte RANGE_6V  =0xD0;
        public const byte RANGE_60V =0xD1;
        public const byte RANGE_60mV=0xD2;
        public const byte RANGE_600V=0xD3;
        public const byte RANGE_600mV=0xD4;
        public const byte RANGE_2A  =0xD5;
        public const byte RANGE_2mA =0xD6;
        public const byte RANGE_20mA=0xD7;
        public const byte RANGE_200mA=0xD8;
        public const byte RANGE_200uA=0xD9;
        public const byte RANGE_4mA =0xDA;
        public const byte RANGE_40mA=0xDB;
        public const byte RANGE_400mA=0xDC;
        public const byte RANGE_400uA=0xDD;
        public const byte RANGE_5mA =0xDE;
        public const byte RANGE_50mA=0xDF;
        public const byte RANGE_500mA=0xE0;
        public const byte RANGE_500uA=0xE1;
        public const byte RANGE_6mA =0xE2;
        public const byte RANGE_60mA=0xE3;
        public const byte RANGE_600mA=0xE4;
        public const byte RANGE_600uA=0xE5;
        public const byte RANGE_4A  =0xE6;
        public const byte RANGE_5A  =0xE7;
        public const byte RANGE_6A  =0xE8;
        public const byte RANGE_2KV =0xE9;
        public const byte RANGE_NKV =0xEA;
        public const byte RANGE_2mV =0xEB;
        public const byte RANGE_20uA=0xEB;
        public const byte RANGE_2KA =0xED;
        public const byte RANGE_NKA =0xEE;
        public const byte RANGE_700V =0xEF;
        #endregion


        #region Kind information
        public const byte CLASS_DC =0x10;
        public const byte CLASS_AC	=0x20;

        public const byte CLASS_FOUR_HALF =0x01;
        public const byte CLASS_THREE_HALF	=0x02;

        public const byte CLASS_DC_FOUR_HALF =0x11;
        public const byte CLASS_DC_THREE_HALF =0x12;
        public const byte CLASS_AC_FOUR_HALF =0x21;
        public const byte CLASS_AC_THREE_HALF	=0x22;
		#endregion
		/*=============================================
		* * Get Fraction()
		* 通过量程及类别信息获取小数位数
		* 即真实值与测量值的倍率关系
		*===========================================*/
		public static byte GetFraction(byte kind, byte range)
		{
			byte N;

			if ((kind & 0x0F) == CLASS_FOUR_HALF)
			{
				switch (range)
				{
					case RANGE_2V:
					case RANGE_2A:
					case RANGE_2mA: N = 4; break;

					case RANGE_4V:
					case RANGE_5V:
					case RANGE_6V:
					case RANGE_4mA:
					case RANGE_5mA:
					case RANGE_6mA:
					case RANGE_4A:
					case RANGE_5A:
					case RANGE_6A:
					case RANGE_10A:
					case RANGE_20V:
					case RANGE_20A:
					case RANGE_20mA:
					case RANGE_20mV: N = 3; break;

					case RANGE_40V:
					case RANGE_50V:
					case RANGE_60V:
					case RANGE_40mV:
					case RANGE_50mV:
					case RANGE_60mV:
					case RANGE_40mA:
					case RANGE_50mA:
					case RANGE_60mA:
					case RANGE_30A:
					case RANGE_40A:
					case RANGE_50A:
					case RANGE_60A:
					case RANGE_70A:
					case RANGE_80A:
					case RANGE_90A:
					case RANGE_100A:
					case RANGE_200A:
					case RANGE_200V:
					case RANGE_200mA:
					case RANGE_200uA:
					case RANGE_200mV: N = 2; break;

					case RANGE_2KV:
					case RANGE_400V:
					case RANGE_500V:
					case RANGE_600V:
					case RANGE_700V:
					case RANGE_400mV:
					case RANGE_500mV:
					case RANGE_600mV:
					case RANGE_400mA:
					case RANGE_500mA:
					case RANGE_600mA:
					case RANGE_400uA:
					case RANGE_500uA:
					case RANGE_600uA:
					case RANGE_300A:
					case RANGE_400A:
					case RANGE_500A:
					case RANGE_600A:
					case RANGE_700A:
					case RANGE_800A:
					case RANGE_900A:
					case RANGE_1000A: N = 1; break;

					default: N = 0; break;

				}
			}
			else
			{
				switch (range)
				{
					case RANGE_2V:
					case RANGE_2A:
					case RANGE_2mA:
					case RANGE_1KHZ:
					case RANGE_2KOhm: N = 3; break;

					case RANGE_4V:
					case RANGE_5V:
					case RANGE_6V:
					case RANGE_4mA:
					case RANGE_5mA:
					case RANGE_6mA:
					case RANGE_4A:
					case RANGE_5A:
					case RANGE_6A:
					case RANGE_10A:
					case RANGE_20V:
					case RANGE_20A:
					case RANGE_20mA:
					case RANGE_20mV:
					case RANGE_10KHZ:
					case RANGE_20KOhm: N = 2; break;

					case RANGE_40V:
					case RANGE_50V:
					case RANGE_60V:
					case RANGE_40mV:
					case RANGE_50mV:
					case RANGE_60mV:
					case RANGE_40mA:
					case RANGE_50mA:
					case RANGE_60mA:
					case RANGE_30A:
					case RANGE_40A:
					case RANGE_50A:
					case RANGE_60A:
					case RANGE_70A:
					case RANGE_80A:
					case RANGE_90A:
					case RANGE_100A:
					case RANGE_200A:
					case RANGE_200V:
					case RANGE_200mA:
					case RANGE_200uA:
					case RANGE_200mV:
					case RANGE_200Ohm:
					case RANGE_200KOhm:
					case RANGE_100KHZ: N = 1; break;

					case RANGE_2KV:
					case RANGE_400V:
					case RANGE_500V:
					case RANGE_600V:
					case RANGE_700V:
					case RANGE_400mV:
					case RANGE_500mV:
					case RANGE_600mV:
					case RANGE_400mA:
					case RANGE_500mA:
					case RANGE_600mA:
					case RANGE_400uA:
					case RANGE_500uA:
					case RANGE_600uA:
					case RANGE_300A:
					case RANGE_400A:
					case RANGE_500A:
					case RANGE_600A:
					case RANGE_700A:
					case RANGE_800A:
					case RANGE_900A:
					case RANGE_1000A:
					case RANGE_2MOhm: N = 0; break;

					default: N = 0; break;
				}
			}

			return N;
		}

		#region message
       public const byte CMD_REQUEST_CONTINUOUS_DATA= 0xF1 ;   /* 请求连续数据(控制连接，原 CMD_CONNECT) */
       public const byte CMD_STOP_CONTINUOUS_DATA= 0xF2 ;   /* 停止连续数据(控制断开，原 CMD_UNCONNECT) */
       public const byte CMD_ACK= 0xF3 ;   /* 控制应答 */
       public const byte CMD_GET_INFO= 0xF4 ;   /* 读取量程信息 */
       public const byte CMD_RET_INFO= 0xF5 ;   /* 量程信息返回 */
       public const byte CMD_RET_DATA= 0xF6 ;   /* 测量数据返回 */
       public const byte CMD_SET_DP_SEL= 0xF7 ;   /* 小数点位置设置 */
       public const byte CMD_SET_SPS= 0xF8 ;   /* 采样速率设置 */
       public const byte CMD_SET_BAUD= 0xF9 ;   /* 更改通信波特率(重新上电后生效) */
       public const byte CMD_GET_DATA= 0xFE ;   /* 单次读取测量值(适用于扫描读取方式) */
       public const byte CMD_SET_RANGE= 0xA1 ;   /* 更改换算量程(仅限于 75mV 分流器专配表和三位半全量程电阻表) */
		public const sbyte FIEX_CMD_LOCATION = 3;
		public const sbyte FIEX_Len_LOCATION = 2;
		public static byte[] FIEX_HEAD = new byte[] { 0xAA, 0x55 };
		public static byte[] checkSum(byte[] data)
		{
			byte[] redata = new byte[2];
			UInt16 sum = 0;
			foreach (byte da in data)
				sum += da;
			redata[0] = (byte)sum;
			redata[1] = (byte)(sum >> 8);
			return redata;
			
		}
	
        #endregion

		
    }
}
