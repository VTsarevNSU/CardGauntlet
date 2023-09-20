
using System.Diagnostics.Contracts;

public record Card(CardColor Color)
{

    public override string ToString()
    {
        return Color == CardColor.Black ? "♠️" : "♦️";
    }

    public static void Split(Card[] deck, out Card[] deck1, out Card[] deck2)
    {
        deck1 = deck.Take(18).ToArray();
        deck2 = deck.Skip(18).ToArray();
    }

}
