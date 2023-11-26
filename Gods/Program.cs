﻿using CardGauntlet.Contracts;
using CardGauntlet.ShufflerLibrary;
using MassTransit;

namespace Gods;
class Program
{
    static async Task Main(string[] args)
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri("rabbitmq://localhost"), h =>
            {
                h.Username("guest");
                h.Password("guest");
            });
        });
            
        busControl.Start();

        Console.WriteLine("Gods are running experiments");

        int elonPort = 20001;
        int markPort = 20002;

        const int totalExperiments = 1000;
        int totalSuccesses = 0;
        IShuffler shuffler = new Shuffler();

        var elon_endpoint = await busControl.GetSendEndpoint(new Uri("rabbitmq://localhost/Elon_queue"));
        var mark_endpoint = await busControl.GetSendEndpoint(new Uri("rabbitmq://localhost/Mark_queue"));

        for (int i = 0; i < totalExperiments; i++)
        {
            var shuffledDeck = shuffler.Shuffle(shuffler.CreateDeck());

            Card[] elonCards = shuffledDeck.Take(18).ToArray();
            Card[] markCards = shuffledDeck.Skip(18).ToArray();

            await elon_endpoint.Send<CardMessage>(new { Cards = elonCards });
            await mark_endpoint.Send<CardMessage>(new { Cards = markCards });

            CardColor elonColor = await GetColorResponse(elonPort);
            CardColor markColor = await GetColorResponse(markPort);

            if (elonColor == markColor)
            {
                totalSuccesses++;
            }
        }

        double successRate = ((double)totalSuccesses / totalExperiments) * 100;
        Console.WriteLine($"success rate: {successRate}%");

        busControl.Stop();
    }

    private static async Task<CardColor> GetColorResponse(int port)
    {
        using HttpClient client = new HttpClient();
        var response = await client.GetAsync($"http://localhost:{port}/game");
        response.EnsureSuccessStatusCode();
        var colorString = await response.Content.ReadAsStringAsync();

        return Enum.Parse<CardColor>(colorString);
    }
}
