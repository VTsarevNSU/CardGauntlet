using System.Reflection;
using Consumers;
using Elon;
using MassTransit;
using CardGauntlet.StrategyLibrary;
using CardGauntlet.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.SetInMemorySagaRepositoryProvider();
    x.AddConsumers(Assembly.GetEntryAssembly());
    x.UsingRabbitMq((_, config) => {
        config.ReceiveEndpoint("Elon_queue", ep => { ep.Consumer<DeckConsumer>(); ep.Consumer<NumberCardConsumer>(); });
        config.Host("localhost", "/", h => { h.Username("guest"); h.Password("guest"); });
    });
});
builder.Services.AddControllers();
builder.Services.AddScoped<ICardPickStrategy, Strategy>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
