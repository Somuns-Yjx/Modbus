using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Modbus
{
    public partial class Write : Form
    {    
        UInt16 Amount = Program.Data_Tcp.Amount;                /* 上一窗体中寄存器数目参数 */

        public Write()
        {
            InitializeComponent();
        }


        /* Name:     Write_Load(object sender, EventArgs e)
         * Function: Create a new form for Tcp 
         * Return:   void
         */
        private void Write_Load(object sender, EventArgs e)
        {
            int Addr_Tcp = Convert.ToInt32(Modbus.form1.Addr_Tcp.Text);
            int Quantity_Tcp = Convert.ToInt32(Modbus.form1.Amount_Tcp.Text);

            for (int i = 0; i < 2; i++)
            {
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
            }
            dataGridView.Columns[0].HeaderText = " NAME";
            dataGridView.Columns[1].HeaderText = " DATA";
            dataGridView.Font = new Font("宋体", 11);

            /* Add rows */
            for (int i = 0; i < Amount; i++)
            {
                int index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells[1].Value = "0";
                dataGridView.Rows[index].Cells[0].Value = Addr_Tcp++;
            }
            dataGridView.AllowUserToAddRows = false;
            /* Line 0 (Count) readonly */
            dataGridView.Columns[0].ReadOnly = true;
        }


        /* Name:     DataShow_Click(object sender, EventArgs e)
         * Function: Show the DataFrame in Form Modbus TextBox          
         * Return:   void
         */
        private void DataShow_Click(object sender, EventArgs e)
        {
            switch (Modbus.form1.Func_Code.Text)
            {
                case "0F":
                    Program.Data_Tcp.Coil_Tcp = new List<byte> { };
                    /* Delete the elements between [11] to end */
                    int count = Program.Data_Tcp.DataSend_Tcp.Count;
                    if (count > 12)
                    {
                        Program.Data_Tcp.DataSend_Tcp.RemoveRange(12, count - 12);
                        Program.Data_Tcp.DataSend_Tcp[4] = 0x00;
                        Program.Data_Tcp.DataSend_Tcp[5] = 0x06;
                    }
                    /* Calculate the byte of elements which needs to add to the end */
                    int len = 0;
                    if (Amount % 8 == 0)
                        len = Amount / 8;
                    else
                        len = Amount / 8 + 1;

                    /* The Max len of List<byte>Coil_Tcp is 256 : 0x01 0x01 */
                    if (len != 250)
                    {
                        Program.Data_Tcp.DataSend_Tcp[5] += (byte)len;
                        Program.Data_Tcp.DataSend_Tcp[5] += 0x01;
                    }
                    else
                    {
                        Program.Data_Tcp.DataSend_Tcp[4] = 0x01;
                        Program.Data_Tcp.DataSend_Tcp[5] = 0x00;
                    }

                    /* Add the Len2 to the end */
                    Program.Data_Tcp.DataSend_Tcp.Add((byte)len);

                    int s = 0;

                    /* Add the Data to the end (behind len2) */
                    for (int i = 1; i <= Amount; i++)
                    {
                        /* 10011 ->  0001 1001 */
                        int times = i % 8;
                        string stemp = Convert.ToString(dataGridView.Rows[i - 1].Cells[1].Value);
                        if (stemp == "0")
                            s += 0x00;
                        else if (stemp == "1")
                            s += 0x01 << (times - 1);
                        else
                            MessageBox.Show("Please Input \"0\" or \"1\"!");

                        /* End */
                        if (i == Amount)
                        {
                            Program.Data_Tcp.DataSend_Tcp.Add((byte)s);
                            break;
                        }
                        /* One byte */
                        if (i % 8 == 0 && i >= 8)
                        {
                            byte sss = (byte)s;
                            Program.Data_Tcp.DataSend_Tcp.Add(sss);
                            s = 0x00;
                        }
                    }

                    /* Show */
                    byte[] bytetemp = { };
                    /* Transform the List<byte> to byte[] */
                    bytetemp = Program.Data_Tcp.DataSend_Tcp.ToArray();
                    int slen = bytetemp.Length;
                    string stemp2 = "";
                    for (int i = 1; i <= slen; i++)
                    {
                        if (bytetemp[i - 1] < 0x10)
                            stemp2 += "0";
                        stemp2 += Convert.ToString(bytetemp[i - 1], 16) + " ";

                    }

                    Modbus.form1.DataFrame.Text = "Send  : " + stemp2 + "\n";
                    Program.Data_Tcp.Coil_Tcp = Program.Data_Tcp.DataSend_Tcp;
                    break;

                case "10":
                    Program.Data_Tcp.Register_Tcp = new List<byte> { };
                    /* Delete the elements between [11] to end */
                    int count1 = Program.Data_Tcp.DataSend_Tcp.Count;
                    if (count1 > 12)
                    {
                        Program.Data_Tcp.DataSend_Tcp.RemoveRange(12, count1 - 12);
                        Program.Data_Tcp.DataSend_Tcp[4] = 0x00;
                        Program.Data_Tcp.DataSend_Tcp[5] = 0x06;
                    }
                    /* Calculate the byte of elements which needs to add to the end */
                    int len1 = Amount * 2;

                    /* The Max len of List<byte> Register is 256 : 0x01 0x01 */
                    if (len1 != 250)
                    {
                        Program.Data_Tcp.DataSend_Tcp[5] += (byte)len1;
                        Program.Data_Tcp.DataSend_Tcp[5] += 0x01;
                    }
                    else
                    {
                        Program.Data_Tcp.DataSend_Tcp[4] = 0x01;
                        Program.Data_Tcp.DataSend_Tcp[5] = 0x00;
                    }

                    /* Add the Len2 to the end */
                    Program.Data_Tcp.DataSend_Tcp.Add((byte)len1);

                    /* Add the Data to the end (behind len2) */
                    for (int i = 1; i <= Amount; i++)
                    {
                        /* 10011 ->  0001 1001 */
                        int times = i % 8;
                        string stemp_0X10 = dataGridView.Rows[i - 1].Cells[1].Value.ToString();
                        Int16 sstemp = Convert.ToInt16(stemp_0X10, 10); 

                        byte Register_Tcp_L = (byte)(sstemp & 0xFF);
                        byte Register_Tcp_H = (byte)(sstemp >> 8);

                        Program.Data_Tcp.DataSend_Tcp.Add(Register_Tcp_H);
                        Program.Data_Tcp.DataSend_Tcp.Add(Register_Tcp_L);
                        
                    }

                    /* Show */
                    byte[] bytetemp1 = { };
                    /* Transform the List<byte> to byte[] */
                    bytetemp = Program.Data_Tcp.DataSend_Tcp.ToArray();
                    int slen1 = bytetemp.Length;
                    string sstemp2 = "";
                    for (int i = 1; i <= slen1; i++)
                    {
                        if (bytetemp[i - 1] < 0x10)
                            sstemp2 += "0";
                        sstemp2 += Convert.ToString(bytetemp[i - 1], 16) + " ";

                    }

                    Modbus.form1.DataFrame.Text = "Send : " + sstemp2 + "\n";
                    Program.Data_Tcp.Register_Tcp = Program.Data_Tcp.DataSend_Tcp;
                    break;
            }
            DataShow.Enabled = false;            
        }
    }
}
