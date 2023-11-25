namespace CardGauntletTesting;

using CardGauntlet.Contracts;
using CardGauntlet.ShufflerLibrary;
using CardGauntlet.StrategyLibrary;
using CardGauntlet.ExperimenterLibrary;
using Moq;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

[TestFixture]
public class DeckTest
{

        [Test]
        public void TestDeck()
        {
            var shuffler = new Shuffler();
            Card[] deck = shuffler.CreateDeck();
            int b = 0;
            int r = 0;
            foreach (var it in deck)
            {
                if (it.Color == CardColor.Red)
                {
                    r++;
                }
                if (it.Color == CardColor.Black)
                {
                    b++;
                }
            }
            Assert.True((b == 18) && (r == 18), "deck must have 18 red and 18 black cards");
        }

}

[TestFixture]
public class StrategyTest
{
        [Test]
        public void TestStrategy()
        {
            Card[] deck = new Card[18];
            var strategy = new Strategy();
            for (int i = 0; i <= 18; i++)
            {
                // we'll have i red cards, so strategy must return Min(i, 17)
                for (int j = 0; j < i; j++){
                    deck[j] = new Card(CardColor.Red);
                }
                for (int j = i; j < 18; j++){
                    deck[j] = new Card(CardColor.Black);
                }
                int res = strategy.Pick(deck);
                Assert.True(res == Math.Min(i, 17), "");
            }
        }
}

[TestFixture]
public class ExperimenterTest
{

        [Test]
        public void TestSingleShuffleCall()
        {

            Card[] realDeck = new Card[36];
            for (int i = 0; i < 18; i++)
            {
                realDeck[i] = new Card(CardColor.Red);
            }
            for (int i = 18; i < 36; i++)
            {
                realDeck[i] = new Card(CardColor.Black);
            }

            Mock<IShuffler> mShuffler = new Mock<IShuffler>();  
            mShuffler.Setup(shuffler => shuffler.Shuffle(It.IsAny<Card[]>())).Returns((Card[] input) => input);
            mShuffler.Setup(shuffler => shuffler.CreateDeck()).Returns(() => realDeck);

            Mock<IPlayer> mPlayerOne = new Mock<IPlayer>();
            mPlayerOne.Setup(elon => elon.PickCard(It.IsAny<Card[]>())).Returns(0);

            Mock<IPlayer> mPlayerTwo = new Mock<IPlayer>();  
            mPlayerTwo.Setup(mark => mark.PickCard(It.IsAny<Card[]>())).Returns(0);

            var experimenter = new Experimenter(mShuffler.Object, mPlayerOne.Object, mPlayerTwo.Object);
            experimenter.ConductSingle();

            mShuffler.Verify(shuffler => shuffler.Shuffle(It.IsAny<Card[]>()), Times.Once());
        }

        [Test]
        public void TestResult()
        {
            
            Card[] elonCards = new Card[18];
            Card[] markCards = new Card[18];
            for (int i = 0; i < 17; i++)
            {
                elonCards[i] = new Card(CardColor.Red);
                markCards[i] = new Card(CardColor.Black);
            }
            elonCards[17] = new Card(CardColor.Black);
            markCards[17] = new Card(CardColor.Red);

            Card[] realDeck = new Card[36];
            for (int i = 0; i < 18; i++)
            {
                realDeck[i] = new Card(CardColor.Red);
            }
            for (int i = 18; i < 36; i++)
            {
                realDeck[i] = new Card(CardColor.Black);
            }

            Mock<IShuffler> mShuffler = new Mock<IShuffler>();  
            mShuffler.Setup(shuffler => shuffler.Shuffle(It.IsAny<Card[]>())).Returns((Card[] input) => input);
            mShuffler.Setup(shuffler => shuffler.CreateDeck()).Returns(() => realDeck);

            var mStrategy = new Mock<ICardPickStrategy>();
            mStrategy.Setup(strategy => strategy.Pick(It.IsAny<Card[]>())).Returns(0);

            var mPlayerOne = new Mock<IPlayer>();
            mPlayerOne.Setup(elon => elon.PickCard(elonCards)).Returns(0);

            var mPlayerTwo = new Mock<IPlayer>();  
            mPlayerTwo.Setup(mark => mark.PickCard(markCards)).Returns(17);

            Experimenter experimenter = new Experimenter(mShuffler.Object, mPlayerOne.Object, mPlayerTwo.Object);
            var res = experimenter.ConductSingle();
            Assert.False(res, "");
        }
}

[TestFixture]
public class DataBaseTests 
{
    private IPlayer _elonPlayer;
    private IPlayer _markPlayer;
    private IHostApplicationLifetime _lifetime;

    [SetUp]
    public void SetUp()
    {
        _elonPlayer = new Mock<IPlayer>().Object;
        _markPlayer = new Mock<IPlayer>().Object;
        _lifetime = new Mock<IHostApplicationLifetime>().Object;
    }

    [Test, Order(1)]
    public async Task SaveExperimentConditionsToMemoryAsync()
    {
        using (var context = new ApplicationDbContext(":memory:"))
        {
            var elonPlayer = new Mock<IPlayer>().Object;
            var markPlayer = new Mock<IPlayer>().Object;
            var lifetime = new Mock<IHostApplicationLifetime>().Object;
            var shuffler = new Mock<IShuffler>().Object;

            // записываем тестовые условия
            var writeWorker = new ExperimenterWrite(context, shuffler, elonPlayer, markPlayer, lifetime);
            await writeWorker.StartAsync(CancellationToken.None);
            // читаем из БД эти условия и проверяем их
            var experimentConditions = context.ExperimentConditions.ToList();

            Assert.That(experimentConditions, Is.Not.Null.And.Not.Empty);
            Assert.That(experimentConditions.Count, Is.EqualTo(100));

            // очистка БД в оперативной памяти чтобы второй тест прошёл спокойно
            foreach(var condition in experimentConditions)
            {
                context.ExperimentConditions.Remove(condition);
            }
            await context.SaveChangesAsync();
        }
    }

    [Test, Order(2)]
    public async Task ReadExperimentConditionsFromMemoryAsync()
    {
        using (var context = new ApplicationDbContext(":memory:"))
        {
            var elonPlayer = new Mock<IPlayer>();
            var markPlayer = new Mock<IPlayer>();
            var lifetime = new Mock<IHostApplicationLifetime>();
            var shuffler = new Mock<IShuffler>().Object;

            var realShuffler = new Shuffler();
            var deck = realShuffler.CreateDeck();

            // создаём 10 тестовых колод и сохраняем в оперативную память
            for (int i = 0; i < 10; i++)
            {
                var experimentCondition = new ExperimentCondition
                {
                    Deck = string.Join(",", deck.Select(card => $"1:{card.Color}")),
                    Success = true
                };
                context.ExperimentConditions.Add(experimentCondition);
            }
            await context.SaveChangesAsync();

            // теперь читаем из оперативной памяти 10 условий и проверяем их корректность
            var readWorker = new ExperimenterRead(context, elonPlayer.Object, markPlayer.Object, lifetime.Object, shuffler);
            await readWorker.StartAsync(CancellationToken.None);

            foreach (var condition in context.ExperimentConditions)
            {
                Assert.That(condition.Deck, Is.EqualTo(string.Join(",", deck.Select(card => $"1:{card.Color}"))));
                Assert.That(condition.Success, Is.True);
            }
        }
    }
}
