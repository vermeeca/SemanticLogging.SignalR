using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Hosting;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks;

namespace SemanticLogging.SignalR
{
    public class SignalRSink : IObserver<string>
    {
        private IDisposable host;
        private IHubConnectionContext clients;


        internal void StartHost()
        {
            this.host = WebApp.Start<Startup>(@"http://localhost:12345");
            this.clients = GlobalHost.ConnectionManager.GetHubContext<SemanticLoggingHub>().Clients;
        }

        public void OnNext(string value)
        {
            clients.All.messageLogged(value);
        }

        public void OnError(Exception error)
        {
            clients.All.errorOccurred(error);
        }

        public void OnCompleted()
        {
            System.Diagnostics.Debug.WriteLine("Completed");
            if (host != null)
            {
                host.Dispose();
            }
        }
    }
}
