using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Pick : Form
    {
        public string userdata;
        public Pick()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (btn1.Enabled == true && btn2.Enabled == true && btn3.Enabled == true)
            {
                MessageBox.Show("請選擇角色");
                return;
            }
            string name = textBox1.Text;
            string[] myname = name.Split();
            foreach (string letter in myname)
                if (letter == "")
                {
                    MessageBox.Show("請輸入名字（請勿輸入空白鍵）");
                    return;
                }
                else if (string.IsNullOrEmpty(textBox1.Text) | textBox1.Text == " ")
                {
                    MessageBox.Show("請輸入名字（請勿輸入空白鍵）");
                    return;
                }
            Level level = new Level();
            if (btn1.Enabled == true)
            {
                level.role = "Elvar";
                level.userdata = userdata;
                level.username = textBox1.Text;
            }
            else if (btn2.Enabled == true)
            {
                level.role = "Grub";
                level.userdata = userdata;
                level.username = textBox1.Text;
            }
            else if (btn3.Enabled == true)
            {
                level.role = "Nig";
                level.userdata = userdata;
                level.username = textBox1.Text;
            }

            level.Show();
            level.TopMost = true;
            this.Dispose();
        }

        private void Pick_Load(object sender, EventArgs e)
        {
            pic1.Image = imageList1.Images[0];
            pic2.Image = imageList1.Images[2];
            pic3.Image = imageList1.Images[4];
        }

        private void pic1_MouseEnter(object sender, EventArgs e)
        {
            pic1.Image = imageList1.Images[1];
        }

        private void pic1_MouseLeave(object sender, EventArgs e)
        {
            pic1.Image = imageList1.Images[0];
        }

        private void pic2_MouseEnter(object sender, EventArgs e)
        {
            pic2.Image = imageList1.Images[3];
        }

        private void pic2_MouseLeave(object sender, EventArgs e)
        {
            pic2.Image = imageList1.Images[2];
        }

        private void pic3_MouseEnter(object sender, EventArgs e)
        {
            pic3.Image = imageList1.Images[5];
        }

        private void pic3_MouseLeave(object sender, EventArgs e)
        {
            pic3.Image = imageList1.Images[4];
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn2.Enabled == false && btn3.Enabled == false)
            {
                btn2.Enabled = true;
                btn3.Enabled = true;
                btn1.Text = "選擇";
            }
            else if(btn2.Enabled == true && btn3.Enabled == true)
            {
                btn2.Enabled = false;
                btn3.Enabled = false;
                btn1.Text = "取消選擇";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn1.Enabled == false && btn3.Enabled == false)
            {
                btn1.Enabled = true;
                btn3.Enabled = true;
                btn2.Text = "選擇";
            }
            else if (btn1.Enabled == true && btn3.Enabled == true)
            {
                btn1.Enabled = false;
                btn3.Enabled = false;
                btn2.Text = "取消選擇";
            }

        }


        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn2.Enabled == false && btn1.Enabled == false)
            {
                btn2.Enabled = true;
                btn1.Enabled = true;
                btn3.Text = "選擇";
            }
            else if (btn2.Enabled == true && btn1.Enabled == true)
            {
                btn2.Enabled = false;
                btn1.Enabled = false;
                btn3.Text = "取消選擇";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setting set = new Setting();
            set.userdata = userdata;
            set.Show();
            this.Dispose();
        }

        private void Pick_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
