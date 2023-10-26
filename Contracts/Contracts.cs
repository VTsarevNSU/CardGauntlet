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
    public void Shuffle(ref Card[] array);
}

public interface IExperimenter
{
    public bool Conduct(Card[] deck);
}
