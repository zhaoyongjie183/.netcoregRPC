using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcService;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace gRPCClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5711");

            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "晓晨" });
            Console.WriteLine("Greeter 服务返回数据: " + reply.Message);
            var catClient = new LuCat.LuCatClient(channel);
            var catReply = await catClient.SuckingCatAsync(new Empty());
            Console.WriteLine("调用撸猫服务：" + catReply.Message);

            var peopleClient = new PeoPleService.PeoPleServiceClient(channel);

            var c = await peopleClient.GetPeoPleNoAsync(new PeoPleNoRequest() { Id = 1 });

            Console.WriteLine("获取人员信息服务:"+ JsonConvert.SerializeObject(c));


            Console.ReadKey();
        }
    }
}
