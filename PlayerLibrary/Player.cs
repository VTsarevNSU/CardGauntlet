using System.Runtime.CompilerServices;
using CardGauntlet.Contracts;

namespace CardGauntlet.PlayerLibrary;

public class Player : IPlayer
{

    private ICardPickStrategy _strategy;

    public Player(ICardPickStrategy strategy){
        _strategy = strategy;
    }

    public int PickCard(Card[] cards)
    {
        return _strategy.Pick(cards);
    }
}