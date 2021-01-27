using System;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
//using System.IO;                    /*TextReader TextWriter*/
using System.Collections.Generic;
using System.Text;

namespace Modbus
{
    public partial class Modbus 
    {
        public bool bConnected = false;
        public static bool CloseFlag = false;
        public static bool DataPackingFlag_Tcp = false;
        private Thread tAcceptMsg = null;        /* 侦听线程 */       
        public IPEndPoint IPP = null;            /* 用于Socket通信的IP地址和端口 */       
        public Socket socket = null;             /* Socket通信 */

        /* Name:     AcceptMessage()
         * Function: A thread especially for Accept Tcp Message
         *           Used a timer for timeout
         * Return:   void
         */
        public void AcceptMessage()  
        {       
            while (bConnected)
            {
                try
                {
                    string sTemp = ""; 
                    byte[] DataRecv = new byte[1024];
                    int result = socket.Receive(DataRecv);                  /* Waitting for the Data until it comes */
                    Recv_Timer.Stop();                                      /* If time <= 1000 , Timer stops */
                    for (int i = 0; i < result; i++)                        /* 将接收到的byte数据存储到byte数组，并赋与sTemp*/
                    {
                        if (DataRecv[i] < 0x10)
                            sTemp += "0";
                        sTemp += Convert.ToString(DataRecv[i], 16) + " ";
                    }
                    RecvRichTextBox.Text = "Recv    : " + sTemp + "\n" + RecvRichTextBox.Text;


                    Program.Data_Tcp.DataRecv_Tcp = new List<byte> { };
                    for (int i = 0; i < result; i++)
                    {
                        Program.Data_Tcp.DataRecv_Tcp.Add(DataRecv[i]);
                    }
                    DataAnalyze_Tcp();
                }
                catch
                {
                    MessageBox.Show("Disconnected !");
                    TcpInit();
                }
            }
        }

        /* Name:     Connect_Init_Tcp()
         * Function: Init the GUI and the Accept thread
         * Return:   void
         */
        private void Connect_Init_Tcp()
        {
            tAcceptMsg = new Thread(new ThreadStart(AcceptMessage));
            tAcceptMsg.Start();
            bConnected = true;
            Connection.Text = "Already Connected";
            TCP_Startbtn.Text = "Disconnect";
            myIPtextBox.ReadOnly = true;
            tcpListenPortTextBox.ReadOnly = true;
        }

        /* Name:     Disconnect_Tcp()
         * Function: If the Tcp disconnected ,then close
         *           the socket and the Accept thread
         * Return:   void
         */
        private void Disconnect_Tcp()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            tAcceptMsg.Abort();
        }

        /* Name:     TcpInit()
         * Function: Init the gui of Tcp Settings & Tcp send if the net 
         *           connected for the first time or disconnected
         * Return:   void
         */
        public void TcpInit()
        {
            /* Tcp Settings Init */
            if (CloseFlag == false)
            {
                Connection.Text = "No connection";
                TCP_Startbtn.Text = "Connect";
                myIPtextBox.ReadOnly = false;
                tcpListenPortTextBox.ReadOnly = false;
                bConnected = false;
                Tcp_Sendbtn.Enabled = false;

                /* Tcp Data Frame Init */
                Counter_Tcp.Text = "0";
                Func_Code.Text = "Select";
                Addr_Tcp.Text = "0";
                Amount_Tcp.Text = "0";
            }
        }

