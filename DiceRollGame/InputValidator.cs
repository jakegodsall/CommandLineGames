namespace DiceRoleGame;

public static class InputValidator
{
    public static bool IsInteger(string? input, out int value)
    {
        if (int.TryParse(input, out value)) return true;
        Console.WriteLine("Please enter a valid integer");
        return false;
    }
}