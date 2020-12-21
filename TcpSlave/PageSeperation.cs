//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ReModbus
//{
//    class PageSeperation
//    {
//        /// <summary>
//        /// 每页记录数
//        /// </summary>
//        public int pageSize = 100;

//        /// <summary>
//        /// 总记录数
//        /// </summary>
//        public int recordCount = 0;

//        /// <summary>
//        /// 总页数
//        /// </summary>
//        public int pageCount = 0;

//        /// <summary>
//        /// 当前页
//        /// </summary>
//        public int currentPage = 0;

//        DataTable table = new DataTable();

//        /// <summary>
//        /// 分页的方法
//        /// </summary>
//        /// <param name="str"></param>
//        private void PageSorter()
//        {

//            //创建虚拟表
//            DataColumn column1 = new DataColumn("test1", Type.GetType("System.String"));
//            DataColumn column2 = new DataColumn("test2", Type.GetType("System.String"));
//            DataColumn column3 = new DataColumn("test3", Type.GetType("System.String"));

//            table.Columns.Add(column1);             //将列添加到table表中
//            table.Columns.Add(column2);
//            table.Columns.Add(column3);
//            for (int i = 1; i <= 30000; i++)
//            {
//                DataRow dr = table.NewRow();            //table表创建行
//                dr["test1"] = "资产编号" + i.ToString();
//                dr["test2"] = "资产名称" + i.ToString();
//                dr["test3"] = "规格型号" + i.ToString();
//                table.Rows.Add(dr);                     //将数据加入到table表中
//            }

//            recordCount = table.Rows.Count;     //记录总行数
//            pageCount = (recordCount / pageSize);
//            if ((recordCount % pageSize) > 0)
//            {
//                pageCount++;
//            }

//            //默认第一页
//            currentPage = 1;

//            LoadPage();//调用加载数据的方法
//        }
//        /// <summary>
//        /// LoadPage方法
//        /// </summary>
//        private void LoadPage()
//        {
//            if (currentPage < 1) currentPage = 1;
//            if (currentPage > pageCount) currentPage = pageCount;

//            int beginRecord;    //开始指针
//            int endRecord;      //结束指针
//            DataTable dtTemp;
//            dtTemp = table.Clone();

//            beginRecord = pageSize * (currentPage - 1);
//            if (currentPage == 1) beginRecord = 0;
//            endRecord = pageSize * currentPage;

//            if (currentPage == pageCount) endRecord = recordCount;
//            for (int i = beginRecord; i < endRecord; i++)
//            {
//                dtTemp.ImportRow(table.Rows[i]);
//            }

//            dataGridView.Rows.Clear();

//            for (int i = 0; i < dtTemp.Rows.Count; i++)
//            {
//                dataGridView.Rows.Add(new object[] { dtTemp.Rows[i][0], dtTemp.Rows[i][1], dtTemp.Rows[i][2] });
//            }

//            labPageIndex.Text = "当前页: " + currentPage.ToString() + " / " + pageCount.ToString();//当前页
//            labRecordCount.Text = "总行数: " + recordCount.ToString() + " 行";//总记录数
//        }
//        /// <summary>
//        /// 首页
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void btnFirst_Click(object sender, EventArgs e)
//        {
//            if (currentPage == 1)
//            { return; }
//            currentPage = 1;
//            LoadPage();
//        }
//        /// <summary>
//        /// 上一页
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void btnPrev_Click(object sender, EventArgs e)
//        {
//            if (currentPage == 1)
//            { return; }
//            currentPage--;
//            LoadPage();
//        }
//        /// <summary>
//        /// 下一页
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void btnNext_Click(object sender, EventArgs e)
//        {
//            if (currentPage == pageCount)
//            { return; }
//            currentPage++;
//            LoadPage();
//        }
//        /// <summary>
//        /// 尾页
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void btnLast_Click(object sender, EventArgs e)
//        {
//            if (currentPage == pageCount)
//            { return; }
//            currentPage = pageCount;
//            LoadPage();
//        }
//        private void Form1_Load(object sender, EventArgs e)
//        {
//            PageSorter();//分页 
//        }
//    }
//}
