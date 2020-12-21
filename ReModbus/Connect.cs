using System;
using System.Windows.Forms;

namespace ReModbus
{
    public partial class Connect : Form
    {
        public static TcpClient client = new TcpClient();
        public Connect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连接点击事件
        /// </summary>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string result = client.TcpConnect(txtBoxIp.Text, txtBoxPort.Text);
            if (client.Connect != true)
            {
                MessageBox.Show(result); return;
            }
            client.SetRecvTimeOut(Convert.ToInt32(txtBoxTimeOut.Text));
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
        }

        /// <summary>
        /// 断开连接点击事件
        /// </summary>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.TcpDisconnect();
            if (client.Connect != false)
                return;
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;
        }
    }
}
