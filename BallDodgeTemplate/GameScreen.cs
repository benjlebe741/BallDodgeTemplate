using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDodgeTemplate
{
    public partial class GameScreen : UserControl
    {
        List<Ball> ballList = new List<Ball>();
        Random random = new Random();

        Player player;


        //Player Movement
        Keys[] keysWSAD = new Keys[4] { Keys.W, Keys.S, Keys.A, Keys.D };
        int[] checkWSAD = new int[4] { 0, 0, 0, 0 };
        int[] directionUpDown = new int[2] { 0, 0 };

        public static int width, height;

        int score = 0;
        public int lives = 0;
        public int startEnemies = 0;
        public GameScreen(int _lives, int _startEnemies)
        {
            InitializeComponent();
            lives = _lives;
            InnitializeGame();

            height = this.Size.Height;
            width = this.Size.Width;

            //Add Start Enemies
            for (int i = 0; i < _startEnemies; i++) 
            {
                addBall(Color.Red);
            }
        }

        public void InnitializeGame()
        {
            addBall(Color.White);
            player = new Player(this.Width / 2, this.Height / 2);
            livesLabel.Text = $"{lives}";
        }
        #region KeyStuff
        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            //I dont know how to delete this safely yet, but this is not neccessary
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (e.KeyCode == keysWSAD[i])
                {
                    checkWSAD[i] = 1;
                }
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (e.KeyCode == keysWSAD[i])
                {
                    checkWSAD[i] = 0;
                }
            }
        }
        #endregion
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.AliceBlue);
            foreach (Ball ball in ballList)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.CadetBlue), ball.rectangle);
                e.Graphics.DrawEllipse(new Pen(ball.brush), ball.rectangle);
            }
            e.Graphics.FillRectangle(brush, player.rectangle);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            #region Move Player
            directionUpDown[0] = (checkWSAD[1] - checkWSAD[0]);
            directionUpDown[1] = (checkWSAD[3] - checkWSAD[2]);

            player.Move(directionUpDown[0], directionUpDown[1]);
            #endregion
            #region Ball Methods
            for (int i = 0; i < ballList.Count; i++)
            {
                ballList[i].Collisions();
                if (player.Collision(ballList[i]) && ballList[i].checkStunTime())
                {
                    ballList[i].ReverseDirections(player.rectangle);
                    if (ballList[i].brush.Color != Color.Red)
                    {
                        addBall(Color.Red);
                        score += 1;
                        scoreLabel.Text = $"{score}";
                    }
                    else 
                    {
                        lives += -1;
                        livesLabel.Text = $"{lives}";

                        if (lives <= 0) 
                        {
                            gameOver();
                        }
                    }
                }
            }
            #endregion
            Refresh();
        }

        void addBall(Color color)
        {
            ballList.Add(new Ball(color, random.Next(20, this.Width - 30), random.Next(20, this.Width - 30), random.Next(0, 2), random.Next(0, 2), random.Next(0,7)));
        }

        public void gameOver() 
        {
            Form1.ChangeScreen(this, new GameOver());
            //Form1.ChangeScreen(this, new GameScreen(1,1));
        }
    }
}
