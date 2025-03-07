using System;
using SnakeGameTask.Models;
using SnakeGameTask.Utils;

namespace SnakeGameTask.Services
{
    public class SnakeService
    {
        public void Move(Snake snake, Direction direction)
        {
            snake.Body.Add(new SnakeBody(snake.Head.XPos, snake.Head.YPos));

            switch (direction)
            {
                case Direction.Up:
                    snake.Head.YPos--;
                    break;
                case Direction.Down:
                    snake.Head.YPos++;
                    break;
                case Direction.Left:
                    snake.Head.XPos--;
                    break;
                case Direction.Right:
                    snake.Head.XPos++;
                    break;
            }

            if (snake.Body.Count > snake.Score)
            {
                snake.Body.RemoveAt(0);
            }
        }

        public void Grow(Snake snake)
        {
            if (snake.Body.Count < snake.Score)
            {
                snake.Body.Add(new SnakeBody(snake.Head.XPos, snake.Head.YPos));
            }
            snake.Score++;
        }

        public bool IsSelfCollision(Snake snake)
        {
            foreach (var chunk in snake.Body)
            {
                if (chunk.XPos == snake.Head.XPos && chunk.YPos == snake.Head.YPos)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsWallCollision(Snake snake, int width, int height)
        {
            return snake.Head.XPos == 0 ||
                   snake.Head.YPos == 0 ||
                   snake.Head.XPos == width - 1 ||
                   snake.Head.YPos == height - 1;
        }

        public void Draw(Snake snake)
        {
            snake.Head.Draw();
            foreach (var chunk in snake.Body)
            {
                chunk.Draw();
            }
        }
    }
}
