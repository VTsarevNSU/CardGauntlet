namespace CardGauntlet.Contracts;

public interface ICard
{
    public string ToString();
}

public interface ICardPickStrategy
{
    /// <summary>
    /// Возвращает номер карты в стопке другой жертвы согласно алгоритма
    /// </summary>
    /// <param name="cards">Стопка карт</param>
    /// <returns>Номер карты начиная с 0</returns>
    public int Pick(Card[] cards);
}

public interface IShuffler
{
    public Card[] Shuffle(Card[] deck);
    public Card[] CreateDeck();
}

public interface IExperimenter
{
    public bool ConductSingle();
    public float ConductMultiple(int n);
}

public interface IPlayer
{
    public int PickCard(Card[] cards);
}

public record CardMessage
{
    public List<Card> Cards { get; init; }
}

public record NumberCardMessage
{
    public int Number { get; init; }
    public string? Player { get; init; }
}
