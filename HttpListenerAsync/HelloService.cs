using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.ServiceHost;
using System.Threading.Tasks;

namespace HttpListenerAsync
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
            //Like Task.Delay() from Async CTP (copied with Reflector)
            return TaskExtensions.Delay(1000)
                .ContinueWith<HelloResponse>(t => 
            {
                return new HelloResponse() { Text = "This is a performance test." };
            });
        }
    }
}
