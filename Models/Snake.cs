using System;
using System.Collections.Generic;
using SnakeGameTask.Utils;

namespace SnakeGameTask.Models
{
    public class Snake
    {
        public SnakeHead Head { get; private set; }
        public List<SnakeBody> Body { get; private set; }
        public int Score { get; set; }

        public Snake(int headX, int headY)
        {
            Head = new SnakeHead(headX, headY);
            Body = new List<SnakeBody>();
            Score = 5;
        }
    }
}
