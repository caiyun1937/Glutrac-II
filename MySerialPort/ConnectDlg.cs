using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace GlutracUpper
{
    public  class ConnectDlg
    {
        public int Baudrate = 115200;
        public int DataBit = 8;
        public StopBits StopBit = StopBits.One;
        public Parity Parity = Parity.None;
        public string Port = "COM1";
        public int StreamCtrl = 1;
        SerialPort m_sio = null;// new SerialPort();

        private byte[] m_buf = new byte[1000]; // 通信数据缓冲区.
        private int m_wIdx = 0;//缓冲区写指针
        private int m_rIdx = 0;//缓冲区读取指针
        private int m_msgSpan = 100;
        private DateTime m_lastRcvTime;
        private Queue<byte[]> m_msgque = new Queue<byte[]>();

        byte[] m_curResp = null;
        byte[] m_curReq = null;
        public ConnectDlg()
        {
            m_sio = new SerialPort();
        }


        public ConnectDlg(string port, int rate) : this()
        {
            // Windows 窗体设计器支持所必需的
            this.Port = port;
            this.Baudrate = rate;
        }

        public ConnectDlg(string port) : this()
        {
            // Windows 窗体设计器支持所必需的
            this.Port = port;

        }

        ///// <summary>
        ///// 清理所有正在使用的资源。
        ///// </summary>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (components != null)
        //        {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose(disposing);
        //}


        public void GetMessage()
        {
            try
            {
                int msgLen = m_wIdx - m_rIdx;
                if (m_rIdx >= m_wIdx)
                {
                    m_wIdx = m_rIdx = 0;
                    return;
                }


                byte[] msg = new byte[msgLen];
                //if (RcvTimeout() && msgLen > 0)
                if(msgLen>0)
                {
                   for (int i = 0; i < msg.Length; i++)
                    {
                        msg[i] = m_buf[m_rIdx++];
                        if (m_rIdx == m_buf.Length)
                            m_rIdx = 0;
                    }
                    m_msgque.Enqueue(msg);
                    m_rIdx = m_wIdx = 0;
                }

            }
            catch (Exception ex)
            {

            }
        }

        // 串口到达字节间隔超过指定时间间隔时的处理
        private bool RcvTimeout()
        {
            try
            {
                if (m_msgSpan == 0)
                    return false;
                if (DateTime.Now.Subtract(m_lastRcvTime).TotalMilliseconds > m_msgSpan)
                    return true;
            }
            catch { }
            return false;
        }

        private void OnDataArriving(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                try
                {
                    while (m_sio.BytesToRead != 0)
                    {
                        if (m_wIdx == m_buf.Length)
                            m_rIdx = m_wIdx = 0;
                        m_lastRcvTime = DateTime.Now; // 该句必须在“启动消息提取线程”的语句之前。
                        m_buf[m_wIdx++] = (byte)m_sio.ReadByte();
                        if (m_wIdx == m_buf.Length)
                            m_wIdx = 0;
                    }
                    GetMessage();
                }
                catch (Exception ex)
                {
                    // LogExcept(ex, "OnDataArriving:");
                }
            }
            catch { }
        }

        public bool OpenSio(string port, int rate)
        {

            if (OpenSio())
                return true;
            else
                return false;
        }


        public bool OpenSio(string port)
        {
            this.Port = port;
            if (OpenSio())
                return true;
            else
                return false;
        }

        public bool OpenSio()
        {
            CloseSio();
            m_sio = new SerialPort();
            m_sio.PortName = Port;
            m_sio.BaudRate = Baudrate;
            m_sio.DataBits = DataBit;
            m_sio.StopBits = StopBit;
            m_sio.Parity = Parity;
            m_sio.DataReceived += new SerialDataReceivedEventHandler(OnDataArriving);
            try
            {
                if (m_sio.IsOpen)
                    m_sio.Close();
                m_sio.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsOpen()
        {
            try
            {
                return m_sio.IsOpen;
            }
            catch { return false; }
        }

        public bool CloseSio()
        {
            try
            {
                if (m_sio != null)
                {
                    m_sio.Close();
                    m_sio.Dispose();
                    m_sio = null;
                    //FlashHint("串口关闭！");
                    //ShowSioState();
                }
                return true;
            }
            catch (Exception ex)
            {
                //LogExcept(ex, "CloseSio:");
                return false;
            }
        }


        public bool sendMsg(byte[] msg)
        {
            try
            {
                if (msg == null)
                    return false;
                if (m_sio.IsOpen)
                {
                    m_sio.Write(msg, 0, msg.Length);
                    m_curResp = null;
                    m_curReq = msg;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool sendMsg(string msg)
        {
            try
            {
                if (msg == null)
                    return false;
                if (m_sio.IsOpen)
                {
                    m_sio.Write(msg);
                    m_curResp = null;
                    m_curReq = DataConvert.strToToHexByte(msg);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //返回读取队列数据
        public byte[] GetQueueMsg()
        {
            byte[] msg = null;
            //if (RcvTimeout())
              //  GetMessage();
            if (m_msgque.Count == 0)
                return null;
            //m_moniTimer.Enabled = false;
            try
            {

                msg = m_msgque.Dequeue();
                return msg;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool QueueMsgIsEmpty()
        {

            if (m_msgque.Count == 0)
                return true;
            return false;

        }

        public void QueueEmpty()
        {
            m_msgque.Clear();
        }
    }
}
