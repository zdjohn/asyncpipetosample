using Akka.Actor;
using Akka.Routing;
using AsyncRpcEmulator;
using DemoActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var system = ActorSystem.Create("demo"))
            {
                var fackApiClient = new AsyncCallEmulator(20, 100);

                var props = Props.Create(() => new CallerActor(fackApiClient))
                    .WithRouter(new RoundRobinPool(5));

                var caller = system.ActorOf(props, "caller");
                for(int i=0; i<100; i++)
                {
                    caller.Tell(i);
                }
                Console.ReadLine();
            }
        }
    }
}
