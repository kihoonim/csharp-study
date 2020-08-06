using System;
using Akka.Actor;
using Akka.Configuration;

namespace Tester
{
    public sealed class SendActor : ReceiveActor
    {
        public static Props Props(Config config)
        {
            return Akka.Actor.Props.Create(() => new SendActor(config));
        }

        public SendActor(Config config)
        {
            Receive<string>(message => ReceiveMessage(message));

            IActorRef receiver = Context.ActorSelection(config.GetString("receiver"))
                .ResolveOne(TimeSpan.FromMilliseconds(3000)).Result;

            SendMessage(receiver);
        }

        private void ReceiveMessage(string message)
        {
            Console.WriteLine($">>>>>>> {Self} : {message}");
        }

        private void SendMessage(IActorRef receiver)
        {
            for (int i = 0; i < 100; i++)
                receiver.Tell("Hello");
        }
    }
}