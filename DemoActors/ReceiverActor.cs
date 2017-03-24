using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoActors
{
    public class ReceiverActor: ReceiveActor
    {
        public ReceiverActor()
        {
            Receive<int>(m =>
            {
                Console.WriteLine($"message recieved with delay: {m}ms");
            });
        }
    }
}
