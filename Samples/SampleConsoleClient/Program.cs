using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace SampleConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var connection = new Connection("http://slabsignalrdemo.azurewebsites.net/semanticLogging");

                connection.Received += data =>
                    {
                        Console.WriteLine(data);
                    };

                connection.Start().ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        Console.WriteLine("There was an error opening the connection:{0}",
                                          task.Exception.GetBaseException());
                    }
                    else
                    {
                        Console.WriteLine("Connected");
                    }

                }).Wait();

                connection.Error += Console.WriteLine;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press enter to close");
            Console.ReadLine();

        }
    }


    public class Rootobject
    {
        public string ProviderId { get; set; }
        public int EventId { get; set; }
        public int Keywords { get; set; }
        public int Level { get; set; }
        public object Message { get; set; }
        public int Opcode { get; set; }
        public int Task { get; set; }
        public int Version { get; set; }
        public Payload Payload { get; set; }
        public string EventName { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Payload
    {
        public string name { get; set; }
    }

}
