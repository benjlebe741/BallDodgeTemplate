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
        string type;
        int xDir, yDir;
        double xSpeed, ySpeed;

        public Rectangle rectangle;

        double time;
        public Ball(string _type, int x, int y, int _size)
        {
            type = _type;
            rectangle = new Rectangle(x, y, _size, _size);

            xDir = yDir = 1;
            xSpeed = ySpeed = 1.5;
        }

        public void Move()
        {
            time += 0.1;

            rectangle.X += (Int32)(xDir * (Math.Sin(time) * xSpeed));
            rectangle.Y += (Int32)(yDir * (Math.Sin(time) * ySpeed));
        }
    }
}
