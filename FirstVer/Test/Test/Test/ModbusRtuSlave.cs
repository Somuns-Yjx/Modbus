using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusFunc
{
    public class ModbusRtuSlave
    {
        //public byte [] DataCoil = new byte[10000];
        //public byte [] DataRegister = new byte[10000];
        public List<byte> DataCoil = new List<byte> { };
        public List<Int16> DataRegister = new List<Int16> { };
        public byte SlaveID = 0x01;
        public void _Rtu_Data_Init()
        {
            /*---------- Init Coil all 0x00 ---------*/
            for (int coilindex = 0; coilindex < 10000; coilindex++)
            {
                DataCoil.Add(0x00);
            }

            /*-------- Init Register All 0 -------*/
            for (int regindex = 0; regindex < 10000; regindex++)
            {
                DataRegister.Add(0x00);
            }
        }

        public List<byte> DataAnalyze_Rtu(List<byte> DataRecv)
        {
            /*-------Slave ID first-------*/
            if (DataRecv[0] != SlaveID)
            {
                DataRecv = new List<byte> { 0x00 };
                return DataRecv;
            }
            /*-------Crc Check Second------*/
            //byte[] DataRecv_copy = DataRecv.ToArray();
            int count = DataRecv.Count;
            byte crc1 = DataRecv[count - 2];
            byte crc2 = DataRecv[count - 1];
            DataRecv.RemoveRange(count - 2, 2);
            CrcCheck_Rtu(DataRecv);
            /*---------------------  CRC Right? ----------------------*/
            if (crc1 != DataRecv[count - 2] && crc2 != DataRecv[count - 1])
            {
                DataRecv = new List<byte> { 0x01 };  //Crc Error
                return DataRecv;
            }
            /*------------------  DataLength Right? ---------------------*/
            int Addr = DataRecv[2] * 256 + DataRecv[3];
            int Amt = DataRecv[4] * 256 + DataRecv[5];
            DataRecv.RemoveRange(count - 2, 2);
            int DataLength = DataRecv.Count;
            switch (DataRecv[1])//Func
            {
                case 0x01:
                    if (DataLength != 6)
                    {
                        DataRecv = new List<byte> { 0x02 }; //"DataLength Error"
                        return DataRecv;
                    }
                    if (Addr >= 10000)
                    {
                        Error_Code("0x02", DataRecv);
                    }
                    else if (Amt == 0 | Amt > 2000)
                    {
                        Error_Code("0x03", DataRecv);
                    }
                    else if (Addr + Amt > 10000)
                    {
                        Error_Code("0x03", DataRecv);
                    }
                    else if (Amt != 0)
                    {
                        _0x01_Rtu(DataRecv);
                        
                    }
                    CrcCheck_Rtu(DataRecv);
                    return DataRecv;

                case 0x03:
                    if (DataLength != 6)
                    {
                        DataRecv = new List<byte> { 0x02 }; //"DataLength Error"
                        return DataRecv;
                    }
                    if (Addr + Amt > 10000)
                    {
                        Error_Code("0x02", DataRecv);
                    }
                    else if (Amt == 0 | Amt > 125)
                    {
                        Error_Code("0x03", DataRecv);
                    }
                    else if (Amt != 0)
                    {
                        _0x03_Rtu(DataRecv);
                    }
                    CrcCheck_Rtu(DataRecv);
                    return DataRecv;

                case 0x0F:
                    try
                    {
                        if (DataLength != 6 + DataRecv[6] + 1)
                        {
                            DataRecv = new List<byte> { 0x02 }; //"DataLength Error"
                            return DataRecv;
                        }
                    }
                    catch
                    {
                        DataRecv = new List<byte> { 0x02 }; //"DataLength Error"
                        return DataRecv;
                    }
                    if (Amt == 0 | Amt > 1968)
                    {
                        Error_Code("0x03", DataRecv);
                    }
                    else if (Addr + Amt > 10000)
                    {
                        Error_Code("0x02", DataRecv);
                    }
                    else if (Amt != 0)
                    {
                        _0x0F_Rtu(DataRecv);
                    }
                    CrcCheck_Rtu(DataRecv);
                    return DataRecv;

                case 0x10:
                    try
                    {
                        if (DataLength != 6 + DataRecv[6] + 1)
                        {
                            DataRecv = new List<byte> { 0x02 }; //"DataLength Error"
                            return DataRecv;
                        }
                    }
                    catch
                    {
                        DataRecv = new List<byte> { 0x02 }; //"DataLength Error"
                        return DataRecv;
                    }
                    if (Amt == 0 | Amt > 123)
                    {
                        Error_Code("0x03", DataRecv);
                    }
                    else if (Addr + Amt >= 10000)
                    {
                        Error_Code("0x02", DataRecv);
                    }
                    else if (Amt != 0)
                    {
                        _0x10_Rtu(DataRecv);
                    }
                    CrcCheck_Rtu(DataRecv);
                    return DataRecv;
                default:
                    {
                        Error_Code("0x01", DataRecv);
                        CrcCheck_Rtu(DataRecv);
                        return DataRecv;                  
                    }
            }                
        }


        private void CrcCheck_Rtu(List<byte> DataRecv)
        {
            UInt16 CrcReg = 0xFFFF;
            for (int i = 0; i < DataRecv.Count; i++)
            {
                CrcReg ^= DataRecv[i];
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
            DataRecv.Add((byte)(CrcReg & 0x00FF));
            DataRecv.Add((byte)(CrcReg >> 8));
        }

        private void Error_Code(string s, List<byte> DataRecv)
        {
            int count = DataRecv.Count;
            byte Func = (byte)(DataRecv[1] + 0x80);
            DataRecv.RemoveRange(1, count - 1);
            DataRecv.Add(Func);
            switch (s)
            {
                case "0x01"://Out of Addr or Did not open Addr
                    {
                        DataRecv.Add(0x01);
                        break;
                    }
                case "0x02"://Out of range
                    {
                        DataRecv.Add(0x02);
                        break;
                    }
                case "0x03"://Read or Write 0 coil/Register 
                    {
                        DataRecv.Add(0x03);
                        break;
                    }
            }
        }

        private void _0x01_Rtu(List<byte> DataRecv)
        {
            int Addr = DataRecv[2] * 256 + DataRecv[3];
            int Amt = DataRecv[4] * 256 + DataRecv[5];
            int count = DataRecv.Count;
            int bytes = (Amt + 7) / 8;
            
            byte s = 0x00;
            int times = 0;

            DataRecv.RemoveRange(2, count - 2);
            DataRecv.Add((byte)bytes);

            for (int i = Addr; i < (Addr + Amt); i++)
            {
                if (times == 7)
                {
                    s += (byte)(DataCoil[i] << times);
                    DataRecv.Add(s);
                    s = 0x00;
                    times = 0;
                }
                else if (i == (Addr + Amt - 1))
                {
                    s += (byte)(DataCoil[i] << times);
                    DataRecv.Add(s);
                    s = 0x00;
                }
                else
                {
                    s += (byte)(DataCoil[i] << times);
                    times++;
                }
            }
        }

        private void _0x03_Rtu(List<byte> DataRecv)
        {

            int Addr = DataRecv[2] * 256 + DataRecv[3];
            int Amt = (DataRecv[4] * 256 + DataRecv[5]);
            int count = DataRecv.Count;
            byte s = 0x00;
            DataRecv.RemoveRange(2, count - 2);
            DataRecv.Add((byte)(Amt * 2));

            for (int i = Addr; i < (Addr + Amt); i++)
            {
                s = (byte)(DataRegister[i] >> 8);
                DataRecv.Add(s);
                s = (byte)(DataRegister[i] & 0xFF);
                DataRecv.Add(s);
            }
        }

        private void _0x0F_Rtu(List<byte> DataRecv)
        {
            int Addr = DataRecv[2] * 256 + DataRecv[3];
            int Amt = DataRecv[4] * 256 + DataRecv[5];
            int count = DataRecv.Count;
            int bytes = 0;
            /*----------- What if Amt != bytes ? ---------*/
            if (Amt % 8 == 0)
                bytes = Amt / 8;
            else
                bytes = Amt / 8 + 1;

            int j = DataRecv[6];

            for (int k = 0; k < j; k++)
            {
                byte s = DataRecv[k + 7];

                for (int i = 0; i < 8; i++)
                {
                    DataCoil[Addr++] = (byte)(s & 0x01);
                    s >>= 1;
                }
            }
            DataRecv.RemoveRange(6, DataRecv.Count - 6);
        }

        private void _0x10_Rtu(List<byte> DataRecv)
        {
            int Addr = DataRecv[2] * 256 + DataRecv[3];
            int Amt = (DataRecv[4] * 256 + DataRecv[5]);
            int count = DataRecv.Count;
            int j = DataRecv[6];

            for (int k = 0; k < j; )
            {

                Int16 temp = DataRecv[k + 7];
                temp <<= 8;
                temp += DataRecv[k + 8];
                DataRegister[Addr++] = temp;
                temp = 0;
                k += 2;
            }
            DataRecv.RemoveRange(6, DataRecv.Count - 6);

        }        
    }
}



