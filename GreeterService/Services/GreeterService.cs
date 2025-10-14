using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GreeterService.Services;

public class GreeterService(ILogger<GreeterService> logger) : Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        logger.LogInformation("Received greeting request for {Name}", request.Name);
        
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
