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
        int result = 0;

        Card[] deck = new Card[36];
        // create a deck
        for (int i = 0; i < 18; i++){
            deck[i] = new Card(CardColor.Red);
            deck[35 - i] = new Card(CardColor.Black);
        }

        for (int i = 0; i < 1000000; i++)
        {
            if (_experimenter.Conduct(deck))
                result++;
        }
        
        float res = ((float)result / 1000000) * 100;
        Console.WriteLine(res);
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}