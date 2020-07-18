using System;
using StackExchange.Redis;
using BasicPackage;
using System.IO;
using Google.Protobuf;
using System.Threading;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            var status = new BasicPackage.Data1 
            { 
                Value1 = true,
                Value2 = "Value2",
                Value3 = 100,
                Value4 = 200,
                Value5 = 10.5f
            };

            var byteString = status.ToByteString().ToStringUtf8();
            Console.WriteLine(byteString);

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");

            IDatabase db = redis.GetDatabase();

            while (true)
            {
                db.ListLeftPush("key1", byteString);
                Thread.Sleep(3 * 1000);
            }
        }
    }
}
