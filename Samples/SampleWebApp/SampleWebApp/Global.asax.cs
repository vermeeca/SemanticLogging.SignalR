using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SampleWebApp.EventSources;
using SemanticLogging.SignalR;

namespace SampleWebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private EventListener listener;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            listener = SignalRLog.CreateListener();
            listener.EnableEvents(SampleWebAppEventSource.Log, EventLevel.Verbose);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SampleWebAppEventSource.Log.ApplicationStart();
        }
    }
}