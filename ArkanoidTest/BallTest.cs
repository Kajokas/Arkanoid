using Arkanoid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidTest
{
    public class BallTest
    {
        [Test]
        public void TestIfBallInitiatesGameOver()
        {
            var ball = new Ball(500, 400, 20, 0, 5);

            ball.move();

            bool gameOver = ball.collidingWithWalls(200, 405);

            Assert.AreEqual(true, gameOver, "Ball touching the bottom of the screen should initiate a game over");
        }
    }
}
