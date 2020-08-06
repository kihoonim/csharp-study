using System;
using System.IO;
using System.Reflection;
using Akka.Actor;
using Akka.Configuration;

namespace RemoteDeploy
{
    class Program
    {
        static void Main(string[] args)
        {
            var hoconFileName = $"{Assembly.GetEntryAssembly().GetName().Name}.hocon";
            var currendDirectory = Directory.GetCurrentDirectory();
            var hoconFilePath = Path.Combine(currendDirectory, hoconFileName);

            var config = ConfigurationFactory.ParseString(File.ReadAllText(hoconFilePath));
            var system = ActorSystem.Create(config.GetString("akka.system.name"), config);

            // Config Deploy
            //var remoteDeploy = system.ActorOf(Props.Create(() => new Actors.BasicActor()), "remotedeploy");

            // Code Deploy
            var remoteDeploy = system.ActorOf(Props.Create(() => new Actors.BasicActor()).
                WithDeploy(Deploy.None.WithScope(new RemoteScope(Address.Parse(config.GetString("remote-address"))))), "remotedeploy");

            Console.ReadLine();
            system.Terminate().Wait();
        }
    }
}