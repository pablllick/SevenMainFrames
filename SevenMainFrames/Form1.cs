using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;
using System.Timers;

namespace SevenMainFrames
{

    public partial class Form1 : Form
    {
        private ButtonAnimator buttonAnimator;
        public string filePath, curItem;
        int time;
        PictureBox pict;
        private FlowLayoutPanel imagePanel;
        private System.Timers.Timer timer;
        private DateTime startTime;
        private int startScrollPosition;
        private int targetScrollPosition;
        private int duration = 1000;
        private int scrollDistance = 500;
        private int mouseDownPosition;
        private bool isDragging = false;
        private int dragThreshold = 10;

        public Form1()
        {
            InitializeComponent();
            InitializeImagePanel();

            buttonAnimator = new ButtonAnimator();

            timer = new System.Timers.Timer();
            timer.Interval = 16;
            timer.Elapsed += Timer_Elapsed;

            flowLayoutPanel1.MouseDown += FlowLayoutPanel1_MouseDown;
            flowLayoutPanel1.MouseUp += FlowLayoutPanel1_MouseUp;
            flowLayoutPanel1.MouseUp += FlowLayoutPanel1_MouseUp;

            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Size = new Size(1920, 290);
            flowLayoutPanel1.Location = new Point(0, flowLayoutPanel1.Location.Y);
            
            void SetDoubleBuffered(Control c)
            {
                System.Reflection.PropertyInfo aProp = typeof(Control).GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
                aProp.SetValue(c, true, null);
            }
            SetDoubleBuffered(this);
            this.DoubleBuffered = true;
            SetDoubleBuffered(flowLayoutPanel1);
            Image empty = new Bitmap(@"C:\Рабочий стол\empty.png");
           
            button1.BackgroundImage = empty;

            this.FormBorderStyle = FormBorderStyle.None;
            
            axWindowsMediaPlayer1.URL = @"C:\Рабочий стол\videos\video.mp4";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;

            this.BackgroundImage = new Bitmap(@"C:\Рабочий стол\photo.png");
            
            SetDoubleBuffered(panel2);
            SetDoubleBuffered(panel3);
            SetDoubleBuffered(panel4);
            SetDoubleBuffered(panel5);
            SetDoubleBuffered(panel6);
            SetDoubleBuffered(panel7);
            SetDoubleBuffered(panel8);
            SetDoubleBuffered(panel9);
            SetDoubleBuffered(panel10);
            SetDoubleBuffered(panel11);
            SetDoubleBuffered(panel12);
            SetDoubleBuffered(panel13);
            SetDoubleBuffered(panel14);

            SetDoubleBuffered(pictureBox1);
            SetDoubleBuffered(pictureBox2);
            SetDoubleBuffered(pictureBox3);
            SetDoubleBuffered(pictureBox4);
            SetDoubleBuffered(pictureBox5);
            SetDoubleBuffered(pictureBox6);
            SetDoubleBuffered(pictureBox7);
            SetDoubleBuffered(pictureBox8);
            SetDoubleBuffered(pictureBox9);
            SetDoubleBuffered(pictureBox10);
            SetDoubleBuffered(pictureBox11);
            SetDoubleBuffered(pictureBox12);
            SetDoubleBuffered(pictureBox13);

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
            pictureBox13.Image = Properties.Resources.photo1;

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
            
            AssignMouseDownEvent(flowLayoutPanel1);
        }

        private void InitializeImagePanel()
        {
            this.Controls.Add(imagePanel);
        }

        private void FlowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPosition = e.Location.X;
            startScrollPosition = flowLayoutPanel1.HorizontalScroll.Value;
            isDragging = false;
        }

