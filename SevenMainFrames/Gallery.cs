using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenMainFrames
{
    public partial class Gallery : Form
    {
        public Gallery()
        {
            InitializeComponent();

            string[] imagePaths = new string[]
            {
                "C:\\Рабочий стол\\photo.png" // здесь можно загружать для разных папок разные фотки
            };

            for (int i = 1; i < 11; i++)
            {
                PictureBox pictureBox = this.Controls["pictureBox" + i.ToString()] as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(imagePaths[0]); // тут можно добавлять разные индекс
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox1.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void Gallery_Click(object sender, EventArgs e)
        {
            pictureBox11.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox2.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox3.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox4.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox5.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox6.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox7.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox8.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox9.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = pictureBox10.Image;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Visible = true;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox11.Visible = false;
        }
    }
}
