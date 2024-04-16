using System.Diagnostics;
using System.Threading;

namespace Snake;

public class Game
{
    public Board Board { get; set; }
    public Snake Snake { get; set; }

    public int Score { get; set; }
    private Stopwatch stopwatch = new Stopwatch();

    public static string currentDirection { get; set; } = "right";
    private static readonly object lockObject = new object();
    
    public void Run()
    {
        InitializeGame(40, 20, 20, 10, 6);
    }

    public void InitializeGame(
        int boardWidth,
        int boardHeight,
        int initialSnakeX,
        int initialSnakeY,
        int initialSnakeLength
        )
    {
        stopwatch.Start();
        Task inputTask = Task.Run(() => HandleInput());
        
        Board = new Board(boardWidth, boardHeight);
        var food = new Food(boardWidth, boardHeight, 'x');
        Snake = new Snake(initialSnakeX, initialSnakeY, initialSnakeLength, '\u2588');

        Board.CalculateBoardState(Snake, food);

        DisplayGame();

        var gameOver = false;

        while (!gameOver)
        {
            string directionToMove;
            lock (lockObject)
            {
                directionToMove = currentDirection;
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
            
            if (Snake.IsAtCoord(food.XPos, food.YPos))
            {
                Score++;
                Snake.hasEaten = true;
                food.Respawn(boardWidth, boardHeight);
            }

            if (Snake.HasCollidedWithSelf() || Snake.HasCollidedWithBorder(boardWidth, boardHeight))
            {
                gameOver = true;
                stopwatch.Stop();
            }
            
            
            Board.CalculateBoardState(Snake, food);
            DisplayGame();
            Thread.Sleep(200);
        }
    }

    private static void HandleInput()
    {
        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;
                lock (lockObject)
                {
                    switch (key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            if (currentDirection != "down")
                                currentDirection = "up";
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            if (currentDirection != "left")
                                currentDirection = "right";
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            if (currentDirection != "up")
                                currentDirection = "down";
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            if (currentDirection != "right")
                                currentDirection = "left";
                            break;
                    }
                }
            }
            Thread.Sleep(50);
        }
    }

    public void DisplayGame()
    {
        Console.Clear();
        Console.WriteLine("Score: " + Score + "           Time: " + FormatElapsedTime(stopwatch.Elapsed));
        Board.Draw();
    }
    
    private static string FormatElapsedTime(TimeSpan time)
    {
        // Formatting elapsed time as MM:SS
        return $"{time.Minutes + time.Hours * 60:D2}:{time.Seconds:D2}";
    }
}