using SnakeGameTask.Models;

namespace SnakeGameTask.Services
{
    class BerryService
    {
        public Berry GenerateNext(int xPos, int yPos)
        {
            return new Berry(xPos, yPos);
        }

        public void Draw(Berry berry)
        {
            berry.Draw();
        }
    }
}