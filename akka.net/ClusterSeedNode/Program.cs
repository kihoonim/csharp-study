using System;
using System.IO;
using System.Reflection;
using Akka.Actor;
using Akka.Routing;
using Akka.Configuration;

namespace ClusterSeedNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var hoconFileName = $"{Assembly.GetEntryAssembly().GetName().Name}.hocon";
            var currentDirectory = Directory.GetCurrentDirectory();
            var hoconFilePath = Path.Combine(currentDirectory, hoconFileName);

            var config = ConfigurationFactory.ParseString(File.ReadAllText(hoconFilePath));
            var system = ActorSystem.Create(config.GetString("akka.system.name"), config);

            system.ActorOf(Props.Create(() => new Actors.GossipReceiveActor()), typeof(Actors.GossipReceiveActor).Name);

            //system.ActorOf(Props.Create(() => new Actors.BasicActor()), typeof(Actors.BasicActor).Name);
            
            var props = Props.Create<Actors.BasicActor>().WithRouter(FromConfig.Instance);
            system.ActorOf(props, "BasicActors");

            Console.ReadLine();
            system.Terminate().Wait();
        }
    }
}
