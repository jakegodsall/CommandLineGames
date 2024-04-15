namespace Snake;

public class SnakeSegment
{
    public int XPos { get; set; }
    public int YPos { get; set; }
    public char Character { get; set; }

    public SnakeSegment(int xPos, int yPos, char character)
    {
        YPos = yPos;
        XPos = xPos;
        Character = character;
    }
}