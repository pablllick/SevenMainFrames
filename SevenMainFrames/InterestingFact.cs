using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace SevenMainFrames
{
    public partial class InterestingFact : Form
    {
        public InterestingFact()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SoundPlayer simpleSound = new SoundPlayer(@"C:\\Рабочий стол\\sound\\loseSound.wav");
            simpleSound.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\\Рабочий стол\\sound\\loseSound.wav");
            simpleSound.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\\Рабочий стол\\sound\\loseSound.wav");
            simpleSound.Play();
        }
    }
}
