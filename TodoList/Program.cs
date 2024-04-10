using System.Diagnostics;
using System.IO;

namespace Todo
{
    public class TodoList
    {
        private List<Todo> _todos = new List<Todo>();
        
        public void Run()
        {
            string input;
            do
            {
                PrintOptions();
                Console.WriteLine("Select an option: ");
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
                        case "S":
                        case "s":
                            Console.WriteLine("Enter filename");
                            var filename = Console.ReadLine();
                            Console.WriteLine($"Writing to {filename}.txt");
                            SaveTodos(filename);
                            Console.WriteLine($"Saved to {filename}.txt");
                            break;
                        case "E":
                        case "e":
                            PrintSelectedOption("Exit");
                            Console.WriteLine("Goodbye");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.\n");
                            break;
                    }
                }

            } while (input != "E" && input != "e");
        }

        private void ShowAllTodos()
        {
            if (_todos.Count == 0)
            {
                ShowNoTodosMethod();
            }
            else
            {
                for (var i = 0; i < _todos.Count; i++)
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
            if (IsDescriptionValid(userInput))
            {
                _todos.Add(new Todo(userInput));
            }
        }
        
        private void RemoveTodoItem()
        {
            if (_todos.Count == 0)
            {
                ShowNoTodosMethod();
            }
            
            Console.WriteLine("Enter item number to remove: ");
            var inputIsNotValid = true;
            int indexToRemove;
            do
            {
                var userInput = Console.ReadLine();
                if (IsInputValidTodoIndex(userInput, out indexToRemove))
                {
                    inputIsNotValid = false;
                }
            } while (inputIsNotValid);

            _todos.RemoveAt(indexToRemove - 1);
        }
        
        private bool IsDescriptionValid(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("The description cannot be empty");
                return false;
            }
            if (_todos.Exists(item => item.Description == description))
            {
                Console.WriteLine("The description must be unique");
                return false;
            }
            return true;
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

        private void SaveTodos(string filename)
        {
            // try
            // {
            // Pass the filepath and filename to the StreamWriter Constructor

            var cwd = Directory.GetCurrentDirectory();
            StreamWriter sw = new StreamWriter(cwd + "/" + filename + ".txt");
            // Loop through the todos
            foreach (var todo in _todos)
            {
                // Write the todo to the file
                Console.WriteLine(todo);
                sw.WriteLine(todo);
            }
            // Close the file
            sw.Close();
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     throw;
            // }
        }
        
        private static void PrintOptions()
        {
            string[] options =
            {
                "[V]iew all TODOs",
                "[A]dd a TODO",
                "[R]emove",
                "[S]ave",
                "[E]xit"
            };
    
            Console.WriteLine("What do you want to do?");
            foreach (var option in options)
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
    }

    public class Todo
    {
        public string Description;
        public DateTime CreatedAt;
        public bool IsComplete;

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

        public override string ToString()
        {
            var substring = Description.Count() < 20 ? Description : Description.Substring(0, 20);
            return $"{substring}... ({FormatCreatedAt()})";
        }

        public string FormatCreatedAt()
        {
            return CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }

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
                    sw.WriteLine(FormatTodoLine(todo));
                }
            }
        }

        private static string FormatTodoLine(Todo todo)
        {
            return $"{todo.Description},{todo.CreatedAt},{todo.IsComplete}";
        }
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            var todoList = new TodoList();

            todoList.Run();
        }
    }
}
