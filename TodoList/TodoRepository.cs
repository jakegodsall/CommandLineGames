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
            var stringRepr = sr.ReadLine().Split(",");
            var todo = new Todo(stringRepr[0], DateTime.Parse(stringRepr[1]), bool.Parse(stringRepr[2]));
            todos.Add(todo);
        }

        return todos;
    }
            
    public static void Write(string filePath, List<Todo> todos)
    {
        using (var sw = new StreamWriter(filePath))
        {
            foreach (var todo in todos) 
            {
                sw.WriteLine(todo.ToStringVerbose());
            }
        }
    }
}