using CardGauntlet.Contracts;

namespace CardGauntlet.StrategyLibrary;

public class Strategy : ICardPickStrategy
{

    public int Pick(Card[] cards) // returns from 0 to 17; who == 0 -> Elon, who == 1 -> Mark
    {
        int red = 0;
        for (int i = 0; i < 18; i++)
        {
            if (cards[i].Color == CardColor.Red)
            {
                red++;
            }
        }
        return Math.Min(red, 17);
    }
}
