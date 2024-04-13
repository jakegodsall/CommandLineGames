namespace TicTacToe;

public class Board
{
    private readonly char[,] _board =
    {
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' }
    };
    
    public bool MakeMove(Player player, int x, int y)
    {
        if (!MoveIsValid(x - 1, y - 1)) return false;
        _board[y - 1, x - 1] = player.Character;
        return true;
    }

    public bool CheckForWin()
    {
        bool hasWon = false;
        // Case one - horizontal line
        for (var i = 0; i < _board.GetLength(0); i++)
        {
            if (_board[i, 0] != ' ' && _board[i, 0] == _board[i, 1] && _board[i, 0] == _board[i, 2])
            {
                hasWon = true;
            }
        }
        // Case two - vertical line
        for (var i = 0; i < _board.GetLength(1); i++)
        {
            if (_board[0, i] != ' ' && _board[0, i] == _board[1, i] && _board[0, i] == _board[2, i])
            {
                hasWon = true;
            }
        }

        // Case 3 - diagonal 1
        if (_board[0, 0] != ' ' && _board[0, 0] == _board[1, 1] && _board[0, 0] == _board[2, 2])
        {
            hasWon = true;
        }
        

        // Case 4 - diagonal 2
        if (_board[0, 2] != ' ' && _board[0, 2] == _board[1, 1] && _board[0, 2] == _board[2, 0])
        {
            hasWon = true;
        }

        return hasWon;
    }

    private bool MoveIsValid(int x, int y)
    {
        // Check is within range
        if (x < 0 || x > 2 || y < 0 || y > 2)
        {
            Console.WriteLine("The entries must be in range");
            return false;
        }
        // Check is not already taken
        if (_board[y, x] != ' ')
        {
            Console.WriteLine("That position is already taken");
            return false;
        }
        return true;
    }
    
    public void Draw()
    {
        var verticalBar = new string('-', 13);
        Console.WriteLine(verticalBar);
        for (var i = 0; i < _board.GetLength(0); i++)
        {
            var row = "| ";
            for (var j = 0; j < _board.GetLength(1); j++)
            {
                row += _board[i, j] + " | ";
            }
            Console.WriteLine(row);
            Console.WriteLine(verticalBar);
        }
        Console.WriteLine();
    }
}