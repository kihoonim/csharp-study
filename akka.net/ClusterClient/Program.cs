using System;
using System.IO;
using System.Reflection;
using Akka.Actor;
using Akka.Routing;
using Akka.Cluster;
using Akka.Cluster.Tools.Client;
using Akka.Configuration;

namespace ClusterClient
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
            ClusterClientReceptionist.Get(system).RegisterService();

            Console.ReadLine();
            system.Terminate().Wait();
        }
    }
}
