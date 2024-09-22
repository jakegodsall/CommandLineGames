namespace EntryPoint.Utils;

public static class ConsoleUtils
{
    public static void GenerateConsoleHeader(string title)
    {
        var padded = title.PadLeft(2).PadRight(4);
        var bar = new string('=', padded.Length);
        
        Console.WriteLine(bar);
        Console.WriteLine(padded);
        Console.WriteLine(bar);
    }
}