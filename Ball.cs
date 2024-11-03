using System.Drawing;

namespace Arkanoid
{
    internal class Ball
    {
        public Rectangle bounds { get; set; }
        public int speedX { get; set; } 
        public int speedY { get; set; }

        public Ball(int startX, int startY, int diameter, int speedX, int speedY)
        {
            bounds = new Rectangle(startX, startY, diameter, diameter);

            this.speedX = speedX;
            this.speedY = speedY;
        }

        public void move()
        {
            bounds = new Rectangle(bounds.Left + speedX, bounds.Top + speedY, bounds.Width, bounds.Height);
        }

        public void bounceHorizontal()
        {
            speedX = -speedX;
        }

        public void bounceVertical()
        {
            speedY = -speedY;
        }

        public bool collidingWithWalls(int windowWidth, int windowHeight)
        {
            if (bounds.Left <= 0 || bounds.Right >= windowWidth)
            {
                bounceHorizontal();
            }

            if (bounds.Top <= 0)
            {
                bounceVertical();
            }
            
            return bounds.Bottom >= windowHeight;
        }

        public void checkCollisionsWithPaddle(Rectangle paddle)
        {
            if (bounds.IntersectsWith(paddle))
            {
                int paddleCenter = paddle.X + paddle.Width/2;
                int ballCenter = bounds.X + bounds.Width / 2;
                double percent = ((ballCenter - paddleCenter) / (paddle.Width / 2));

                if (percent < 0)
                    speedX = (int)(speedX * (-1 + percent));
                else
                    speedX = (int)(speedX * (1 + percent));

                /*
                if (((paddleCenter - (paddle.Width / 3)) - ballCenter  > 0 && speedX > 0) || ((paddleCenter + (paddle.Width / 3)) - ballCenter < 0 && speedX < 0))
                {
                    bounceHorizontal();
                }
                */

                bounceVertical();
            }
        }

        public void draw(Graphics g)
        {
            g.FillEllipse(Brushes.White, bounds);
        }
    }
}
