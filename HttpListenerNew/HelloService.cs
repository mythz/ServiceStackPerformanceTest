using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.ServiceHost;
using System.Threading;

namespace HttpListenerNew
{
    [Route("/hello")]
    public class Hello { }
    
    public class HelloResponse
    {
        public string Text { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

    public class HelloService : ServiceBase<Hello>
    {
        protected override object Run(Hello request)
        {
            Thread.Sleep(1000);
            return new HelloResponse() { Text = "This is a performance test." };
        }
    }
}
