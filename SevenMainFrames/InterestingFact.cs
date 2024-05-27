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
        int count;
        public InterestingFact()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(1920, 1080);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label2.Text = "Поздравляем, вы угадали";
            SoundPlayer simpleSound = new SoundPlayer(@"C:\\Рабочий стол\\sound\\1.wav");
            simpleSound.Play();
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label2.Text = "Жаль, вы не угадали";
            SoundPlayer simpleSound = new SoundPlayer(@"C:\\Рабочий стол\\sound\\loseSound.wav");
            simpleSound.Play();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label2.Text = "Жаль, вы не угадали";
            SoundPlayer simpleSound = new SoundPlayer(@"C:\\Рабочий стол\\sound\\loseSound.wav");
            simpleSound.Play();
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label2.Text = "Жаль, вы не угадали";
            SoundPlayer simpleSound = new SoundPlayer(@"C:\\Рабочий стол\\sound\\loseSound.wav");
            simpleSound.Play();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 3)
            {
                panel1.Visible = false;
                count = 0;
                timer1.Stop();
            }
        }
    }
}
