namespace Snake;

public class Food
{
    public int XPos { get; set; }
    public int YPos { get; set; }
    public char Symbol { get; init; }

    public Food(int boardWidth, int boardHeight, char symbol)
    {
        Symbol = symbol;
        Respawn(boardWidth, boardHeight);
    }

    public void Respawn(int boardWidth, int boardHeight)
    {
        Random rnd = new Random();
        XPos = rnd.Next(0, boardWidth);
        YPos = rnd.Next(0, boardHeight);
    }

    public bool IsAtCoord(int xPos, int yPos)
    {
        return (XPos == xPos && YPos == yPos);
    }
}