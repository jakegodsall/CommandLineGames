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

    public void CalculateBoardState(Snake snake, Food food)
    {
        var arr = new char[Height, Width];
        for (var y = 0; y < arr.GetLength(0); y++)
        {
            for (var x = 0; x < arr.GetLength(1); x++)
            {
                if (snake.IsAtCoord(x, y))
                {
                    arr[y, x] = snake.Symbol;
                }
                else if (food.IsAtCoord(x, y))
                {
                    arr[y, x] = food.Symbol;
                }
                else
                {
                    arr[y, x] = ' ';
                }
            }
        }
        BoardArray = arr;
    }

    public void Draw()
    {
        string verticalBar = new string('-', Width + 2);
        
        Console.WriteLine(verticalBar);
        for (var y = 0; y < BoardArray.GetLength(0); y++)
        {
            var row = "|";
            for (var x = 0; x < BoardArray.GetLength(1); x++)
            {
                row += BoardArray[y, x];
            }

            Console.WriteLine(row += "|");
        }
        Console.WriteLine(verticalBar);
    }
}