using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace breakout_game
{
    public partial class Form1 : Form
    {
        bool goRight;
        bool goLeft;
        int speed = 10;

        int ballx = 5;
        int bally = 5;

        int score = 0;
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    x.BackColor = randomColor;
                }
            }

        }        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            //if the player pressed the left key AND the player is inside the panel
            // then we set the car left boolean to true
            if (e.KeyCode == Keys.Left && padale.Left > 0)
            {
                goLeft = true;
            }
            // if player pressed the right key and the player left plus player width is less then the panel1 width
            // then we set the player right to true
            if (e.KeyCode == Keys.Right && padale.Left + padale.Width < 920)
            {
                goRight = true;
            }
        }
    

        private void keyisup(object sender, KeyEventArgs e)
        {
            // if the LEFT key is up we set the car left to false
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            // if the RIGHT key is up we set the car right to false
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
        }
        private void gameOver()
        {
            timer1.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Left += ballx;
            ball.Top += bally;


            label1.Text = "Score: " + score;

                if (goLeft) { padale.Left -= speed; } // move left
                if (goRight) { padale.Left += speed; } // move right

                if (padale.Left < 1)
                {
                    goLeft = false; // stop the car from going off screen
                }
                else if (padale.Left + padale.Width > 920)
                {
                    goRight = false;
                }
                if (ball.Left + ball.Width > ClientSize.Width || ball.Left < 0)
                {
                    ballx = -ballx; // this will bounce the object from the left or right border
                }

                if (ball.Top < 0 || ball.Bounds.IntersectsWith(padale.Bounds))
                {
                    bally = -bally; // this will bounce the object from top and bottom border
                }

                if (ball.Top + ball.Height > ClientSize.Height)
                {
                    gameOver();
                MessageBox.Show("You loose");
                }
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "block")
                    {
                        if (ball.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
                            bally = -bally;
                            score++;
                        }
                    }
                }

                if (score > 34)
                {
                    gameOver();
                    MessageBox.Show("You Win");
                }
         
             
            }
        }
    }

