using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.Plugins.Tasks;

namespace HttpListenerAsync
{
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost()
            : base("Performance Test v4.0.0 async", typeof(HelloService).Assembly)
        {
        }

        public override void Configure(Funq.Container container)
        {
            this.Plugins.Add(new TaskSupport());
        }
    }

    class Program
    {
        private const string ListeningOn = "http://localhost:9200/";

        static void Main(string[] args)
        {
            Console.WriteLine("ServiceStack v4.0.0 async");

            var appHost = new AppHost();
            appHost.Init();
            appHost.Start(ListeningOn);

            Console.WriteLine("Started HTTP host on: " + ListeningOn);

            Console.ReadKey();
        }
    }
}
