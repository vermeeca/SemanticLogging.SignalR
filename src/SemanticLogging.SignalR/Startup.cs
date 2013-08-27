using Microsoft.AspNet.SignalR;
using Owin;

namespace SemanticLogging.SignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Turn cross domain on 
            var config = new HubConfiguration { EnableCrossDomain = true };
            app.MapHubs(config);
        }
    }
}