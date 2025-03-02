using Arkanoid.Statics;
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
        const int PLAYER_STARTING_X = 425;
        const int PLAYER_STARTING_Y = 550;
        const int PLAYER_WIDTH = 150;
        const int PLAYER_HEIGHT = 20;
        const int PLAYER_SPEED = 10;

        const int BALL_STARTING_X = 500;
        const int BALL_STARTING_Y = 400;
        const int BALL_DIAMETER = 20;
        const int BALL_SPEED_X = 1;
        const int BALL_SPEED_Y = 5;

        const int GAME_INTERVAL = 20;

        const int BRICK_ROWS = 3;
        const int BRICK_COLS = 6;

        const int POWERUP_FALL_SPEED = 5;

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
            paddle = new Paddle(PLAYER_STARTING_X, PLAYER_STARTING_Y, PLAYER_WIDTH, PLAYER_HEIGHT, PLAYER_SPEED);
            ball = new Ball(BALL_STARTING_X, BALL_STARTING_Y, BALL_DIAMETER, BALL_SPEED_X, BALL_SPEED_Y);

            bricks = BrickSpawner.spawnBricks(BRICK_ROWS, BRICK_COLS);

            gameTime = new System.Windows.Forms.Timer();
            gameTime.Interval = GAME_INTERVAL;
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

        private void Update(object? sender, EventArgs e)
        {
            ball.move();

            if (ball.collidingWithWalls(ClientSize.Width, ClientSize.Height))
                gameOver("Game Over");

            ball.checkCollisionsWithPaddle(paddle.Bounds);

            if (bricks.Count == 0)
                gameOver("You Win");

            gameLoopOfBricks();

            gameLoopOfPowerUps();

            Invalidate();
        }

        public void gameLoopOfBricks()
        {
            foreach (Brick brick in bricks)
            {
                if (!brick.checkCollisionWithBall(ball))
                    continue;

                ball.bounceVertical();

                PowerUp temp = brick.spawnPowerUp();
                powerUps.Add(temp);
                bricks.Remove(brick);
                break;
            }
        }

        public void gameLoopOfPowerUps()
        {
            foreach (PowerUp powerUp in powerUps)
            {
                powerUp.fall(POWERUP_FALL_SPEED);

                if (powerUp.bounds.Bottom >= ClientSize.Height)
                {
                    powerUps.Remove(powerUp);
                    break;
                }

                if (powerUp.collidedWithPaddle(paddle.Bounds))
                {
                    powerUp.specPower(paddle, ball);
                    powerUps.Remove(powerUp);
                    break;
                }
            }
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
