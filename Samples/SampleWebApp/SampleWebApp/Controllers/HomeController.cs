using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleWebApp.EventSources;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        
        public string SayHello(NameInputModel id)
        {
            SampleWebAppEventSource.Log.SayHello(id != null ? id.Name : string.Empty);
            return id.Name;
        }

        
    }
}
