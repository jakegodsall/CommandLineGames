namespace Snake;

public class Board
{
    public int Width { get; init; }
    public int Height { get; init; }
    public char[,] BoardArray { get; private set; }

    public Board(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public char[,] CalculateBoardState(Snake snake, Food food)
    {
        var arr = new char[Height, Width];
        for (var i = 0; i < arr.GetLength(0); i++)
        {
            for (var j = 0; j < arr.GetLength(1); j++)
            {
                if (snake.IsAtCoord(i, j))
                {
                    arr[i, j] = snake.Symbol;
                }
                else if (food.IsAtCoord(i, j))
                {
                    arr[i, j] = food.Symbol;
                }
                else
                {
                    arr[i, j] = ' ';
                }
            }
        }

        BoardArray = arr;
        return arr;
    }

    public void Draw()
    {
        Console.Clear();
        string verticalBar = new string('-', Width + 2);
        
        Console.WriteLine(verticalBar);
        for (var i = 0; i < BoardArray.GetLength(0); i++)
        {
            var row = "|";
            for (var j = 0; j < BoardArray.GetLength(1); j++)
            {
                row += BoardArray[i, j];
            }

            Console.WriteLine(row += "|");
        }
        Console.WriteLine(verticalBar);
    }
}