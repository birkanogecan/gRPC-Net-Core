using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using Person;

namespace gRPC.Test
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Include port of the gRPC server as an application argument
            var port = args.Length > 0 ? args[0] : "50051";

            var channel = new Channel("localhost:" + port, ChannelCredentials.Insecure);
            var GreeterClient = new Greeter.GreeterClient(channel);

            var PersonerClient = new Personer.PersonerClient(channel);

            var greetReply = await GreeterClient.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + greetReply.Message);

            var personReply = await PersonerClient.GetPersonAsync(new PersonRequest { Id = "1" });
            Console.WriteLine("1 Id'li kullanýcý: " + personReply.Name);

            await channel.ShutdownAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
