namespace TodoList;

public class Todo
{
    public string Description { get; private set;  }
    private DateTime CreatedAt { get; set; }
    private bool IsComplete { get; set; }

    public Todo(string description)
    {
        Description = description;
        CreatedAt = DateTime.Now;
        IsComplete = false;
    }

    public Todo(string description, DateTime createdAt, bool isComplete)
    {
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
        var substring = Description.Count() < 20 ? Description : Description.Substring(0, 20);
        return $"{FormatCreatedAt()}: {substring}... {FormatComplete()}";
    }
        
    public string ToStringVerbose()
    {
        return $"{Description},{CreatedAt},{IsComplete}";
    }
}