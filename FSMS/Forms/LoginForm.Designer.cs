namespace FSMS
{
    partial class LoginForm
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.lblFSMS = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.pnlLogin = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.chkShowPassword = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSubtittle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(43)))));
            this.pnlLeft.Controls.Add(this.picLogin);
            this.pnlLeft.Controls.Add(this.lblDescription);
            this.pnlLeft.Controls.Add(this.lblSystemName);
            this.pnlLeft.Controls.Add(this.lblFSMS);
            this.pnlLeft.Controls.Add(this.picLogo);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(825, 1041);
            this.pnlLeft.TabIndex = 0;
            // 
            // picLogin
            // 
            this.picLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.picLogin.BackColor = System.Drawing.Color.Transparent;
            this.picLogin.Image = global::FSMS.Properties.Resources.big;
            this.picLogin.Location = new System.Drawing.Point(195, 626);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(352, 273);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogin.TabIndex = 4;
            this.picLogin.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.lblDescription.Location = new System.Drawing.Point(96, 461);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(422, 80);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Connecting Surplus Food With People In Need";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSystemName
            // 
            this.lblSystemName.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSystemName.Location = new System.Drawing.Point(77, 266);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(653, 218);
            this.lblSystemName.TabIndex = 2;
            this.lblSystemName.Text = "Food Surplus Management System";
            this.lblSystemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFSMS
            // 
            this.lblFSMS.AutoSize = true;
            this.lblFSMS.Font = new System.Drawing.Font("Segoe UI", 69.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFSMS.ForeColor = System.Drawing.Color.White;
            this.lblFSMS.Location = new System.Drawing.Point(255, 124);
            this.lblFSMS.Name = "lblFSMS";
            this.lblFSMS.Size = new System.Drawing.Size(292, 124);
            this.lblFSMS.TabIndex = 1;
            this.lblFSMS.Text = "FSMS";
            this.lblFSMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::FSMS.Properties.Resources.FSMSlogo;
            this.picLogo.Location = new System.Drawing.Point(89, 103);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(150, 150);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogin.Controls.Add(this.chkShowPassword);
            this.pnlLogin.Controls.Add(this.lblError);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Controls.Add(this.lblSubtittle);
            this.pnlLogin.Controls.Add(this.lblWelcome);
            this.pnlLogin.FillColor = System.Drawing.Color.White;
            this.pnlLogin.Location = new System.Drawing.Point(1104, 266);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Radius = 30;
            this.pnlLogin.ShadowColor = System.Drawing.Color.Khaki;
            this.pnlLogin.ShadowDepth = 150;
            this.pnlLogin.ShadowShift = 10;
            this.pnlLogin.Size = new System.Drawing.Size(562, 573);
            this.pnlLogin.TabIndex = 2;
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.Animated = true;
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.chkShowPassword.CheckedState.BorderRadius = 0;
            this.chkShowPassword.CheckedState.BorderThickness = 0;
            this.chkShowPassword.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.chkShowPassword.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.chkShowPassword.Location = new System.Drawing.Point(70, 387);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(118, 21);
            this.chkShowPassword.TabIndex = 20;
            this.chkShowPassword.Text = "show password";
            this.chkShowPassword.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.chkShowPassword.UncheckedState.BorderRadius = 0;
            this.chkShowPassword.UncheckedState.BorderThickness = 2;
            this.chkShowPassword.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.showPassword_CheckedChanged);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(57, 426);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(445, 35);
            this.lblError.TabIndex = 19;
            this.lblError.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtPassword.Location = new System.Drawing.Point(61, 323);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPassword.PlaceholderText = "Enter  Password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtPassword.ShadowDecoration.Depth = 50;
            this.txtPassword.Size = new System.Drawing.Size(450, 45);
            this.txtPassword.TabIndex = 18;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 10;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.ForeColor = System.Drawing.Color.Gray;
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtUsername.Location = new System.Drawing.Point(61, 218);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtUsername.PlaceholderText = "Enter Username";
            this.txtUsername.SelectedText = "";
            this.txtUsername.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtUsername.ShadowDecoration.Depth = 50;
            this.txtUsername.Size = new System.Drawing.Size(450, 45);
            this.txtUsername.TabIndex = 17;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderColor = System.Drawing.Color.Empty;
            this.btnLogin.BorderRadius = 13;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.btnLogin.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(61, 476);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.btnLogin.Size = new System.Drawing.Size(450, 65);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(52, 293);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 20);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(52, 184);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(78, 20);
            this.lblUsername.TabIndex = 15;
            this.lblUsername.Text = "Username";
            // 
            // lblSubtittle
            // 
            this.lblSubtittle.AutoSize = true;
            this.lblSubtittle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtittle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.lblSubtittle.Location = new System.Drawing.Point(121, 107);
            this.lblSubtittle.Name = "lblSubtittle";
            this.lblSubtittle.Size = new System.Drawing.Size(354, 28);
            this.lblSubtittle.TabIndex = 13;
            this.lblSubtittle.Text = "Enter your credentials to access FSMS";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Black", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.lblWelcome.Location = new System.Drawing.Point(182, 42);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(232, 54);
            this.lblWelcome.TabIndex = 12;
            this.lblWelcome.Text = "User Login";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "loginForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblFSMS;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox picLogin;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlLogin;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblSubtittle;
        private System.Windows.Forms.Label lblWelcome;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lblError;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowPassword;
    }
}

