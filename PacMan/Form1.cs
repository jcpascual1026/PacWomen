
using System.Media;

namespace PacMan
{
    public partial class Game1 : Form
    {

        bool goup, godown, goleft, goright, isgameOver;
        int score, playerspeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY, pinkGhost1X, pinkGhost1Y;
        public Game1()
        {
            InitializeComponent();
            SoundPlayer sound = new SoundPlayer("Pac-manbg.wav");
            sound.Play();
            resetGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {

        }

        private void YellowGhost_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox35_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void KeyisDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void KeyisUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if (e.KeyCode == Keys.Enter && isgameOver == true)
            {
                resetGame();
            }
        }

        private void MainGameTime(object sender, EventArgs e)
        {
            TxtScore.Text = "Score: " + score;


            if (goleft == true)
            {
                PacWomen.Left -= playerspeed;
                PacWomen.Image = Properties.Resources.left;
            }
            if (goright == true)
            {
                PacWomen.Left += playerspeed;
                PacWomen.Image = Properties.Resources.right;
            }
            if (godown == true)
            {
                PacWomen.Top += playerspeed;
                PacWomen.Image = Properties.Resources.down;
            }
            if (goup == true)
            {
                PacWomen.Top -= playerspeed;
                PacWomen.Image = Properties.Resources.Up;
            }

            if (PacWomen.Left < -5)
            {
                PacWomen.Left = 1340;
            }
            if (PacWomen.Left > 1340)
            {
                PacWomen.Left = -5;
            }

            if (PacWomen.Top < -5)
            {
                PacWomen.Top = 790;
            }
            if (PacWomen.Top > 790)
            {
                PacWomen.Top = 5;
            }

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox)
                {

                    if ((string)x.Tag == "Coin" && x.Visible == true)
                    {

                        if (PacWomen.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "Walls")
                    {
                        if (PacWomen.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("You Lose!");
                        }

                        if (pinkGhost.Bounds.IntersectsWith(x.Bounds) || PinkGhost1.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                            pinkGhost1X = -pinkGhostX;
                        }
                    }

                    if ((string)x.Tag == "Ghost")
                    {
                        if (PacWomen.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("You Lose!");
                        }
                    }
                }
            }

            RedGhost.Left += redGhostSpeed;
            RedGhost1.Left += redGhostSpeed;
            YellowGhost.Left += yellowGhostSpeed;
            YellowGhost1.Left += yellowGhostSpeed;

            if (RedGhost1.Bounds.IntersectsWith(walls3.Bounds) || RedGhost1.Bounds.IntersectsWith(walls4.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            if (RedGhost.Bounds.IntersectsWith(wall1.Bounds) || RedGhost.Bounds.IntersectsWith(wall2.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            if (YellowGhost1.Bounds.IntersectsWith(wall5.Bounds) || YellowGhost1.Bounds.IntersectsWith(wall6.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }

            if (YellowGhost.Bounds.IntersectsWith(wall7.Bounds) || YellowGhost.Bounds.IntersectsWith(wall8.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }


            pinkGhost.Left -= pinkGhostX;
            pinkGhost.Top -= pinkGhostY;

            if (pinkGhost.Top < 0 || pinkGhost.Top > 520)
            {
                pinkGhostY = -pinkGhostY;
            }

            if (pinkGhost.Left < 0 || pinkGhost.Left > 620)
            {
                pinkGhostX = -pinkGhostX;
            }




            PinkGhost1.Left -= pinkGhostX;
            PinkGhost1.Top -= pinkGhostY;

            if (PinkGhost1.Top < 1 || PinkGhost1.Top > 790)
            {
                pinkGhost1Y = -pinkGhost1Y;
            }

            if (PinkGhost1.Left < 1 || PinkGhost1.Left > 1340)
            {
                pinkGhost1X = -pinkGhost1X;
            }

            if (score == 19)
            {
                gameOver("!!! You WIN !!!");
            }
        }

        private void resetGame()
        {
            TxtScore.Text = "Score: 0";
            score = 0;

            redGhostSpeed = 10;
            yellowGhostSpeed = 10;
            pinkGhostX = 10;
            pinkGhostY = 10;
            pinkGhost1X = 308;
            pinkGhost1Y = 413;
            playerspeed = 12;

            isgameOver = false;

            PacWomen.Left = 657;
            PacWomen.Top = 283;

            RedGhost.Left = 192;
            RedGhost.Top = 280;

            RedGhost1.Left = 984;
            RedGhost1.Top = 625;

            YellowGhost.Left = 318;
            YellowGhost.Top = 625;

            YellowGhost1.Left = 974;
            YellowGhost1.Top = 280;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            GameTime.Start();
        }
        private void gameOver(string message)
        {
            isgameOver = true;
            GameTime.Stop();
            TxtScore.Text += "Score: " + score + Environment.NewLine + message;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void pictureBox28_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }
    }
}
