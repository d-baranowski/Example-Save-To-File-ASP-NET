

using ExtensionMethods;
using SaveToTextFileOnServer.Models;
using SaveToTextFileOnServer.Services;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace SaveToTextFileOnServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataResolver _dataResolver;

        public HomeController(IDataResolver dataResolver)
        {
            _dataResolver = dataResolver;
        }

        public ActionResult Index()
        {
            ViewData["CurrentString"] = _dataResolver.getEntireText();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult SaveTwoStrings(TwoStringsModel Vm)
        {
            if (ModelState.IsValid)
            {
                _dataResolver.addToText(Vm.StringOne, Vm.StringTwo);
                return PartialView("_TwoStringsTextArea", _dataResolver.getEntireText());
            }

            var stringOne = ModelState["StringOne"].Errors != null ? ModelState["StringOne"].Errors.ToJSON() : "";
            var stringTwo = ModelState["StringTwo"].Errors != null ? ModelState["StringTwo"].Errors.ToJSON() : "";

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest,
                string.Format("{{StringOne: {0} , StringTwo: {1}}}", stringOne, stringTwo)             
         
            );

        }
    }
}