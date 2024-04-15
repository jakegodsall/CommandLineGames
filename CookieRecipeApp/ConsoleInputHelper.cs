namespace CookieRecipeApp;

public class ConsoleInputHelper
{
    public static int GetIntegerInputInRange(string errorMessage, int min, int max)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out var intInput))
            {
                if (intInput > min && intInput < max)
                {
                    return intInput;
                }
            }
            Console.WriteLine(errorMessage);
        }
    }
    
}