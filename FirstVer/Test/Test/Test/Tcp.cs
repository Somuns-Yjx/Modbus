using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;


namespace Modbus_Tcp
{
    class Tcp
    {
        public bool connectedflag = false;
        public bool recvflag = false;
        public bool datashowflag = true;
        public IPEndPoint IPP = null;
        public Socket socket = null;
        public byte[] DataRecv = new byte[1024];
        public List<byte> DataRecvList = new List<byte> { };
        public string DataRecvStr = "";
        public int recvlen = 0;
        /// <summary>
        /// 建立连接后初始化
        /// </summary>
        public void Connect_Init_Tcp()
        { 
            connectedflag = true;
        }

        public void AcceptMessage()
        {
            while (connectedflag)
            {
                try
                {
                    if (recvflag == false && datashowflag == true)
                    {
                        DataRecv = new byte[1024];
                        DataRecvStr = "";
                        recvlen = socket.Receive(DataRecv);
                        recvflag = true;
                        datashowflag = false;
                    }
                }
                catch
                {
                    recvflag = false;
                    connectedflag = false;
                    MessageBox.Show("Disconnected !");
                }
            }
        }

        public void DataRecv_Show()
        {

            for (int index = 0; index < recvlen; index++)
            {
                DataRecvList.Add(DataRecv[index]);
            }
            for (int i = 0; i < recvlen; i++)
            {
                if (DataRecv[i] < 0x10)
                    DataRecvStr += "0";
                DataRecvStr += Convert.ToString(DataRecv[i], 16) + " ";
            }
            datashowflag = true;
        }


        
    }
}
