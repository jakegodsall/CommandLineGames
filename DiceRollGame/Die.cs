namespace DiceRoleGame;

public class Die
{
    public int NumberOfSides { get; set; }
    private static Random _randomGenerator = new Random();

    public Die(int numberOfSides)
    {
        NumberOfSides = numberOfSides;
    }

    public int Role()
    {
        return _randomGenerator.Next(1, NumberOfSides + 1);
    }
}