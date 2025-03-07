using SnakeGameTask.Utils;

namespace SnakeGameTask.Models
{
    public class SnakeHead : Pixel
    {
        public SnakeHead(int xPos, int yPos) : base(xPos, yPos, ConsoleColor.Red) { }
    }
}
