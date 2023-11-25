using Microsoft.AspNetCore.Mvc;
using CardGauntlet.Contracts;

namespace Elon.Controllers;

[Route("[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly ICardPickStrategy _elonCardStrategy;

    [HttpPost("choice")]
    public IActionResult GetChoice([FromBody] List<Card> cards)
    {
        int elonChoice = _elonCardStrategy.Pick(cards.ToArray());
        return Ok(elonChoice);
    }

    public GameController(ICardPickStrategy elonCardStrategy)
    {
        _elonCardStrategy = elonCardStrategy;
    }

}
