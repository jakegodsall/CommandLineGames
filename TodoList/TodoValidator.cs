namespace TodoList;

public static class TodoValidator
{
    public static bool IsDescriptionValid(string description, List<Todo> todos)
    {
        return !IsDescriptionNullOrEmpty(description) && IsDescriptionUnique(description, todos);
    }

    public static bool IsDescriptionNullOrEmpty(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            Console.WriteLine("The description cannot be empty");
            return true;
        }
        return false;
    }

    public static bool IsDescriptionUnique(string description, List<Todo> todos)
    {
        return !todos.Exists(item => item.Description == description);
    }
}