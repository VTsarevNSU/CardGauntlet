namespace StrategyLibrary;

using InterfacesLibrary;

public class ICardPickStrategy
{
    public int Pick(Card[] cards, int who) // returns from 0 to 17; who == 0 -> Elon, who == 1 -> Mark
    {

        if (who == 0){ // Elon chooses

            int red = 0;
            for (int i = 0; i < 18; i++)
            {
                if (cards[i].Color == CardColor.Red)
                {
                    red++;
                }
            }
            return Math.Min(red, 17);

        } else { // Mark chooses

            int red = 0;
            for (int i = 0; i < 18; i++)
            {
                if (cards[i].Color == CardColor.Red)
                {
                    red++;
                }
            }
            return Math.Min(18 - red, 17);

        }

    }
}
