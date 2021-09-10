namespace WindowsFormsApplication1
{
    partial class Pick
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pick));
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            this.SuspendLayout();
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(85, 100);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(250, 350);
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            this.pic1.MouseEnter += new System.EventHandler(this.pic1_MouseEnter);
            this.pic1.MouseLeave += new System.EventHandler(this.pic1_MouseLeave);
            // 
            // pic2
            // 
            this.pic2.Location = new System.Drawing.Point(355, 100);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(250, 350);
            this.pic2.TabIndex = 1;
            this.pic2.TabStop = false;
            this.pic2.MouseEnter += new System.EventHandler(this.pic2_MouseEnter);
            this.pic2.MouseLeave += new System.EventHandler(this.pic2_MouseLeave);
            // 
            // pic3
            // 
            this.pic3.Location = new System.Drawing.Point(625, 100);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(250, 350);
            this.pic3.TabIndex = 2;
            this.pic3.TabStop = false;
            this.pic3.MouseEnter += new System.EventHandler(this.pic3_MouseEnter);
            this.pic3.MouseLeave += new System.EventHandler(this.pic3_MouseLeave);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btn3.Location = new System.Drawing.Point(700, 475);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(100, 40);
            this.btn3.TabIndex = 5;
            this.btn3.Text = "選擇";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btn1.Location = new System.Drawing.Point(160, 475);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(100, 40);
            this.btn1.TabIndex = 6;
            this.btn1.Text = "選擇";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btn2.Location = new System.Drawing.Point(430, 475);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(100, 40);
            this.btn2.TabIndex = 7;
            this.btn2.Text = "選擇";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F);
            this.label1.Location = new System.Drawing.Point(155, 600);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "你的名字";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft JhengHei", 15F);
            this.textBox1.Location = new System.Drawing.Point(260, 592);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(304, 34);
            this.textBox1.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.button4.Location = new System.Drawing.Point(625, 592);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 34);
            this.button4.TabIndex = 10;
            this.button4.Text = "確認";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "011.png");
            this.imageList1.Images.SetKeyName(1, "012.png");
            this.imageList1.Images.SetKeyName(2, "021.png");
            this.imageList1.Images.SetKeyName(3, "022.png");
            this.imageList1.Images.SetKeyName(4, "031.png");
            this.imageList1.Images.SetKeyName(5, "032.png");
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(819, 676);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "返回主畫面";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 721);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.pic3);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Name = "Pick";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色選擇";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pick_FormClosed);
            this.Load += new System.EventHandler(this.Pick_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
    }
}