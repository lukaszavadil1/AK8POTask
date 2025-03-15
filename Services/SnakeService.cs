using System;
using SnakeGameTask.Models;
using SnakeGameTask.Utils;

namespace SnakeGameTask.Services
{
    public class SnakeService
    {
        public void Move(Snake snake, Direction direction)
        {
            // Add new body chunk on the position of the head
            snake.Body.Add(new SnakeBody(snake.Head.XPos, snake.Head.YPos));

            // Move the head in the desired direction
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

            // Remove the snake's previous tail chunk if it hasn't grown
            if (snake.Body.Count > snake.Score)
            {
                snake.Body.RemoveAt(0);
            }
        }

        public void Grow(Snake snake)
        {
            snake.Body.Add(new SnakeBody(snake.Head.XPos, snake.Head.YPos));
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
            return snake.Head.XPos == 0 || // Left wall
                   snake.Head.YPos == 0 || // Top wall
                   snake.Head.XPos == width - 1 || // Right wall
                   snake.Head.YPos == height - 1; // Bottom wall
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
