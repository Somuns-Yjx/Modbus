using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus
{

    class Program
    {
        public struct Data_Tcp
        {
            public static UInt16 Amount;
            public static List<byte> DataSend_Tcp = new List<byte> { };
            public static List<byte> DataRecv_Tcp = new List<byte> { };
            public static List<byte> Read_Tcp = new List<byte> { };
            public static List<byte> Coil_Tcp = new List<byte> { };
            public static List<byte> Register_Tcp = new List<byte> { };
            public static bool CreateFlag = false;

            public static List<byte> DataRecv_Rtu = new List<byte> { };
            public static List<byte> DataRecv_Rtu_copy = new List<byte> { };
            public static List<byte> Coil_Rtu = new List<byte> { };
            public static List<bool> Coil_Bool_Rtu = new List<bool> { };

            public static List<Int16> Register_Rtu = new List<Int16> { };
            public static List<bool> Register_Bool_Rtu = new List<bool> { };

        };

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Modbus());
        }
    }

}
