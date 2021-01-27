using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace ModbusFunc
{
    public class ModbusTcpMaster
    {
        public string DataAnalyze_Tcp(byte[] datarecv, byte[] datasend)
        {
            int countrecv = datarecv.Length;
            int countsend = datasend.Length;
            int transsend = datasend[0] * 256 + datasend[1];
            int transrecv = datarecv[0] * 256 + datarecv[1];
            int protorecv = datarecv[2] * 256 + datarecv[3];
            byte funcsend = datasend[7];
            UInt16 quantity = (UInt16)(datasend[10] * 256 + datasend[11]);

            /*-------- MBAP ---------*/
            int lenrecv = datarecv[4] * 256 + datarecv[5];
            /*------ 理应接收到的数据区字节长度 -----*/
            int lenshouldrecv = LenObtain(funcsend, quantity);                    
            if (transsend != transrecv)      return "Transction Erro";               
            if (protorecv != 0)              return "Protocol Erro";            
            /*----- ID ------*/
            if (datarecv[6] != datasend[6])  return "ID Error";
            /*------- 接收报文MBAP字节与发送报文不符 ------*/
            if( lenrecv != countrecv - 6 ) return "MBAP Data Length Error";
            /*----- Func ----*/
            switch (datarecv[7])
            {
                case 0x01:  break;                    
                case 0x03:  break;                  
                case 0x0F:
                    if (datarecv[8] != datasend[8] | datarecv[9] != datasend[9])
                        return "Addr does not match";
                    if (datarecv[10] != datasend[10] | datarecv[11] != datasend[11])
                        return "Quantity does not match";
                    break;
                case 0x10:
                    if (datarecv[8] != datasend[8] | datarecv[9] != datasend[9])
                        return "Addr does not match";
                    if (datarecv[10] != datasend[10] | datarecv[11] != datasend[11])
                        return "Quantity does not match";
                    break;
                default:                    /*-- Func --*/
                    string stemp = ErrorCode(datarecv[7],datarecv[8], datarecv.Length);
                    return stemp;
            }

            /*------  写报文  -------*/
            if (lenshouldrecv == -1)
            {
                datasend[4] = 0x00;
                datasend[5] = 0x06;
                List<byte> listsend = new List<byte> { };
                listsend.AddRange(datasend);
                int count = listsend.Count;
                listsend.RemoveRange(11, count - 12);
                byte[] datasendcopy = listsend.ToArray();
                if (datasendcopy.Length != datarecv.Length)
                    return "Data Length Error";
                return "Right";                                    
            }
            /*------- 接收报文数据区字节与理应接收不符 ------*/
            if (lenshouldrecv != datarecv[8] | lenshouldrecv != lenrecv - 3)
                return "Data Section Length Error";
            return "Right";
        }

        private int LenObtain(byte funcsend, UInt16 quantity)
        {
            int len = 0;
            /*------ Func Send -----*/
            switch (funcsend)
            {
                case 0x01: len = (quantity + 7) / 8; break;                                       
                case 0x03: len = 2 * quantity;       break;                                     
                case 0x0F: return -1;
                case 0x10: return -1;                   
                default:   return 9;
            }
            return len;
        }

        private string ErrorCode(int func,int errcode, int count)
        {
            if (count != 9)
                return "Error Code Data Length Error";
            switch(func)
            {
                case 0x81: break;
                case 0x83: break;
                case 0x8F: break;
                case 0x90: break;
                default:   return "Illegal Function Code";
            }
            switch (errcode)
            {
                case 0x01: return "Illegal Function";
                case 0x02: return "Illegal Data Addr";                   
                case 0x03: return "Illegal Data";
                case 0x04: return "Slave Device Error";
                default:   return "Other Error";                    
            }
        }
    }
}
