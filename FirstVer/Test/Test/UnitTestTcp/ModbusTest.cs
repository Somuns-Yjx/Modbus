using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTcp
{
    [TestClass]
    public class ModbusTest
    {
        [TestMethod]
        public void UnitTcp()
        {
            TestTcp testtcp = new TestTcp();
            testtcp.UnitTestTcp();
        }
        [TestMethod]
        public void UnitRtu()
        {
            TestRtu testRtu = new TestRtu();
            testRtu.UnitTestRtu();
        }
    }
}
