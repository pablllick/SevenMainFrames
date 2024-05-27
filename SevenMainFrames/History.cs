using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenMainFrames
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(1920, 1080);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
