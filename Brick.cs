using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class Brick
    {
        public Rectangle bounds { get; set; }

        public Brick(int x, int y, int width, int height)
        {
            bounds = new Rectangle(x, y, width, height);
        }

        public void draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, bounds);
        }

        public PowerUp spawnPowerUp()
        {
            Random random = new Random();
            int chance = random.Next(1, 101);

            PowerUp powerUp = null;

            switch (chance)
            {
                case int x when chance >= 1 && chance <= 10:
                    powerUp = new PowerUp(1, Brushes.Aqua, bounds.X, bounds.Y, 30, 30);
                    return powerUp;
                case int x when chance >= 10 && chance <= 20:
                    powerUp = new PowerUp(2, Brushes.Red, bounds.X, bounds.Y, 30, 30);
                    return powerUp;
                case int x when chance >=20 && chance <= 30:
                    powerUp = new PowerUp(3, Brushes.Yellow, bounds.X, bounds.Y, 30, 30);
                    return powerUp;
                case int x when chance >= 30 && chance <= 40:
                    powerUp = new PowerUp(4, Brushes.Pink, bounds.X, bounds.Y, 30, 30);
                    return powerUp;
                default:
                    return null;
            }
        }

        public bool checkCollisionWithBall(Ball ball)
        {
            if (bounds.IntersectsWith(ball.bounds))
            {
                return true;
            }
            else return false;
        }
    }
}
