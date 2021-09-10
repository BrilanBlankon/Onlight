using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Intro : Form
    {
        public string userdata;
        public Intro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pick character = new Pick();
            character.userdata = userdata;
            character.Show();          
            character.TopMost = true;
            this.Dispose();

        }

        private void Intro_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"說明.png");
            var pic = new Bitmap(this.BackgroundImage, new Size(this.Width, this.Height));
            this.BackgroundImage = pic;
        }

        private void Intro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
