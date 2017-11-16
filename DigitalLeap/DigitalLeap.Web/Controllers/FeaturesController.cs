using System.Web.Mvc;

namespace DigitalLeap.Web.Controllers
{
    public class FeaturesController : Controller
    {
        // GET: Home
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Capabilities()
        {
            return View();
        }
        public ActionResult ChoosePlan()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}