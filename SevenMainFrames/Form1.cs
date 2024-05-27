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
        int count, count2, addNumber, startLocationX, endLocationX, distance, distanceTemp, time;
        PictureBox pict;

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            
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

            AssignMouseDownEvent(panel1);
        }

        private void AssignMouseDownEvent(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is PictureBox || control is Panel)
                {
                    control.MouseDown += Panel_MouseDown;
                    control.MouseUp += Panel_MouseUp;
                    if (control.HasChildren)
                    {
                        AssignMouseDownEvent(control);
                    }
                }
            }
            parent.MouseDown += Panel_MouseDown;
            parent.MouseUp += Panel_MouseUp;
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            Point screenCoordinates = panel1.PointToScreen(e.Location);
            Point panelCoordinates = panel1.PointToClient(screenCoordinates);
            Panel parentPanel = control.Parent as Panel;

            if (control is PictureBox)
            {
                if (parentPanel != null)
                {
                    endLocationX = panelCoordinates.X + parentPanel.Location.X;
                }
            }
            else
            {
                endLocationX = panelCoordinates.X + control.Location.X;
            }
            distance = startLocationX - endLocationX;
            distanceTemp = distance;
           // label1.Text = startLocationX.ToString() + " - " + distanceTemp.ToString();
            timer2.Start();
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;
            
            Point screenCoordinates = panel1.PointToScreen(e.Location);
            Point panelCoordinates = panel1.PointToClient(screenCoordinates);
            Panel parentPanel = control.Parent as Panel;

            if (control is PictureBox)
            {
                if (parentPanel != null)
                {
                    startLocationX = panelCoordinates.X + parentPanel.Location.X;
                }
            }
            else
            {
                startLocationX = panelCoordinates.X + control.Location.X;
            }
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

        public static class PanelHelper
        {
            private static Panel previousPanel = null;
            public static void SetPanelBorderStyle(Control control)
            {
                Panel currentPanel = control.Parent as Panel;
                if (currentPanel != null)
                {
                    if (previousPanel != null && previousPanel != currentPanel)
                    {
                        previousPanel.BorderStyle = BorderStyle.None;
                    }
                    currentPanel.BorderStyle = BorderStyle.FixedSingle;
                    previousPanel = currentPanel;
                }
            }
        }

        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            axWindowsMediaPlayer1.Visible = false;
            timer3.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo;
            pict = sender as PictureBox;

            PanelHelper.SetPanelBorderStyle(pict);

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
            pict = sender as PictureBox;

            PanelHelper.SetPanelBorderStyle(pict);
           
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
            pict = sender as PictureBox;

            PanelHelper.SetPanelBorderStyle(pict);

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
            pict = sender as PictureBox;

            PanelHelper.SetPanelBorderStyle(pict);

            curItem = pict.Name.Split('x')[1];
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", textBox1, textBox2);
            fileProcessor.ProcessFile();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo1;
            pict = sender as PictureBox;

            PanelHelper.SetPanelBorderStyle(pict);

            curItem = pict.Name.Split('x')[1];
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", textBox1, textBox2);
            fileProcessor.ProcessFile();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo2;
            pict = sender as PictureBox;

            PanelHelper.SetPanelBorderStyle(pict);

            curItem = pict.Name.Split('x')[1];
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", textBox1, textBox2);
            fileProcessor.ProcessFile();

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Gallery gallery = new Gallery();
            time = 0;
            gallery.Show();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            time++;
            if (time == 300)
            {
                axWindowsMediaPlayer1.Visible = true;
                time = 0;
                timer3.Stop();
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].Name != "Form1")
                        Application.OpenForms[i].Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            History history = new History();
            time = 0;
            history.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InterestingFact interestingFact = new InterestingFact();
            time = 0;
            interestingFact.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Newsreel newsreel = new Newsreel();
            newsreel.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           

            if (distance < 0)
            {
                if (distanceTemp > -20)
                {

                    panel1.HorizontalScroll.Value = 0;
                    timer2.Stop();
                }
                else
                {
                    distanceTemp += 20;
                    int a = panel1.HorizontalScroll.Value - 20;
                    if (a < 0)
                    {
                        panel1.HorizontalScroll.Value = 0;
                        timer2.Stop();
                    }
                    else
                    {
                        panel1.HorizontalScroll.Value = a;
                    }
                }
            }

            /*else if (distance > 0)
            {
                if (distanceTemp < 20)
                {
                    if (panel1.HorizontalScroll.Maximum != panel1.HorizontalScroll.Value)
                    {
                        distanceTemp -= 20;
                        panel1.HorizontalScroll.Value += 20;
                    }
                    else
                    {

                    }
                }

            }*/










            /*if (distance > 0) 
            {
                if (distanceTemp < -21)
                {
                    distance += 20;
                    panel1.HorizontalScroll.Value -= 20;
                }
                else
                {
                    panel1.HorizontalScroll.Value -= distance;
                    timer2.Stop();
                }
            }
            else if (distance < 0)
            {
                if (distanceTemp > 0)
                {
                    if (distanceTemp > 21)
                    {
                        distance -= 20;
                        panel1.HorizontalScroll.Value += 20;
                    }
                    else
                    {
                        panel1.HorizontalScroll.Value += distance;
                        timer2.Stop();
                    }
                }
            }*/


            /*if (count < 27)
            {
                if (panel1.HorizontalScroll.Value < 20 && addNumber < 0)
                {
                    panel1.HorizontalScroll.Value = 0;
                    count = 0;
                    timer2.Stop();
                }
                else
                {
                    panel1.HorizontalScroll.Value += addNumber;
                }
            }
            else
            {
                count = 0;
                timer2.Stop();
            }*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addNumber = -20;
            time = 0;
            timer1.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addNumber = 20;
            time = 0;
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
            time = 0;
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
