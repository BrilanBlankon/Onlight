namespace WindowsFormsApplication1
{
    partial class UserLogin
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
            this.IDtxt = new System.Windows.Forms.TextBox();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.signup = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IDtxt
            // 
            this.IDtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IDtxt.Font = new System.Drawing.Font("Microsoft JhengHei", 13F);
            this.IDtxt.Location = new System.Drawing.Point(199, 312);
            this.IDtxt.Multiline = true;
            this.IDtxt.Name = "IDtxt";
            this.IDtxt.Size = new System.Drawing.Size(367, 35);
            this.IDtxt.TabIndex = 2;
            // 
            // passwordtxt
            // 
            this.passwordtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.passwordtxt.Font = new System.Drawing.Font("Microsoft JhengHei", 13F);
            this.passwordtxt.Location = new System.Drawing.Point(199, 367);
            this.passwordtxt.Multiline = true;
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.PasswordChar = '*';
            this.passwordtxt.Size = new System.Drawing.Size(367, 37);
            this.passwordtxt.TabIndex = 3;
            // 
            // signup
            // 
            this.signup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.signup.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.signup.Location = new System.Drawing.Point(302, 422);
            this.signup.Name = "signup";
            this.signup.Size = new System.Drawing.Size(114, 33);
            this.signup.TabIndex = 4;
            this.signup.Text = "註冊";
            this.signup.UseVisualStyleBackColor = true;
            this.signup.Click += new System.EventHandler(this.signup_Click);
            // 
            // login
            // 
            this.login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.login.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.login.Location = new System.Drawing.Point(449, 422);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(117, 33);
            this.login.TabIndex = 5;
            this.login.Text = "登入";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F);
            this.label1.Location = new System.Drawing.Point(130, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "帳號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F);
            this.label2.Location = new System.Drawing.Point(130, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "密碼";
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(721, 534);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.signup);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.IDtxt);
            this.Name = "UserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登入/註冊";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserLogin_FormClosed);
            this.Load += new System.EventHandler(this.登入_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox IDtxt;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Button signup;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

