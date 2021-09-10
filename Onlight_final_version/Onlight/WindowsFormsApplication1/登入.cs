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
using System.Collections;
using System.Media;


namespace WindowsFormsApplication1
{
    public partial class UserLogin : Form
    {
        SoundPlayer player1 = new SoundPlayer(@"BGM.wav");
        Setting setting;
        public UserLogin()
        {
            InitializeComponent();
        }   
        private void signup_Click(object sender, EventArgs e)
        {
            try
            {
                string userSignUp = IDtxt.Text + '\t' + passwordtxt.Text;

                
                FileStream myfile = File.Open("../../../data.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(myfile);
                string line = sr.ReadLine();
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] user = userSignUp.Split('\t');
                    string[] data = line.Split('\t');
                    if (user[0] == data[0]) 
                    {
                        MessageBox.Show("帳號已被註冊","錯誤",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        sr.Close();
                        myfile.Close();
                        return;
                    }
                    line = sr.ReadLine();
                }
                sr.Dispose();
                myfile.Dispose();
                myfile = File.Open("../../../data.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(myfile);
                if (IDtxt.TextLength != 0 && passwordtxt.TextLength != 0)
                {
                    sw.WriteLine(userSignUp +'\t'+"" + '\t' + "" + '\t' + "");
                    MessageBox.Show("註冊成功，請按登入", "");
                }
                else
                {
                    MessageBox.Show("帳號/密碼格式錯誤 " , "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }        

                
                sw.Close();
                myfile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Exception: " + ex.Message , "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void 登入_Load(object sender, EventArgs e)
        {
            player1.PlayLooping();
            IDtxt.Text = "";
            passwordtxt.Text = "";
            this.BackgroundImage = Image.FromFile( @"登入畫面.png");
            var pic = new Bitmap(this.BackgroundImage, new Size(this.Width, this.Height));
            this.BackgroundImage = pic;
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                
                FileStream myfile = File.Open("../../../data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(myfile);
                List<string> userData = new List<string>();
                string line = sr.ReadLine();
                line = sr.ReadLine();
                while (line != null)
                {
                    string ID = line.Split('\t')[0], password = line.Split('\t')[1];
                    userData.Add(ID + '\t' +password);
                    line = sr.ReadLine();
                }
                sr.Close();
                myfile.Close();

                string nowID = IDtxt.Text, nowpassword = passwordtxt.Text;
                string userLogin = nowID + '\t' + nowpassword;
                if (userData.Contains(userLogin))
                {
                    MessageBox.Show("登入成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                    setting = new Setting();
                    setting.userdata = userLogin;
                    setting.Show();                  
                    setting.TopMost = true;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("登入失敗", "", MessageBoxButtons.OK, MessageBoxIcon.None);                                     
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
