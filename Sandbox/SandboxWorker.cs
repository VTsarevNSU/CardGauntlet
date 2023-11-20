using CardGauntlet.Contracts;
using Microsoft.Extensions.Hosting;

class SandboxWorker : IHostedService
{

    private IExperimenter _experimenter;

    public SandboxWorker(IExperimenter experimenter)
    {
        _experimenter = experimenter;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        float res = _experimenter.ConductMultiple(100000);
        Console.WriteLine(res);
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}