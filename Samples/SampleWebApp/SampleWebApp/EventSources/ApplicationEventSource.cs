using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;

namespace SampleWebApp.EventSources
{
    public class ApplicationEventSource : EventSource
    {

        public static readonly ApplicationEventSource Log = new ApplicationEventSource();

        public void ApplicationStart()
        {
            if(IsEnabled()) WriteEvent(1);
        }
    }
}