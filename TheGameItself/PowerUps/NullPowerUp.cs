using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.PowerUps
{
    internal class NullPowerUp: PowerUp
    {
        public NullPowerUp() : base(Brushes.Transparent, 0, 0, 0, 0)
        {
        }

        public override void specPower(Paddle paddle, Ball ball)
        {
        }
    }
}
