using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Setting : Form
    {
        public string userdata;
        public Setting()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Intro introduction = new Intro();
            introduction.userdata = userdata;
            introduction.Show();
            introduction.TopMost = true;
            this.Dispose();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"登入畫面2.png");
            var pic = new Bitmap(this.BackgroundImage, new Size(this.Width, this.Height));
            this.BackgroundImage = pic;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("確定要離開嗎?", "登出", MessageBoxButtons.OKCancel);

            if (Result == DialogResult.OK)
            {
                try
                {
                    System.Environment.Exit(0);
                }
                catch(Exception ex)
                {
                }
            }
            else if (Result == DialogResult.Cancel)
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {         
            RANK RANK = new RANK();
            RANK.userdata = userdata;
            RANK.Show();
            RANK.TopMost = true;
            this.Dispose();
        }

        private void Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {                        
            FileStream myfile = File.Open("../../../data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(myfile);
            string line = sr.ReadLine(),ID,PW,name,role,level;
            while((line = sr.ReadLine()) != null )
            {
               ID = line.Split('\t')[0];
               PW = line.Split('\t')[1];                   
               if ((ID + '\t' + PW) == userdata)
               {
                    name = line.Split('\t')[2];
                    role = line.Split('\t')[3];
                    level = line.Split('\t')[4];
                    if(role == "" || level == "")
                    {
                        MessageBox.Show("請先建立新遊戲");
                        break;
                    }
                    Level level_form = new Level();
                    level_form.role = role;
                    level_form.userdata = userdata;
                    level_form.username = name;
                    level_form.level = level+" 完成";
                    level_form.Show();
                    level_form.TopMost = true;
                    this.Dispose();
                }
             }
             myfile.Close();
             sr.Close();  
        }
    }
}
