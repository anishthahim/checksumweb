using ChecksumWeb.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChecksumWeb.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void CalcChecksumTest_ValidNmiValue_ReturnsNmiJsonObjectWithChecksumValue()
        {
            var controller = new HomeController();
            var result = controller.CalcChecksum("ABCD1234YY");

        }
    }
}
