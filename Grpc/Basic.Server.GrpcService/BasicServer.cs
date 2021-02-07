using System;
using Grpc.Core;
using Helloworld;

namespace Basic.Server.GrpcService
{
    public class BasicServer
    {
        private Grpc.Core.Server _server;

        public BasicServer(string ip, int port)
        {
            _CreateServer(ip, port);
        }

        private Grpc.Core.Server _CreateServer(string ip, int port)
        {
            Grpc.Core.Server server = new Grpc.Core.Server
            {
                Services = { Greeter.BindService(new BasicServerImpl()) },
                Ports = { new ServerPort(ip, port, ServerCredentials.Insecure) }
            };

            return server;
        }

        public void Start()
        {
            _server.Start();
        }

        public void Stop()
        {
            _server.ShutdownAsync().Wait();
        }
    }
}
