using System;
using SnakeGameTask.Core.Game;

namespace SnakeGameTask
{
    class Program
    {
        static void Main(string[] args)
        {
            SnakeGame game = new SnakeGame(16, 32);
            game.Run();
        }
    }
}
