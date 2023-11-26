using CardGauntlet.Contracts;
using Microsoft.AspNetCore.Mvc;
using CardGauntlet.LockerNew;

namespace Mark;

[ApiController]
public class MarkController : ControllerBase
{
    [Route("game")]
    [HttpGet]
    public async Task<CardColor> GetColor()
    {
        await LockerNew.WaitForResourceAsync();
        return await Task.FromResult(MarkDeck.Color);
    }
}
