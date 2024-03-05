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
    public partial class GameOver : UserControl
    {
        public GameOver(double _score)
        {
            InitializeComponent();
            scoreLabel.Text = _score.ToString();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
