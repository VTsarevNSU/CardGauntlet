using CardGauntlet.LockerNew;
using CardGauntlet.Contracts;
using MassTransit;

namespace Elon;
public class NumberCardConsumer: IConsumer<NumberCardMessage>
{
    public Task Consume(ConsumeContext<NumberCardMessage> context)
    {
        if (context.Message.Player == "Mark")
        {
            ElonDeck.Color = ElonDeck.Cards[context.Message.Number].Color;
            LockerNew.ResourceAvailable();
        }
        return Task.CompletedTask;
    }
}
