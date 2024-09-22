using System.Runtime.InteropServices.JavaScript;

namespace EntryPoint.Utils;

public class UserInputUtils
{
    public static int GetIntFromUser(Action<List<string>> writeOptions, List<string> options)
    {
        writeOptions(options);
        var success = false;
        var number = 1;
        do
        {
            var userInput = Console.ReadLine();
            success = int.TryParse(userInput, out number);

            if (success) continue;
            
            Console.WriteLine("Invalid input. Please choose a valid option:\n");
            writeOptions(options);

        } while (!success);
        
        return number;
    }
}