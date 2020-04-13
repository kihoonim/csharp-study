using System;
using Akka.Actor;

namespace Actors
{
    public sealed class BasicActor : ReceiveActor
    {
        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new BasicActor());
        }

        public BasicActor()
        {
            Receive<string>(message => ReceiveMessage(message));

            Console.WriteLine($">>>>>>> {Self} Created");
        }

        private void ReceiveMessage(string message)
        {
            Console.WriteLine($">>>>>>> {Self} : {message}");
        }
    }
}
