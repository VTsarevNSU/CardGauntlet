using CardGauntlet.Contracts;
using Mark;
using MassTransit;
using CardGauntlet.StrategyLibrary;

namespace Consumers;
public class DeckConsumer : IConsumer<CardMessage>
{
    public Task Consume(ConsumeContext<CardMessage> context)
    {
        MarkDeck.Cards = context.Message.Cards;
        ICardPickStrategy markStrategy = new Strategy();
        int markChoice = markStrategy.Pick(context.Message.Cards.ToArray());
        context.Publish(new NumberCardMessage { Number = markChoice, Player = "Mark" });
        return Task.CompletedTask;
    }    
}
