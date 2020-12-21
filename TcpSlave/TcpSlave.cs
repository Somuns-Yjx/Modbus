using System;
using System.Drawing;
using System.Windows.Forms;

namespace TcpSlave
{
    public partial class TcpSlave : Form
    {
        public static Connect connect = new Connect();

        public TcpSlave()
        {
            InitializeComponent();
            TcpServer.slave.InitData();
            timerMsg.Start();
            timerMsg.Interval = 250;
        }

        #region 关闭窗体事件
        private void TcpSlave_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);             // 如果产生异常，则因为没有足够的权限关闭线程
        }
        #endregion

        /// <summary>
        /// 菜单选择Tcp连接 
        /// </summary>
        private void tcp连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connect.ShowDialog();
        }

        /// <summary>
        /// 清除历史记录 
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            richBoxHistory.Text = "";
        }

        #region datagridview页面

        //public int pageSize = 100;
        //public int recordCount = 0;
        public int totalPage = 100;
        public int currentPage = 1;                           // 初始化为第一页
        private bool modtype = true;                       // 线圈为true 寄存器为false

        /// <summary>
        /// dataGridView初加载 
        /// </summary>
        private void LoadPage(bool type)
        {
            dataGridView.Rows.Clear();
            int columnCount = dataGridView.ColumnCount;
            if (columnCount != 2)
            {
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView.Columns[0].HeaderText = " Addr";
                dataGridView.Columns[1].HeaderText = " Value";
                dataGridView.Font = new Font("Calibri", 11);
            }
            // pageIndex = 100 * (currentPage - 1)   第一页 首地址为0，第二页则为100  其实pageIndex = address
            for (int pageIndex = 100 * (currentPage - 1); pageIndex < 100 * currentPage; pageIndex++)
            {
                int index = dataGridView.Rows.Add();
                if (type == true) 
                    dataGridView.Rows[index].Cells[1].Value = TcpServer.slave.coil[pageIndex];
                else
                    dataGridView.Rows[index].Cells[1].Value = TcpServer.slave.register[pageIndex];
                dataGridView.Rows[index].Cells[0].Value = pageIndex;
            }
            dataGridView.ClearSelection();                                                                                          // 清除选择
            labPageNow.Text = "当前页" + currentPage.ToString() + "/" + totalPage.ToString();     // 当前页显示
        }

        private void btnPageClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
                throw new Exception("Unknown Error");
            switch (btn.Text)
            {
                case "首页":
                    if (currentPage != 1) 
                        currentPage = 1; 
                        break;
                case "上一页":
                    if (currentPage == 1) 
                        return; 
                        currentPage--; 
                        break;
                case "下一页":
                    if (currentPage == totalPage) 
                        return; 
                        currentPage++; 
                        break;
                case "末页":
                    if (currentPage == totalPage) 
                        return; 
                        currentPage = totalPage; 
                        break;
                case "刷新": 
                    break;
            }
            LoadPage(modtype);
        }

        /// <summary>
        ///  radiobutton选择点击事件 
        /// </summary>
        private void radioBtnClick(object sender, EventArgs e)
        {
            RadioButton radioBtn = sender as RadioButton;
            if (radioBtn.Text == "线圈") modtype = true; else modtype = false;
            try
            {
                LoadPage(modtype);
                btnFirstPage.Enabled = true;
                btnPrevPage.Enabled = true;
                btnLastPage.Enabled = true;
                btnNextPage.Enabled = true;
                btnFreshPage.Enabled = true;
            }
            catch (Exception eCoilClick)
            {
                MessageBox.Show(eCoilClick.Message);
            }
        }

        /// <summary>
        /// 跳页键盘事件  如果按键是回车，则重加载允许范围内的数据页
        /// </summary>
        private void txtBoxSkip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    int pageSkip = Convert.ToInt16(txtBoxSkip.Text);
                    if (pageSkip > 0 && pageSkip <= totalPage && btnFreshPage.Enabled == true)
                    {
                        currentPage = pageSkip;
                        LoadPage(modtype);
                    }
                }
                catch (Exception eSkip) { MessageBox.Show(eSkip.Message); }
            }
        }
        #endregion

        /// <summary>
        /// 定时器触发事件 扫描信息层，若存在最新数据，则更新ui
        /// </summary>
        private void timerMsg_Tick(object sender, EventArgs e)
        {
            if (TcpServer.message.recvFlag != false)
            {
                TcpServer.message.recvFlag = false;
                DataShow("Recv", TcpServer.message.dataRecv);
            }
            if (TcpServer.message.sendFlag != false)
            {
                TcpServer.message.sendFlag = false;
                DataShow("Send", TcpServer.message.dataSend);
            }
        }

        /// <summary>
        ///  更新历史数据
        /// </summary>
        public void DataShow(string type, byte[] data)
        {
            //if (InvokeRequired)
            //{
            //    UpdateUi updata = new UpdateUi(DataShow);
            //Invoke(updata, new object[] { richBoxHistory.Text });//执行唤醒操作
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
