using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MIGEOT_DE_BARAN_LACOUTIERE2.PSI
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool b = false;
            Pixel pixel = new Pixel("noir");
            Pixel pixel2 = new Pixel("blanc");
            if (pixel.Egale(pixel2) == true) b = true;
            Assert.AreEqual(false, b);
       }


        [TestMethod]
        public void TestMethod2()
        {
            bool b = false;
            Pixel pixel = new Pixel("noir");
            Pixel pixel2 = new Pixel("blanc");
            if (pixel.Egale(pixel2) == true) b = true;
            Assert.AreEqual(false, b);
        }


    }
}
