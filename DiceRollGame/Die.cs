namespace DiceRoleGame;

public class Die
{
    public int NumberOfSides { get; set; }
    private readonly Random _random = new Random();

    public Die(int numberOfSides)
    {
        NumberOfSides = numberOfSides;
    }

    public int Roll()
    {
        return _random.Next(1, NumberOfSides + 1);
    }

    public void Describe()
    {
        Console.WriteLine($"A {NumberOfSides}-sided die.");
    }
}