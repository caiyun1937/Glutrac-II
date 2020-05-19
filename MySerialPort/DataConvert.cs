using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlutracUpper
{
    static class DataConvert
    {
        //将字符串转换成16进制
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        public static string ByteToString(byte[] data)
        {
            string returnStr = "";
            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    returnStr += data[i].ToString("X2");
                }
            }
            return returnStr;
        }


        public static string asciiToHex(string str)
        {
            byte[] ba = System.Text.ASCIIEncoding.Default.GetBytes(str);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in ba)
            {
                sb.Append(b.ToString("x") + " ");
            }
            return sb.ToString();
        }
        public static string asciiToTen(string str)
        {
            string d = "";
            for (int i = 0; i < str.Length; i++)
            {
                int ii = (int)Convert.ToChar(str.Substring(i, 1));
                d = d + " " + ii.ToString();
            }
            return d;
        }
        public static string HexStringToString(string hs, Encoding encode)
        {
            string strTemp = "";
            byte[] b = new byte[hs.Length / 2];
            for (int i = 0; i < hs.Length / 2; i++)
            {
                strTemp = hs.Substring(i * 2, 2);
                b[i] = Convert.ToByte(strTemp, 16);
            }
            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }

    }
}
