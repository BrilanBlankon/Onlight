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
    public partial class RANK : Form
    {
        public string userdata;
        public RANK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setting set = new Setting();
            set.userdata = userdata;
            set.Show();
            this.Dispose();
        }

        private void RANK_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public List<string> sort(List<string> data)
        {
            List<string> sorted_data = new List<string>();
            string temp_level="";
            for(int i = data.Count-1; i>= 0  ;i--)
            {
                if(i%2 != 0)
                {
                    if (data[i] == "hard")
                    {
                        temp_level = data[i];
                    }                
                }
                else
                {
                    if (temp_level == "hard")
                    {
                        sorted_data.Add(data[i]);
                        sorted_data.Add(temp_level);
                        temp_level = "";
                    }                                       
                }
            }
            for (int i = data.Count-1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    if (data[i] == "normal")
                    {
                        temp_level = data[i];
                    }
                }
                else
                {
                    if (temp_level == "normal")
                    {
                        sorted_data.Add(data[i]);
                        sorted_data.Add(temp_level);
                        temp_level = "";
                    }
                }
            }
            for (int i = data.Count-1; i >=0; i--)
            {
                if (i % 2 != 0)
                {
                    if (data[i] == "simple")
                    {
                        temp_level = data[i];
                    }
                }
                else
                {
                    if (temp_level == "simple")
                    {
                        sorted_data.Add(data[i]);
                        sorted_data.Add(temp_level);
                        temp_level = "";
                    }
                }
            }
            for (int i = data.Count - 1; i >=0; i--)
            {
                if (i % 2 != 0)
                {
                    if (data[i] == "none")
                    {
                        temp_level = data[i];
                    }
                }
                else
                {
                    if (temp_level == "none")
                    {
                        sorted_data.Add(data[i]);
                        sorted_data.Add(temp_level);
                        temp_level = "";
                    }
                }
            }
            return sorted_data;
        }
        private void RANK_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                FileStream myfile = File.Open("../../../data.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(myfile);
                string line = sr.ReadLine();
                string name, rank;
                List<string> data = new List<string>();
                line = sr.ReadLine();
                while(line != null)
                {
                    name = line.Split('\t')[2];
                    rank = line.Split('\t')[4];

                    if(name == "" || rank == "")
                    {
                        line = sr.ReadLine();
                        continue;
                    }
                    else
                    {
                        data.Add(name);
                        data.Add(rank);
                        line = sr.ReadLine();
                    }                    
                    
                }
                data = sort(data);
                bool nextline = false;
                foreach (string pair in data)
                {
                    if (nextline == false)
                    {
                        textBox1.Text += pair + '\t';
                        nextline = true;
                    }
                    else if (nextline == true)
                    {
                        textBox1.Text += pair + '\r'+'\n';
                        nextline = false;
                    }
                             
                }
                myfile.Close();
                sr.Close();
                
            
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("bug?");
            }

        }

    }
}
