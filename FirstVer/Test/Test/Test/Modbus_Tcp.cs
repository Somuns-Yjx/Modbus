using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO.Ports;
using System.Threading;
using System.IO;


namespace Modbus_Tcp
{
    public partial class Modbus_Tcp : Form
    {
        public Thread AcptMsgThread = null;
        public Modbus_Tcp()
        {
            InitializeComponent();

        }

        Tcp tcp = new Tcp();
        Modbus_Tcp_Master ModbusTcp = new Modbus_Tcp_Master();
        Modbus_Rtu_Slave ModbusRtu = new Modbus_Rtu_Slave();
        private void DisconnectInit_Tcp()
        {
            if (tcp.socket != null)
                tcp.socket.Close();
            if (AcptMsgThread.IsAlive)
                AcptMsgThread.Abort();
            Btn_Start_Tcp.Text = "Connect";
        }



        private void Btn_Start_Tcp_Click(object sender, EventArgs e)
        {
            Timer_ScanStatus.Start();
            try
            {
                if (Btn_Start_Tcp.Text == "Connect")
                {
                    tcp.IPP = new IPEndPoint(IPAddress.Parse(txt_RemoteIP.Text), int.Parse(txt_TcpPort.Text));
                    tcp.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    tcp.socket.Connect(tcp.IPP);
                    if (tcp.socket.Connected)
                    {
                        Btn_Start_Tcp.Text = "Disconnect";
                        tcp.Connect_Init_Tcp();
                        AcptMsgThread = new Thread(new ThreadStart(tcp.AcceptMessage));
                        AcptMsgThread.Start();
                    }

                }
                else if (Btn_Start_Tcp.Text == "Disconnect")
                {
                    DisconnectInit_Tcp();
                }
            }
            catch
            {
                MessageBox.Show("Can not connect to " + "\"" + txt_RemoteIP.Text + "\"");
            }

        }
        
        private void Btn_Create_Tcp_Click(object sender, EventArgs e)
        {
            //byte[] datasend = new byte[] { 0x00, 0x26, 0x00, 0x00, 0x00, 0x09, 0x01, 0x11, 0x00, 0x00, 0x00, 0x01, 0x02, 0x00, 0x6f };
            //byte[] datarecv = new byte[] { 0x00, 0x26, 0x00, 0x00, 0x00, 0x03, 0x01, 0x91, 0x01 };

            //string result = ModbusTcp.DataAnalyze_Tcp(datarecv, datasend);
            //Txt_Recv.Text = result;

            //byte[] datasend = new byte[] { 0x00, 0x26, 0x00, 0x00, 0x00, 0x09, 0x01, 0x11, 0x00, 0x00, 0x00, 0x01, 0x02, 0x00, 0x6f };
            List<byte> datarecv = new List<byte> { 0x01, 0x05, 0x00, 0x00, 0x00, 0x01, 0x0C, 0x0A };
            List<byte> data = new List<byte> { };

            string recv = "Recv = 0x";
            for (int i = 0; i < datarecv.Count; i++)
            {
                if (datarecv[i] < 0x10)
                    recv += "0";
                recv += Convert.ToString(datarecv[i], 16);
                if (i != datarecv.Count - 1)
                    recv += ",0x";
            }

            Txt_Recv.Text = recv + "\n";
            string result = "Send = 0x";

            ModbusRtu._Rtu_Data_Init();

            data = ModbusRtu.DataAnalyze_Rtu(datarecv);



            for (int index = 0; index < data.Count; index++)
            {
                if (data[index] < 0x10)
                    result += "0";
                result += Convert.ToString(data[index], 16) ;
                if (index != data.Count - 1)
                    result += ",0x";
            }
            
            Txt_Recv.Text += result;

        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            if (tcp.connectedflag)
            {
                try
                {

                    byte[] s = { 0x01,0x02,0x03,0x04,0x05};
                    string stemp = "";
                    for (int i = 1; i <= s.Length; i++)
                    {
                        if (s[i - 1] < 0x10)
                            stemp += "0";
                        stemp += Convert.ToString(s[i - 1], 16) + " ";

                    }
                    Txt_Recv.Text = "Send    : " + stemp + "\n" + Txt_Recv.Text;
                    tcp.recvflag = false;
                    tcp.socket.Send(s);
                    Timer_Init();


                }
                catch
                {
                    MessageBox.Show("Connect to " + txt_RemoteIP.Text + "failed !");
                    DisconnectInit_Tcp();
                }
                try
                {

                    if (tcp.recvflag == true)
                    {
                        Timer_Recv.Stop();
                        tcp.DataRecv_Show();
                        if (tcp.DataRecvStr != "")
                            Txt_Recv.Text = "Recv    : " + tcp.DataRecvStr + "\n" + Txt_Recv.Text;
                     
                    }
                }
                catch
                {
                    DisconnectInit_Tcp();
                }
            }
        }
        private void Timer_Init()
        {
            Timer_Recv.Stop();
            Timer_Recv.Interval = Convert.ToInt32(txt_Time_Out.Text);
            Timer_Recv.Start();
        }
        private void Timer_Recv_Tick(object sender, EventArgs e)
        {
            Txt_Recv.Text = "Recv    : Error,Receive time Out ! " + "\n" + Txt_Recv.Text;
            Timer_Recv.Stop();
            tcp.datashowflag = true;
        }
        private void Timer_ScanStatus_Tick(object sender, EventArgs e)
        {
            if (tcp.connectedflag == false && Btn_Start_Tcp.Text == "Disconnect")
            {
                Btn_Start_Tcp.Text = "Connect";
                if (tcp.socket.Connected)
                    tcp.socket.Close();
                if (AcptMsgThread.IsAlive)
                    AcptMsgThread.Abort();
            }

        }
        private void Btn_Clean_Tcp_Click(object sender, EventArgs e)
        {
            Txt_Recv.Text = "";
        }

    }
}
