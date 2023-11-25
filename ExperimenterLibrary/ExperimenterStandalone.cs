using Microsoft.EntityFrameworkCore;
using CardGauntlet.Contracts;
using Microsoft.Extensions.Hosting;

namespace CardGauntlet.ExperimenterLibrary;

public class ExperimenterStandalone : BackgroundService
{
    private readonly IPlayer _elonPlayer;
    private readonly IPlayer _markPlayer;
    private readonly IHostApplicationLifetime _lifeTime;
    private IShuffler _shuffler;

    public ExperimenterStandalone(IShuffler shuffler, IPlayer elonPlayer, IPlayer markPlayer, IHostApplicationLifetime lifeTime)
    {
        _elonPlayer = elonPlayer;
        _markPlayer = markPlayer;
        _lifeTime = lifeTime;
        _shuffler = shuffler;
    }

    public bool ConductSingle()
    {

        Card[] deck1; // Elon's deck
        Card[] deck2; // Mark's deck

        Card.Split(_shuffler.Shuffle(_shuffler.CreateDeck()), out deck1, out deck2);
        
        if (deck2[_elonPlayer.PickCard(deck1)].ToString() == deck1[_markPlayer.PickCard(deck2)].ToString())
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public float ConductMultiple(int n)
    {
        int result = 0;

        _shuffler.CreateDeck();

        for (int i = 0; i < n; i++)
        {
            if (ConductSingle())
                result++;
        }
        
        float res = (float)result / n * 100;
        return res;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {

        float res = ConductMultiple(100000);
        Console.WriteLine(res);

        _lifeTime.StopApplication();

        return Task.CompletedTask;
    }
}