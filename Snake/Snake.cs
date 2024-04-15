using System.Runtime.CompilerServices;

namespace Snake;

public class Snake
{
    public Queue<SnakeSegment> snake;
    public char Symbol { get; set; }
    public bool hasEaten = false;

    public Snake(
        int initialSnakeX,
        int initialSnakeY,
        int initialLength,
        char character
        )
    {
        Symbol = character;
        snake = new Queue<SnakeSegment>();

        for (var i = 0; i < initialLength; i++)
        {
            snake.Enqueue(new SnakeSegment(initialSnakeX - initialLength + i, initialSnakeY, character));
        }
    }

    public bool IsAtCoord(int xPos, int yPos)
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
        var head = snake.Last(); // Get the current position of the head of the snake
        Move(head.YPos - 1, head.XPos);
    }

    public void MoveRight()
    {
        var head = snake.Last(); // Get the current position of the head of the snake
        Move(head.YPos, head.XPos + 1);
    }

    public void MoveDown()
    {
        var head = snake.Last(); // Get the current position of the head of the snake
        Move(head.YPos + 1, head.XPos);
    }

    public void MoveLeft()
    {
        var head = snake.Last(); // Get the current position of the head of the snake
        Move(head.YPos, head.XPos - 1);
    }
    
    public void Move(int newY, int newX)
    {
        // Add the new head position
        snake.Enqueue(new SnakeSegment(newX, newY, Symbol));
        
        // If the snake has eaten, it grows by not removing the tail in this frame
        if (!hasEaten)
        {
            // remove the tail
            snake.Dequeue();
        }
        else
        {
            // Reset the hasEaten flag for the next frame
            hasEaten = false;
        }
    }

    public bool HasCollidedWithBorder(int boardWidth, int boardHeight)
    {
        var head = snake.First();
        return (head.XPos < 0 || head.XPos > boardWidth || head.YPos < 0 || head.YPos > boardHeight);
    }
}