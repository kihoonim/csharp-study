using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Helloworld;

namespace Basic.Server.GrpcService
{
    class BasicServerImpl : Greeter.GreeterBase
    {
        // Server side handler of the SayHello RPC
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            context.CancellationToken.Register(() => { Console.WriteLine("Cancel"); });

            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }
    }
}
