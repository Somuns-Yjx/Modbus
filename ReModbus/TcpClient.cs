using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ReModbus
{
    public class TcpClient     // 该类为Tcp客户端
    {
        private IPEndPoint IPP = null;
        private Socket socket = null;

        /// <summary>
        /// 设置超时时间
        /// </summary>
        public void SetRecvTimeOut(int time)
        {
            socket.ReceiveTimeout = time;
        }

        /// <summary>
        /// 连接状态字段
        /// </summary>
        private bool my_connect = false;
        public bool Connect
        {
            get { return my_connect; }
            set { my_connect = value; }
        }

        /// <summary>
        ///  Tcp连接
        /// </summary>
        public string TcpConnect(string ip, string port)
        {
            try
            {
                if (my_connect == false)
                {
                    IPP = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(IPP);
                }
                Connect = true;
                return "";
            }
            catch (Exception econnect)
            {
                my_connect = false;
                return econnect.Message;
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void TcpDisconnect()
        {
            Connect = false;
            //socket.Close();
            socket.Dispose();      // 释放由 System.Net.Sockets.Socket 类的当前实例占用的所有资源。
        }

        /// <summary>
        ///  发送数据
        /// </summary>
        public void Send(byte[] data)
        {
            if (socket != null && Connect )
            {
                socket.Send(data);
            }
        }

        /// <summary>
        ///  接收线程
        /// </summary>
        public bool AcceptMsg()
        {
            try
            {
                byte[] arrDataRecv = new byte[1024];                // 定义接收数组
                int len = socket.Receive(arrDataRecv);
                List<byte> listDataRecv = new List<byte> { };      // 定义截取列表
                for (int i = 0; i < len; i++)                                       // 截取所需数据
                {
                    listDataRecv.Add(arrDataRecv[i]);
                }
                byte[] arrData = listDataRecv.ToArray();
                TcpMaster.master.DataAnalyze(arrData);            // 解析数据
                return true;
            }
             catch(SocketException e)
            {
                MessageBox.Show(e.Message);
                Connect = false;
                return false;
            }
            catch (Exception edisconnect) // 远程服务器关闭、拔网线
            {
                //if (edisconnect.Message != "正在中止线程。")
                MessageBox.Show(edisconnect.Message);
                return false;
            }
        }

    }
}
