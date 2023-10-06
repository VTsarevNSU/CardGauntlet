using System.Runtime.CompilerServices;
using InterfacesLibrary;

public static class Shuffler
{
    public static void Shuffle(this Random rng, Card[] array)
    {
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