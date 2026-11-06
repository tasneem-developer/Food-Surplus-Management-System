namespace FSMS.Forms
{
    partial class AddRestaurantForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.Desc = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.RestName = new System.Windows.Forms.Label();
            this.txtRestaurantName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContactPerson = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkShowPassword = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsername = new System.Windows.Forms.Label();
            this.lblAccountInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmdAddress = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ShadowPanel1.SuspendLayout();
            this.guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(281, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Restaurant";
            // 
            // Desc
            // 
            this.Desc.AutoSize = true;
            this.Desc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.Desc.Location = new System.Drawing.Point(30, 50);
            this.Desc.Name = "Desc";
            this.Desc.Size = new System.Drawing.Size(247, 17);
            this.Desc.TabIndex = 1;
            this.Desc.Text = "Fill in the restaurant information below.";
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlLine.Location = new System.Drawing.Point(30, 100);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(640, 1);
            this.pnlLine.TabIndex = 2;
            // 
            // RestName
            // 
            this.RestName.AutoSize = true;
            this.RestName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.RestName.Location = new System.Drawing.Point(30, 125);
            this.RestName.Name = "RestName";
            this.RestName.Size = new System.Drawing.Size(118, 17);
            this.RestName.TabIndex = 3;
            this.RestName.Text = "Restaurant Name ";
            // 
            // txtRestaurantName
            // 
            this.txtRestaurantName.Animated = true;
            this.txtRestaurantName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtRestaurantName.BorderRadius = 10;
            this.txtRestaurantName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRestaurantName.DefaultText = "";
            this.txtRestaurantName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRestaurantName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRestaurantName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRestaurantName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRestaurantName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtRestaurantName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRestaurantName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.txtRestaurantName.Location = new System.Drawing.Point(30, 150);
            this.txtRestaurantName.Name = "txtRestaurantName";
            this.txtRestaurantName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRestaurantName.PlaceholderText = "Enter restaurant name";
            this.txtRestaurantName.SelectedText = "";
            this.txtRestaurantName.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtRestaurantName.ShadowDecoration.Depth = 100;
            this.txtRestaurantName.Size = new System.Drawing.Size(300, 45);
            this.txtRestaurantName.TabIndex = 4;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblPhone.Location = new System.Drawing.Point(380, 125);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(105, 17);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Phone Number ";
            // 
            // txtPhone
            // 
            this.txtPhone.Animated = true;
            this.txtPhone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtPhone.BorderRadius = 10;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.txtPhone.Location = new System.Drawing.Point(378, 153);
            this.txtPhone.MaxLength = 9;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPhone.PlaceholderText = "77XXXXXXX";
            this.txtPhone.SelectedText = "";
            this.txtPhone.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtPhone.ShadowDecoration.Depth = 100;
            this.txtPhone.Size = new System.Drawing.Size(300, 45);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label1.Location = new System.Drawing.Point(30, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Contact Person ";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Animated = true;
            this.txtContactPerson.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtContactPerson.BorderRadius = 10;
            this.txtContactPerson.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContactPerson.DefaultText = "";
            this.txtContactPerson.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContactPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContactPerson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactPerson.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContactPerson.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtContactPerson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContactPerson.ForeColor = System.Drawing.Color.DimGray;
            this.txtContactPerson.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.txtContactPerson.Location = new System.Drawing.Point(30, 245);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContactPerson.PlaceholderText = "Enter your name";
            this.txtContactPerson.SelectedText = "";
            this.txtContactPerson.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtContactPerson.ShadowDecoration.Depth = 100;
            this.txtContactPerson.Size = new System.Drawing.Size(300, 45);
            this.txtContactPerson.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label2.Location = new System.Drawing.Point(380, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Status ";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderRadius = 10;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbStatus.ItemHeight = 30;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(380, 245);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.cmbStatus.ShadowDecoration.Depth = 100;
            this.cmbStatus.Size = new System.Drawing.Size(300, 36);
            this.cmbStatus.StartIndex = 0;
            this.cmbStatus.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label3.Location = new System.Drawing.Point(30, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Address ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label4.Location = new System.Drawing.Point(34, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Animated = true;
            this.txtNotes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtNotes.BorderRadius = 10;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.ForeColor = System.Drawing.Color.DimGray;
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.txtNotes.Location = new System.Drawing.Point(30, 460);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNotes.PlaceholderText = "Optional notes..";
            this.txtNotes.SelectedText = "";
            this.txtNotes.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtNotes.ShadowDecoration.Depth = 100;
            this.txtNotes.Size = new System.Drawing.Size(650, 60);
            this.txtNotes.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BorderColor = System.Drawing.Color.White;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(396, 862);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Color = System.Drawing.Color.Khaki;
            this.btnCancel.ShadowDecoration.Depth = 50;
            this.btnCancel.Size = new System.Drawing.Size(140, 45);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BorderColor = System.Drawing.Color.White;
            this.btnSave.BorderRadius = 10;
            this.btnSave.BorderThickness = 2;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(134, 862);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Color = System.Drawing.Color.Khaki;
            this.btnSave.ShadowDecoration.Depth = 50;
            this.btnSave.Size = new System.Drawing.Size(140, 45);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lblTitle);
            this.guna2ShadowPanel1.Controls.Add(this.Desc);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(30, 8);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 15;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Silver;
            this.guna2ShadowPanel1.ShadowDepth = 200;
            this.guna2ShadowPanel1.ShadowShift = 2;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(375, 81);
            this.guna2ShadowPanel1.TabIndex = 17;
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.label6);
            this.guna2ShadowPanel2.Controls.Add(this.label5);
            this.guna2ShadowPanel2.Controls.Add(this.chkShowPassword);
            this.guna2ShadowPanel2.Controls.Add(this.txtPassword);
            this.guna2ShadowPanel2.Controls.Add(this.lblPassword);
            this.guna2ShadowPanel2.Controls.Add(this.tUsername);
            this.guna2ShadowPanel2.Controls.Add(this.txtUsername);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(33, 613);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(637, 243);
            this.guna2ShadowPanel2.TabIndex = 18;
            this.guna2ShadowPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel2_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(93, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(93, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "*";
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
            this.chkShowPassword.Location = new System.Drawing.Point(30, 204);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(99, 17);
            this.chkShowPassword.TabIndex = 21;
            this.chkShowPassword.Text = "show password";
            this.chkShowPassword.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.chkShowPassword.UncheckedState.BorderRadius = 0;
            this.chkShowPassword.UncheckedState.BorderThickness = 2;
            this.chkShowPassword.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Animated = true;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.txtPassword.Location = new System.Drawing.Point(27, 133);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.PlaceholderText = "Enter password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtPassword.ShadowDecoration.Depth = 100;
            this.txtPassword.Size = new System.Drawing.Size(420, 43);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblPassword.Location = new System.Drawing.Point(27, 112);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(74, 17);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password  ";
            // 
            // tUsername
            // 
            this.tUsername.Animated = true;
            this.tUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.tUsername.BorderRadius = 10;
            this.tUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tUsername.DefaultText = "";
            this.tUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.tUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.tUsername.Location = new System.Drawing.Point(27, 47);
            this.tUsername.Margin = new System.Windows.Forms.Padding(0);
            this.tUsername.Name = "tUsername";
            this.tUsername.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tUsername.PlaceholderText = "Enter Username";
            this.tUsername.SelectedText = "";
            this.tUsername.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.tUsername.ShadowDecoration.Depth = 100;
            this.tUsername.Size = new System.Drawing.Size(420, 43);
            this.tUsername.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtUsername.Location = new System.Drawing.Point(26, 24);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(73, 17);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "Username ";
            // 
            // lblAccountInfo
            // 
            this.lblAccountInfo.AutoSize = true;
            this.lblAccountInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblAccountInfo.Location = new System.Drawing.Point(33, 579);
            this.lblAccountInfo.Name = "lblAccountInfo";
            this.lblAccountInfo.Size = new System.Drawing.Size(169, 21);
            this.lblAccountInfo.TabIndex = 19;
            this.lblAccountInfo.Text = "Account Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(143, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(473, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(126, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(423, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(85, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmdAddress
            // 
            this.cmdAddress.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddress.BorderRadius = 10;
            this.cmdAddress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmdAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdAddress.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmdAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmdAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdAddress.ItemHeight = 30;
            this.cmdAddress.Items.AddRange(new object[] {
            "Hadda",
            "Al Tahrir",
            "Shamlan",
            "Al Zubairi",
            "Al Sittin",
            "Madhbah",
            "Asr",
            "Bayt Baws",
            "alsnaina"});
            this.cmdAddress.Location = new System.Drawing.Point(27, 347);
            this.cmdAddress.Name = "cmdAddress";
            this.cmdAddress.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.cmdAddress.ShadowDecoration.Depth = 100;
            this.cmdAddress.Size = new System.Drawing.Size(300, 36);
            this.cmdAddress.StartIndex = 0;
            this.cmdAddress.TabIndex = 26;
            // 
            // AddRestaurantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(699, 481);
            this.Controls.Add(this.cmdAddress);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblAccountInfo);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtRestaurantName);
            this.Controls.Add(this.RestName);
            this.Controls.Add(this.pnlLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRestaurantForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label Desc;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label RestName;
        private Guna.UI2.WinForms.Guna2TextBox txtRestaurantName;
        private System.Windows.Forms.Label lblPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtContactPerson;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private System.Windows.Forms.Label lblAccountInfo;
        private System.Windows.Forms.Label txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox tUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2ComboBox cmdAddress;
    }
}