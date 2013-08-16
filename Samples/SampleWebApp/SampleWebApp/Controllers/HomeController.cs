using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToAction("SayHello", new NameInputModel());
        }

        [HttpPost]
        public ActionResult SayHello(NameInputModel id)
        {
            return View(id);
        }

        public ActionResult SayHello()
        {
            return View();
        }
    }
}
