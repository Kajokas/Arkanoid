using Arkanoid;
using Arkanoid.PowerUps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidTest
{
    public class PowerUpTest
    {
        [Test]
        public void TestIfEnlargePowerUpDoublesTheSize()
        {
            var powerup = new EnlargePowerup(Brushes.Aqua, 0, 0, 30, 30);

            var paddle = new Paddle(0, 550, 150, 20, 10);
            var ball = new Ball(500, 400, 20, 0, 5);

            powerup.specPower(paddle, ball);

            Assert.AreEqual(300, paddle.Bounds.Width, "Paddle should have doubled");
        }
    }
}
