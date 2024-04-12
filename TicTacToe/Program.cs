namespace TicTacToe
{
    class TicTacToe
    {
        private Player _player1;
        private Player _player2;
        private Board _board = new Board();
        private int _turnCount = 1;

        
        public void Play()
        {
            InitialiseGame();
            
            var gameInPlay = true;

            while (gameInPlay)
            {
                int x, y;
                var currentPlayer = DeterminePlayer();
                
                _board.Draw();

                Console.WriteLine(_player1.Equals(DeterminePlayer()) ? "Player 1's Turn:" : "Player 2's Turn:");
                Console.WriteLine("Choose a position in the form: x y");
                var input = Console.ReadLine();
                while (!GetMoveFromUser(input, out x, out y))
                {
                    input = Console.ReadLine();
                }
                
                _board.MakeMove(currentPlayer, x, y);

                ++_turnCount;
            }
        }

        private void InitialiseGame()
        {
            Console.WriteLine("Player 1: Do you want to be X or O?");
            var userInput = "";
            userInput = Console.ReadLine();
            while (userInput != "x" && userInput != "X" && userInput != "o" && userInput != "O")
            {
                Console.WriteLine("Invalid value. Please try again");
                userInput = Console.ReadLine();
            }

            switch (userInput)
            {
                case "x": case "X":
                    _player1 = new Player('X');
                    _player2 = new Player('O');
                    break;
                case "o": case "O":
                    _player1 = new Player('O');
                    _player2 = new Player('X');
                    break;
            }
            Console.WriteLine($"Player 1 is {_player1.Character}. Player 2 is {_player2.Character}.");
            Console.WriteLine();
        }

        private static bool GetMoveFromUser(string input, out int x, out int y)
        {
            x = 0;
            y = 0;

            // Check that the input is not null or whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty");
                return false;
            }

            // Split the input based on whitespace
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                Console.WriteLine("Please enter exactly two numbers separated by a space");
                return false;
            }

            // Check the inputs are numerical
            bool isXValid = int.TryParse(parts[0], out x);
            bool isYValid = int.TryParse(parts[1], out y);
            if (!isXValid || !isYValid)
            {
                Console.WriteLine("Both entries must be numerical");
                return false;
            }

            // Check the inputs are in range
            if (x < 1 || x > 3 || y < 1 || y > 3)
            {
                Console.WriteLine("The entries must be in range");
                return false;
            }

            return true; // Otherwise the input is valid
        }

        private Player DeterminePlayer()
        {
            if (_turnCount % 2 == 1)
            {
                return _player1;
            }

            return _player2;
        }
    }

    class Program
    {
        public static void Main(String[] args)
        {
            var game = new TicTacToe();
            game.Play();
        }
    }
}