using System;
using System.Web.Mvc;
using DigitalLeap.Domain.Model;
using DigitalLeap.Services;

namespace DigitalLeap.Web.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly IEnquiryService _enquiryService;

        public FeaturesController(IEnquiryService enquiryService)
        {
            _enquiryService = enquiryService;
        }
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
            return View(new ContactInformation());
        }

        [HttpPost]
        public PartialViewResult ContactUs(ContactInformation model)
        {
            string error;

            if (ModelState.IsValid)
            {
                try
                {
                    _enquiryService.Save(model);

                    // Success
                    return PartialView("FormResult", string.Empty);
                }
                catch (Exception e)
                {
                    error = e.Message;
                }
            }
            else
            {
                error = "The Model is invalid";
            }

            return PartialView("FormResult", error);
        }
    }
}