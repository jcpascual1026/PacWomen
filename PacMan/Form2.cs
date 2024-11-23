using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Front_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Credits Credit = new Credits();
            Credit.ShowDialog();
            this.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                this.Hide();
                Game1 form = new Game1();
                form.ShowDialog();
                this.Show();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label mylab = new Label();
            mylab.Size = new Size(220, 35);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
