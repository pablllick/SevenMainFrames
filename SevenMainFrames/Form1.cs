using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenMainFrames
{
    public partial class Form1 : Form
    {
        private Panel scrollablePanel;
        private bool isDragging = false;
        int startPoint, startY, endY, count, distance;
        public Form1()
        {
            InitializeComponent();

            string tempPath = Path.Combine(Path.GetTempPath(), "video.mp4");
            File.WriteAllBytes(tempPath, Properties.Resources.video);
            //this.FormBorderStyle = FormBorderStyle.None; 

            axWindowsMediaPlayer1.URL = tempPath;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;

            this.BackgroundImage = Properties.Resources.photo;

            pictureBox2.Image = Properties.Resources.photo;
            pictureBox3.Image = Properties.Resources.photo1;
            pictureBox4.Image = Properties.Resources.photo2;
            pictureBox5.Image = Properties.Resources.photo;
            pictureBox6.Image = Properties.Resources.photo1;
            pictureBox7.Image = Properties.Resources.photo2;

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;

            label1.Text = "Lorem ipsum dolor sit amet, consectetur\n adipiscing elit, sed do eiusmod tempor \nincididunt ut labore et dolore magna aliqua.\nUt enim ad minim veniam, quis nostrud exercitation \nullamco laboris nisi\nut aliquip ex ea commodo consequat. Duis aute \nirure dolor in reprehenderit in \nvoluptate velit esse cillum dolore eu fugiat\nnulla pariatur. Excepteur sint\noccaecat cupidatat non proident, \nsunt in culpa qui officia\ndeserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, \nconsectetur adipiscing elit,\n sed do eiusmod tempor \nincididunt ut labore et dolore magna aliqua.\nUt enim ad minim veniam, quis \nnostrud exercitation ullamco laboris nisi\nut aliquip ex ea commodo consequat. \nDuis aute irure dolor in reprehenderit in \nvoluptate velit esse \ncillum dolore eu fugiat\nnulla pariatur. Excepteur sint\noccaecat cupidatat non \nproident, sunt in culpa qui officia\ndeserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur\n adipiscing elit, sed do eiusmod tempor \nincididunt ut labore et dolore magna aliqua.\nUt enim ad minim veniam, quis nostrud exercitation \nullamco laboris nisi\nut aliquip ex ea commodo consequat. Duis aute \nirure dolor in reprehenderit in \nvoluptate velit esse cillum dolore eu fugiat\nnulla pariatur. Excepteur sint\noccaecat cupidatat non proident, \nsunt in culpa qui officia\ndeserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, \nconsectetur adipiscing elit,\n sed do eiusmod tempor \nincididunt ut labore et dolore magna aliqua.\nUt enim ad minim veniam, quis \nnostrud exercitation ullamco laboris nisi\nut aliquip ex ea commodo consequat. \nDuis aute irure dolor in reprehenderit in \nvoluptate velit esse \ncillum dolore eu fugiat\nnulla pariatur. Excepteur sint\noccaecat cupidatat non \nproident, sunt in culpa qui officia\ndeserunt mollit anim id est laborum.";
            this.FormClosing += (sender, e) => File.Delete(tempPath);
        }

        private void panel8_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(1920, 1080);
            this.BackgroundImageLayout= ImageLayout.Stretch;
            //label1.Text = "Lorem ipsum dolor sit amet, consectetur\n adipiscing elit, sed do eiusmod tempor \nincididunt ut labore et dolore magna aliqua.\nUt enim ad minim veniam, quis nostrud exercitation \nullamco laboris nisi\nut aliquip ex ea commodo consequat. Duis aute \nirure dolor in reprehenderit in \nvoluptate velit esse cillum dolore eu fugiat\nnulla pariatur. Excepteur sint\noccaecat cupidatat non proident, \nsunt in culpa qui officia\ndeserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, \nconsectetur adipiscing elit,\n sed do eiusmod tempor \nincididunt ut labore et dolore magna aliqua.\nUt enim ad minim veniam, quis \nnostrud exercitation ullamco laboris nisi\nut aliquip ex ea commodo consequat. \nDuis aute irure dolor in reprehenderit in \nvoluptate velit esse \ncillum dolore eu fugiat\nnulla pariatur. Excepteur sint\noccaecat cupidatat non \nproident, sunt in culpa qui officia\ndeserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur\n adipiscing elit, sed do eiusmod tempor \nincididunt ut labore et dolore magna aliqua.\nUt enim ad minim veniam, quis nostrud exercitation \nullamco laboris nisi\nut aliquip ex ea commodo consequat. Duis aute \nirure dolor in reprehenderit in \nvoluptate velit esse cillum dolore eu fugiat\nnulla pariatur. Excepteur sint\noccaecat cupidatat non proident, \nsunt in culpa qui officia\ndeserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, \nconsectetur adipiscing elit,\n sed do eiusmod tempor \nincididunt ut labore et dolore magna aliqua.\nUt enim ad minim veniam, quis \nnostrud exercitation ullamco laboris nisi\nut aliquip ex ea commodo consequat. \nDuis aute irure dolor in reprehenderit in \nvoluptate velit esse \ncillum dolore eu fugiat\nnulla pariatur. Excepteur sint\noccaecat cupidatat non \nproident, sunt in culpa qui officia\ndeserunt mollit anim id est laborum.";
            
            label2.Text = "Очень интересный текст";
            label3.Text = "Очень интересный текст";
            label4.Text = "Очень интересный текст";
            label5.Text = "Очень интересный текст";
            label6.Text = "Очень интересный текст";
            label7.Text = "Очень интересный текст";
        }

 
        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            axWindowsMediaPlayer1.Visible = false;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo1;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo2;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo1;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo2;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count += 10;
            if (count < distance)
            {
                panel8.VerticalScroll.Value += 10;
            }
            else
            {
                timer1.Stop();
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            //startPoint = panel8.VerticalScroll.Value;
            startY = e.Y;
            label8.Text = startY.ToString();
        }


        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            endY = e.Y;
            distance = endY - startY;
         //   Math.Round(label1.Size.Height - distance);
            count = 0;
            timer1.Start();
        }
    }
}
