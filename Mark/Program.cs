using CardGauntlet.StrategyLibrary;
using CardGauntlet.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICardPickStrategy, Strategy>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();