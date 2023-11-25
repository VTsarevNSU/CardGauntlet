using CardGauntlet.Contracts;

namespace CardGauntlet.ExperimenterLibrary;

public class Experimenter : IExperimenter
{

    private IShuffler _shuffler;
    private IPlayer _playerOne;
    private IPlayer _playerTwo;

    public Experimenter(IShuffler shuffler, IPlayer playerOne, IPlayer playerTwo){
        _shuffler = shuffler;
        _playerOne = playerOne; // Elon
        _playerTwo = playerTwo; // Mark
    }

    public bool ConductSingle()
    {

        Card[] deck1; // Elon's deck
        Card[] deck2; // Mark's deck

        Card.Split(_shuffler.Shuffle(_shuffler.CreateDeck()), out deck1, out deck2);
        
        if (deck2[_playerOne.PickCard(deck1)].ToString() == deck1[_playerTwo.PickCard(deck2)].ToString())
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public float ConductMultiple(int n)
    {
        int result = 0;

        _shuffler.CreateDeck();

        for (int i = 0; i < 1000000; i++)
        {
            if (ConductSingle())
                result++;
        }
        
        float res = (float)result / 1000000 * 100;
        return res;
    }

}