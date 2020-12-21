using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace TcpSlave
{
    public class TcpServer     // 该类为Tcp服务器
    {

        private bool my_connect = false;
        private IPEndPoint IPP = null;
        private Socket socket = null;
        private Socket socketclient = null;
        private Thread tConnect = null;
        private Thread tAccept = null;

        public static Slave slave = new Slave();
        public static Message message = new Message();


        #region 连接状态字段
        public bool Connect
        {
            get { return my_connect; }
            set { my_connect = value; }
        }
        #endregion

        #region  开启服务器
        public string OpenServer(string ip, int port, byte id)
        {
            try
            {
                IPP = new IPEndPoint(IPAddress.Parse(ip), port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(IPP);
                socket.Listen(0);
                tConnect = new Thread(AcceptConnection);
                tConnect.Start();
                slave.SlaveId = id;
                return "";
            }
            catch (Exception econnect)
            {
                return econnect.Message;
            }
        }
        #endregion

        #region 关闭服务器
        public void CloseServer()
        {
            Connect = false;
            if (socketclient != null)
                socketclient.Close();
            socket.Close();
            if (tAccept != null && tAccept.IsAlive)
                tAccept.Abort();
        }
        #endregion

        #region 接收客户端连接
        private void AcceptConnection()
        {
            try                                                               // 这里用try catch是因为该线程等待连接时(阻塞),关闭服务器（该线程）会产生异常
            {
                while (true)
                {
                    socketclient = socket.Accept();         // 阻塞等待客户端连接
                    Connect = true;
                    tAccept = new Thread(AcpMsg); ;    // 开接收线程
                    tAccept.Start();
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region 接收数据
        private void AcpMsg()
        {
            try
            {
                while (true)
                {
                    byte[] arrDataRecv = new byte[1024];                // 定义接收数组
                    int len = socketclient.Receive(arrDataRecv);
                    if (len == 0) throw new Exception("远程主机强迫关闭了一个现有的连接。");
                    List<byte> listDataRecv = new List<byte> { };      // 定义截取列表
                    for (int i = 0; i < len; i++)                                       // 截取所需数据
                    {
                        listDataRecv.Add(arrDataRecv[i]);
                    }
                    byte[] arrData = listDataRecv.ToArray();
                    message.dataRecv = arrData; message.recvFlag = true;         // 接收的数据传递给消息层
                    byte[] dataShouldSend = slave.DataAnalyze(arrData);             // 解析数据
                    if (dataShouldSend != null)                                                         // 数据解析返回不为空
                    {
                        message.dataSend = dataShouldSend; message.sendFlag = true; // 发送的数据传给消息层
                        socketclient.Send(dataShouldSend);                                      // 发送数据
                    }
                }
            }
            catch (Exception eDisconnect) // 客户端断开连接
            {
                if (eDisconnect.Message != "正在中止线程。" )
                    MessageBox.Show(eDisconnect.Message);
                Connect = false;
                if (socketclient != null)
                    socketclient.Close();
            }
        }
        #endregion






    }
}
