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
    public partial class MenuScreen : UserControl
    {
        Button[] buttons;
        public MenuScreen()
        {
            InitializeComponent();
            buttons = new Button[4] { easyButton, mediumButton, hardButton, exitButton };
        }

        private void easyButton_Click(object sender, EventArgs e)
        {

            Form1.ChangeScreen(this, new GameScreen(40, 0));
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen(20, 10));
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen(5, 20));
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
