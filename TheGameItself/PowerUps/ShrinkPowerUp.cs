using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.PowerUps
{
    internal class ShrinkPowerUp : PowerUp
    {
        public ShrinkPowerUp(Brush color, int x, int y, int width, int height) : base(color, x, y, width, height)
        {
        }

        public override void specPower(Paddle paddle, Ball ball)
        {
            paddle.Bounds = new Rectangle(paddle.Bounds.X, paddle.Bounds.Y, paddle.Bounds.Width / 2, paddle.Bounds.Height);
        }
    }
}
