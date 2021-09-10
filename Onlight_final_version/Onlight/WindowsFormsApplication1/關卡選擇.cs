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
    public partial class Level : Form
    {
        public string role,userdata,username,level;
        GameForm game;
        public Level()
        {
            InitializeComponent();
        }

        private void Level_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = imageList1.Images[0];
            pictureBox2.Image = imageList1.Images[1];
            pictureBox3.Image = imageList1.Images[2];
            adjust();
        }
        public void adjust()
        {
                if (level == "" || level == "simple 失敗")
                {
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
                else if (level == "simple 完成" || level == "normal 失敗")
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = false;
                }
                else if (level == "normal 完成" || level == "hard 完成" || level == "hard 失敗")
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            

           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            game = new GameForm();
            game.role = role;
            game.level = "simple";
            game.userdata = userdata;
            game.username = username;
            game.Show();
            game.TopMost = true;
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            game = new GameForm();
            game.role = role;
            game.level = "normal";
            game.userdata = userdata;
            game.username = username;
            game.Show();
            game.TopMost = true;
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game = new GameForm();
            game.role = role;
            game.level = "hard";
            game.userdata = userdata;
            game.username = username;
            game.Show();
            game.TopMost = true;
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Setting set = new Setting();
            set.userdata = userdata;
            set.Show();
            this.Dispose();
        }

        private void Level_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
