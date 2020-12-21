using System;
using System.Collections.Generic;

namespace ReModbus
{
    //功能优先
    public class Master  // 该类主要为数据处理与解析
    {
        public UInt16 transaction = 0;
        byte[] protoAndLen = { 0x00, 0x00, 0x00, 0x06 };
        const int totalAmount = 10000;
        public byte[] coil = new byte[10000];
        public int[] register = new int[10000];
        private int dataShouldRecvLen = 0;


        public byte[] send;
        public byte[] recv;
        public string Analyze = "";


        #region 功能码 设备号 地址 数量设置

        // 功能码
        private byte functionCode = 0x01;
        public void SetFunc(string func)
        {
            switch (func)
            {
                case "01": functionCode = 0x01; break;
                case "03": functionCode = 0x03; break;
                case "0F": functionCode = 0x0F; break;
                case "10": functionCode = 0x10; break;
                default: break;
            }
        }

        // 设备号
        public byte my_slaveId = 0;
        public byte slaveId
        {
            get { return my_slaveId; }
            set { my_slaveId = value; }
        }

        public UInt16 address = 0;
        public UInt16 amount = 0;
        /// <summary>
        ///  设置地址与数量，返回为true，设置成功，返回false，设置异常
        /// </summary>
        public bool SetAddrAndAmount(UInt16 addr, UInt16 amt)
        {
            if (addr + amt <= 10000 && addr + amt != 0)
            {
                address = addr;
                amount = amt;
                return true;
            }
            else return false;
        }
        #endregion

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            for (int i = 0; i < totalAmount; i++)
            {
                coil[i] = 0;
                register[i] = 0;
            }
        }

        /// <summary>
        /// 写功能码保存数据
        /// </summary>
        public string DataChanged(int num, object input)
        {
            try
            {
                switch (functionCode)
                {
                    case 0x0F:
                        byte dataCoil = Convert.ToByte(input);
                        if (dataCoil != 0 && dataCoil != 1)
                            return "请输入0或1。";
                        else
                            coil[num] = dataCoil;
                        break;
                    case 0x10:
                        int dataReg = Convert.ToInt16(input);
                        register[num] = dataReg;
                        break;
                }
                return "";
            }
            catch (Exception eDataChanged)
            {
                return eDataChanged.Message;
            }
        }

        #region 构成数据帧
        public byte[] DataFrameCreate()
        {
            List<byte> data = new List<byte> { };
            byte[] dataAdd = new byte[] { };
            data.Add(Convert.ToByte(transaction >> 8));         // 传输标识高8位
            data.Add(Convert.ToByte(transaction & 0xFF));     // 传输标识低8位
            data.AddRange(protoAndLen);
            data.Add(slaveId);
            data.Add(functionCode);
            data.Add(Convert.ToByte(address >> 8));                // 地址高8位
            data.Add(Convert.ToByte(address & 0xFF));           // 地址低8位
            data.Add(Convert.ToByte(amount >> 8));                // 寄存器数高8位
            data.Add(Convert.ToByte(amount & 0xFF));           // 寄存器数低8位
            transaction++;
            ForWriting(data);

            byte[] datasend = data.ToArray();
            send = datasend;                                                       // 把将要发送的数据帧传给本类全局变量，使UI层访问
            return datasend;
        }

        private void ForWriting(List<byte> data)
        {
            int coilLen = (amount + 7) / 8;
            int regLen = amount * 2;
            switch (functionCode)
            {
                case 0x01: dataShouldRecvLen = coilLen; break;
                case 0x03: dataShouldRecvLen = regLen; break;
                case 0x0F: dataShouldRecvLen = coilLen;
                    data[5] += (byte)(coilLen + 1);                                                     // +1是因为数据区有一字节位
                    data.Add((byte)(coilLen));
                    byte stemp = 0; int times = 0;
                    for (int index = address; index < address + amount; index++)
                    {
                        stemp += (byte)(coil[index] << (times));
                        times++;
                        if (index == address + amount - 1)
                        {
                            data.Add(stemp); break;
                        }
                        if (times == 8)
                        {
                            data.Add(stemp);
                            stemp = 0; times = 0;
                        }
                    }
                    break;
                case 0x10:
                    dataShouldRecvLen = regLen;
                    data[5] += (byte)(regLen + 1);
                    data.Add((byte)(regLen));
                    for (int index = address; index < address + amount; index++)
                    {
                        data.Add((byte)(register[index] >> 8));
                        data.Add((byte)(register[index] & 0xFF));
                    }
                    break;
            }
        }
        #endregion

        #region 数据解析
        public void DataAnalyze(byte[] datarecv)
        {
            recv = datarecv;
            int dataRecvLen = datarecv.Length;
            if (recv[6] != send[6])                                                              // 设备号  
            { ErrorMsg("UnitID"); return; }
            int Trans = recv[0] * 256 + recv[1];                                        // 报头
            if (Trans != transaction -1| recv[2] != 0 | recv[3] != 0 )// dataShouldRecvLen != recv[4] * 256 + recv[5] - 6
            { ErrorMsg("MBAP"); return; }
            if (recv[7] != functionCode)                                                    // 功能码
            { ErrorMsg("FUNC"); return; }

            if (functionCode == 0x01 | functionCode == 0x03)               // 主要判断数据长度，但读与写数据帧响应数据帧格式不同
            {   // 数据帧字节长度                         // 接收数据长度!=前部分字节长+数据区字节长度+字节位
                if (dataShouldRecvLen != recv[8] | dataRecvLen != 8 + dataShouldRecvLen + 1 | dataRecvLen != recv[4] * 256 + recv[5] + 6)          // 数据长度
                { ErrorMsg("DataLen"); return; }
            }
            else
            {
                byte[] datacopy = datarecv; 
                datacopy[4] = 0x00; 
                datacopy[5] = 0x06;
                if (datacopy != datarecv)
                { ErrorMsg("DataMatch"); return; }
            }
            Analyze = "Right";
        }

        private void ErrorMsg(string s)
        {
            switch (s)
            {
                case "MBAP":
                    Analyze = "MBAP  Data  Error !"; break;
                case "FUNC":
                    Analyze = "Error : Function Code Recv Error !"; break;
                case "UnitID":
                    Analyze = " Error : Unit ID Error !"; break;
                case "DataLen":
                    Analyze = " Error : Data Length Error !"; break;
                case "DataMatch":
                    Analyze = " Error : Data dose not match !"; break;
                default:
                    Analyze = " Error : Unknown Error !"; break;
            }
        }
        #endregion


    }
}
