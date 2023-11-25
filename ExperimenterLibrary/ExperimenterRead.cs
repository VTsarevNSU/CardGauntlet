using Microsoft.EntityFrameworkCore;
using CardGauntlet.Contracts;
using Microsoft.Extensions.Hosting;

namespace CardGauntlet.ExperimenterLibrary;
public class ExperimenterRead : IHostedService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPlayer _elonPlayer;
    private readonly IPlayer _markPlayer;
    private readonly IHostApplicationLifetime _lifeTime;
    private IShuffler _shuffler;

    public ExperimenterRead(ApplicationDbContext dbContext, IPlayer elonPlayer, IPlayer markPlayer, IHostApplicationLifetime lifeTime, IShuffler shuffler)
    {
        _dbContext = dbContext;
        _elonPlayer = elonPlayer;
        _markPlayer = markPlayer;
        _lifeTime = lifeTime;
        _shuffler = shuffler;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        int winsCount = 0;
        var experiments = await _dbContext.ExperimentConditions.ToListAsync();// получаем условия экспериментов из БД
        int experimentsCount = experiments.Count;

        foreach (var experimentCondition in experiments)
        {

            Card[] deck1; // колода
            Card[] deck2; // колода Марка
            Card[] deck = new Card[36]; // общая колода
            var deckInfo = experimentCondition.Deck.Split(',');// достаём карты из БД

            int i = 0;
            foreach (var cardInfo in deckInfo)
            {
                var parts = cardInfo.Split(':');
                if (Enum.TryParse(parts[1], out CardColor color))
                {
                    deck[i] = new Card(color);
                    i++;
                }
            }
            Card.Split(deck, out deck1, out deck2); // разделяем полученную колоду на две
        
            // проверяем условие победы
            if (deck2[_elonPlayer.PickCard(deck1)].ToString() == deck1[_markPlayer.PickCard(deck2)].ToString())
            {
                winsCount++;
            }

        }
        float res = ((float)winsCount / experimentsCount) * 100;
        Console.WriteLine(res);
        _lifeTime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
