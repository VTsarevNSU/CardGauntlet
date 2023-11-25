using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using CardGauntlet.Contracts;
using CardGauntlet.ShufflerLibrary;
using CardGauntlet.ExperimenterLibrary;
using CardGauntlet.PlayerLibrary;
using CardGauntlet.StrategyLibrary;

namespace CardGauntlet.Sandbox;

class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("type: write, read, default");
        }
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                switch (args[0])
                {
                    case "write":
                        services.AddHostedService<ExperimenterWrite>();
                        break;
                    case "read":
                        services.AddHostedService<ExperimenterRead>();
                        break;
                    case "default":
                        services.AddHostedService<ExperimenterStandalone>();
                        break;
                }
                services.AddDbContext<ApplicationDbContext>();
                services.AddScoped<IShuffler, Shuffler>();
                services.AddScoped<ICardPickStrategy, Strategy>();
                services.AddTransient<IPlayer, Player>();
            });
    }
}