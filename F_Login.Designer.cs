namespace PWMS
{
    partial class F_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butClose = new DevComponents.DotNetBar.ButtonX();
            this.butLogin = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textName = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "f";
            // 
            // butClose
            // 
            this.butClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.butClose.Location = new System.Drawing.Point(140, 160);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.butClose.TabIndex = 12;
            this.butClose.Text = "取消";
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butLogin
            // 
            this.butLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.butLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.butLogin.Location = new System.Drawing.Point(21, 160);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(75, 23);
            this.butLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.butLogin.TabIndex = 11;
            this.butLogin.Text = "登录";
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(21, 116);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 10;
            this.labelX2.Text = "密码";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(21, 81);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "用户名";
            // 
            // textPass
            // 
            this.textPass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textPass.Border.Class = "TextBoxBorder";
            this.textPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textPass.DisabledBackColor = System.Drawing.Color.White;
            this.textPass.ForeColor = System.Drawing.Color.Black;
            this.textPass.Location = new System.Drawing.Point(115, 120);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.PreventEnterBeep = true;
            this.textPass.Size = new System.Drawing.Size(100, 21);
            this.textPass.TabIndex = 8;
            this.textPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPass_KeyPress);
            // 
            // textName
            // 
            this.textName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textName.Border.Class = "TextBoxBorder";
            this.textName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textName.DisabledBackColor = System.Drawing.Color.White;
            this.textName.ForeColor = System.Drawing.Color.Black;
            this.textName.Location = new System.Drawing.Point(115, 81);
            this.textName.Name = "textName";
            this.textName.PreventEnterBeep = true;
            this.textName.Size = new System.Drawing.Size(100, 21);
            this.textName.TabIndex = 7;
            this.textName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textName_KeyPress);
            // 
            // F_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 195);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butLogin);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "F_Login";
            this.Text = "F_Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX butClose;
        private DevComponents.DotNetBar.ButtonX butLogin;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textPass;
        private DevComponents.DotNetBar.Controls.TextBoxX textName;

    }
}