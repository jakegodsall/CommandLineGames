namespace TodoList;

public static class TodoRepository
{
    public static List<Todo> Read(string filePath)
    {
        var todos = new List<Todo>();
            
        if (!File.Exists(filePath))
        {
            return [];
        }

        using (var sr = new StreamReader(filePath))
        {
            
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var stringRepr = line.Split(",");
                if (stringRepr.Length == 4)
                {
                    try
                    {
                        var todo = new Todo(
                            int.Parse(stringRepr[0]),
                            stringRepr[1],
                            DateTime.Parse(stringRepr[2]),
                            bool.Parse(stringRepr[3])
                            );
                        todos.Add(todo);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Error parsing line: {line}. Exception: {e.Message}");
                        throw;
                    }
                }
                else
                {
                    Console.WriteLine($"Line format error: {line}");
                }
            }
          
        }
        return todos;
    }
            
    public static void Write(string filePath, List<Todo> todos)
    {
        using (var sw = new StreamWriter(filePath))
        {
            foreach (var todo in todos)
            {
                Console.WriteLine(todo.ToStringVerbose());
                sw.WriteLine(todo.ToStringVerbose());
            }
        }
    }
}