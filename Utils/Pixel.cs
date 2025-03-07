using System;

namespace SnakeGameTask.Utils
{
    public abstract class Pixel
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public ConsoleColor Color { get; set; }

        protected Pixel(int xPos, int yPos, ConsoleColor color)
        {
            XPos = xPos;
            YPos = yPos;
            Color = color;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(XPos, YPos);
            Console.ForegroundColor = Color;
            Console.Write("■");
        }
    }
}
