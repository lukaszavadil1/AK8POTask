using SnakeGameTask.Utils;

namespace SnakeGameTask.Models
{
    public class SnakeBody : Pixel
    {
        public SnakeBody(int xPos, int yPos) : base(xPos, yPos, ConsoleColor.Green) { }
    }
}
