namespace TodoList;

public class TodoList
{
    private List<Todo> _todos = new List<Todo>();
    private static readonly string DataFilePath = Directory.GetCurrentDirectory() + "/data.txt";
    private static readonly string[] Options =
    {
        "[V]iew all TODOs",
        "[A]dd a TODO",
        "[R]emove",
        "[M]ark TODO as complete",
        "[S]ave",
    };
        
    public void Run()
    {
        _todos = TodoRepository.Read(DataFilePath);
        Todo.InitialiseLastId(_todos);
        if (TodoCount() == 0)
        {
            Console.WriteLine("No saved todos.");
        }
        else
        {
            Console.WriteLine(TodoCount() == 1 ? $"Loaded {TodoCount()} saved todo." : $"Loaded {TodoCount()} saved todos.");
        }

        Console.WriteLine();

        ConsoleKeyInfo consoleKeyInfo;
        do
        {
            Console.WriteLine("Press enter to show options.");
            Console.WriteLine("Press q to exit.\n");
            consoleKeyInfo = Console.ReadKey();
            if (consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                SelectOption();
            }
        } while (consoleKeyInfo.Key != ConsoleKey.Q);
    }

    private void SelectOption()
    {
        string input;
        PrintOptions();
        Console.WriteLine("Select an option:\n");
        input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
                
            switch (input)
            {
                case "V":
                case "v":
                    Console.Clear();
                    PrintSelectedOption("View all TODOs");
                    ShowAllTodos();
                    break;
                case "A":
                case "a":
                    PrintSelectedOption("Add a TODO");
                    AddTodoItem();
                    break;
                case "R":
                case "r":
                    PrintSelectedOption("Remove");
                    RemoveTodoItem();
                    break;
                case "M":
                case "m":
                    PrintSelectedOption("Mark TODO as complete");
                    MarkTodoAsComplete();
                    break;
                case "S":
                case "s":
                    SaveTodos();
                    break;
            }
        }
    }

    private void ShowAllTodos()
    {
        if (TodoCount() == 0)
        {
            ShowNoTodosMethod();
        }
        else
        {
            for (var i = 0; i < TodoCount(); i++)
            {
                var item = _todos[i];
                PrintTableRow(item);
            }
            Console.WriteLine();
        }
    }
        
    private void AddTodoItem()
    {
        Console.WriteLine("Enter a TODO description: ");
        var userInput = Console.ReadLine();
        if (TodoValidator.IsDescriptionValid(userInput, _todos))
        {
            _todos.Add(new Todo(userInput));
            Console.WriteLine("Todo item added.");
        }
    }
        
    private void RemoveTodoItem()
    {
        if (_todos.Count == 0)
        {
            ShowNoTodosMethod();
        }

        int indexToRemove = ConsoleInputHelper.GetIntegerFromUser("Please enter the index of the TODO to remove");

        _todos.RemoveAll(todo => todo.Id == indexToRemove);
    }

    private bool IsInputValidTodoIndex(string input, out int indexToRemove)
    {
        var isInteger = (int.TryParse(input, out indexToRemove));
        if (!isInteger)
        {
            Console.WriteLine("The value must be an integer");
            return false;
        } 
        if (indexToRemove < 1 || indexToRemove > _todos.Count + 1)
        {
            Console.WriteLine("The value must be in range");
            return false;
        }
        return true;
    }

    public void MarkTodoAsComplete()
    {
        Console.WriteLine("Select a TODO to mark as complete (by index):");
        ShowAllTodos();

        int indexToMarkAsComplete = ConsoleInputHelper.GetIntegerFromUser("Please enter the index of the TODO to mark as complete");

        foreach (var todo in _todos)
        {
            if (todo.Id == indexToMarkAsComplete)
            {
                todo.IsComplete = true;
                break;
            }
        }
        
        ShowAllTodos();
    }

    

    private void SaveTodos()
    {
        TodoRepository.Write(DataFilePath, _todos);
        Console.WriteLine("Todos saved to disk.");
    }
        
    private static void PrintOptions()
    {
        Console.WriteLine("What do you want to do?");
        foreach (var option in Options)
        {
            Console.WriteLine(option);
        }

        Console.WriteLine();
    }
        
    private void PrintSelectedOption(string selectedOption)
    {
        Console.WriteLine("Selected option: " + selectedOption);
    }

    private void PrintTableRow(Todo item)
    {
        Console.WriteLine(item);
    }

    private static void ShowNoTodosMethod()
    {
        Console.WriteLine("No TODOS have been added yet");
    }
        
    private int TodoCount()
    {
        return _todos.Count();
    }
}