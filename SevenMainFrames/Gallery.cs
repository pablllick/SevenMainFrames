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
        // надо брать curItem из Form1 один, чтобы отслеживать какие нужны папки с фото
        string curItem;
        public Gallery()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(1920, 1080);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form1"];
            curItem = ((Form1)f).curItem;
            string imagePaths = $@"C:\SevenMainFrames\{curItem}\img_motorcycles\img_gallery\gallery.png"; // здесь можно загружать для разных папок разные фотки

            
            //for (int i = 1; i < 11; i++)
            //{
                /*var pb = new PictureBox();
                pb.Size = new Size(300, 300);
                try
                {
                    pb.Image = Image.FromFile(imagePaths[0]);
                }
                catch 
                {

                }
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                flowLayoutPanel1.Controls.Add(pb);*/

                //PictureBox pictureBox = this.Controls["pictureBox" + i.ToString()] as PictureBox;
                //if (pictureBox != null)
                //{
            for (int i = 0; i < flowLayoutPanel1.Controls.OfType<PictureBox>().Count(); i++)
            {
                PictureBox sourcePictureBox = flowLayoutPanel1.Controls.OfType<PictureBox>().ElementAt(i);
                sourcePictureBox.Image = Image.FromFile(imagePaths);
            }
                    //pictureBox.Image = Image.FromFile(imagePaths); // тут можно добавлять разные индекс
                //}
            //}
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
