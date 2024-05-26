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
using System.Windows.Forms.VisualStyles;
using WMPLib;

namespace SevenMainFrames
{
    public partial class Newsreel : Form
    {
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form1"];
        int count;
        public Newsreel()
        {
            InitializeComponent();

            timer1.Start();

            string curItem = ((Form1)f).curItem;

            string[] strings = Directory.GetFiles($@"C:\Рабочий стол\items\{curItem}");

            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.URL = strings[0];
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.settings.autoStart = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count > 5 && axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsPlaying)
            {
                this.Close();
                timer1.Stop();
                count = 0;
            }
        }
    }
}
