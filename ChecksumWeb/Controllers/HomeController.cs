using ChecksumWeb.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace ChecksumWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var nmi = new Nmi("A1BCD4PTYG");
            ViewBag.Checksum = nmi.Checksum;
            return View();
        }

        public ContentResult CalcChecksum(string nmiValue)
        {
            var nmi = new Nmi(nmiValue);
            return Content(JsonConvert.SerializeObject(nmi));
        }

    }
}