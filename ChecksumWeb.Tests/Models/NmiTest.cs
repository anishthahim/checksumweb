using ChecksumWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChecksumWeb.Tests.Models
{
    [TestClass]
    public class NmiTest
    {
        [TestMethod]
        public void CalculateChecksum_ValidNmi_ReturnsNmiObjectWithChecksum()
        {
            var nmi = new Nmi("A1BCD4GTYG");
            Assert.IsTrue(nmi.Checksum >= 0 && nmi.Checksum <= 9 && nmi.IsChecksumCalculated == true);
        }

        [TestMethod]
        public void CalculateChecksum_NmiValueAB456HGTDR_ReturnsNmiObjectWithChecksumValue3()
        {
            var nmi = new Nmi("AB456HGTDR");
            Assert.IsTrue(nmi.Checksum == 3);
        }


        [TestMethod]
        public void CalculateChecksum_NmiValueContainsSpecialChar_ReturnsNmiObjectWithIsNmiValidFalseAndIsChecksumCalcFalse()
        {
            var nmi = new Nmi("A1BCD4$TYG");
            Assert.IsTrue(nmi.IsNmiValid == false && nmi.IsChecksumCalculated == false);
        }

        [TestMethod]
        public void CalculateChecksum_NmiValueLengthIsLessThanTen_ReturnsNmiObjectWithIsNmiValidFalseAndIsChecksumCalcFalse()
        {
            var nmi = new Nmi("ABCD34");
            Assert.IsTrue(nmi.IsNmiValid == false && nmi.IsChecksumCalculated == false);
        }

        [TestMethod]
        public void CalculateChecksum_NmiValueLengthIsMoreThanTen_ReturnsNmiObjectWithIsNmiValidFalseAndIsChecksumCalcFalse()
        {
            var nmi = new Nmi("ABCD34DFFQ1234");
            Assert.IsTrue(nmi.IsNmiValid == false && nmi.IsChecksumCalculated == false);
        }

        [TestMethod]
        public void CalculateChecksum_NmiValueIsNull_ReturnsNmiObjectWithIsNmiValidFalseAndIsChecksumCalcFalse()
        {
            var nmi = new Nmi(null);
            Assert.IsTrue(nmi.IsNmiValid == false && nmi.IsChecksumCalculated == false);
        }
    }
}
