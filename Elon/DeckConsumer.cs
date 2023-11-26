using CardGauntlet.Contracts;
using Elon;
using MassTransit;
using CardGauntlet.StrategyLibrary;

namespace Consumers;
public class DeckConsumer: IConsumer<CardMessage>
{
    public Task Consume(ConsumeContext<CardMessage> context)
    {
        ElonDeck.Cards = context.Message.Cards;
        ICardPickStrategy elonStrategy = new Strategy();
        int elonChoice = elonStrategy.Pick(context.Message.Cards.ToArray());
        context.Publish(new NumberCardMessage {Number = elonChoice, Player = "Elon"});
        return Task.CompletedTask;
    }    
}
