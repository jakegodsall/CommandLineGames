namespace DiceRoleGame;

public class Game
{
    public Die Die { get; set; }
    public int NumberOfGuesses { get; private set; }

    public Game()
    {
    }

    public void Run()
    {
        InitialiseGame();
    }

    private void InitialiseGame()
    {
        Console.WriteLine("Welcome to the dice rolling game!");
        Console.WriteLine("Press enter to play");
        while (true)
        {
            var consoleKeyInfo = Console.ReadKey();
            if (consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
        
        
        var numberOfSides = 6;
        var isValidInput = false;

        while (!isValidInput)
        {
            Console.WriteLine("How many sides should the die have?");
            var input = Console.ReadLine();
            isValidInput = InputValidator.IsInteger(input, out numberOfSides);
        }

        Die = new Die(numberOfSides);
        
        isValidInput = false;
        int tempNumberOfGuesses;
        while (!isValidInput)
        {
            Console.WriteLine("How many guesses should you have?");
            var input = Console.ReadLine();
            isValidInput = InputValidator.IsInteger(input, out tempNumberOfGuesses);
            NumberOfGuesses = tempNumberOfGuesses;
        }

        Console.WriteLine(
            $"Game initialised: You have {NumberOfGuesses} guesses to guess the value rolled on a {Die.NumberOfSides}-sided die.");
    }
}