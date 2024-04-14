namespace Snake;

public class Snake
{
    public List<SnakeSegment> snake;
    public char Character { get; set; }

    public Snake(
        int initialSnakeX,
        int initialSnakeY,
        int initialLength,
        char character
        )
    {
        Character = character;
        snake = new List<SnakeSegment>()
        {
            new SnakeSegment(initialSnakeY, initialSnakeX, Character),
        };
    }

    public bool IsAtCoord(int yPos, int xPos)
    {
        foreach (var segment in snake)
        {
            if (segment.XPos == xPos && segment.YPos == yPos)
            {
                return true;
            }
        }
        return false;
    }

    public void MoveUp()
    {
        foreach (var segment in snake)
        {
            segment.YPos++;
        }
    }

    public void MoveRight()
    {
        foreach (var segment in snake)
        {
            segment.XPos++;
        }
    }

    public void MoveDown()
    {
        foreach (var segment in snake)
        {
            segment.YPos--;
        }
    }

    public void MoveLeft()
    {
        foreach (var segment in snake)
        {
            segment.XPos--;
        }
    }

    public bool IsOutOfBounds(int boardWidth, int boardHeight)
    {
        var head = snake[0];
        return (head.XPos < 0 || head.XPos > boardWidth || head.YPos < 0 || head.YPos > boardHeight);
    }
}