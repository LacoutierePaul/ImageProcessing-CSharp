using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MIGEOT_DE_BARAN_LACOUTIERE2.PSI
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Méthode qui teste si les deux pixels sont les mêmes
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            bool b = false;
            Pixel pixel = new Pixel("noir");
            Pixel pixel2 = new Pixel("blanc");
            if (pixel.Egale(pixel2) == true) b = true;
            Assert.AreEqual(false, b);
        }

        /// <summary>
        /// Méthode qui teste si la somme des caractères est égale à 744
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            bool b = false;
            QRCode qrcode1 = new QRCode("GOOD JOB.");
            if (qrcode1.Somme('G', 'O') == 744) b = true;
            Assert.AreEqual(true, b);
        }

        /// <summary>
        /// Méthode qui teste si la convertion de 'G' en int est égale à 16
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            bool b = false;
            QRCode qrcode1 = new QRCode("GOOD JOB.");
            if (qrcode1.ConvertCharToInt('G') == 16) b = true;
            Assert.AreEqual(true, b);
        }

        /// <summary>
        /// Méthode qui teste si les deux pixels sont les mêmes
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            bool b = false;
            Pixel pixel = new Pixel(255, 255, 255);
            Pixel pixel2 = new Pixel("blanc");
            if (pixel.Egale(pixel2) == true) b = true;
            Assert.AreEqual(true, b);
        }

    }
}
