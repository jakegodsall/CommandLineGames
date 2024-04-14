namespace Snake;

public class SnakeSegment
{
    public int XPos { get; set; }
    public int YPos { get; set; }
    public char Character { get; set; }

    public SnakeSegment(int yPos, int xPos, char character)
    {
        YPos = yPos;
        XPos = xPos;
        Character = character;
    }
}