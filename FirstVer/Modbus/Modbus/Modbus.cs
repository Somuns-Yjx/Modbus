using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace Modbus
{
    public partial class Modbus : Form
    {
        public static Modbus form1;
        public Modbus()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            form1 = this;
            Tcp_Sendbtn.Enabled = false;

        }
        public static bool CreateCoilFlag = false;
        public static bool CreateRegisterFlag = false;
        private Thread Savethread = null;


        private void Modbus_Load(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey software11 = hklm.OpenSubKey("HARDWARE");
            Microsoft.Win32.RegistryKey software = software11.OpenSubKey("DEVICEMAP");
            Microsoft.Win32.RegistryKey sitekey = software.OpenSubKey("SERIALCOMM");
            string[] Str2 = System.IO.Ports.SerialPort.GetPortNames();
            int ValueCount = Str2.Length;
            for (int i = 0; i < ValueCount; i++)
            {
                comboPortName.Items.Add(Str2[i]);
            }
            if (comboPortName.Items.Count != 0)
                comboPortName.SelectedIndex = 1;

            //向波特率下拉框里添加波特率值
            comboPortBaudRate.Items.Add("9600");
            comboPortBaudRate.Items.Add("115200");
            comboPortBaudRate.Items.Add("19200");
            comboPortBaudRate.Items.Add("38400");
            comboPortBaudRate.SelectedIndex = 0;
            //向数据位下拉框里添加数据位5,7,8
            comboDataBits.Items.Add("8");
            comboDataBits.Items.Add("7");
            comboDataBits.Items.Add("5");
            comboDataBits.SelectedIndex = 0;
            //向停止位下拉框里添加停止位1,1.5,2
            comboStopBits.Items.Add("1");
            comboStopBits.Items.Add("1.5");
            comboStopBits.Items.Add("2");
            comboStopBits.SelectedIndex = 0;
            //向校验位下拉框里添加检错方式，NONE，ODD，EVEN
            comboParity.Items.Add("NONE");
            comboParity.Items.Add("ODD");
            comboParity.Items.Add("EVEN");
            comboParity.SelectedIndex = 0;

        }

        private void TCP_Startbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TCP_Startbtn.Text == "Connect")
                {
                    IPP = new IPEndPoint(IPAddress.Parse(myIPtextBox.Text), int.Parse(tcpListenPortTextBox.Text));
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    socket.Connect(IPP);
                    if (socket.Connected)                                                       /*连接成功*/
                    {
                        Connect_Init_Tcp();
                        TcpSendDataInit();                                                      /* 发送帧初始化 */
                    }
                }
                else if (TCP_Startbtn.Text == "Disconnect")
                {
                    Disconnect_Tcp();
                    TcpInit();
                }
            }
            catch
            {
                MessageBox.Show("Can not connect to " + "\"" + myIPtextBox.Text + "\"");
            }
        }

        #region
        /* Name:    Create_btn_Click(object sender, System.EventArgs e)
        * Function: Create the DataFrame (0x01 0x03) or Create the Excel List (0x0F 0x10)           
        * Return:   void
        */
        #endregion
        private void Create_Tcp_Click(object sender, System.EventArgs e)
        {
            if (bConnected)
            {
                switch (Func_Code.Text)
                {
                    /* Read coils */
                    case "01":
                        Datashow();
                        break;
                    /*  Read registers */
                    case "03":
                        Datashow();
                        break;
                    /* Write coils */
                    case "0F":
                        if (Convert.ToInt32(Amount_Tcp.Text) <= 2040)
                            Datashow();
                        else
                            MessageBox.Show("Please Input Amount <= \"2040\"");
                        break;
                    /* Write registers */
                    case "10":
                        if (Convert.ToInt32(Amount_Tcp.Text) <= 127)
                            Datashow();
                        else
                            MessageBox.Show("Please Input Amount <= \"127\"");
                        break;
                    case "Select":
                        MessageBox.Show("Please Select the Function Code !");
                        break;
                    default:
                        MessageBox.Show("Please Select the Function Code between 01 03 0F 10 !");
                        break;
                }
            }
            else
                MessageBox.Show("Please Connect to the remote PC !");
        }

        private void Tcp_Sendbtn_Click(object sender, System.EventArgs e)
        {
            if (bConnected)
            {
                try
                {
                    lock (this)
                    {
                        byte[] s = { };
                        s = Program.Data_Tcp.DataSend_Tcp.ToArray();

                        if (DataPackingFlag_Tcp)
                        {
                            int slen = s.Length;
                            string stemp = "";
                            for (int i = 1; i <= slen; i++)
                            {
                                if (s[i - 1] < 0x10)
                                    stemp += "0";
                                stemp += Convert.ToString(s[i - 1], 16) + " ";

                            }
                            RecvRichTextBox.Text = "Send    : " + stemp + "\n" + RecvRichTextBox.Text;
                            socket.Send(s);
                            /* Timer Start*/
                            Recv_Timer.Stop();
                            Recv_Timer.Interval = Convert.ToInt32(Time_Out_Textbox.Text);
                            Recv_Timer.Start();
                            Tcp_Sendbtn.Enabled = false;

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Connect to " + myIPtextBox.Text + "failed !");
                    TcpInit();
                    Disconnect_Tcp();
                }
            }
        }

        private void Recv_Timer_Tick(object sender, EventArgs e)
        {
            RecvRichTextBox.Text = "Recv    : Error,Receive time Out ! " + "\n" + RecvRichTextBox.Text;
            Recv_Timer.Stop();
            Recv_Timer.Interval = Convert.ToInt32(Time_Out_Textbox.Text);

        }

        private void Create_Rtu_Click(object sender, EventArgs e)
        {
            if (Spconnection)
            {
                int Quantity = Convert.ToInt32(Modbus.form1.Amount_Rtu.Text);
                int Addr_Rtu = Convert.ToInt32(Modbus.form1.Addr_Rtu.Text);
                switch (Func_Code_Rtu.Text)
                {
                    case "Coil":
                        if (Addr_Rtu > 19999 | Addr_Rtu < 0)
                            MessageBox.Show("Warning :Please input the Addr between 0 and 19999");
                        else if (Addr_Rtu + Quantity > 20000)
                            MessageBox.Show("Warning :Please input the Addr_Rtu + Amt between 0 and 19999");
                        else
                        {
                            Excel_Rtu excel_rtu1 = new Excel_Rtu();
                            excel_rtu1.Show();
                            CreateCoilFlag = true;
                        }
                        break;
                    case "Register":
                        if (Addr_Rtu > 10000 | Addr_Rtu < 0)
                            MessageBox.Show("Warning :Please input the Addr between 0 and 10000");
                        else if (Addr_Rtu + Quantity > 10000)
                            MessageBox.Show("Warning :Please input the Addr + Amt between 0 and 10000");
                        else
                        {
                            Excel_Rtu excel_rtu2 = new Excel_Rtu();
                            excel_rtu2.Show();
                            CreateRegisterFlag = true;
                        }
                        break;
                    case "Select":
                        MessageBox.Show("Please Select the Function Code !");
                        break;
                    default:
                        MessageBox.Show("Please Select the Function Code between Coil or Register !");
                        break;
                }
            }
            else
                MessageBox.Show("Please Open the serial port !");
        }

        private void Clean_Tcp_Click(object sender, EventArgs e)
        {
            RecvRichTextBox.Text = "";
        }

        private void Clean_Rtu_Click(object sender, EventArgs e)
        {
            SerialRecv_TextBox.Text = "";
        }

        private void Serial_OpenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Serial_OpenBtn.Text == "Open Serial")
                {
                    if (sp.IsOpen)
                    {
                        sp.Close();

                        SerialPortRecv.Abort();

                        Serial_OpenBtn.Text = "Open Serial";
                        MessageBox.Show("Error ,the serial port opened already \nAnd it is closed now");
                    }
                    else
                    {
                        sp.PortName = comboPortName.Text;//设置串口号
                        sp.BaudRate = Convert.ToInt32(comboPortBaudRate.Text);//设置波特率
                        sp.DataBits = Convert.ToInt32(comboDataBits.Text);//设置数据位
                        //设置停止位
                        switch (comboStopBits.Text)
                        {
                            case "1":
                                sp.StopBits = StopBits.One;
                                break;
                            case "1.5":
                                sp.StopBits = StopBits.OnePointFive;
                                break;
                            case "2":
                                sp.StopBits = StopBits.Two;
                                break;
                            default:
                                MessageBox.Show("Error:参数不正确", "Error");
                                break;
                        }

                        //设置校验位
                        switch (comboParity.Text)
                        {
                            case "NONE":
                                sp.Parity = Parity.None;
                                break;
                            case "ODD":
                                sp.Parity = Parity.Odd;
                                break;
                            case "EVEN":
                                sp.Parity = Parity.Even;
                                break;
                            default:
                                MessageBox.Show("Error:参数不正确", "Error");
                                break;
                        }

                        /*-------- Set Time Out ---------*/
                        sp.ReadTimeout = 10;
                        sp.Open();

                        Serial_OpenBtn.Text = "Close Serial";
                        MessageBox.Show("Open serial successfully");

                        /* Thread serial port Recv start */
                        SerialPortRecv = new Thread(new ThreadStart(SpAcceptMessage));
                        SerialPortRecv.Start();
                        Spconnection = true;

                        /*------------ Rtu Data Init ------------*/
                        _Rtu_Data_Init();
                    }
                }
                else
                {
                    /*------ Close Serial -------*/
                    sp.Close();
                    SerialPortRecv.Abort();
                    Spconnection = false;
                    Serial_OpenBtn.Text = "Open Serial";
                    MessageBox.Show("Close serial successfully");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error:" + er.Message, "Error");
                return;
            }

        }

        private void Save_Tcp_Btn_Click(object sender, EventArgs e)
        {
            Savethread = new Thread(new ThreadStart(SaveLog_Tcp));
            Savethread.Start();
        }

        private void Save_Rtu_Btn_Click(object sender, EventArgs e)
        {
            Savethread = new Thread(new ThreadStart(SaveLog_Rtu));
            Savethread.Start();
        }


        private void SaveLog_Tcp()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "(*.txt)|*.txt|(*.*)|*.*",
                    FileName = "Modbus Tcp " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".txt"
                };

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true);
                    streamWriter.Write(RecvRichTextBox.Text);
                    streamWriter.Close();
                }
                Savethread.Abort();
            }
            catch { }
        }

        private void SaveLog_Rtu()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "(*.txt)|*.txt|(*.*)|*.*",
                    FileName = "Modbus Rtu " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".txt"
                };

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true);
                    streamWriter.Write(SerialRecv_TextBox.Text);
                    streamWriter.Close();
                }
                Savethread.Abort();
            }
            catch { }
        }

        /* Name:     Modbus_FormClosing(object sender, FormClosingEventArgs e)
         * Function: If the Form closed , then close all thread, and close the sp                 
         * Return:   void
         */
        private void Modbus_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CloseFlag = true;
                if (socket != null)
                    socket.Close();
                if (tAcceptMsg != null)
                    tAcceptMsg.Abort();
                if (SerialPortRecv != null)
                    SerialPortRecv.Abort();
                if (Savethread != null)
                    Savethread.Abort();
                //if (SerialPortSend != null)
                //    SerialPortSend.Abort();
                if (sp != null)
                {
                    if (sp.IsOpen)
                        sp.Close();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error:" + er.Message, "Error");
            }
        }
    }
}