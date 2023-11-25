using Microsoft.EntityFrameworkCore;
using CardGauntlet.Contracts;
using Microsoft.Extensions.Hosting;

namespace CardGauntlet.ExperimenterLibrary;

    public class ExperimenterWrite : IHostedService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPlayer _elonPlayer;
        private readonly IPlayer _markPlayer;
        private readonly IHostApplicationLifetime _lifeTime;
        private IShuffler _shuffler;

        public ExperimenterWrite(ApplicationDbContext dbContext, IShuffler shuffler, IPlayer elonPlayer, IPlayer markPlayer, IHostApplicationLifetime lifeTime)
        {
            _dbContext = dbContext;
            _elonPlayer = elonPlayer;
            _markPlayer = markPlayer;
            _lifeTime = lifeTime;
            _shuffler = shuffler;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            const int experimentsCount = 100;

            for (int i = 0; (i < experimentsCount && !cancellationToken.IsCancellationRequested); i++)
            {
                var deck = _shuffler.Shuffle(_shuffler.CreateDeck());

                var experimentCondition = new ExperimentCondition
                {
                    Deck = string.Join(",", deck.Select(card => $"1:{card.Color}")),// генерируем строку-колоду //todo единичку убрать
                    Success = true
                };// создание записи

                _dbContext.ExperimentConditions.Add(experimentCondition);// добавляем в рамках транзакции
                await _dbContext.SaveChangesAsync(cancellationToken);// commit транзакции
            }

            _lifeTime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
