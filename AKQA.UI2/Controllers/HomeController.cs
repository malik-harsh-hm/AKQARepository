using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AKQA.UI2.Models;
using AKQA.SharedLogic;
using AKQA.Service;

namespace AKQA.UI2.Controllers
{
    public class HomeController : Controller
    {
        private IServiceFactories _serviceFactories;

        //public HomeController()
        //{
        //    _serviceFactories = new ServiceFactoriesWrapper();
        //}
        public HomeController(IServiceFactories serviceFactories)
        {
            _serviceFactories = serviceFactories;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Razor Page (Calling Service Layer)";

            return View();
        }
        public ActionResult AjaxApp()
        {
            ViewBag.Message = "Javascript page (Calling Web API)";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Please Read";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Author";

            return View();
        }
        [HttpPost]
        public ActionResult Submit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Home/Index.cshtml", person);
            }

            IConvertService service = _serviceFactories.ConvertServiceFactory.CreateInstance();
            var res = service.GetData(person.DecimalAmount);
            person.StringAmount = res;

            return View("~/Views/Home/Index.cshtml", person);
        }

    }
}