using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDodgeTemplate
{
    internal class Player
    {
        //PlayerInfo
        int playerWidth = 30;
        int playerHeight = 10;
        int playerSpeed = 4;
        public Rectangle rectangle;


        public Player(int x, int y)
        {
            rectangle = new Rectangle(x, y, playerWidth, playerHeight);


        }

        public void Move(int dirY, int dirX)
        {
            Rectangle ghostRectangle = rectangle;
            ghostRectangle.Y += (dirY * playerSpeed);
            ghostRectangle.X += (dirX * playerSpeed);
            if (ghostRectangle.X > GameScreen.width - ghostRectangle.Width)
            {
                ghostRectangle.X = GameScreen.width - ghostRectangle.Width;
            }
            if (ghostRectangle.X < 0)
            {
                ghostRectangle.X = 0;
            }
            if (ghostRectangle.Y > GameScreen.height - ghostRectangle.Height)
            {
                ghostRectangle.Y = GameScreen.height - ghostRectangle.Height;
            }
            if (ghostRectangle.Y < 0)
            {
                ghostRectangle.Y = 0;
            }

            rectangle.Location = ghostRectangle.Location;
        }

        public bool Collision(Ball ball)
        {
            if (rectangle.IntersectsWith(ball.rectangle))
            {
                return (true);
            }
            else
            {
                return false;
            }
        }
    }
}
