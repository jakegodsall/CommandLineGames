using System.Threading;

namespace Snake;

public class Game
{
    public Board Board { get; set; }
    public Snake Snake { get; set; }
    
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
        Board = new Board(boardWidth, boardHeight);
        Snake = new Snake(initialSnakeX, initialSnakeY, initialSnakeLength, '\u2588');

        Board.RenderSnakeOnBoardArray(Snake);
        Board.Draw();

        var gameOver = false;

        while (!gameOver)
        {
            Snake.MoveRight();
            Board.RenderSnakeOnBoardArray(Snake);
            Board.Draw();

            if (Snake.IsOutOfBounds(boardWidth, boardHeight))
            {
                gameOver = true;
            }

            Thread.Sleep(200);
        }
    }
}