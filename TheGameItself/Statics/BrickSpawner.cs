using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Arkanoid.Statics
{
    internal static class BrickSpawner
    {
        const int BRICK_WIDTH = 100;
        const int BRICK_HEIGHT = 20;
        const int FIRST_BRICK_X = 75;
        const int FIRST_BRICK_Y = 30;
        const int BRICK_X_OFFSET = 50;
        const int BRICK_Y_OFFSET = 20;

        public static List<Brick> spawnBricks(int rows, int colloms)
        {
            List<Brick> result = new List<Brick>();

            Brick prototypeBrick = new Brick(FIRST_BRICK_X, FIRST_BRICK_Y, BRICK_WIDTH, BRICK_HEIGHT);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < colloms; col++)
                {
                    Brick newBrick = prototypeBrick.clone();

                    newBrick.bounds = new Rectangle(
                        FIRST_BRICK_X + (BRICK_WIDTH + BRICK_X_OFFSET) * col,
                        FIRST_BRICK_Y + (BRICK_HEIGHT + BRICK_Y_OFFSET) * row,
                        BRICK_WIDTH, BRICK_HEIGHT
                        );

                    result.Add(newBrick);
                }
            }
            return result;
        }
    }
}
