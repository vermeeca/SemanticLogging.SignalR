using System;
using Microsoft.Owin.Hosting;

namespace SemanticLogging.SignalR
{
    public class OwinSignalRHost : ISignalRHost
    {
        private IDisposable host;

        public void ShutDown()
        {
            if (host != null)
            {
                host.Dispose();
            }
        }

        public void Start()
        {
            host = WebApp.Start<Startup>(@"http://localhost:12345");
        }
    }
}