namespace TodoList;

public class Todo
{
    private static int lastId = 0;
    public int Id { get; private set; }
    public string Description { get; private set;  }
    private DateTime CreatedAt { get; set; }
    private bool IsComplete { get; set; }

    public Todo(string description)
    {
        Id = ++lastId;
        Description = description;
        CreatedAt = DateTime.Now;
        IsComplete = false;
    }

    public Todo(int id, string description, DateTime createdAt, bool isComplete)
    {
        Id = ++lastId;
        Description = description;
        CreatedAt = createdAt;
        IsComplete = isComplete;
    }
        
    private string FormatCreatedAt()
    {
        return CreatedAt.ToString("yyyy/MM/dd HH:mm");
    }

    private string FormatComplete()
    {
        if (IsComplete)
        {
            return "[X]";
        }

        return "[]";
    }

    public override string ToString()
    {
        var substring = Description.Count() < 100 ? Description : Description.Substring(0, 100) + "...";
        return $"{FormatCreatedAt()}: {substring} {FormatComplete()}";
    }
        
    public string ToStringVerbose()
    {
        return $"{Id},{Description},{CreatedAt},{IsComplete}";
    }

    public static void InitialiseLastId(List<Todo> todos)
    {
        if (todos.Any())
        {
            lastId = todos.Max(todo => todo.Id);
        }
    }
}