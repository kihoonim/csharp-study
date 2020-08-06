using System;
using System.IO;
using System.Reflection;
using Akka.Actor;
using Akka.Configuration;
using Akka.Routing;

namespace Router
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

            // Code Base

            // Pool
            //var props = Props.Create<Actors.BasicActor>().WithRouter(new RoundRobinPool(5));
            //system.ActorOf(props, "BasicActors");

            // Group
            //var actors = new[] { "user/BasicActors/1", "user/BasicActors/2", "user/BasicActors/3" };
            //var props = Props.Create<Actors.BasicActor>().WithRouter(new RoundRobinGroup(actors));
            //system.ActorOf(props, "BasicActors");

            // Config Base

            // Pool
            var props = Props.Create<Actors.BasicActor>().WithRouter(FromConfig.Instance);
            system.ActorOf(props, "BasicActors");

            // Group
            //var props = Props.Create<Actors.BasicActor>().WithRouter(FromConfig.Instance);
            //system.ActorOf(props, "BasicActors");

            Console.ReadLine();

            system.Terminate().Wait();
        }
    }
}
