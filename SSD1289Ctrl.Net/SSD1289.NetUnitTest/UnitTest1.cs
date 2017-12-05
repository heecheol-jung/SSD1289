using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSD1289.Net;
using SSD1289.Net.Support;

namespace SSD1289.NetUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOscillatorReg()
        {
            ushort regValue = 0x0001;
            OscillatorReg oscReg = BitFieldExtensions.CreateBitField<OscillatorReg>(regValue);

            Assert.IsNotNull(oscReg);
            Assert.AreEqual((bool)true, oscReg.OSCEN);

            ushort bits = (ushort)oscReg.ToUInt64();
            Assert.AreEqual(regValue, bits);

            string bitString = oscReg.ToBinaryString();
            Assert.AreEqual("0000000000000001", bitString);
        }
    }
}
