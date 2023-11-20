using System.Runtime.CompilerServices;
using CardGauntlet.Contracts;

namespace CardGauntlet.ShufflerLibrary;

public class Shuffler : IShuffler
{

    public Shuffler(){
    }

    public Card[] CreateDeck()
    {
        var deck = new Card[36];
        for (int i = 0; i < 18; i++){
            deck[i] = new Card(CardColor.Red);
            deck[35 - i] = new Card(CardColor.Black);
        }
        return deck;
    }

    public Card[] Shuffle(Card[] deck)
    {
        Random rng = new Random();
        int n = deck.Length;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            Card temp = deck[n];
            deck[n] = deck[k];
            deck[k] = temp;
        }
        return deck;
    }

}