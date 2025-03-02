using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.PowerUps
{
    internal class SlowDownPowerUp : PowerUp
    {
        public SlowDownPowerUp(Brush color, int x, int y, int width, int height) : base(color, x, y, width, height)
        {
        }

        public override void specPower(Paddle paddle, Ball ball)
        {
            if (ball.speedX>2)
                ball.speedX /= 2;
            ball.speedY /= 2;
        }
    }
}
