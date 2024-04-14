namespace Snake;

public class Snake
{
    public List<SnakeSegment> snake;
    public char Character { get; set; }

    public Snake(int initialLength, char character)
    {
        Character = character;
        snake = new List<SnakeSegment>()
        {
            new SnakeSegment(5, 10, Character),
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
}