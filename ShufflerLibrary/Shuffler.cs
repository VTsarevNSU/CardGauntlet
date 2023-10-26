using System.Runtime.CompilerServices;
using CardGauntlet.Contracts;

namespace CardGauntlet.ShufflerLibrary;

public class Shuffler : IShuffler
{
    public void Shuffle(ref Card[] array)
    {
        Random rng = new Random();
        int n = array.Length;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            Card temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

}