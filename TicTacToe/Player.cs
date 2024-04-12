namespace TicTacToe;

public class Player
{
    private char _character;

    public char Character
    {
        get => _character;
        set => _character = value;
    }

    public Player(char character)
    {
        _character = character;
    }
        
        
}