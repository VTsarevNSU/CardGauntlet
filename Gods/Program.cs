using CardGauntlet.Contracts;
using CardGauntlet.ShufflerLibrary;
using MassTransit;

namespace CardGauntlet.Gods;
class Program
{

    private static async Task<CardColor> GetColorResponse(int port)
    {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync($"http://localhost:{port}/game");
        response.EnsureSuccessStatusCode();
        return Enum.Parse<CardColor>(await response.Content.ReadAsStringAsync());
    }

    static async Task Main(string[] args)
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(config =>
        {
            config.Host(new Uri("rabbitmq://localhost"), host =>
            {
                host.Username("guest");
                host.Password("guest");
            });
        });
        bus.Start();

        int elonPort = 20001;
        int markPort = 20002;
        var elonEndpoint = await bus.GetSendEndpoint(new Uri("rabbitmq://localhost/Elon_queue"));
        var markEndpoint = await bus.GetSendEndpoint(new Uri("rabbitmq://localhost/Mark_queue"));

        int experimentsCount = 100;
        int winCount = 0;
        IShuffler shuffler = new Shuffler();
        for (int i = 0; i < experimentsCount; i++)
        {
            Card[] shuffledDeck = shuffler.Shuffle(shuffler.CreateDeck());
            Card[] elonCards = shuffledDeck.Take(18).ToArray();
            Card[] markCards = shuffledDeck.Skip(18).ToArray();

            await elonEndpoint.Send<CardMessage>(new { Cards = elonCards });
            await markEndpoint.Send<CardMessage>(new { Cards = markCards });
            CardColor elonColor = await GetColorResponse(elonPort);
            CardColor markColor = await GetColorResponse(markPort);
            if (elonColor == markColor) winCount++;
        }

        Console.WriteLine((double)winCount / experimentsCount * 100);
        bus.Stop();
    }

}
