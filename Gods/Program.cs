using System.Text;
using System.Text.Json;
using CardGauntlet.Contracts;
using CardGauntlet.ShufflerLibrary;

namespace Gods;

class Program
{
    private static async Task<int> SendDeckAsync(Card[] cards, int port)
    {
        using (HttpClient client = new HttpClient())
        {
            string json = JsonSerializer.Serialize(cards);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await client.PostAsync($"http://localhost:{port}/game/choice", content);
            response.EnsureSuccessStatusCode();
            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }
    }

    static async Task Main(string[] args)
    {

        Shuffler shuffler = new Shuffler();
        var shuffledDeck = shuffler.Shuffle(shuffler.CreateDeck());
        Card[] elonCards = shuffledDeck.Take(18).ToArray();
        Card[] markCards = shuffledDeck.Skip(18).ToArray();

        var elonChoice = await SendDeckAsync(elonCards, 20001);
        var markChoice = await SendDeckAsync(markCards, 20002);

        Console.WriteLine($"Elon chose: {markCards[elonChoice]}");
        Console.WriteLine($"Mark chose: {elonCards[markChoice]}");
        if (markCards[elonChoice].Color == elonCards[markChoice].Color)
        {
            Console.WriteLine("win");
        }
        else
        {
            Console.WriteLine("lose");
        }
    }

}
