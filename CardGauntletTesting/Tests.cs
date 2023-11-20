namespace CardGauntletTesting;

using Xunit;
using CardGauntlet.Contracts;
using CardGauntlet.ShufflerLibrary;
using CardGauntlet.StrategyLibrary;
using CardGauntlet.ExperimenterLibrary;
using CardGauntlet.PlayerLibrary;
using Moq;

public class DeckTest
{

        [Fact]
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

public class StrategyTest
{
        [Fact]
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

public class ExperimenterTest
{

        [Fact]
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

        [Fact]
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