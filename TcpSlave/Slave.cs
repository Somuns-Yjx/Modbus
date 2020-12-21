using System.Collections.Generic;

namespace TcpSlave
{
    public class Slave    // 该类主要为数据处理与解析
    {
        public byte[] coil = new byte[10000];
        public int[] register = new int[10000];
        private int totalAmount = 10000;
        /// <summary>
        ///  初始化数据
        /// </summary>
        public void InitData()
        {
            for (int i = 0; i < totalAmount; i++)
            {
                coil[i] = 0;
                register[i] = 0;
            }
        }

        private byte my_slaveId = 0;
        public byte SlaveId
        {
            get { return my_slaveId; }
            set { my_slaveId = value; }
        }

        #region 数据解析
        /// <summary>
        ///  数据解析 如果数据帧本身错误，则返回空
        /// </summary>
        /// <param name="dataRecv"></param>
        /// <returns></returns>
        public byte[] DataAnalyze(byte[] dataRecv)
        {
            byte[] datasend = null;
            //List<byte> dataSend = new List<byte>{};
            int lenRecv = dataRecv.Length;                                        // 数据帧长度
            if (dataRecv[6] != SlaveId) return null;                             // 先判断设备号      设备号不符直接返回空数组
            byte func = dataRecv[7];
            if (func != 0x01 && func != 0x03 && func != 0x0F && func != 0x10)   // 判断功能码
            { return ErrorCode(dataRecv, "0x01"); }
            if (dataRecv[2] * 256 + dataRecv[3] != 0) { return null; }                       // 协议标识非0  返回空
            int mbapLen = dataRecv[4] * 256 + dataRecv[5];                                   // 报头中字节长度
            int address = dataRecv[8] * 256 + dataRecv[9];                                     // 地址数量
            int amount = dataRecv[10] * 256 + dataRecv[11];                                 // 线圈、寄存器数量


            if (address > 10000 | address + amount > 10000) { return ErrorCode(dataRecv, "0x03"); }                // 地址越界
            if ((func == 0x0F && amount > 1968) |                                                      // 越界写线圈
                (func == 0x10 && amount > 123))                                                          // 越界写寄存器
            { return ErrorCode(dataRecv, "0x02"); }

            switch (func)
            {
                case 0x01: 
                    if (mbapLen != 0x06 | lenRecv != 12) 
                        return null; 
                        datasend = DataSoluteAndFrameCreate(dataRecv, 0x01, address, amount); 
                        break;
                case 0x03: 
                    if (mbapLen != 0x06 | lenRecv != 12) 
                        return null; 
                        datasend = DataSoluteAndFrameCreate(dataRecv, 0x03, address, amount); 
                        break;
                case 0x0F:
                    int afterDataLenCoil = (amount + 7) / 8;
                    if (afterDataLenCoil != dataRecv[12] |                                                      // 后续字节不正确
                       mbapLen != 6 + afterDataLenCoil + 1 |                                                 // 报头字节不正确
                        lenRecv != mbapLen + 6) return null;                                                   // 总长度不正确
                    datasend = DataSoluteAndFrameCreate(dataRecv, 0x0F, address, amount);
                    break;
                case 0x10:
                    int afterDataLenReg = amount * 2;
                    if (afterDataLenReg != dataRecv[12] |                                                      // 后续字节不正确
                        mbapLen != 6 + afterDataLenReg + 1 |                                                 // 报头字节不正确
                            lenRecv != mbapLen + 6) return null;                                               // 总长度不正确
                    datasend = DataSoluteAndFrameCreate(dataRecv, 0x10, address, amount);
                    break;
            }
            return datasend;
        }
        #endregion


        private byte[] DataSoluteAndFrameCreate(byte[] data, byte func, int addr, int amt)
        {
            int databegin = 13;                                                                           // 对于写功能来说，数据区开始在第13字节
            int len = data.Length;
            List<byte> datacopy = new List<byte> { };
            int coilLen = (amt + 7) / 8;
            int regLen = amt * 2;
            datacopy.AddRange(data);                                                              // 复制数据帧为list列表

            switch (func)
            {
                case 0x01:
                    datacopy.RemoveRange(len - 4, 4);                                         // 将末尾地址，数量去除          ？？？
                    datacopy[5] += (byte)(coilLen + 1 - 4);                                     // +1是因为数据区有一字节位; -4是因为去除了末尾4字节  
                    datacopy.Add((byte)(coilLen));
                    byte stemp = 0; int times = 0;
                    for (int index = addr; index < addr + amt; index++)
                    {
                        stemp += (byte)(coil[index] << (times));
                        times++;
                        if (index == addr + amt - 1)
                        {
                            datacopy.Add(stemp); break;
                        }
                        if (times == 8)
                        {
                            datacopy.Add(stemp);
                            stemp = 0; times = 0;
                        }
                    }
                    break;
                case 0x03:
                    datacopy.RemoveRange(len - 4, 4);                                                                       // 将末尾地址，数量去除          ？？？
                    datacopy[5] += (byte)(regLen + 1 - 4);
                    datacopy.Add((byte)(regLen));
                    for (int index = addr; index < addr + amt; index++)
                    {
                        datacopy.Add((byte)(register[index] >> 8));
                        datacopy.Add((byte)(register[index] & 0xFF));
                    }
                    break;
                case 0x0F:
                    for (int index = addr; databegin <= len - 1; databegin++)
                    {
                        int temp = datacopy[databegin];
                        for (int i = 0; i < 8; i++)
                        {
                            coil[index] = (byte)(temp & 1);
                            temp >>= 1;
                            index++;
                        }
                    }
                    datacopy[4] = 0x00;
                    datacopy[5] = 0x06;
                    datacopy.RemoveRange(12, datacopy.Count - 12);                                                // 将末尾数据去除          ？？？
                    break;
                case 0x10:
                    for (int index = addr; index < addr + amt; index++)
                    {
                        register[index] = datacopy[databegin] * 256 + datacopy[databegin + 1];
                        databegin += 2;
                    }
                    datacopy[4] = 0x00;
                    datacopy[5] = 0x06;
                    datacopy.RemoveRange(12, datacopy.Count - 12);                                                // 将末尾数据去除
                    break;
            }
            return datacopy.ToArray();
        }

        /// <summary>
        /// 异常码
        /// </summary>
        /// <param name="data"></param>
        /// <param name="errFunc"></param>
        private byte[] ErrorCode(byte[] data, string errFunc)
        {
            List<byte> errorCodeResp = new List<byte> { };
            errorCodeResp.AddRange(data);
            int count = errorCodeResp.Count;                                      // 取长度
            errorCodeResp.RemoveRange(8, count - 8);                      // 删去地址数量
            errorCodeResp[4] = 0x00; errorCodeResp[5] = 0x03;        // 异常码后续长度固定为3字节
            errorCodeResp[7] += 0x80;                                                  // 功能码+0x80
            switch (errFunc)
            {
                case "0x01": errorCodeResp.Add(0x01); break;
                case "0x02": errorCodeResp.Add(0x02); break;
                case "0x03": errorCodeResp.Add(0x03); break;
                case "0x04": errorCodeResp.Add(0x04); break;
                default: break;
            }
            return errorCodeResp.ToArray();
        }



    }
}
