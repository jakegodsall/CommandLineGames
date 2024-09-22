using EntryPoint.Utils;

namespace EntryPoint;

public class MainMenu
{
    private static List<string> _options = new List<string>()
    {
        "Snake",
        "Tic-Tac-Toe"
    };
    
    public void Run()
    {
        ConsoleUtils.WriteHeader("COMMAND LINE GAMES");
        Console.WriteLine("\nSelect a game:\n");

        var success = false;
        var userInput = -1;
        do
        {
            userInput = UserInputUtils.GetIntFromUser(ConsoleUtils.WriteListOfItems, _options);
            success = userInput > 0 && userInput < _options.Count + 1;
            if (!success)
            {
                Console.WriteLine("Input must be in range");
            }

        } while (!success);

        Console.WriteLine("Selected value: " + userInput);
    }
}