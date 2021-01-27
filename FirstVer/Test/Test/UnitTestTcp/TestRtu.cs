using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace UnitTestTcp
{
    class TestRtu
    {
        ModbusFunc.ModbusRtuSlave ModbusRtu = new ModbusFunc.ModbusRtuSlave();
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
        private void IniFile(string iniPath = "./ModbusRtu.ini")
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

        public void UnitTestRtu()
        {
            try
            {
                IniFile();
                string sectionhead = "Example";
                string totalstr = ReadIni("Example", "Total");
                int total = Convert.ToInt32(totalstr);
                ModbusRtu._Rtu_Data_Init();
                for (int index = 1; index <= total; index++)
                {
                    string section = sectionhead + index.ToString();

                    string Recvstr = ReadIni(section, "Recv");
                    string Sendstr = ReadIni(section, "Send");
               
                    string[] Recvstrarr = Recvstr.Split(',');
                    string[] Sendstrarr = Sendstr.Split(',');

                    List<byte> RecvList = new List<byte> { };
                    List<byte> SendList = new List<byte> { };
                    List<byte> Resultlist = new List<byte> { };

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

                    Resultlist = ModbusRtu.DataAnalyze_Rtu(RecvList);
                    string Resultstr = "";
                    for (int m = 0; m < Resultlist.Count; m++)
                    {
                        Resultstr += "0x";
                        Resultstr += Convert.ToString(Resultlist[m], 16) + ",";
                    }

                    if (SendList.Count != Resultlist.Count)
                        Assert.IsTrue(1 == 0);
                    for (int k = 0; k < SendList.Count; k++)
                    {
                        if(SendList[k]!= Resultlist[k])
                            Assert.IsTrue(1 == 0);
                    }

                }
            }
            catch
            {
                Assert.IsTrue(0 == 1);
            }

        }
    }
}
