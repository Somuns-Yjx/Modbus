using System;
using System.Windows.Forms;
using System.IO;                    /*TextReader TextWriter*/
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Modbus
{
    public partial class Modbus
    {
        private Thread SerialPortRecv = null;
        public bool Spconnection = false;
        private SerialPort sp = new SerialPort();//定义SerialPort并实例化

        /* Name:     SpAcceptMessage()  
         * Function: A thread especially for Accept Rtu Message
         *           Used a interrupt for catch
         * Return:   void
         */
        public void SpAcceptMessage()
        {
            while (Spconnection)
            {
                try
                {
                    while (true)
                    {
                        int bytetemp = sp.ReadByte();
                        Program.Data_Tcp.DataRecv_Rtu.Add((byte)bytetemp);
                    }
                }

                catch
                {
                    if (Program.Data_Tcp.DataRecv_Rtu.Count != 0)
                    {
                        string sTemp = "0x";
                        int count = Program.Data_Tcp.DataRecv_Rtu.Count;
                        for (int i = 0; i < count; i++)
                        {
                            if (Program.Data_Tcp.DataRecv_Rtu[i] < 0x10)
                                sTemp += "0";
                            sTemp += Convert.ToString(Program.Data_Tcp.DataRecv_Rtu[i], 16);
                            if (i != count - 1)
                                sTemp += ",0x";
                        }
                        SerialRecv_TextBox.Text = "Recv = " + sTemp + "\n" + SerialRecv_TextBox.Text;
                        SpDataSend();
                    }
                }
            }
        }

        /* Name:     SpDataSend()
         * Function: 
         * Return:   void
         */
        public void SpDataSend()
        {
            try
            {
                DataAnalyze_Rtu();

                byte[] s = Program.Data_Tcp.DataRecv_Rtu.ToArray();
                int len = s.Length;
                sp.Write(s, 0, len);
                string stemp = "0x";
                int count = Program.Data_Tcp.DataRecv_Rtu.Count;

                for (int i = 0; i < count; i++)
                {
                    if (Program.Data_Tcp.DataRecv_Rtu[i] < 0x10)
                        stemp += "0";
                    stemp += Convert.ToString(Program.Data_Tcp.DataRecv_Rtu[i], 16);
                    if (i != count - 1)
                        stemp += ",0x";
                }
                if (stemp != "")
                {
                    SerialRecv_TextBox.Text = "Send = " + stemp + "\n" + SerialRecv_TextBox.Text;
                }
                Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
            }
            catch
            {
                /*---------- Serial port closed ----------*/
                Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
            }

        }

        /* Name:     DataAnalyze_Rtu()
         * Function: Analyze the Data Received, Judge whether it is a Correct Frame or not,
         *           and how to reply to the remote   
         *           Include Slave ID , Crc check , Data length & Parament Judge
         * Return:   void
         */
        public void DataAnalyze_Rtu()
        {
            /*-------Slave ID first-------*/
            if (Program.Data_Tcp.DataRecv_Rtu[0].ToString() != SlaveID_Rtu.Text)
            {
                Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
                return;
            }
            /*-------Crc Check Second------*/
            byte[] DataRecv_Rtu_copy = Program.Data_Tcp.DataRecv_Rtu.ToArray();
            int count = Program.Data_Tcp.DataRecv_Rtu.Count;
            byte crc1 = Program.Data_Tcp.DataRecv_Rtu[count - 2];
            byte crc2 = Program.Data_Tcp.DataRecv_Rtu[count - 1];
            Program.Data_Tcp.DataRecv_Rtu.RemoveRange(count - 2, 2);
            CrcCheck_Rtu();
            /*---------------------  CRC Right? ----------------------*/
            if (crc1 != Program.Data_Tcp.DataRecv_Rtu[count - 2] | crc2 != Program.Data_Tcp.DataRecv_Rtu[count - 1])
            {
                string stemp = "Crc Error";
                SerialRecv_TextBox.Text = "Erro   : " + stemp + "\n" + SerialRecv_TextBox.Text;
                Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
                return;
            }
            /*------------------  DataLength Right? ---------------------*/
            int Addr = Program.Data_Tcp.DataRecv_Rtu[2] * 256 + Program.Data_Tcp.DataRecv_Rtu[3];
            int Amt = Program.Data_Tcp.DataRecv_Rtu[4] * 256 + Program.Data_Tcp.DataRecv_Rtu[5];
            Program.Data_Tcp.DataRecv_Rtu.RemoveRange(count - 2, 2);
            int DataLength = Program.Data_Tcp.DataRecv_Rtu.Count;

            switch (Program.Data_Tcp.DataRecv_Rtu[1])
            {
                case 0x01:
                    if (DataLength != 6)
                    {
                        SerialRecv_TextBox.Text = "Erro   : " + "DataLength Error" + "\n" + SerialRecv_TextBox.Text;
                        Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
                        break;
                    }
                    if (CreateCoilFlag == true)
                    {
                        if (Addr + Amt > 20000)
                        {
                            Error_Code("0x02");
                        }
                        else if (Amt == 0 | Amt > 2040)
                        {
                            Error_Code("0x03");
                        }
                        else if (Amt != 0)
                        {
                            _0x01_Rtu();
                        }
                    }
                    else
                    {
                        Error_Code("0x01");
                    }
                    break;

                case 0x03:
                    if (DataLength != 6)
                    {
                        SerialRecv_TextBox.Text = "Erro   : " + "DataLength Error" + "\n" + SerialRecv_TextBox.Text;
                        Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
                        break;
                    }
                    if (CreateRegisterFlag != true)
                    {
                        Error_Code("0x01");
                        break;
                    }
                    if (Addr + Amt >= 10000)
                    {
                        Error_Code("0x02");
                    }
                    else if (Amt == 0 | Amt > 127)
                    {
                        Error_Code("0x03");
                    }
                    else if (Amt != 0)
                    {
                        _0x03_Rtu();
                    }
                    break;

                case 0x0F:
                    if (Amt == 0)
                    {
                        Error_Code("0x03");
                        break;
                    }
                    if (DataLength != 6 + Program.Data_Tcp.DataRecv_Rtu[6] + 1)
                    {
                        SerialRecv_TextBox.Text = "Erro   : " + "DataLength Error" + "\n" + SerialRecv_TextBox.Text;
                        Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
                        break;
                    }
                    if (CreateCoilFlag != true)
                    {
                        Error_Code("0x01");
                    }
                    if (Addr + Amt > 20000)
                    {
                        Error_Code("0x02");
                    }
                    else if (Amt > 2040)
                    {
                        Error_Code("0x03");
                    }
                    else if (Amt != 0)
                    {
                        _0x0F_Rtu();
                    }
                    break;

                case 0x10:
                    try
                    {
                        if (Amt == 0)
                        {
                            Error_Code("0x03");
                            break;
                        }
                        if (DataLength != 6 + Program.Data_Tcp.DataRecv_Rtu[6] + 1)
                        {
                            SerialRecv_TextBox.Text = "Erro   : " + "DataLength Error" + "\n" + SerialRecv_TextBox.Text;
                            Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
                            break;
                        }
                        if (CreateRegisterFlag != true)
                        {
                            Error_Code("0x01");
                            break;
                        }
                        if (Addr + Amt >= 10000)
                        {
                            Error_Code("0x02");
                        }
                        else if (Amt > 127)
                        {
                            Error_Code("0x03");
                        }
                        else if (Amt != 0)
                        {
                            _0x10_Rtu();
                        }
                    }
                    catch
                    {
                        SerialRecv_TextBox.Text = "Erro   : " + "DataLength Error" + "\n" + SerialRecv_TextBox.Text;
                        Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
                    }
                    break;
            }
            int counttemp = Program.Data_Tcp.DataRecv_Rtu.Count;
            if (counttemp != 0)
                CrcCheck_Rtu();
        }


        /* Name:     CrcCheck_Rtu()
         * Function: Crc_16 Check         
         * Return:   void
         */
        public void CrcCheck_Rtu()
        {
            UInt16 CrcReg = 0xFFFF;

            for (int i = 0; i < Program.Data_Tcp.DataRecv_Rtu.Count; i++)
            {
                CrcReg ^= Program.Data_Tcp.DataRecv_Rtu[i];
                for (int j = 0; j < 8; j++)
                {
                    int Lastbit = CrcReg & 0x0001;

                    if (Lastbit == 1)
                    {
                        CrcReg >>= 1;
                        CrcReg ^= 0xA001;
                    }
                    else
                        CrcReg >>= 1;
                }
            }
            Program.Data_Tcp.DataRecv_Rtu.Add((byte)(CrcReg & 0x00FF));
            Program.Data_Tcp.DataRecv_Rtu.Add((byte)(CrcReg >> 8));
        }

        /* Name:     _Rtu_Data_Init()
         * Function: Init the Rtu Data in the local
         *           Coil_Rtu for 0x00(byte)  for the amount of 20000 (0  - 19999)
         *           Coil_Bool_Rtu            All false
         *           Register for 0(short)    for the amount of 10000 (0  -  9999)
         *           Register_Bool_Rtu        All false
         * Return:   void
         */
        private void _Rtu_Data_Init()
        {
            /*---------- Init Coil all 0x00 ---------*/
            /*---------- Coil Bool All False --------*/
            for (int i = 0; i < 20000; i++)
            {
                Program.Data_Tcp.Coil_Rtu.Add(0x00);
                Program.Data_Tcp.Coil_Bool_Rtu.Add(false);
            }
            /*-------- Init Register All 0 -------*/
            for (int j = 0; j < 10000; j++)
            {
                Program.Data_Tcp.Register_Rtu.Add(0);
                Program.Data_Tcp.Register_Bool_Rtu.Add(false);
            }
        }

        /* Name:     _0x01_Rtu()
         * Function: Rtu_Slave 0x01
         * Return:   void
         */
        private void _0x01_Rtu()
        {
            int Addr = Program.Data_Tcp.DataRecv_Rtu[2] * 256 + Program.Data_Tcp.DataRecv_Rtu[3];
            int Amt = Program.Data_Tcp.DataRecv_Rtu[4] * 256 + Program.Data_Tcp.DataRecv_Rtu[5];
            int count = Program.Data_Tcp.DataRecv_Rtu.Count;
            int bytes = 0;
            if (Amt % 8 == 0)
                bytes = Amt / 8;
            else
                bytes = Amt / 8 + 1;
            byte s = 0x00;
            int times = 0;
            Program.Data_Tcp.DataRecv_Rtu.RemoveRange(2, count - 2);
            Program.Data_Tcp.DataRecv_Rtu.Add((byte)bytes);

            for (int i = Addr; i < (Addr + Amt); i++)
            {
                /*-------------------- whether the Addr is opened or not ? ------------------------*/
                if (Program.Data_Tcp.Coil_Bool_Rtu[i] != true)
                {
                    /*--------- Error Code 0x02 ---------*/
                    int count2 = Program.Data_Tcp.DataRecv_Rtu.Count;
                    Program.Data_Tcp.DataRecv_Rtu.RemoveRange(1, count2 - 1);
                    Program.Data_Tcp.DataRecv_Rtu.Add(0x81);
                    Program.Data_Tcp.DataRecv_Rtu.Add(0x02);
                    break;
                }
                if (times == 7)
                {
                    s += (byte)(Program.Data_Tcp.Coil_Rtu[i] << times);
                    Program.Data_Tcp.DataRecv_Rtu.Add(s);
                    s = 0x00;
                    times = 0;
                }
                else if (i == (Addr + Amt - 1))
                {
                    s += (byte)(Program.Data_Tcp.Coil_Rtu[i] << times);
                    Program.Data_Tcp.DataRecv_Rtu.Add(s);
                    s = 0x00;
                }
                else
                {
                    s += (byte)(Program.Data_Tcp.Coil_Rtu[i] << times);
                    times++;
                }                                     
            }
        }

        /* Name:     _0x03_Rtu()
         * Function: Rtu_Slave 0x03
         * Return:   void
         */
        private void _0x03_Rtu()
        {

            int Addr = Program.Data_Tcp.DataRecv_Rtu[2] * 256 + Program.Data_Tcp.DataRecv_Rtu[3];
            int Amt = (Program.Data_Tcp.DataRecv_Rtu[4] * 256 + Program.Data_Tcp.DataRecv_Rtu[5]);
            int count = Program.Data_Tcp.DataRecv_Rtu.Count;
            byte s = 0x00;
            Program.Data_Tcp.DataRecv_Rtu.RemoveRange(2, count - 2);
            Program.Data_Tcp.DataRecv_Rtu.Add((byte)(Amt * 2));

            for (int i = Addr; i < (Addr + Amt); i++)
            {
                if (Program.Data_Tcp.Register_Bool_Rtu[i] != true)
                {
                    int count1 = Program.Data_Tcp.DataRecv_Rtu.Count;
                    Program.Data_Tcp.DataRecv_Rtu.RemoveRange(1, count1 - 1);
                    Program.Data_Tcp.DataRecv_Rtu.Add(0x83);
                    Program.Data_Tcp.DataRecv_Rtu.Add(0x02);
                    break;
                }
                try
                {
                    s = (byte)(Program.Data_Tcp.Register_Rtu[i] >> 8);
                    Program.Data_Tcp.DataRecv_Rtu.Add(s);
                    s = (byte)(Program.Data_Tcp.Register_Rtu[i] & 0xFF);
                    Program.Data_Tcp.DataRecv_Rtu.Add(s);
                }
                catch
                {
                    MessageBox.Show("Unknown Error!");
                }                
            }
        }

        /* Name:     _0x0F_Rtu()
         * Function: Rtu_Slave 0x0F
         * Return:   void
         */
        private void _0x0F_Rtu()
        {
            int Addr = Program.Data_Tcp.DataRecv_Rtu[2] * 256 + Program.Data_Tcp.DataRecv_Rtu[3];
            int Amt = Program.Data_Tcp.DataRecv_Rtu[4] * 256 + Program.Data_Tcp.DataRecv_Rtu[5];
            int count = Program.Data_Tcp.DataRecv_Rtu.Count;
            int bytes = 0;
            /*----------- What if Amt != bytes ? ---------*/
            if (Amt % 8 == 0)
                bytes = Amt / 8;
            else
                bytes = Amt / 8 + 1;
            int j = Program.Data_Tcp.DataRecv_Rtu[6];
            /*----------  BreakFlag ------------*/
            bool BreakFlag = false;
            for (int k = 0; k < j; k++)
            {
                if (BreakFlag == true)
                    break;
                byte s = Program.Data_Tcp.DataRecv_Rtu[k + 7];
                for (int i = 0; i < 8; i++)
                {
                    if (Program.Data_Tcp.Coil_Bool_Rtu[Addr] == true)
                    {
                        Program.Data_Tcp.Coil_Rtu[Addr++] = (byte)(s & 0x01);
                        if (Addr >= 20000)
                            break;
                        s >>= 1;
                    }
                    else
                    {
                        BreakFlag = true;
                        int count1 = Program.Data_Tcp.DataRecv_Rtu.Count;
                        Program.Data_Tcp.DataRecv_Rtu.RemoveRange(1, count1 - 1);
                        Program.Data_Tcp.DataRecv_Rtu.Add(0x8F);
                        Program.Data_Tcp.DataRecv_Rtu.Add(0x02);
                        break;
                    }
                }
            }
            if (BreakFlag != true)
                Program.Data_Tcp.DataRecv_Rtu.RemoveRange(6, count - 6);
        }

        /* Name:     _0x10_Rtu()
         * Function: Rtu_Slave 0x10
         * Return:   void
         */
        private void _0x10_Rtu()
        {
            int Addr = Program.Data_Tcp.DataRecv_Rtu[2] * 256 + Program.Data_Tcp.DataRecv_Rtu[3];
            int Amt = (Program.Data_Tcp.DataRecv_Rtu[4] * 256 + Program.Data_Tcp.DataRecv_Rtu[5]);
            int count = Program.Data_Tcp.DataRecv_Rtu.Count;
            int j = Program.Data_Tcp.DataRecv_Rtu[6];

            bool BreakFlag = false;
            try
            {
                for (int k = 0; k < j; )
                {
                    if (Program.Data_Tcp.Register_Bool_Rtu[Addr] != true)
                    {
                        BreakFlag = true;
                        int count1 = Program.Data_Tcp.DataRecv_Rtu.Count;
                        Program.Data_Tcp.DataRecv_Rtu.RemoveRange(1, count1 - 1);
                        Program.Data_Tcp.DataRecv_Rtu.Add(0x80);
                        Program.Data_Tcp.DataRecv_Rtu.Add(0x02);
                        break;        
                    }
                        Int16 temp = Program.Data_Tcp.DataRecv_Rtu[k + 7];
                        temp <<= 8;
                        temp += Program.Data_Tcp.DataRecv_Rtu[k + 8];
                        Program.Data_Tcp.Register_Rtu[Addr++] = temp;
                        temp = 0;
                        k += 2;                                    
                }
                if (BreakFlag != true)
                    Program.Data_Tcp.DataRecv_Rtu.RemoveRange(6, count - 6);
            }
            catch
            {
                SerialRecv_TextBox.Text = "Erro   : " + "Master is trying to write out of range of (-32768 - 32767)" + "\n" + SerialRecv_TextBox.Text;
                Program.Data_Tcp.DataRecv_Rtu = new List<byte> { };
            }
        }

        /* Name:     Error_Code(string s)
         * Function: Response Error Frame to the romote 
         * Parament: string "0x01" "0x03" "0x0F" "0x10"
         * Return:   void
         */
        private void Error_Code(string s)
        {
            int count = Program.Data_Tcp.DataRecv_Rtu.Count;
            byte Func = (byte)(Program.Data_Tcp.DataRecv_Rtu[1] + 0x80);
            Program.Data_Tcp.DataRecv_Rtu.RemoveRange(1, count - 1);
            Program.Data_Tcp.DataRecv_Rtu.Add(Func);
            switch (s)
            {
                case "0x01"://Out of Addr or Did not open Addr
                    {
                        Program.Data_Tcp.DataRecv_Rtu.Add(0x01);
                        break;
                    }
                case "0x02"://Out of range
                    {
                        Program.Data_Tcp.DataRecv_Rtu.Add(0x02);
                        break;
                    }
                case "0x03"://Read or Write 0 coil/Register 
                    {
                        Program.Data_Tcp.DataRecv_Rtu.Add(0x03);
                        break;
                    }
            }
        }
    }
}   
