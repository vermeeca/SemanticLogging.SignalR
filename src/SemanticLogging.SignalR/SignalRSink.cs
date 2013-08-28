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
        private IPersistentConnectionContext connection;
        private object host;

        public ISignalRHost Host { get; set; }


        public SignalRSink(ISignalRHost host = null)
        {
            this.Host = host ?? new MvcSignalRHost();
        }

        public void Startup()
        {
            this.Host.Start();
            this.connection = GlobalHost.ConnectionManager.GetConnectionContext<SemanticLoggingConnection>();
        }



        public void OnNext(string value)
        {
            connection.Connection.Broadcast(value);
        }

        public void OnError(Exception error)
        {
            connection.Connection.Broadcast(error.ToString());
        }

        public void OnCompleted()
        {
            this.Host.ShutDown();
        }
    }
}
