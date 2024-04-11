namespace DiceRoleGame;

public class Game
{
    public int NumberOfGuesses { get; private set; }
    public Die Die { get; set; }
    public int RolledValue { get; set;  }
    
    

    public Game()
    {
    }

    public void Run()
    {
        InitialiseGame();
        int guessCount = 0;
        bool gameInPlay = true;
        while (gameInPlay)
        {
            var guessedCorrectly = MakeGuess();
            ++guessCount;

            if (guessedCorrectly)
            {
                Console.WriteLine($"Correct! You guessed the correct value in {guessCount} guesses.");
                gameInPlay = false;
            }
            else if (guessCount == NumberOfGuesses)
            {
                Console.WriteLine("You lose :(");
                gameInPlay = false;
            }
        }

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

        RolledValue = Die.Role();
    }

    private bool MakeGuess()
    {
        int guess = 1;
        var isValidInput = false;
        while (!isValidInput)
        {
            Console.WriteLine("Enter a number:");
            var input = Console.ReadLine();
            isValidInput = InputValidator.IsInteger(input, out guess);
        }

        return guess == RolledValue;
    }
}