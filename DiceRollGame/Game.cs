namespace DiceRoleGame;

public class Game
{
    private int NumberOfGuesses { get; set; }
    private Die? _die;
    private int RolledValue { get; set;  }

    public void Play()
    {
        InitialiseGame();
        var guessCount = 0;
        var gameInPlay = true;
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
            isValidInput = InputValidator.IsInteger(Console.ReadLine(), out numberOfSides);
        }

        _die = new Die(numberOfSides);
        
        isValidInput = false;
        while (!isValidInput)
        {
            Console.WriteLine("How many guesses should you have?");
            isValidInput = InputValidator.IsInteger(Console.ReadLine(), out var tempNumberOfGuesses);
            NumberOfGuesses = tempNumberOfGuesses;
        }

        Console.WriteLine(
            $"Game initialised: You have {NumberOfGuesses} guesses to guess the value rolled on a {_die.NumberOfSides}-sided die.");

        RolledValue = _die.Roll();
    }

    private bool MakeGuess()
    {
        var guess = 1;
        var isValidInput = false;
        while (!isValidInput)
        {
            Console.WriteLine("Enter a number:");
            isValidInput = InputValidator.IsInteger(Console.ReadLine(), out guess);
        }

        return guess == RolledValue;
    }
}