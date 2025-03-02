using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.PowerUps
{
    internal class SpeedUpBallPowerUp : PowerUp
    {
        public SpeedUpBallPowerUp(Brush color, int x, int y, int width, int height) : base(color, x, y, width, height)
        {
        }

        public override void specPower(Paddle paddle, Ball ball)
        {
            ball.speedX *= 2;
            ball.speedY *= 2;
        }
    }
}
