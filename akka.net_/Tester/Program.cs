using System;
using System.IO;
using System.Reflection;
using Akka.Actor;
using Akka.Configuration;

namespace Tester
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

            system.ActorOf(Props.Create(() => new SendActor(config)), typeof(SendActor).Name);

            Console.ReadLine();

            system.Terminate().Wait();
        }
    }
}
