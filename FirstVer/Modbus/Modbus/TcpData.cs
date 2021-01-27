using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Modbus
{
    public partial class Modbus
    {
        /* Name:     TcpSendDataInit()
         * Function: Init the Tcp Datasend
         * Return:   void
         */
        public void TcpSendDataInit()
        {
                         /*--Trans-------Protocol----Length-------ID---Func--Addr--------Amt-----*/
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            Program.Data_Tcp.DataSend_Tcp.AddRange(bytes);
        }

        /* Name:     DataPacking_Tcp()
         * Function: Pack a Tcp Data sending to Slave from the gui
         *           
         * Return:   void
         */
        public void DataPacking_Tcp()
        {
            try
            {
                int count = Program.Data_Tcp.DataSend_Tcp.Count;
                if (count > 12)
                {
                    Program.Data_Tcp.DataSend_Tcp.RemoveRange(12, count - 12);
                    Program.Data_Tcp.DataSend_Tcp[4] = 0x00;
                    Program.Data_Tcp.DataSend_Tcp[5] = 0x06;
                }
                DataPackingFlag_Tcp = true;
                byte Id = (byte)(Convert.ToByte(UnitID.Text));
                Program.Data_Tcp.DataSend_Tcp[6] = Id;
                string FunctionCode_Tcpstr = Convert.ToString(Func_Code.Text);
                byte FunctionCode_Tcp = 0x00;
                switch (FunctionCode_Tcpstr)
                {
                    case "01": FunctionCode_Tcp = 0x01; break;
                    case "03": FunctionCode_Tcp = 0x03; break;
                    case "0F": FunctionCode_Tcp = 0x0f; break;
                    case "10": FunctionCode_Tcp = 0x10; break;
                    default:                                                            /* 非法功能码 */
                        MessageBox.Show("Please select the Function Code rightly !");
                        DataPackingFlag_Tcp = false; break;                                  /* 标志位 */
                }
                Program.Data_Tcp.DataSend_Tcp[7] = FunctionCode_Tcp;

                if (DataPackingFlag_Tcp)
                {
                    try
                    {
                        UInt16 Address_Tcpint = Convert.ToUInt16(Addr_Tcp.Text);
                        UInt16 Amount_Tcpint = Convert.ToUInt16(Amount_Tcp.Text);

                        byte Address_L_Tcp = (byte)(Address_Tcpint & 0x00FF);
                        byte Address_H_Tcp = (byte)(Address_Tcpint >> 8);

                        byte Amount_L_Tcp = (byte)(Amount_Tcpint & 0x00FF);
                        byte Amount_H_Tcp = (byte)(Amount_Tcpint >> 8);

                        Program.Data_Tcp.DataSend_Tcp[8] = Address_H_Tcp;
                        Program.Data_Tcp.DataSend_Tcp[9] = Address_L_Tcp;
                        Program.Data_Tcp.DataSend_Tcp[10] = Amount_H_Tcp;
                        Program.Data_Tcp.DataSend_Tcp[11] = Amount_L_Tcp;
                    }

                    catch
                    {
                        DataPackingFlag_Tcp = false;
                        MessageBox.Show("Please input the Amount between 0 - 65535 !");
                    }
                }

                /* 传输标识 */
                if (Program.Data_Tcp.DataSend_Tcp[1] == 0xFF)
                {
                    Program.Data_Tcp.DataSend_Tcp[1] = 0x00;
                    if (Program.Data_Tcp.DataSend_Tcp[0] != 0xFF)
                        Program.Data_Tcp.DataSend_Tcp[0]++;
                    else
                        Program.Data_Tcp.DataSend_Tcp[0] = 0x00;
                }
                else
                    Program.Data_Tcp.DataSend_Tcp[1]++;
                int Count = Program.Data_Tcp.DataSend_Tcp[0] * 256 + Program.Data_Tcp.DataSend_Tcp[1];
                Counter_Tcp.Text = Count.ToString();
                DataPackingFlag_Tcp = true;

            }
            catch
            {
                DataPackingFlag_Tcp = false;
                MessageBox.Show("Error ! Please fill in all the blanks rightly");
            }
        }


        /* Name:    Datashow()
        * Function: Show the DataFrame(0x01 0x03) or Show the Excel List(0x0F 0x10)
        * Return:   void
        */
        private void Datashow()
        {
            if (Func_Code.Text == "01" | Func_Code.Text == "03")
            {
                Program.Data_Tcp.Read_Tcp = new List<byte> { };
                DataPacking_Tcp();
                int len = Program.Data_Tcp.DataSend_Tcp.Count;
                string stemp = "";
                /* Datashow */
                for (int i = 1; i <= len; i++)
                {
                    if (Program.Data_Tcp.DataSend_Tcp[i - 1] < 0x10)
                        stemp += "0";
                    stemp += Convert.ToString(Program.Data_Tcp.DataSend_Tcp[i - 1], 16) + " ";

                }
                Program.Data_Tcp.Read_Tcp = Program.Data_Tcp.DataSend_Tcp;
                DataFrame.Text = "Send  : " + stemp + "\n";

            }
            else if (Func_Code.Text == "0F")
            {
                DataPacking_Tcp();
                Program.Data_Tcp.Amount = Convert.ToUInt16(Amount_Tcp.Text);
                Write write1 = new Write();
                write1.Show();

            }
            else if (Func_Code.Text == "10")
            {
                DataPacking_Tcp();
                Program.Data_Tcp.Amount = Convert.ToUInt16(Amount_Tcp.Text);
                Write write1 = new Write();
                write1.Show();
            }
            else
                MessageBox.Show("Unknow Error! ");

            Tcp_Sendbtn.Enabled = true;
        }
    }
}

