using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SevenMainFrames
{
    public partial class Form1 : Form
    {
        public string filePath, curItem;
        int count, addNumber;
       
        //int startPoint, startY, endY, count, distance;

        

        public Form1()
        {
            InitializeComponent();

            //this.FormBorderStyle = FormBorderStyle.None;
            
            axWindowsMediaPlayer1.URL = @"C:\Рабочий стол\videos\video.mp4";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;

            this.BackgroundImage = Properties.Resources.photo;

            pictureBox1.Image = Properties.Resources.photo;
            pictureBox2.Image = Properties.Resources.photo1;
            pictureBox3.Image = Properties.Resources.photo2;
            pictureBox4.Image = Properties.Resources.photo;
            pictureBox5.Image = Properties.Resources.photo1;
            pictureBox6.Image = Properties.Resources.photo2;
            pictureBox7.Image = Properties.Resources.photo;
            pictureBox8.Image = Properties.Resources.photo1;
            pictureBox9.Image = Properties.Resources.photo2;
            pictureBox10.Image = Properties.Resources.photo;
            pictureBox11.Image = Properties.Resources.photo1;
            pictureBox12.Image = Properties.Resources.photo2;
            pictureBox13.Image = Properties.Resources.photo;
            pictureBox14.Image = Properties.Resources.photo1;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;

            textBox1.TextAlign = HorizontalAlignment.Left;
            textBox2.TextAlign = HorizontalAlignment.Right;
        }

        public class FileProcessor
        {
            private string _filePath;
            private TextBox _textBox1;
            private TextBox _textBox2;

            public FileProcessor(string filePath, TextBox textBox1, TextBox textBox2)
            {
                _filePath = filePath;
                _textBox1 = textBox1;
                _textBox2 = textBox2;
            }



            public void ProcessFile()
            {
                using (StreamReader streamReader = new StreamReader(_filePath))
                {
                    _textBox1.Text = "";
                    _textBox2.Text = "";
                    while (!streamReader.EndOfStream)
                    {
                        string[] totalData = streamReader.ReadLine().Split(',');
                        if (totalData.Length >= 2) 
                        {
                            _textBox1.AppendText(totalData[0] + Environment.NewLine);
                            _textBox2.AppendText(totalData[1] + Environment.NewLine);
                        }
                    }
                }
            }
        }

        

            private void Form1_Load(object sender, EventArgs e)
        { 
            this.Size = new System.Drawing.Size(1920, 1080);
            this.BackgroundImageLayout= ImageLayout.Stretch;
            curItem = "1";
            filePath = "..//..//..//1.txt";
            FileProcessor fileProcessor = new FileProcessor(filePath, textBox1, textBox2);
            fileProcessor.ProcessFile();
          
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo;
            /*Panel panel = this.Controls["panel" + (int.Parse(curItem) + 1).ToString()] as Panel;
            if (panel != null)
            {
                panel.BorderStyle = BorderStyle.FixedSingle;
            }*/
            PictureBox pict = sender as PictureBox;
            curItem = pict.Name.Split('x')[1];
                
            string[] dirWithVideos = Directory.GetFiles($@"C:\Рабочий стол\items\{curItem}");
            if (dirWithVideos.Length == 0)
            {
                button5.Visible = false;
                button5.Enabled = false;
            }
            else
            {
                button5.Visible = true;
                button5.Enabled = true;
            }
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", textBox1, textBox2);
            fileProcessor.ProcessFile();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo1;
            PictureBox pict = sender as PictureBox;
            curItem = pict.Name.Split('x')[1];
            string[] dirWithVideos = Directory.GetFiles($@"C:\Рабочий стол\items\{curItem}");
            if (dirWithVideos.Length == 0)
            {
                button5.Visible = false;
                button5.Enabled = false;
            }
            else
            {
                button5.Visible = true;
                button5.Enabled = true;
            }
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", textBox1, textBox2);
            fileProcessor.ProcessFile();
        }

 

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo2;
            PictureBox pict = sender as PictureBox;
            curItem = pict.Name.Split('x')[1];
            string[] dirWithVideos = Directory.GetFiles($@"C:\Рабочий стол\items\{curItem}");
            if (dirWithVideos.Length == 0)
            {
                button5.Visible = false;
                
            }
            else
            {
                button5.Visible = true;
                button5.Enabled = true;
            }
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", textBox1, textBox2);
            fileProcessor.ProcessFile();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo;
            PictureBox pict = sender as PictureBox;
            curItem = pict.Name.Split('x')[1];
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", textBox1, textBox2);
            fileProcessor.ProcessFile();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo1;
            PictureBox pict = sender as PictureBox;
            curItem = pict.Name.Split('x')[1];
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", textBox1, textBox2);
            fileProcessor.ProcessFile();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo2;
            PictureBox pict = sender as PictureBox;
            curItem = pict.Name.Split('x')[1];
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", textBox1, textBox2);
            fileProcessor.ProcessFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gallery gallery = new Gallery();
            gallery.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InterestingFact interestingFact = new InterestingFact();
            interestingFact.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Newsreel newsreel = new Newsreel();
            newsreel.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addNumber = -20;
            timer1.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addNumber = 20;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count ++;
            if (count < 27)
            {
                if (panel1.HorizontalScroll.Value < 20 && addNumber < 0)
                {
                    panel1.HorizontalScroll.Value = 0;
                    count = 0;
                    timer1.Stop();
                }
                else
                {
                    panel1.HorizontalScroll.Value += addNumber;
                }  
            }
            else
            {
                count = 0;
                timer1.Stop();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer($@"C:\\Рабочий стол\\sound\\{curItem}.wav");
            simpleSound.Play();
        }

        /* private void timer1_Tick(object sender, EventArgs e)
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
         } */
    }
}
