using System;
using Basic.Server.GrpcService;

namespace Basic.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicServer basicServer = new BasicServer("127.0.0.1", 8081);
            basicServer.Start();
        }
    }
}
