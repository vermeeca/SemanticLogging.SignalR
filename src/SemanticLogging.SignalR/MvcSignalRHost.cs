using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace SemanticLogging.SignalR
{
    public class MvcSignalRHost : ISignalRHost
    {
        private RouteCollection routes;


        public MvcSignalRHost(RouteCollection routes = null)
        {
            this.routes = routes ?? RouteTable.Routes;
        }

        public void ShutDown()
        {
            
        }

        public void Start()
        {
            var innerResolver = GlobalHost.DependencyResolver;
            routes.MapConnection<SemanticLoggingConnection>("semanticLogging", "/semanticLogging",
                                                            new ConnectionConfiguration
                                                                {
                                                                    EnableCrossDomain = true,
                                                                    Resolver =
                                                                        new SemanticLoggingSinkResolver(innerResolver)
                                                                });
        }
    }
}