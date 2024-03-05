using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BallDodgeTemplate
{
    internal class Ball
    {
        int[] plusOrMinus = new int[2] { 1, -1 };
        int xDir, yDir;
        double xSpeed, ySpeed;
        public SolidBrush brush;
        public Rectangle rectangle;

        int speedBoost = 0;
        double time;
        
        double stunTimeStart;
        const double STUN_TIME_DURATION = 5;  
        public Ball(Color color, int x, int y, int xRandom, int yRandom, double timeRandom)
        {
            int size = 10;
            rectangle = new Rectangle(x, y, size, size);
            xDir = plusOrMinus[xRandom];
            yDir = plusOrMinus[yRandom];
            xSpeed = ySpeed = 2.5;
            
            time += timeRandom;

            brush = new SolidBrush(color);

        }

        Rectangle SinMove()
        {
            Rectangle ghostRectangle = rectangle;
            ghostRectangle.X += (Int32)(xDir * ((Math.Sin(time + 2) + 1) * (xSpeed + speedBoost)));
            ghostRectangle.Y += (Int32)(yDir * ((Math.Sin(time) + 1) * (ySpeed + speedBoost)));

            return ghostRectangle;
        }

        public void Collisions()
        {
            if (speedBoost > 0) 
            {
                speedBoost--;
            }
            time += 0.15;
            Rectangle ghostRectangle = SinMove();

            if ((ghostRectangle.Y > (GameScreen.height - ghostRectangle.Height)) || (ghostRectangle.Y <= 0))
            {
                yDir *= -1;
            }
            if ((ghostRectangle.X > (GameScreen.width - ghostRectangle.Width)) || (ghostRectangle.X <= 0))
            {
                xDir *= -1;
            }

            rectangle = SinMove();
        }

        public void ReverseDirections(Rectangle playerRectangle) 
        {
            ySpeed *= -1;
            xDir *= -1;

            speedBoost += 5;
        }

        public bool checkStunTime() 
        {
            if (time - stunTimeStart > STUN_TIME_DURATION)
            {
                stunTimeStart = time;
                return (true);
            }
            return false;
        }

    }
}
