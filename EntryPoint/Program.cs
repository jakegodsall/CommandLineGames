namespace EntryPoint
{
    class EntryPoint
    {
        private static List<string> _options = new List<string>()
        {
            "Todo List",
            "Tic-Tac-Toe"
        };
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Select a tool:");
            DisplayOptions();
            
            int intInput;
            var inputIsValid = false;
            do
            {
                var input = Console.ReadLine();
                if (InputIsValid(input, out intInput))
                {
                    inputIsValid = true;
                };
            } while (!inputIsValid);
            
            
        }

        private static RunApplication(int value)
        {
            
        }

        private static void DisplayOptions()
        {
            for (int i = 0; i < _options.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {_options[i]}");
            }
        }

        private static bool InputIsValid(string input, out int intInput)
        {
            if (!int.TryParse(input, out intInput))
            {
                Console.WriteLine("Input must be an integer");
                return false;
            }
            if (intInput < 1 || intInput > _options.Count + 1)
            {
                Console.WriteLine("Input must be in range");
                return false;
            }
            return true;
        }
    }
}