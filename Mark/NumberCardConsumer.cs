using CardGauntlet.LockerNew;
using CardGauntlet.Contracts;
using MassTransit;

namespace Mark;
public class NumberCardConsumer: IConsumer<NumberCardMessage>
{
    public Task Consume(ConsumeContext<NumberCardMessage> context)
    {
        if (context.Message.Player == "Elon")
        {
            MarkDeck.Color = MarkDeck.Cards[context.Message.Number].Color;
            LockerNew.ResourceAvailable();
        }
        return Task.CompletedTask;
    }
}
