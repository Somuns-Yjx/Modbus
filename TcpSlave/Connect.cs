using System;
using System.Windows.Forms;

namespace TcpSlave
{
    public partial class Connect : Form
    {
        public static TcpServer server = new TcpServer();
        
        public Connect()
        {
            InitializeComponent();
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            try
            {
                int port = Convert.ToInt16(txtBoxPort.Text);
                string result = server.OpenServer("127.0.0.1", port, Convert.ToByte(numericUpDownSlaveId.Text));
                if (result != "")
                {
                    MessageBox.Show(result);
                    return;
                }
                btnOpenServer.Enabled = false;
                btnCloseServer.Enabled = true;

            }
            catch (Exception eopen)
            {
                MessageBox.Show(eopen.Message);
            }
        }

        #region 关闭服务器点击事件
        private void btnCloseServer_Click(object sender, EventArgs e)
        {
            server.CloseServer();
            btnCloseServer.Enabled = false;
            btnOpenServer.Enabled = true;
        }
        #endregion

    }
}
