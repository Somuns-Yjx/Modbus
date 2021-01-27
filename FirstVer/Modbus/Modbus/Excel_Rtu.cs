using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus
{
    public partial class Excel_Rtu : Form
    {

        public Excel_Rtu()
        {
            InitializeComponent();            
        }


        /* Name:     Write_Load(object sender, EventArgs e)
         * Function: Create a new form
         * Return:   void
         */
        private void Excel_Rtu_Load(object sender, EventArgs e)
        {
            int Quantity = Convert.ToInt32(Modbus.form1.Amount_Rtu.Text);
            int Addr_Rtu = Convert.ToInt32(Modbus.form1.Addr_Rtu.Text);
            try
            {
                /*------ Coil -----*/
                if (Modbus.form1.Func_Code_Rtu.Text == "Coil")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        DataGridView_Rtu.Columns.Add(new DataGridViewTextBoxColumn());
                    }

                    /* Titel of the two lines */
                    DataGridView_Rtu.Columns[0].HeaderText = " NAME";
                    DataGridView_Rtu.Columns[1].HeaderText = " DATA";
                    DataGridView_Rtu.Font = new Font("宋体", 11);

                    int Quantity2 = 0;
                    int addr2 = Addr_Rtu;
                    if (Quantity % 8 == 0)
                        Quantity2 = Quantity / 8;
                    else
                        Quantity2 = Quantity / 8 + 1;
                    for (int i = 0; i < Quantity2 * 8; i++)
                    {
                        Program.Data_Tcp.Coil_Bool_Rtu[addr2++] = true;
                        if (addr2 >= 20000)
                            break;
                    }
                    /* Add Rows*/
                    if (Quantity > 0)
                    {
                        /* Add rows */
                        for (int i = 0; i < Quantity; i++)
                        {
                            int index = DataGridView_Rtu.Rows.Add();
                            DataGridView_Rtu.Rows[index].Cells[1].Value = Program.Data_Tcp.Coil_Rtu[Addr_Rtu];
                            DataGridView_Rtu.Rows[index].Cells[0].Value = Addr_Rtu++;
                        }
                        DataGridView_Rtu.AllowUserToAddRows = false;
                        DataGridView_Rtu.Columns[0].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Warning :Please input a number bigger than \"0\" of Coil Amount ");
                    }
                }

                /*------ Register -----*/
                else if (Modbus.form1.Func_Code_Rtu.Text == "Register")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        DataGridView_Rtu.Columns.Add(new DataGridViewTextBoxColumn());
                    }

                    DataGridView_Rtu.Columns[0].HeaderText = " NAME";
                    DataGridView_Rtu.Columns[1].HeaderText = " DATA";
                    DataGridView_Rtu.Font = new Font("宋体", 11);

                    if (Quantity > 0)
                    {
                        for (int i = 0; i < Quantity; i++)
                        {
                            int index = DataGridView_Rtu.Rows.Add();
                            DataGridView_Rtu.Rows[index].Cells[1].Value = Program.Data_Tcp.Register_Rtu[Addr_Rtu];
                            Program.Data_Tcp.Register_Bool_Rtu[Addr_Rtu] = true;
                            DataGridView_Rtu.Rows[index].Cells[0].Value = Addr_Rtu++;
                        }
                        DataGridView_Rtu.AllowUserToAddRows = false;
                        DataGridView_Rtu.Columns[0].ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Warning :Please input a number bigger than \"0\" of Register Amount ");
                    }
                }
                else
                    MessageBox.Show("Warning :Please select the Function code rightly !");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error:" + er.Message, "Error Create Excel");
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            
            int Addr = Convert.ToInt32(Modbus.form1.Addr_Rtu.Text);
            int Amt = Convert.ToInt32(Modbus.form1.Amount_Rtu.Text);
            /*------------------ Coil ---------------------*/
            if (Modbus.form1.Func_Code_Rtu.Text == "Coil")
            {
                for (int i = 0; i < Amt; i++)
                {
                    string s = Convert.ToString(DataGridView_Rtu.Rows[i].Cells[1].Value);
                    if (s == "0" | s == "1")
                    {
                        Program.Data_Tcp.Coil_Rtu[Addr++] = Convert.ToByte(s);
                    }
                    else
                    {
                        MessageBox.Show("Please Input the right elements !");
                        break;
                    }
                }
            }
            /*------------------ Register -------------------*/
            if (Modbus.form1.Func_Code_Rtu.Text == "Register")
            {
                try
                {
                    for (int i = 0; i < Amt; i++)
                    {
                        string s = Convert.ToString(DataGridView_Rtu.Rows[i].Cells[1].Value);
                        Program.Data_Tcp.Register_Rtu[Addr++] = Convert.ToInt16(s);/* ToInt16 -32768 - 32767*/
                    }
                }
                catch
                {
                    MessageBox.Show("Please Input the Data between -32768 and 32767 !");
                }
            }           
        }
    }
}
