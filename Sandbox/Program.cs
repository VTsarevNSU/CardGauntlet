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
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {

                services.AddHostedService<SandboxWorker>();
                services.AddScoped<IExperimenter, Experimenter>();
                services.AddScoped<IShuffler, Shuffler>();
                services.AddScoped<ICardPickStrategy, Strategy>();
                services.AddTransient<IPlayer, Player>();

            });
    }
}
