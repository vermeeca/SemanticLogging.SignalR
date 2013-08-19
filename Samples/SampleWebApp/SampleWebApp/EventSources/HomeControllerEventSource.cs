using System.Diagnostics.Tracing;

namespace SampleWebApp.EventSources
{
    
    public class HomeControllerEventSource : EventSource
    {

        public static readonly HomeControllerEventSource Log = new HomeControllerEventSource();

        public void SayHello(string name)
        {
            if(IsEnabled())WriteEvent(1, name);
        }
    }
}