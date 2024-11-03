using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class GameWindow : Form
    {
        Paddle paddle;
        Ball ball;
        List<Brick> bricks = new List<Brick>();
        List<PowerUp> powerUps = new List<PowerUp>();

        System.Windows.Forms.Timer gameTime;
        public GameWindow()
        {
            InitializeComponent();
            startGame();
            this.KeyDown += new KeyEventHandler(getKeysDown);
        }

        private void startGame()
        {
            paddle = new Paddle(425, 550, 150, 20, 10);
            ball = new Ball(500, 400, 20, 1, 5);

            spawnBricks(3, 6);

            gameTime = new System.Windows.Forms.Timer();
            gameTime.Interval = 20;
            gameTime.Tick += Update;
            
        }

        private void gameOver(String message)
        {
            gameTime.Stop();

            Label text = new Label();
            text.Location = new Point(300, 300);
            text.Text = message;
            text.ForeColor = Color.Red;
            text.AutoSize = true;
            text.Font = new Font("Calibri", 50);

            this.Controls.Add(text);
        }

        private void spawnBricks(int rows, int colloms)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colloms; j++)
                {
                    bricks.Add(new Brick(150*j+100, 30*i+50, 100, 20));
                }
            }
        }

        private void Update(object? sender, EventArgs e)
        {
            ball.move();

            if (ball.collidingWithWalls(ClientSize.Width, ClientSize.Height))
            {
                gameOver("Game Over");
            }

            ball.checkCollisionsWithPaddle(paddle.Bounds);

            if (bricks.Count == 0)
                gameOver("You Win");

            foreach (Brick brick in bricks) 
            {
                if (brick.checkCollisionWithBall(ball))
                {
                    ball.bounceVertical();

                    PowerUp temp = brick.spawnPowerUp();
                    if (temp != null)
                        powerUps.Add(temp);
                    bricks.Remove(brick);
                    break;
                }
            }

            foreach (PowerUp powerUp in powerUps)
            {
                powerUp.fall(5);

                if (powerUp.collidedWithPaddle(paddle.Bounds))
                {
                    powerUp.specPower(paddle, ball);
                    powerUps.Remove(powerUp);
                    break;
                }
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            paddle.draw(e.Graphics);
            ball.draw(e.Graphics);

            foreach (Brick brick in bricks)
            {
                brick.draw(e.Graphics);
            }

            foreach (PowerUp powerUp in powerUps)
            {
                powerUp.draw(e.Graphics);
            }
        }

        private void getKeysDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    paddle.moveLeft();
                    break;
                case Keys.Right:
                    paddle.moveRight(ClientSize.Width);
                    break;
                case Keys.R:
                    Application.Restart();
                    break;
                case Keys.Space:
                    gameTime.Start();
                    break;
            }

        }
    }
}
