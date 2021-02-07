using System;
using Akka.Actor;
using Akka.Event;
using Akka.Cluster;

namespace Actors
{
    public sealed class GossipReceiveActor : ReceiveActor
    {
        private Cluster cluster = Cluster.Get(Context.System);

        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new GossipReceiveActor());
        }

        public GossipReceiveActor()
        {
            Receive<string>(message => ReceiveMessage(message));
            Receive<ClusterEvent.MemberUp>(message => ReceiveMessage(message));
            Receive<ClusterEvent.UnreachableMember>(message => ReceiveMessage(message));
            Receive<ClusterEvent.MemberRemoved>(message => ReceiveMessage(message));
            Receive<ClusterEvent.CurrentClusterState>(message => ReceiveMessage(message));

            Console.WriteLine($">>>>>>> {Self} Created");
        }

        protected override void PreStart()
        {
            cluster.Subscribe(Self, ClusterEvent.InitialStateAsEvents,
                new[] { typeof(ClusterEvent.IMemberEvent),
                        typeof(ClusterEvent.UnreachableMember) });
        }

        protected override void PostStop()
        {
            cluster.Unsubscribe(Self);
        }

        private void ReceiveMessage(string message)
        {
            Console.WriteLine($">>>>>>> {Self} : {message}");
        }

        private void ReceiveMessage(ClusterEvent.MemberUp message)
        {
            Console.WriteLine($">>>>>>> {Self} : {message}");
        }

        private void ReceiveMessage(ClusterEvent.UnreachableMember message)
        {
            Console.WriteLine($">>>>>>> {Self} : {message}");
        }

        private void ReceiveMessage(ClusterEvent.MemberRemoved message)
        {
            Console.WriteLine($">>>>>>> {Self} : {message}");
        }

        private void ReceiveMessage(ClusterEvent.CurrentClusterState message)
        {
            Console.WriteLine($">>>>>>> {Self} : {message}");
        }
    }
}