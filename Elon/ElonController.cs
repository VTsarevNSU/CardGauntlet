using CardGauntlet.Contracts;
using Microsoft.AspNetCore.Mvc;
using CardGauntlet.LockerNew;

namespace Elon;

[ApiController]
public class ElonController : ControllerBase
{
    [Route("game")]
    [HttpGet]
    public async Task<CardColor> GetColor()
    {
        await LockerNew.WaitForResourceAsync();
        return await Task.FromResult(ElonDeck.Color);
    }
}
