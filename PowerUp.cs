using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class PowerUp
    {
        private int id;
        private Brush color;
        public Rectangle bounds {get; set;}

        public PowerUp(int id, Brush color, int x, int y, int width, int height)
        {
            this.id = id;
            this.color = color;

            bounds = new Rectangle(x, y, width, height);
        }

        public void fall(int speed)
        {
            bounds = new Rectangle(bounds.X, bounds.Y + speed, bounds.Width, bounds.Height);
        }

        public bool collidedWithPaddle(Rectangle paddle)
        {
            if (bounds.IntersectsWith(paddle))
            {
                return true;
            }
            else return false;
        }

        public void specPower(Paddle paddle, Ball ball)
        {
            switch (id) 
            {
                case 1:
                    paddle.Bounds = new Rectangle(paddle.Bounds.X, paddle.Bounds.Y, paddle.Bounds.Width * 2, paddle.Bounds.Height);
                    break;
                case 2:
                    paddle.Bounds = new Rectangle(paddle.Bounds.X, paddle.Bounds.Y, paddle.Bounds.Width / 2, paddle.Bounds.Height);
                    break;
                case 3:
                    ball.speedX *= 2;
                    ball.speedY *= 2;
                    break;
                case 4:
                    ball.speedX /= 2;
                    ball.speedY /= 2;
                    break;
                default:
                    break;
            }
        }

        public void draw(Graphics g)
        {
            g.FillRectangle(color, bounds);
        }
    }
}
