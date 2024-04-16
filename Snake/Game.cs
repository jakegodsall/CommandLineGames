using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        private Board Board { get; set; }
        private Snake Snake { get; set; }

        private Food _food;

        private bool GameOver { get; set; } = false;

        private int Score { get; set; }
        private readonly Stopwatch _stopwatch = new Stopwatch();

        private static string CurrentDirection { get; set; } = "right";
        private static readonly object LockObject = new object();

        public void Run()
        {
            _stopwatch.Start();
            InitializeGame(40, 20, 20, 10, 6);
            var gameDelay = 200;

            while (!GameOver)
            {
                UpdateGame();
                Thread.Sleep(gameDelay);
            }
        }

        private void InitializeGame(
            int boardWidth,
            int boardHeight,
            int initialSnakeX,
            int initialSnakeY,
            int initialSnakeLength
        )
        {
            var inputTask = Task.Run(() => HandleInput());

            Board = new Board(boardWidth, boardHeight);
            _food = new Food(boardWidth, boardHeight, 'x');
            Snake = new Snake(initialSnakeX, initialSnakeY, initialSnakeLength, '\u2588');

            Board.CalculateBoardState(Snake, _food);
            Render();
        }

        private void UpdateGame()
        {
            Board.CalculateBoardState(Snake, _food);
            MoveSnake();
            HandleSnakeEatsFood();
            HandleCollision();
            Render();
        }

        private void HandleSnakeEatsFood()
        {
            if (Snake.IsAtCoord(_food.XPos, _food.YPos))
            {
                Score++;
                Snake.hasEaten = true;
                _food.Respawn(Board.Width, Board.Height);
            }
        }

        private void MoveSnake()
        {
            string directionToMove;
            lock (LockObject)
            {
                directionToMove = CurrentDirection;
            }

            switch (directionToMove)
            {
                case "up":
                    Snake.MoveUp();
                    break;
                case "right":
                    Snake.MoveRight();
                    break;
                case "down":
                    Snake.MoveDown();
                    break;
                case "left":
                    Snake.MoveLeft();
                    break;
            }
        }

        private void HandleCollision()
        {
            if (!Snake.HasCollidedWithSelf() && !Snake.HasCollidedWithBorder(Board.Width, Board.Height)) return;
            GameOver = true;
            _stopwatch.Stop();
        }

        private static void HandleInput()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    lock (LockObject)
                    {
                        switch (key)
                        {
                            case ConsoleKey.W:
                            case ConsoleKey.UpArrow:
                                if (CurrentDirection != "down")
                                    CurrentDirection = "up";
                                break;
                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                if (CurrentDirection != "left")
                                    CurrentDirection = "right";
                                break;
                            case ConsoleKey.S:
                            case ConsoleKey.DownArrow:
                                if (CurrentDirection != "up")
                                    CurrentDirection = "down";
                                break;
                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                if (CurrentDirection != "right")
                                    CurrentDirection = "left";
                                break;
                        }
                    }
                }

                Thread.Sleep(50);
            }
        }

        private void Render()
        {
            Console.Clear();
            Console.WriteLine("Score: " + Score + "           Time: " + FormatElapsedTime(_stopwatch.Elapsed));
            Board.Draw();
        }

        private static string FormatElapsedTime(TimeSpan time)
        {
            // Formatting elapsed time as MM:SS
            return $"{time.Minutes + time.Hours * 60:D2}:{time.Seconds:D2}";
        }
    }
}