using System;
using System.Threading;
using SnakeGameTask.Models;
using SnakeGameTask.Utils;
using SnakeGameTask.Services;

namespace SnakeGameTask.Core.Game
{
    class SnakeGame
    {
        private int screenWidth;
        private int screenHeight;
        private bool isGameOver;
        private Snake snake;
        private Berry berry;
        private Direction direction;
        private Random random;
        private BerryService berryService;
        private SnakeService snakeService;

        public SnakeGame(int height, int width)
        {
            screenWidth = width;
            screenHeight = height;

            random = new Random();
            snake = new Snake(screenWidth / 2, screenHeight / 2);
            snakeService = new SnakeService();
            berryService = new BerryService();
            berry = berryService.GenerateNext(random.Next(1, screenWidth - 2), random.Next(1, screenHeight - 2));
            direction = Direction.Right;
            isGameOver = false;
        }

        public void Run()
        {
            // Main game loop
            Console.Clear();
            while (!isGameOver)
            {
                Draw();
                CheckInput();
                UpdateGame();
                Thread.Sleep(500);
            }
            ShowGameOverScreen();
        }

        private void Draw()
        {
            Console.Clear();
            DrawEdges();
            snakeService.Draw(snake);
            berryService.Draw(berry);
        }

        private void DrawEdges()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, screenHeight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(screenWidth - 1, i);
                Console.Write("■");
            }
        }

        private void CheckInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                direction = pressedKey switch
                {
                    ConsoleKey.UpArrow when direction != Direction.Down => Direction.Up,
                    ConsoleKey.DownArrow when direction != Direction.Up => Direction.Down,
                    ConsoleKey.LeftArrow when direction != Direction.Right => Direction.Left,
                    ConsoleKey.RightArrow when direction != Direction.Left => Direction.Right,
                    _ => direction
                };
            }
        }

        private void UpdateGame()
        {
            snakeService.Move(snake, direction);

            // Snake eats berry
            if (snake.Head.XPos == berry.XPos && snake.Head.YPos == berry.YPos)
            {
                snakeService.Grow(snake);
                berry = berryService.GenerateNext(random.Next(1, screenWidth - 2), random.Next(1, screenHeight - 2));
            }

            // Snake collides with wall or itself
            if (snakeService.IsWallCollision(snake, screenWidth, screenHeight) || snakeService.IsSelfCollision(snake))
            {
                isGameOver = true;
            }
        }

        private void ShowGameOverScreen()
        {
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
            Console.WriteLine("Game over, Score: " + snake.Score);
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
