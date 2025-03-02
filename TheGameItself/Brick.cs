using Arkanoid.PowerUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class Brick:DrawableInterface
    {
        private const int POWER_UP_WIDTH = 30;
        private const int POWER_UP_HEIGHT = 30;
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

            switch (chance)
            {
                case int x when chance >= 1 && chance <= 10:
                    EnlargePowerup powerUp1 = new EnlargePowerup(Brushes.Aqua, bounds.X, bounds.Y, POWER_UP_WIDTH, POWER_UP_HEIGHT);
                    return powerUp1;
                case int x when chance >= 10 && chance <= 20:
                    ShrinkPowerUp powerUp2 = new ShrinkPowerUp(Brushes.Red, bounds.X, bounds.Y, POWER_UP_WIDTH, POWER_UP_HEIGHT);
                    return powerUp2;
                case int x when chance >=20 && chance <= 30:
                    SpeedUpBallPowerUp powerUp3 = new SpeedUpBallPowerUp(Brushes.Yellow, bounds.X, bounds.Y, POWER_UP_WIDTH, POWER_UP_HEIGHT);
                    return powerUp3;
                case int x when chance >= 30 && chance <= 40:
                    SlowDownPowerUp powerUp4 = new SlowDownPowerUp(Brushes.Pink, bounds.X, bounds.Y, POWER_UP_WIDTH, POWER_UP_HEIGHT);
                    return powerUp4;
                default:
                    return new NullPowerUp();
            }
        }

        public bool checkCollisionWithBall(Ball ball)
        {
            return (bounds.IntersectsWith(ball.bounds));
        }

        public Brick clone()
        {
            return new Brick(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }
    }
}
