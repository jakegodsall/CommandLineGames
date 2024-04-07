namespace Todo
{
    class TodoList
    {
        private List<TodoItem> _todos = new List<TodoItem>();
        
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
                        case "S":
                        case "s":
                            PrintSelectedOption("See all TODOs");
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
                Console.WriteLine("TODOS:");
                for (var i = 0; i < _todos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_todos[i].Description}");
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
                _todos.Add(new TodoItem(userInput));
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
        
        private static void PrintOptions()
        {
            string[] options =
            {
                "[S]ee all TODOs",
                "[A]dd a TODO",
                "[R]emove",
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

        private static void ShowNoTodosMethod()
        {
            Console.WriteLine("No TODOS have been added yet");
        }
    }

    class TodoItem
    {
        public string Description;
        private DateTime CreatedAt;
        private bool IsComplete;

        public TodoItem(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
            IsComplete = false;
        }
    }

    class Program
    {
        static void Main(String[] args)
        {
            var todoList = new TodoList();

            todoList.Run();
        }
    }
}
