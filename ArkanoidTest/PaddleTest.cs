using Arkanoid;

namespace ArkanoidTest
{
    public class PaddleTest
    {
        [Test]
        public void TestIfPadleDoesNotGoOutOfBoundsLeft()
        {
            var paddle = new Paddle(0, 550, 150, 20, 10);

            paddle.moveLeft();

            Assert.AreEqual(0, paddle.Bounds.X, "Paddle should not go ot of bounds left");
        }

        [Test]
        public void TestIfPadleDoesNotGoOutOfBoundsRight()
        {
            var paddle = new Paddle(500, 550, 150, 20, 10);

            paddle.moveRight(650);

            Assert.AreEqual(500, paddle.Bounds.X, "Paddle should not go ot of bounds moving right");
        }
    }
}