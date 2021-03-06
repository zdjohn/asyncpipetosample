﻿using Akka.Actor;
using AsyncRpcEmulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoActors
{
    public class CallerActor : ReceiveActor
    {
        private readonly IActorRef _receiver;
        private readonly AsyncCallEmulator _asyncCallClient = new AsyncCallEmulator(20,100);

        public CallerActor()
        {
            _receiver = Context.ActorOf<ReceiverActor>("receiver");

            Receive<int>(m =>
            {
                Console.WriteLine($"message #{m} recieved by caller");
                _asyncCallClient.CallWithDelayedResponse().PipeTo(_receiver);
            });
        }

    }
}
