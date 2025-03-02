using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    public abstract class PowerUp:DrawableInterface
    {
        private Brush color;
        public Rectangle bounds {get; set;}

        public PowerUp(Brush color, int x, int y, int width, int height)
        {
            this.color = color;

            bounds = new Rectangle(x, y, width, height);
        }

        public void fall(int speed)
        {
            bounds = new Rectangle(bounds.X, bounds.Y + speed, bounds.Width, bounds.Height);
        }

        public bool collidedWithPaddle(Rectangle paddle)
        {
            return bounds.IntersectsWith(paddle);
        }

        abstract public void specPower(Paddle paddle, Ball ball);

        public void draw(Graphics g)
        {
            g.FillRectangle(color, bounds);
        }
    }
}
