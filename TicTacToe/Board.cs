namespace TicTacToe;

public class Board
{
    private char[,] _board =
    {
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' }
    };
    
    public void MakeMove(Player player, int x, int y)
    {
        _board[y - 1, x - 1] = player.Character;
    }
    
    public void Draw()
    {
        var verticalBar = new string('-', 13);
        Console.WriteLine(verticalBar);
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            var row = "| ";
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                row += _board[i, j] + " | ";
            }
            Console.WriteLine(row);
            Console.WriteLine(verticalBar);
        }
    }
}