using ChannelProcessingSystem.Application;
using ChannelProcessingSystem.Data;
using ChannelProcessingSystem.Functions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChannelProcessingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var provider = serviceScope.ServiceProvider;
                var channel = provider.GetRequiredService<IChannel>();

                channel.Process();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddTransient<IChannelWriter>(s =>
                    {
                        var channelWriter = new FileChannelWriter("channel_output.txt", "parameter_output.txt");
                        return channelWriter;
                    });
                    services.AddTransient<IChannelReader>(s =>
                    {
                        var channelReader = new FileChannelReader("channels.txt", "parameters.txt");
                        return channelReader;
                    });
                    services.AddTransient<IChannel, Channel>();
                    services.AddScoped<FunctionsFactory>();
                });
        }
    }
}
