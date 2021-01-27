using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace UnitTestTcp
{
    class TestTcp
    {
        ModbusFunc.ModbusTcpMaster ModbusTcp = new ModbusFunc.ModbusTcpMaster();
        /* 
        * 声明API函数 
        */
        public string iniPath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="iniPath">ini文件路径，默认为当前路径(bin/Debug)</param>  
        private void IniFile(string iniPath = "./Modbus.ini")
        {
            this.iniPath = iniPath;
            ExistINIFile();
        }

        private string ReadIni(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(65535);
            int i = GetPrivateProfileString(Section, Key, "", temp, 65535, iniPath);
            return Convert.ToString(temp);
        }

        public bool ExistINIFile()
        {
            return File.Exists(iniPath);
        }

        public void UnitTestTcp()
        {
            try
            {
                IniFile();
                string sectionhead = "Example";
                string totalstr = ReadIni("Example", "Total");
                int total = Convert.ToInt32(totalstr);
                for (int index = 1; index <= total; index++)
                {
                    string section = sectionhead + index.ToString();
                    string Sendstr = ReadIni(section, "Send");
                    string Recvstr = ReadIni(section, "Recv");
                    string Output = ReadIni(section, "Output");

                    string[] Sendstrarr = Sendstr.Split(',');
                    string[] Recvstrarr = Recvstr.Split(',');
                    List<byte> SendList = new List<byte> { };
                    List<byte> RecvList = new List<byte> { };

                    for (int i = 0; i < Sendstrarr.Length; i++)
                    {
                        byte num = Convert.ToByte(Sendstrarr[i], 16);
                        SendList.Add(num);
                    }
                    for (int j = 0; j < Recvstrarr.Length; j++)
                    {
                        byte num = Convert.ToByte(Recvstrarr[j], 16);
                        RecvList.Add(num);
                    }
                    byte[] Send = SendList.ToArray();
                    byte[] Recv = RecvList.ToArray();

                    string result = ModbusTcp.DataAnalyze_Tcp(Recv, Send);

                    Assert.IsTrue(result == Output);

                }
            }
            catch
            {
                Assert.IsTrue(0 == 1);
            }

        }


    }

   
}
