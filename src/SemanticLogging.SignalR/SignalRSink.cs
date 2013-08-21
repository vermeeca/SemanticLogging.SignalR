using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks;

namespace SemanticLogging.SignalR
{
    public class SignalRSink : IObserver<string>
    {
        public SignalRSink()
        {
            
        }

        public void OnNext(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        public void OnError(Exception error)
        {
            System.Diagnostics.Debug.WriteLine(error);
        }

        public void OnCompleted()
        {
            System.Diagnostics.Debug.WriteLine("Completed");
        }
    }
}
