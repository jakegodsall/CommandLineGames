using System.Threading;

namespace Snake;

public class Game
{
    public Board Board { get; set; }
    public Snake Snake { get; set; }

    public static string currentDirection { get; set; } = "right";
    private static readonly object lockObject = new object();
    
    public void Run()
    {
        InitializeGame(80, 20, 40, 10, 6);
    }

    public void InitializeGame(
        int boardWidth,
        int boardHeight,
        int initialSnakeX,
        int initialSnakeY,
        int initialSnakeLength
        )
    {
        Task inputTask = Task.Run(() => HandleInput());
        
        Board = new Board(boardWidth, boardHeight);
        var food = new Food(boardWidth, boardHeight, 'x');
        Snake = new Snake(initialSnakeX, initialSnakeY, initialSnakeLength, '\u2588');

        Board.CalculateBoardState(Snake, food);
        Board.Draw();

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
            
            if (Snake.IsAtCoord(food.YPos, food.XPos))
            {
                Snake.hasEaten = true;
                food.Respawn(boardWidth, boardHeight);
            }

            if (Snake.HasCollidedWithBorder(boardWidth, boardHeight))
            {
                gameOver = true;
            }
            
            
            Board.CalculateBoardState(Snake, food);
            Board.Draw();
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
}