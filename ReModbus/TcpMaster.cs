using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReModbus
{
    public partial class TcpMaster : Form
    {
        Connect formconnect = new Connect();
        public static Master master = new Master();

        public TcpMaster()
        {
            InitializeComponent();
            master.InitData();                                                                          // 初始化线圈、寄存器
        }

        #region 发送按钮点击事件
        private void btnsend_Click(object sender, EventArgs e)
        {
            if (Connect.client.Connect != true)
                return;
            try
            {  // 从处理层获取事物号；向处理层传入设备号、功能码、地址、数量。
                txtBoxTrans.Text = master.transaction.ToString();
                master.slaveId = Convert.ToByte(numericUpDownSlaveId.Text);
                master.SetFunc(comboFunc.Text);
                bool setResult = master.SetAddrAndAmount(Convert.ToUInt16(numericUpDownAddr.Text), Convert.ToUInt16(numericUpDownAmt.Text));
                if (setResult != true)  // 地址、数量设置失败
                { MessageBox.Show("地址溢出。"); return; }
                Connect.client.Send(master.DataFrameCreate()); // Tcp socket发送
                DataShow("Send", master.send);
                bool res = Connect.client.AcceptMsg();
                if (res != false)
                {
                    DataShow("Recv", master.recv); string result = master.Analyze;
                    richBoxHistory.Text = "Analyze" + " : " + result + "\n" + richBoxHistory.Text;
                }
            }
            catch (Exception ebtnsend)
            {
                MessageBox.Show(ebtnsend.Message);
            }
        }
        #endregion

        #region 下拉框选择事件
        private void comboFunc_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboFunc.Text)
            {
                case "01":
                    numericUpDownAmt.Maximum = 2000;
                    btnSend.Enabled = true;
                    btnCreate.Enabled = false; break;
                case "03":
                    numericUpDownAmt.Maximum = 125;
                    btnSend.Enabled = true;
                    btnCreate.Enabled = false; break;
                case "0F":
                    numericUpDownAmt.Maximum = 1968;
                    btnSend.Enabled = false;
                    btnCreate.Enabled = true; break;
                case "10":
                    numericUpDownAmt.Maximum = 123;
                    btnSend.Enabled = false;
                    btnCreate.Enabled = true; break;
            }
        }
        #endregion

        #region 清空文本框
        private void btnClear_Click(object sender, EventArgs e)
        {
            richBoxHistory.Text = "";
        }
        #endregion

        #region 0F 10 功能码下  表生成

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                UInt16 addr = Convert.ToUInt16(numericUpDownAddr.Text);
                UInt16 amt = Convert.ToUInt16(numericUpDownAmt.Text);
                master.SetFunc(comboFunc.Text);
                bool setResult = master.SetAddrAndAmount(addr, amt);
                if (setResult != true)
                { MessageBox.Show("地址溢出 "); return; }

                dataGridView.Rows.Clear();
                int columncount = dataGridView.ColumnCount;
                // 添加列
                if (columncount != 2)
                {
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                    dataGridView.Columns[0].HeaderText = " Addr";
                    dataGridView.Columns[1].HeaderText = " Value";
                    dataGridView.Font = new Font("Calibri", 11);
                }
                // 添加行 
                for (int i = 0; i < amt; i++)
                {
                    int index = dataGridView.Rows.Add();
                    if (comboFunc.Text == "0F") dataGridView.Rows[index].Cells[1].Value = master.coil[addr];
                    else if (comboFunc.Text == "10") dataGridView.Rows[index].Cells[1].Value = master.register[addr];
                    dataGridView.Rows[index].Cells[0].Value = addr++;
                }
                dataGridView.Columns[0].ReadOnly = true;
                btnSave.Enabled = true;
            }
            catch (Exception ecreate)
            {
                MessageBox.Show(ecreate.Message);
            }
        }
        #endregion

        #region 保存按钮点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = 0;
                for (int addr = master.address; addr < master.address + master.amount; addr++)
                {
                    string result = master.DataChanged(addr, dataGridView.Rows[rowIndex++].Cells[1].Value); // 处理层保存数据
                    if (result != "") { MessageBox.Show(result); return; }
                }
                dataGridView.ClearSelection();                              // 清除选择
                btnSend.Enabled = true;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        #endregion

        /// <summary>
        ///  关闭窗体
        /// </summary>
        private void TcpMaster_FormClosing(object sender, FormClosingEventArgs e)
        { try { System.Environment.Exit(0); } catch { } }// 如果产生异常，是因为没有足够的权限关闭线程

        /// <summary>
        /// 菜单TCP连接点击事件
        /// </summary>
        private void tcp连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formconnect.ShowDialog();
        }

        /// <summary>
        /// 接收、发送数据与解析情况显示
        /// </summary>
        public void DataShow(string type, byte[] data)
        {
            string sTemp = "";
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                if (data[i] < 0x10)
                    sTemp += "0";
                sTemp += Convert.ToString(data[i], 16) + " ";
            }
            richBoxHistory.Text = type + " : " + sTemp + "\n" + richBoxHistory.Text;
        }
    }
}
