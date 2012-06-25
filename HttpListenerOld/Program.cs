using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceInterface.Admin;

namespace HttpListenerOld
{
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost()
            : base("Performance Test v3.8.3", typeof(HelloService).Assembly)
        {
        }

        public override void Configure(Funq.Container container)
        {
        }
    }

    class Program
    {
        private const string ListeningOn = "http://localhost:9200/";

        static void Main(string[] args)
        {
            Console.WriteLine("ServiceStack v3.8.3");

            var appHost = new AppHost();
            appHost.Init();
            appHost.Start(ListeningOn);

            Console.WriteLine("Started HTTP host on: " + ListeningOn);

            Console.ReadKey();
        }
    }
}
