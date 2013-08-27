using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks;

namespace SemanticLogging.SignalR
{
    public class SignalRSink : IObserver<string>
    {
        private IHubConnectionContext clients;
        private object host;

        public ISignalRHost Host { get; set; }


        public SignalRSink(ISignalRHost host = null)
        {
            this.Host = host ?? new MvcSignalRHost();
        }

        public void Startup()
        {
            this.Host.Start();
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
            this.Host.ShutDown();
        }
    }
}
