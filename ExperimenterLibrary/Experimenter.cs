using CardGauntlet.Contracts;
using CardGauntlet.PlayerLibrary;

namespace CardGauntlet.ExperimenterLibrary;

public class Experimenter : IExperimenter
{

    private IShuffler _shuffler;
    private Player _playerOne;
    private Player _playerTwo;
    

    public Experimenter(IShuffler shuffler, Player playerOne, Player playerTwo){
        _shuffler = shuffler;
        _playerOne = playerOne; // Elon
        _playerTwo = playerTwo; // Mark
    }

    public bool Conduct(Card[] deck)
    {

        _shuffler.Shuffle(ref deck);

        Card[] deck1; // Elon's deck
        Card[] deck2; // Mark's deck

        Card.Split(deck, out deck1, out deck2);//TODO Memory/Span
        
        if (deck2[_playerOne.PickCard(deck1)].ToString() == deck1[_playerTwo.PickCard(deck2)].ToString())
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}