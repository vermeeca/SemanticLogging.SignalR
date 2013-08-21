using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;

namespace SampleWebApp.EventSources
{
    public class SampleWebAppEventSource : EventSource
    {

        public static readonly SampleWebAppEventSource Log = new SampleWebAppEventSource();

        public void ApplicationStart()
        {
            if(IsEnabled()) WriteEvent(1);
        }

        public void SayHello(string name)
        {
            if(IsEnabled())WriteEvent(2, name);
        }
    
    }
}