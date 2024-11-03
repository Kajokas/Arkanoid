using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Arkanoid
{
    internal class Paddle
    {
        public Rectangle Bounds { get; set; }
        private int speed { get; set; }

        public Paddle(int startX, int startY, int width, int height, int speed)
        { 
            Bounds = new Rectangle(startX, startY, width, height);
            this.speed = speed;
        }

        public void moveLeft()
        {
            if (Bounds.Left > 0)
            {
                Bounds = new Rectangle(Bounds.Left - speed, Bounds.Top, Bounds.Width, Bounds.Height);
            }
        }

        public void moveRight(int boundaryWidth)
        {
            if (Bounds.Right < boundaryWidth)
            {
                Bounds = new Rectangle(Bounds.Left + speed, Bounds.Top, Bounds.Width, Bounds.Height);
            }
        }

        public void draw(Graphics g)
        { 
            g.FillRectangle(Brushes.White, Bounds); 
        }
    }
}