        private void FlowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging && Math.Abs(e.X - mouseDownPosition) > dragThreshold)
            {
                isDragging = true;
            }
        }

        private void FlowLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int mouseUpPosition = e.Location.X;

                if (mouseUpPosition > mouseDownPosition)
                {
                    targetScrollPosition = startScrollPosition - scrollDistance;
                }
                else
                {
                    targetScrollPosition = startScrollPosition + scrollDistance;
                }

                targetScrollPosition = Math.Max(0, Math.Min(targetScrollPosition, flowLayoutPanel1.HorizontalScroll.Maximum));

                startTime = DateTime.Now;
                timer.Start();
            }
            else
            {

            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            double elapsed = (DateTime.Now - startTime).TotalMilliseconds;
            double t = elapsed / duration;

            if (t > 1)
            {
                t = 1;
                timer.Stop();
            }

            double easedT = EaseOutCubic(t);

            int newScrollPosition = startScrollPosition + (int)((targetScrollPosition - startScrollPosition) * easedT);

            flowLayoutPanel1.Invoke((MethodInvoker)delegate
            {
                flowLayoutPanel1.HorizontalScroll.Value = newScrollPosition;
                flowLayoutPanel1.PerformLayout();
            });
        }

        private double EaseOutCubic(double x)
        {
            return 1 - Math.Pow(1 - x, 3);
        }

        private void AssignMouseDownEvent(Control parent)
         {
             foreach (Control control in parent.Controls)
             {
                 if (control is PictureBox || control is Panel)
                 {
                    control.MouseDown += FlowLayoutPanel1_MouseDown;
                    control.MouseMove += FlowLayoutPanel1_MouseMove;
                    control.MouseUp += FlowLayoutPanel1_MouseUp;

                    if (control.HasChildren)
                    {
                        AssignMouseDownEvent(control);
                    }
                 }
             }
             parent.MouseDown += FlowLayoutPanel1_MouseDown;
            parent.MouseMove += FlowLayoutPanel1_MouseMove;
             parent.MouseUp += FlowLayoutPanel1_MouseUp;
         }

        public class FileProcessor
        {
            private string _filePath;
            private Label _label8;
            private Label _label1;

            public FileProcessor(string filePath, Label label8, Label label1)
            {
             
                _filePath = filePath;
                _label8 = label8;
                _label1 = label1;
            }

            public class TransparentControl : UserControl
            {
                public TransparentControl()
                {
                    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                    this.BackColor = Color.Transparent;
                }
            }

            public void ProcessFile()
            {
                using (StreamReader streamReader = new StreamReader(_filePath))
                {
                    _label8.Text = "";
                    _label1.Text = "";
                    string l = "";
                    string r = "";
                    while (!streamReader.EndOfStream)
                    {
                        string[] totalData = streamReader.ReadLine().Split(',');
                        if (totalData.Length >= 2) 
                        {
                            l += totalData[0] + Environment.NewLine;
                            r += totalData[1] + Environment.NewLine;
                            
                            _label1.SuspendLayout();
                            _label1.Text += totalData[1] + Environment.NewLine;
                            _label1.ResumeLayout();
                        }
                    }
                    _label8.SuspendLayout();
                    _label8.Text = l;
                    _label8.ResumeLayout();
                    _label1.SuspendLayout();
                    _label1.Text = r;
                    _label1.ResumeLayout();
                }
            }
        }

        

            private void Form1_Load(object sender, EventArgs e)
            { 
                this.Size = new System.Drawing.Size(1920, 1080);
                this.BackgroundImageLayout= ImageLayout.Stretch;
            
                curItem = "1";
                filePath = "..//..//..//1.txt";
                FileProcessor fileProcessor = new FileProcessor(filePath, label8, label1);
                fileProcessor.ProcessFile();
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
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", label8, label1);
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
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", label8, label1);
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
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", label8, label1);
            fileProcessor.ProcessFile();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo;
            pict = sender as PictureBox;

            PanelHelper.SetPanelBorderStyle(pict);

            curItem = pict.Name.Split('x')[1];
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", label8, label1);
            fileProcessor.ProcessFile();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo1;
            pict = sender as PictureBox;

            PanelHelper.SetPanelBorderStyle(pict);

            curItem = pict.Name.Split('x')[1];
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", label8, label1);
            fileProcessor.ProcessFile();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.photo2;
            pict = sender as PictureBox;

            PanelHelper.SetPanelBorderStyle(pict);

            curItem = pict.Name.Split('x')[1];
            FileProcessor fileProcessor = new FileProcessor($"..//..//..//{curItem}.txt", label8, label1);
            fileProcessor.ProcessFile();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonAnimator.StartAnimation(button2, Button2Action);
            
        }

        private void Button2Action()
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
        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.First)
            {
                LockWindowUpdate(this.Handle);
            }
            else
            {
                LockWindowUpdate(IntPtr.Zero);
                flowLayoutPanel1.Update();
                if (e.Type != ScrollEventType.Last) LockWindowUpdate(this.Handle);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWindowUpdate(IntPtr hWnd);

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_COMPOSITED = 0x02000000;
                var cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonAnimator.StartAnimation(button1, Button1Action);
            
        }

        private void Button1Action()
        {
            History history = new History();
            time = 0;
            history.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonAnimator.StartAnimation(button3, Button3Action);
        }

        private void Button3Action()
        {
            InterestingFact interestingFact = new InterestingFact();
            time = 0;
            interestingFact.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonAnimator.StartAnimation(button5, Button5Action);
        }

        private void Button5Action()
        {
            Newsreel newsreel = new Newsreel();
            newsreel.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonAnimator.StartAnimation(button4, Button4Action);
        }

        private void Button4Action()
        {
            SoundPlayer simpleSound = new SoundPlayer($@"C:\\Рабочий стол\\sound\\{curItem}.wav");
            time = 0;
            simpleSound.Play();
        }
    }

    public class ButtonAnimator
    {
        private System.Windows.Forms.Timer timer;
        private Button button;
        private int count;
        private int startX;
        private int startY;
        private const int AnimationSteps = 5;
        private const int SizeChange = 2;
        private const int PositionChange = 1;

        public event Action AnimationCompleted;

        public ButtonAnimator()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1; // Adjust the interval as needed
            timer.Tick += Timer_Tick;
        }

        public void StartAnimation(Button btn, Action onComplete)
        {
            button = btn;
            startX = btn.Location.X;
            startY = btn.Location.Y;
            count = 0;
            AnimationCompleted = onComplete;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            count++;
            if (count < AnimationSteps)
            {
                button.Size = new Size(button.Width - SizeChange, button.Height - SizeChange);
                button.Location = new Point(button.Location.X + PositionChange, button.Location.Y - PositionChange);
            }
            else
            {
                button.Size = new Size(button.Width + SizeChange, button.Height + SizeChange);
                button.Location = new Point(button.Location.X - PositionChange, button.Location.Y + PositionChange);
            }
            if (startX == button.Location.X && startY == button.Location.Y)
            {
                timer.Stop();
                AnimationCompleted?.Invoke();
            }
        }
    }
}