// launch: dotnet run
using System.Runtime.CompilerServices;

const int picks = 1000000;

void printArray(Card[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write("{0} ", array[i].Color);
    }
    Console.WriteLine("\n");
}

var deck = new Card[36];

var deck1 = new Card[18];
var deck2 = new Card[18];

// create a deck
for (int i = 0; i < 18; i++)
{
    deck[i] = new Card(CardColor.Red);
}
for (int i = 18; i < 36; i++)
{
    deck[i] = new Card(CardColor.Black);
}

int correct = 0;
var rng = new Random();

ICardPickStrategy cardPickStrategy = new ICardPickStrategy();
for (int i = 0; i < picks; i++)
{
    Shuffler.Shuffle(rng, deck);
    //printArray(deck);

    Card.Split(deck, out deck1, out deck2);
    //printArray(deck1);
    //printArray(deck2);

    Card.Split(deck, out deck1, out deck2);
    int elon = cardPickStrategy.Pick(deck1, 0);
    int mark = cardPickStrategy.Pick(deck2, 1);
    if (deck2[elon].Color == deck1[mark].Color){
        correct++;
    }
}

Console.WriteLine(100 * (double)correct / picks);