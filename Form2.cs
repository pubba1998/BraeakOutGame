using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace breakout_game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SoundPlayer sound  = new SoundPlayer(@"C:/Users/pubudu perera/Desktop/breakout game/Resources/theme.wav");
            sound.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
