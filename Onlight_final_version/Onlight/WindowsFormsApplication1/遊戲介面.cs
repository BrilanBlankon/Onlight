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
using System.Runtime.InteropServices;
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class GameForm : Form
    {
        SoundPlayer player1 = new SoundPlayer(@"BGM.wav");
        SoundPlayer player = new SoundPlayer();
        int t = 90, rep = 5, attcardindex = 0, defcardindex = 10, specardindex = 20, att = 0, def = 0, spe = 0, enemy_att = 0, enemy_def = 0, enemy_spe = 0, damage = 0, HPuser, HPenemy;
        Timer timer;
        bool[] btnChecked = new bool[12];
        List<int> cardindex = new List<int>();
        //紀錄卡片的索引值
        List<int> usercard = new List<int>();
        //紀錄玩家現在手中卡片的圖像索引值    
        List<string> enemyallcards = new List<string>(); 
        List<string> enemycard = new List<string>();
        //紀錄敵人現在手中卡片
        Random ran = new Random();
        bool turn ;
        // true = att turn,false = def turn

        Level level_form;
        
        public string role, level,userdata,username;
        public GameForm()
        {
            InitializeComponent();
        }
        public void setbtn()
        {
            Button[] btn = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12 };
            for (int i = 0; i < 8; i++)
            {
                btn[i].ImageList = imageList1;
                int index = randomcard();
                usercard.Add(index);
                btn[i].Click += new EventHandler(button_Click);
            }
            for (int i = 8; i <12; i++)
            {
                btn[i].ImageList = imageList1;
                usercard.Add(30);
                btn[i].Click += new EventHandler(button_Click);
            }
            usercard.Sort();
            for(int i = 0; i<12;i++)
            {
                btn[i].ImageIndex = usercard[i];
            }
            usercard.Clear();
        }
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void setcard()
        {
            while(rep >0)
            {
               for(int j = 0; j<rep;j++)
               {
                    cardindex.Add(attcardindex);
                    cardindex.Add(defcardindex);
                    cardindex.Add(specardindex);
               }
               rep -= 1;
               attcardindex += 2;
               defcardindex += 2;
               specardindex += 2;                     
            }
            attcardindex = 0;
            defcardindex = 10; 
            specardindex = 20;
            rep = 5;
        }

        public int randomcard()
        {           
            int index = ran.Next(cardindex.Count);               
            return cardindex[index];        
        }
        void timer_TickTock(object sender, EventArgs e)
        {
            if (t == 0)
            {
                newturn();
                label5.Visible = true;
                t = 90;
            }
            if (t == 89)
            {
                label5.Visible = false;
            }
            timelab.Text = " time" + '\n' + ' ' + t;
            t--;
        }
        private void 遊戲介面_Load(object sender, EventArgs e)
        {
            if (role == "Elvar")
            {
                pictureBox1.Image = imageList2.Images[0];
                skillnametxt.Text = "射擊";
                skilllimittxt.Text = "當特殊牌總數值≥5 + 攻擊牌總數值≥3";
                skilltxt.Text = "攻擊+4";
                HPuser = 8;
            }
            else if (role == "Grub")
            {
                pictureBox1.Image = imageList2.Images[1];
                skillnametxt.Text = "猛擊";
                skilllimittxt.Text = "當特殊牌總數值≥2 + 2張數值=1的攻擊牌";
                skilltxt.Text = "攻擊+6";
                HPuser = 9;
            }
            else if (role == "Nig")
            {
                pictureBox1.Image = imageList2.Images[2];
                skillnametxt.Text = "深淵";
                skilllimittxt.Text = "當特殊牌總數值≥4";
                skilltxt.Text = "攻擊+特/2(小數無條件捨棄)";
                HPuser = 10;
            }
            if(level == "simple")
            {
                this.BackgroundImage = Image.FromFile(@"pic1.png");
                HPenemy = 8;
                player.SoundLocation = @"BGM1.wav";
                player.PlayLooping();
            }
            else if (level == "normal")
            {
                this.BackgroundImage = Image.FromFile(@"pic2.png");
                player.SoundLocation = @"BGM2.wav";
                player.PlayLooping();
                HPenemy = 9;
            }
            else if (level == "hard")
            {
                this.BackgroundImage = Image.FromFile(@"pic3.png");
                player.SoundLocation = @"BGM3.wav";
                player.PlayLooping();
                HPenemy = 10;
            }
            progressBarUser.Maximum = HPuser;
            progressBarUser.Value = HPuser;
            progressBarUser.Minimum = 0;
            progressBarUser.Step = -1;
            progressBarEnemy.Maximum = HPenemy;
            progressBarEnemy.Value = HPenemy;
            progressBarEnemy.Minimum = 0;
            progressBarEnemy.Step = -1;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_TickTock);
            timer.Start();
            setcard();
            setbtn();
            turntxt.Text = "攻擊回合";
            label7.Text = "自己的血量: " + progressBarUser.Value + "/" + Convert.ToString(HPuser);
            label8.Text = "敵人的血量: " + progressBarEnemy.Value + "/" + Convert.ToString(HPenemy);
            turn = true;
            set_enemy();           
        }
        public int UserChar(string name, int att, int spe, int num4att1)
        {
            //目前只規劃三個角色
            if (name == "Elvar")
            {
                if (att >= 3 && spe >= 5)
                {
                    return att + 4;
                }
                return att;
            }
            else if (name == "Grub")
            {
                if (num4att1 == 2 && spe >= 2)
                {
                    return att + 6;
                }
                return att;
            }
            else
            {
                if (spe >= 4)
                {
                    if (spe % 2 != 0)
                    {
                        spe -= 1;
                    }
                    return att + (spe / 2);
                }
                return att;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int site = int.Parse(btn.Name.Split('n')[1])-1;
            if (btn.ImageIndex != 30)
            {
                if (btnChecked[site] == false)
                {
                    btn.ImageIndex += 1;
                    btnChecked[site] = true;
                }
                else
                {
                    btn.ImageIndex -= 1;
                    btnChecked[site] = false;
                }
            }               
        }
        private void confirmedbtn_Click(object sender, EventArgs e)
        {
            Button[] btn = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12 };
            int num4att1 = 0;
            for (int i = 0; i < 12; i++)
            {
                if (btnChecked[i] == true)
                {
                    int site = btn[i].ImageIndex;
                    string name = Convert.ToString(imageList1.Images.Keys[site]);
                    btnChecked[i] = false;
                    if (name.Split(',')[0] == "1")
                    {
                        if (name.Split(',')[1] == "1")
                        {
                            num4att1 += 1;
                        }
                        att += int.Parse(name.Split(',')[1]);
                    }
                    else if (name.Split(',')[0] == "2")
                        def += int.Parse(name.Split(',')[1]);
                    else if (name.Split(',')[0] == "3")
                        spe += int.Parse(name.Split(',')[1]);
                    btn[i].ImageIndex = 30;
                }
            }
            att = UserChar(role, att, spe, num4att1);
            //MessageBox.Show("您選擇的攻擊總數值為：" + Convert.ToString(att) + '\n' + "您選擇的防禦總數值為:" + Convert.ToString(def) + '\n' + "您選擇的特殊總數值為:" + Convert.ToString(spe) + '\n');           
            if (turn == true)
            {
                damage = att;
                textBox1.Text += "您攻擊的總數值為：" + Convert.ToString(att) + '\r' + '\n';
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            else
            {
                damage = -def;
                textBox1.Text +=  "您防禦的總數值為:" + Convert.ToString(def) + '\r' + '\n' ;
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            att = 0;
            def = 0;
            spe = 0;
            usercard.Clear();
            if (level == "simple")
            {
                enemymode2_simple();
            }
            else if (level == "normal")
            {
                enemymode3_normal();
            }
            else if (level == "hard")
            {
                enemymode4_hard();
            }
            fight();
            newturn();
            t = 90;
        }
        public void newturn()
        {
            Button[] btn = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12 };
            int tem;
            //紀錄開始沒牌的那個位置
            if (turn == true)
            {
                turntxt.Text = "防禦回合";
                turn = false;
            }
            else
            {
                turntxt.Text = "攻擊回合";
                turn = true;
            }
            if (turn == true)
            {
                resort();
                for (int i = 0;i<12;i++)
                {
                    if (btn[i].ImageIndex == 30)
                    {
                        tem = i;
                        for (int j = 0; j < 3; j++)
                        {
                            if(1 + tem <= 12)
                            {
                                int index = randomcard();
                                btn[tem].ImageIndex = index;
                                tem++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            resort();
        }
        public void resort()
        {
            Button[] btn = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12 };
            for (int i = 0; i < 12; i++)
            {
                usercard.Add(btn[i].ImageIndex);
            }
            usercard.Sort();
            for (int i = 0; i < 12; i++)
            {
                btn[i].ImageIndex = usercard[i];
            }
            usercard.Clear();
        }
        public void set_enemy()
        {
            while (rep > 0)
            {             
                    for (int j = 0; j < rep; j++)
                    {
                        enemyallcards.Add(imageList1.Images.Keys[attcardindex]);
                        enemyallcards.Add(imageList1.Images.Keys[defcardindex]);
                    }               
                rep -= 1;
                attcardindex += 2;
                defcardindex += 2;
            }
            for (int i = 0; i < 8; i++)
            {
                int index = ran.Next(enemyallcards.Count-1);             
                string name =enemyallcards[index];
                enemycard.Add(name);
            }
            label6.Text = "敵人手牌數：" + Convert.ToString(enemycard.Count());
            enemycard.Sort();
        }
        public void newturn_enemy()
        {
            if (turn == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    int index = ran.Next(enemyallcards.Count - 1);
                    string name = enemyallcards[index];
                    enemycard.Add(name);
                }
            }
            enemycard.Sort();
        }
        public void enemymode1_test()
        {
            //隨機出牌的敵人
            int num = ran.Next(1, 3);
            //隨機出1~3張牌
            for (int i = 0; i < num; i++)
            {
                int cardindex = ran.Next(0, enemycard.Count() - 1);
                string card = enemycard[cardindex];
                if (card.Split(',')[0] == "1")
                    enemy_att += int.Parse(card.Split(',')[1]);
                else if (card.Split(',')[0] == "2")
                    enemy_def += int.Parse(card.Split(',')[1]);
                else if (card.Split(',')[0] == "3")
                    enemy_spe += int.Parse(card.Split(',')[1]);
                enemycard.Remove(card);
            }
            newturn_enemy();
            MessageBox.Show("敵人選擇的攻擊總數值為：" + Convert.ToString(enemy_att) + '\n' + "敵人選擇的防禦總數值為:" + Convert.ToString(enemy_def) + '\n' + "敵人選擇的特殊總數值為:" + Convert.ToString(enemy_spe) + '\n' + "敵人出了" + Convert.ToString(num) + "張牌");
            label6.Text = "敵人手牌數：" + Convert.ToString(enemycard.Count());
            if (turn == true)
            {
                damage += -enemy_def;
            }
            else
            {
                damage += enemy_att;
            }
            enemy_att = 0;
            enemy_def = 0;
            enemy_spe = 0;
        }
        public void enemymode2_simple()
        {
            // 不拿特殊牌，攻擊出攻擊，防禦出防禦，random出牌
            int num_att = 0, num_def = 0;
            foreach (string card in enemycard)
            {
                if (card.Split(',')[0] == "1")
                    num_att += 1;
                else if (card.Split(',')[0] == "2")
                    num_def += 1;
            }
            if (turn == false)
            {
                //敵人的攻擊回合
                int num = ran.Next(num_att);
                for (int i = 0; i < num; i++)
                {
                    int cardindex = ran.Next(0, enemycard.Count() - 1);
                    string card = enemycard[cardindex];
                    if (card.Split(',')[0] == "1")
                    {
                        enemy_att += int.Parse(card.Split(',')[1]);
                    }
                    else if (card.Split(',')[0] == "2")
                    {
                        i--;
                        continue;
                    }
                    enemycard.Remove(card);
                }
            }
            else
            {
                //敵人的防禦回合
                int num = ran.Next(num_def);
                for (int i = 0; i < num; i++)
                {
                    int cardindex = ran.Next(0, enemycard.Count() - 1);
                    string card = enemycard[cardindex];
                    if (card.Split(',')[0] == "1")
                    {
                        i--;
                        continue;
                    }
                    else if (card.Split(',')[0] == "2")
                    {

                        enemy_def += int.Parse(card.Split(',')[1]);
                    }
                    enemycard.Remove(card);
                }
            }
            newturn_enemy();
            //MessageBox.Show("敵人選擇的攻擊總數值為：" + Convert.ToString(enemy_att) + '\n' + "敵人選擇的防禦總數值為:" + Convert.ToString(enemy_def) + '\n' + "敵人選擇的特殊總數值為:" + Convert.ToString(enemy_spe));
            
            label6.Text = "敵人手牌數：" + Convert.ToString(enemycard.Count());
            if (turn == true)
            {
                damage += -enemy_def;
                textBox1.Text +=  "敵人防禦的總數值為:" + Convert.ToString(enemy_def) + '\r' + '\n' ;
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            else
            {
                damage += enemy_att;
                textBox1.Text += "敵人攻擊的總數值為：" + Convert.ToString(enemy_att) + '\r' + '\n' ;
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            enemy_att = 0;
            enemy_def = 0;
            enemy_spe = 0;
        }     
        public void enemymode3_normal()
        {
            // 不拿特殊牌，血量/2以上，防禦回合只出防禦，攻擊回合不出，血量/2以下，攻擊回合全出攻擊，防禦回合只出防禦
            int num_att = 0, num_def = 0;
            foreach (string card in enemycard)
            {
                if (card.Split(',')[0] == "1")
                    num_att += 1;
                else if (card.Split(',')[0] == "2")
                    num_def += 1;
            }
            if (turn == false)
            {
                //敵人的攻擊回合
                if (progressBarEnemy.Value >= (HPenemy / 2))
                {
                    //不出牌
                    enemy_att = 0;
                }
                else
                {
                    for (int i = 0; i < num_att; i++)
                    {
                        int cardindex = ran.Next(0, enemycard.Count() - 1);
                        string card = enemycard[cardindex];
                        if (card.Split(',')[0] == "1")
                        {
                            enemy_att += int.Parse(card.Split(',')[1]);
                        }
                        else if (card.Split(',')[0] == "2")
                        {
                            i--;
                            continue;
                        }
                        enemycard.Remove(card);
                    }
                }

            }
            else
            {
                //敵人的防禦回合
                int num = ran.Next(num_def);
                for (int i = 0; i < num; i++)
                {
                    int cardindex = ran.Next(0, enemycard.Count() - 1);
                    string card = enemycard[cardindex];
                    if (card.Split(',')[0] == "1")
                    {
                        i--;
                        continue;
                    }
                    else if (card.Split(',')[0] == "2")
                    {

                        enemy_def += int.Parse(card.Split(',')[1]);
                    }
                    enemycard.Remove(card);
                }
            }
            newturn_enemy();
           // MessageBox.Show("敵人選擇的攻擊總數值為：" + Convert.ToString(enemy_att) + '\n' + "敵人選擇的防禦總數值為:" + Convert.ToString(enemy_def) + '\n' + "敵人選擇的特殊總數值為:" + Convert.ToString(enemy_spe));
            label6.Text = "敵人手牌數：" + Convert.ToString(enemycard.Count());
            if (turn == true)
            {
                damage += -enemy_def;
                textBox1.Text += "敵人防禦的總數值為:" + Convert.ToString(enemy_def) + '\r' + '\n';
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            else
            {
                damage += enemy_att;
                textBox1.Text += "敵人攻擊的總數值為：" + Convert.ToString(enemy_att) + '\r' + '\n';
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            enemy_att = 0;
            enemy_def = 0;
            enemy_spe = 0;
        }
        public void enemymode4_hard()
        {
            //不拿特殊牌， 攻擊出攻擊，防禦出防禦，額外回血
            int num_att = 0, num_def = 0;
            foreach (string card in enemycard)
            {
                if (card.Split(',')[0] == "1")
                    num_att += 1;
                else if (card.Split(',')[0] == "2")
                    num_def += 1;
            }
            if (turn == false)
            {
                //敵人的攻擊回合+回1~2血
                int num = ran.Next(num_att);
                for (int i = 0; i < num; i++)
                {
                    int cardindex = ran.Next(0, enemycard.Count() - 1);
                    string card = enemycard[cardindex];
                    if (card.Split(',')[0] == "1")
                    {
                        enemy_att += int.Parse(card.Split(',')[1]);
                    }
                    else if (card.Split(',')[0] == "2")
                    {
                        i--;
                        continue;
                    }
                    enemycard.Remove(card);
                }
            }
            else
            {
                //敵人的防禦回合
                int num = ran.Next(num_def);
                for (int i = 0; i < num; i++)
                {
                    int cardindex = ran.Next(0, enemycard.Count() - 1);
                    string card = enemycard[cardindex];
                    if (card.Split(',')[0] == "1")
                    {
                        i--;
                        continue;
                    }
                    else if (card.Split(',')[0] == "2")
                    {

                        enemy_def += int.Parse(card.Split(',')[1]);
                    }
                    enemycard.Remove(card);
                }
            }
            newturn_enemy();
            label6.Text = "敵人手牌數：" + Convert.ToString(enemycard.Count());
            if (turn == false)
            {
                int recover = ran.Next(1, 2);
                try
                {
                    progressBarEnemy.Value += recover;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    progressBarEnemy.Value = HPenemy;
                }
                //MessageBox.Show("敵人發動了回血術!!");
                label8.Text = "敵人的血量: " + progressBarEnemy.Value + "/" + Convert.ToString(HPenemy);
            }

            if (turn == true)
            {
                damage += -enemy_def;
                textBox1.Text += "敵人防禦的總數值為:" + Convert.ToString(enemy_def) + '\r' + '\n';
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            else
            {
                damage += enemy_att;
                textBox1.Text += "敵人攻擊的總數值為：" + Convert.ToString(enemy_att) + '\r' + '\n';
                textBox1.Text += "敵人發動了回血術!!" + '\r' + '\n';
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            enemy_att = 0;
            enemy_def = 0;
            enemy_spe = 0;
        }
        public void record(int userHP,int enenmyHP)
        {
            string ID = userdata.Split('\t')[0], password = userdata.Split('\t')[1];
            FileStream file = File.Open("../../../data.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            //原來的帳密檔
            FileStream tempfile = File.Open("../../../temp.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            //暫存的帳密檔
            StreamReader sr = new StreamReader(file);
            StreamWriter sw = new StreamWriter(tempfile);
            string line = sr.ReadLine();
            while (line != null)
            {
                if (line.Split('\t')[0] == ID && line.Split('\t')[1] == password)
                {
                    if (level == "simple")
                    {
                        if(userHP == 0)
                        {
                            sw.WriteLine(ID + '\t' + password +'\t'+username+'\t' + role + '\t' + "none");
                        }
                        else if (enenmyHP == 0)
                        {
                            sw.WriteLine(ID + '\t' + password + '\t' + username + '\t' + role + '\t' + "simple");
                        }
                    }
                    else if (level == "normal")
                    {

                        if (userHP == 0)
                        {
                            sw.WriteLine(ID + '\t' + password + '\t' + username + '\t' + role + '\t' + "simple");
                        }
                        else if (enenmyHP == 0)
                        {
                            sw.WriteLine(ID + '\t' + password + '\t' + username + '\t' + role + '\t' + "normal");
                        }
                    }
                    else if (level == "hard")
                    {

                        if (userHP == 0)
                        {
                            sw.WriteLine(ID + '\t' + password + '\t' + username + '\t' + role + '\t' + "normal");
                        }
                        else if (enenmyHP == 0)
                        {
                            sw.WriteLine(ID + '\t' + password + '\t' + username + '\t' + role + '\t' + "hard");
                        }
                    }
                }
                else
                {
                    sw.WriteLine(line);
                }
                line = sr.ReadLine();     
            }
            sr.Close();
            sw.Close();
            file.Close();
            tempfile.Close();
            File.Delete("../../../data.txt");
            File.Move("../../../temp.txt", "../../../data.txt");

        }
        public void fight()
        {
            int hit = 0;
            if (turn == true)
            {
                if (damage > 0)
                {
                    for (int i = 0; i < damage; i++)
                    {
                        //設定1/3的機率
                        int dice = ran.Next(1, 3);
                        if (dice == 1)
                        {
                            hit++;
                        }
                    }
                    //MessageBox.Show("您對敵人產生了" + Convert.ToString(hit) + "點傷害");
                    textBox1.Text += "您對敵人產生了" + Convert.ToString(hit) + "點傷害" + '\r' + '\n';
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.ScrollToCaret();
                    try
                    {
                        progressBarEnemy.Value += progressBarEnemy.Step * hit;
                        label7.Text = "自己的血量: " + progressBarUser.Value + "/" + Convert.ToString(HPuser);
                        label8.Text = "敵人的血量: " + progressBarEnemy.Value + "/" + Convert.ToString(HPenemy);
                        if (progressBarEnemy.Value == 0)
                        {
                            label7.Text = "自己的血量: " + progressBarUser.Value + "/" + Convert.ToString(HPuser);
                            label8.Text = "敵人的血量: " + progressBarEnemy.Value + "/" + Convert.ToString(HPenemy);
                            DialogResult result = MessageBox.Show("You Win.");
                            if (result == DialogResult.OK)
                            {
                                player.Stop();
                                player1.PlayLooping();
                                level_form = new Level();
                                level_form.userdata = userdata;
                                level_form.role = role;
                                level_form.username = username;
                                level_form.level = level+" 完成";
                                level_form.Show();
                                level_form.TopMost = true;
                                record(progressBarUser.Value, progressBarEnemy.Value);
                                this.Dispose();
                            }

                        }
                    }
                    catch (ArgumentException e)
                    {
                        progressBarEnemy.Value = 0;
                        label7.Text = "自己的血量: " + progressBarUser.Value + "/" + Convert.ToString(HPuser);
                        label8.Text = "敵人的血量: " + progressBarEnemy.Value + "/" + Convert.ToString(HPenemy);
                        DialogResult result = MessageBox.Show("You Win.");
                        if (result == DialogResult.OK)
                        {
                            player.Stop();
                            player1.PlayLooping();
                            level_form = new Level();
                            level_form.userdata = userdata;
                            level_form.role = role;
                            level_form.username = username;
                            level_form.level = level + " 完成";
                            level_form.Show();
                            level_form.TopMost = true;
                            record(progressBarUser.Value, progressBarEnemy.Value);
                            this.Dispose();
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("敵人毫髮無傷");
                    textBox1.Text += "敵人毫髮無傷" + '\r' + '\n';
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.ScrollToCaret();
                }
            }
            else
            {
                if (damage > 0)
                {
                    for (int i = 0; i < damage; i++)
                    {
                        //設定1/3的機率
                        int dice = ran.Next(1, 3);
                        if (dice == 1)
                        {
                            hit++;
                        }
                    }
                    //MessageBox.Show("敵人對您產生了" + Convert.ToString(hit) + "點傷害");
                    textBox1.Text += "敵人對您產生了" + Convert.ToString(hit) + "點傷害" + '\r' + '\n';
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.ScrollToCaret();
                    try
                    {
                        progressBarUser.Value += progressBarUser.Step * hit;
                        label7.Text = "自己的血量: " + progressBarUser.Value + "/" + Convert.ToString(HPuser);
                        label8.Text = "敵人的血量: " + progressBarEnemy.Value + "/" + Convert.ToString(HPenemy);
                        if (progressBarUser.Value == 0)
                        {
                            label7.Text = "自己的血量: " + progressBarUser.Value + "/" + Convert.ToString(HPuser);
                            label8.Text = "敵人的血量: " + progressBarEnemy.Value + "/" + Convert.ToString(HPenemy);
                            DialogResult result = MessageBox.Show("You Lose.");
                            if (result == DialogResult.OK)
                            {
                                player.Stop();
                                player1.PlayLooping();
                                level_form = new Level();
                                level_form.userdata = userdata;
                                level_form.role = role;
                                level_form.username = username;
                                level_form.level = level + " 失敗"; ;
                                level_form.Show();
                                level_form.TopMost = true;
                                record(progressBarUser.Value, progressBarEnemy.Value);
                                this.Dispose();
                            }
                        }
                    }
                    catch (ArgumentException e)
                    {
                        progressBarUser.Value = 0;
                        label7.Text = "自己的血量: " + progressBarUser.Value + "/" + Convert.ToString(HPuser);
                        label8.Text = "敵人的血量: " + progressBarEnemy.Value + "/" + Convert.ToString(HPenemy);
                        DialogResult result = MessageBox.Show("You Lose.");
                        if (result == DialogResult.OK)
                        {
                            player.Stop();
                            player1.PlayLooping();
                            level_form = new Level();
                            level_form.userdata = userdata;
                            level_form.role = role;
                            level_form.username = username;
                            level_form.level = level + " 失敗";
                            level_form.Show();
                            level_form.TopMost = true;
                            record(progressBarUser.Value, progressBarEnemy.Value);
                            this.Dispose();
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("您毫髮無傷");
                    textBox1.Text += "您毫髮無傷" + '\r' + '\n';
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.ScrollToCaret();
                }
            }
            hit = 0;
            damage = 0;
        }
    }
}
