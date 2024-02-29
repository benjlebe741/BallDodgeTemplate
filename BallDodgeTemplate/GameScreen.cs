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

        //PlayerInfo
        int playerWidth = 30;
        int playerHeight = 10;
        int playerSpeed = 4;
        Rectangle Player;

        //Player Movement
        Keys[] keysWSAD = new Keys[4] { Keys.W, Keys.S, Keys.A, Keys.D };
        int[] checkWSAD = new int[4] { 0, 0, 0, 0 };
        int[] directionUpDown = new int[2] { 0, 0 };

        public GameScreen()
        {
            InitializeComponent();
            addBall();
            Player = new Rectangle(this.Width / 2, this.Height / 2, playerWidth, playerHeight);
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
                e.Graphics.FillEllipse(brush, ball.rectangle);
            }
            e.Graphics.FillRectangle(brush, Player);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            #region Move Player
            directionUpDown[0] = (checkWSAD[1] - checkWSAD[0]);
            directionUpDown[1] = (checkWSAD[3] - checkWSAD[2]);

            Player.Y += (directionUpDown[0] * playerSpeed);
            Player.X += (directionUpDown[1] * playerSpeed);
            #endregion
            #region Ball Methods
            for (int i = 0; i < ballList.Count; i++)
            {
                ballList[i].Move();
                if (Player.IntersectsWith(ballList[i].rectangle))
                {
                    addBall();
                }
            }
            #endregion
            Refresh();
        }

        void addBall() { ballList.Add(new Ball("", random.Next(0, this.Width), random.Next(0, this.Width), 10)); }
    }
}
