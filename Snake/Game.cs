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
        InitializeGame(80, 20, 5, 10, 2);
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
        Snake = new Snake(initialSnakeX, initialSnakeY, initialSnakeLength, '\u2588');

        Board.RenderSnakeOnBoardArray(Snake);
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
            
            Board.RenderSnakeOnBoardArray(Snake);
            Board.Draw();

            if (Snake.IsOutOfBounds(boardWidth, boardHeight))
            {
                gameOver = true;
            }

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