        private void DataAnalyze_Tcp()
        {
            int Trans = Program.Data_Tcp.DataRecv_Tcp[0] * 256 + Program.Data_Tcp.DataRecv_Tcp[1];
            if (Trans == Convert.ToInt32(Counter_Tcp.Text))
            {
                switch (Program.Data_Tcp.DataRecv_Tcp[7])
                {
                    case 0x01:
                        Read_Tcp("0x01");
                        break;
                    case 0x03:
                        Read_Tcp("0x03");
                        break;
                    case 0x0F:
                        Write_Tcp();
                        break;
                    case 0x10:
                        Write_Tcp();
                        break;
                    default:
                        RecvRichTextBox.Text = "Recv    :" + " Error : Function Code Error !" + "\n" + RecvRichTextBox.Text;
                        break;
                }
            }
            else
            {
                RecvRichTextBox.Text = "Recv    :" + " Error : Transaction Error !" + "\n" + RecvRichTextBox.Text;
            }

        }
        private void Read_Tcp(string s)
        {
            int count1 = Program.Data_Tcp.DataRecv_Tcp.Count;
            int count2 = Program.Data_Tcp.DataSend_Tcp.Count;
            try
            {
                int DataLenSend = 0;
                int DataLenRecv = 0;
                switch (s)
                {
                    case "0x01":
                        // 判断接收的字节总长度与理应接收到长度是否匹配
                        DataLenSend = Program.Data_Tcp.DataSend_Tcp[count2 - 2] * 256 + Program.Data_Tcp.DataSend_Tcp[count2 - 1];
                        if (DataLenSend % 8 != 0)
                        {
                            DataLenSend /= 8;
                            DataLenSend++;
                        }
                        else
                        {
                            DataLenSend /= 8;
                        }
                        break;

                    case "0x03":
                        DataLenSend = Program.Data_Tcp.DataSend_Tcp[count2 - 2] * 256 + Program.Data_Tcp.DataSend_Tcp[count2 - 1];
                        DataLenSend *= 2;
                        break;
                }
                DataLenRecv = Program.Data_Tcp.DataRecv_Tcp[8];
                
                int MBAP_Length = Program.Data_Tcp.DataRecv_Tcp[4] * 256 + Program.Data_Tcp.DataRecv_Tcp[5];
                if (MBAP_Length != count1 - 6)//判断MBAP中长度是否正确
                {
                    Error_Mesg_Tcp("MBAP");                
                }
                else if (Program.Data_Tcp.DataSend_Tcp[7] != Program.Data_Tcp.DataRecv_Tcp[7])//功能码
                {
                    Error_Mesg_Tcp("Func");                  
                }
                else if (Program.Data_Tcp.DataSend_Tcp[6] != Program.Data_Tcp.DataRecv_Tcp[6])//设备ID
                {
                    Error_Mesg_Tcp("UnitID");                  
                }
                else if (DataLenSend != DataLenRecv | count1 != count2 - 4 + 1 + DataLenRecv)//数据区长度
                {
                    Error_Mesg_Tcp("DataLen");                  
                }

                else
                    RecvRichTextBox.Text = "Recv    :" + " Right !" + "\n" + RecvRichTextBox.Text;
                Program.Data_Tcp.DataRecv_Tcp = new List<byte> { };

            }
            catch
            {
                RecvRichTextBox.Text = "Recv    :" + "Error : ReadTcp Error !" + "\n" + RecvRichTextBox.Text;
                Program.Data_Tcp.DataRecv_Tcp = new List<byte> { };
            }
        }
        
        private void Write_Tcp()
        {
            byte [] byteSend = new byte[12] ; 
            for (int i = 0; i < 12; i++)
            {
                byteSend[i] = Program.Data_Tcp.DataSend_Tcp[i];
            }

            byteSend[4] = 0x00;
            byteSend[5] = 0x06;

            byte[] byteRecv = Program.Data_Tcp.DataRecv_Tcp.ToArray();

            if (byteRecv[6] != byteSend[6])
                Error_Mesg_Tcp("UnitID");
            else if (byteRecv[7] != byteSend[7])
                Error_Mesg_Tcp("Func");
            else if (Encoding.Default.GetString(byteRecv) == Encoding.Default.GetString(byteSend))
                RecvRichTextBox.Text = "Recv    :" + " Right !" + "\n" + RecvRichTextBox.Text;          
            else
                Error_Mesg_Tcp("Null");

            Program.Data_Tcp.DataRecv_Tcp = new List<byte> { };
        }

        private void Error_Mesg_Tcp(string s)
        {
            switch (s)
            {
                case "MBAP":
                    RecvRichTextBox.Text = "Recv    :" + " Error : MBAP Data Length Error !" + "\n" + RecvRichTextBox.Text;
                    break;
                case "Func":
                    RecvRichTextBox.Text = "Recv    :" + " Error : Function Code Recv Error !" + "\n" + RecvRichTextBox.Text;
                    break;
                case "UnitID":
                    RecvRichTextBox.Text = "Recv    :" + " Error : Unit ID Error !" + "\n" + RecvRichTextBox.Text;
                    break;
                case "DataLen":
                    RecvRichTextBox.Text = "Recv    :" + " Error : Data Length Error !" + "\n" + RecvRichTextBox.Text;
                    break;
                case "Null":
                    RecvRichTextBox.Text = "Recv    :" + " Error : Data dose not match !" + "\n" + RecvRichTextBox.Text;
                    break;
                default:
                    RecvRichTextBox.Text = "Recv    :" + " Error : Unknown Error !" + "\n" + RecvRichTextBox.Text;
                    break;
            }

        }
    }
}
