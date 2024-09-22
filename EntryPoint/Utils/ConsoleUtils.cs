namespace EntryPoint.Utils;

public static class ConsoleUtils
{
    public static void WriteHeader(string title)
    {
        var padded = title.PadLeft(2).PadRight(4);
        var bar = new string('=', padded.Length);
        
        Console.WriteLine(bar);
        Console.WriteLine(padded);
        Console.WriteLine(bar);
    }
    
    public static void WriteListOfItems(List<string> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"\u2192 {i + 1}. {items[i]}");
        }
        Console.Write("\nPlease select an option: ");
    }
}