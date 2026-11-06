namespace FSMS.Forms
{
    partial class RequestForm
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
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDonation = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFoodType = new Guna.UI2.WinForms.Guna2TextBox();
            this.Quantity = new System.Windows.Forms.Label();
            this.RestName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVolunteer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtAssignedDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRestaurant = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(684, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(33, 55);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(210, 17);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Assign a donation to a volunteer.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Assign Donation";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.guna2Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.guna2Panel1.Location = new System.Drawing.Point(20, 81);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(640, 1);
            this.guna2Panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Donation Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label2.Location = new System.Drawing.Point(30, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Donation";
            // 
            // cmbDonation
            // 
            this.cmbDonation.BackColor = System.Drawing.Color.Transparent;
            this.cmbDonation.BorderRadius = 8;
            this.cmbDonation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDonation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDonation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDonation.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbDonation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbDonation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDonation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbDonation.ItemHeight = 30;
            this.cmbDonation.Location = new System.Drawing.Point(30, 178);
            this.cmbDonation.Name = "cmbDonation";
            this.cmbDonation.Size = new System.Drawing.Size(300, 36);
            this.cmbDonation.TabIndex = 4;
            this.cmbDonation.SelectedIndexChanged += new System.EventHandler(this.cmbDonation_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label3.Location = new System.Drawing.Point(30, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Food Type";
            // 
            // txtFoodType
            // 
            this.txtFoodType.Animated = true;
            this.txtFoodType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtFoodType.BorderRadius = 10;
            this.txtFoodType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFoodType.DefaultText = "";
            this.txtFoodType.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFoodType.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFoodType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFoodType.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFoodType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtFoodType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoodType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.txtFoodType.Location = new System.Drawing.Point(30, 263);
            this.txtFoodType.Name = "txtFoodType";
            this.txtFoodType.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFoodType.PlaceholderText = "";
            this.txtFoodType.ReadOnly = true;
            this.txtFoodType.SelectedText = "";
            this.txtFoodType.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtFoodType.ShadowDecoration.Depth = 100;
            this.txtFoodType.Size = new System.Drawing.Size(300, 40);
            this.txtFoodType.TabIndex = 38;
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.Quantity.Location = new System.Drawing.Point(30, 320);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(62, 17);
            this.Quantity.TabIndex = 40;
            this.Quantity.Text = "Quantity";
            // 
            // RestName
            // 
            this.RestName.AutoSize = true;
            this.RestName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.RestName.Location = new System.Drawing.Point(30, 405);
            this.RestName.Name = "RestName";
            this.RestName.Size = new System.Drawing.Size(74, 17);
            this.RestName.TabIndex = 42;
            this.RestName.Text = "Restaurant";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(380, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 25);
            this.label4.TabIndex = 44;
            this.label4.Text = "Assignment Information";
            // 
            // cmbVolunteer
            // 
            this.cmbVolunteer.BackColor = System.Drawing.Color.Transparent;
            this.cmbVolunteer.BorderRadius = 10;
            this.cmbVolunteer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbVolunteer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVolunteer.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbVolunteer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbVolunteer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVolunteer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbVolunteer.ItemHeight = 30;
            this.cmbVolunteer.Location = new System.Drawing.Point(360, 181);
            this.cmbVolunteer.Name = "cmbVolunteer";
            this.cmbVolunteer.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.cmbVolunteer.ShadowDecoration.Depth = 100;
            this.cmbVolunteer.Size = new System.Drawing.Size(300, 36);
            this.cmbVolunteer.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label5.Location = new System.Drawing.Point(359, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "Volunteer";
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
            "Pending",
            "",
            "",
            "Approved",
            "",
            "",
            "Completed"});
            this.cmbStatus.Location = new System.Drawing.Point(360, 284);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.cmbStatus.ShadowDecoration.Depth = 100;
            this.cmbStatus.Size = new System.Drawing.Size(300, 36);
            this.cmbStatus.StartIndex = 0;
            this.cmbStatus.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label6.Location = new System.Drawing.Point(357, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 47;
            this.label6.Text = "Status ";
            // 
            // dtAssignedDate
            // 
            this.dtAssignedDate.BorderRadius = 10;
            this.dtAssignedDate.Checked = true;
            this.dtAssignedDate.CustomFormat = "dd/MM/yyyy";
            this.dtAssignedDate.FillColor = System.Drawing.Color.White;
            this.dtAssignedDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAssignedDate.ForeColor = System.Drawing.Color.Black;
            this.dtAssignedDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtAssignedDate.Location = new System.Drawing.Point(354, 392);
            this.dtAssignedDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtAssignedDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtAssignedDate.Name = "dtAssignedDate";
            this.dtAssignedDate.Size = new System.Drawing.Size(300, 40);
            this.dtAssignedDate.TabIndex = 50;
            this.dtAssignedDate.Value = new System.DateTime(2026, 7, 30, 1, 30, 23, 158);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label7.Location = new System.Drawing.Point(357, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "Assigned Date";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Animated = true;
            this.txtQuantity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtQuantity.BorderRadius = 10;
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.DefaultText = "";
            this.txtQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.txtQuantity.Location = new System.Drawing.Point(30, 350);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQuantity.PlaceholderText = "";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtQuantity.ShadowDecoration.Depth = 100;
            this.txtQuantity.Size = new System.Drawing.Size(300, 40);
            this.txtQuantity.TabIndex = 51;
            // 
            // txtRestaurant
            // 
            this.txtRestaurant.Animated = true;
            this.txtRestaurant.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtRestaurant.BorderRadius = 10;
            this.txtRestaurant.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRestaurant.DefaultText = "";
            this.txtRestaurant.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRestaurant.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRestaurant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRestaurant.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRestaurant.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtRestaurant.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestaurant.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.txtRestaurant.Location = new System.Drawing.Point(30, 431);
            this.txtRestaurant.Name = "txtRestaurant";
            this.txtRestaurant.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRestaurant.PlaceholderText = "";
            this.txtRestaurant.ReadOnly = true;
            this.txtRestaurant.SelectedText = "";
            this.txtRestaurant.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtRestaurant.ShadowDecoration.Depth = 100;
            this.txtRestaurant.Size = new System.Drawing.Size(300, 40);
            this.txtRestaurant.TabIndex = 52;
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
            this.btnSave.Location = new System.Drawing.Point(132, 531);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Color = System.Drawing.Color.Khaki;
            this.btnSave.ShadowDecoration.Depth = 50;
            this.btnSave.Size = new System.Drawing.Size(140, 45);
            this.btnSave.TabIndex = 54;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(361, 531);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Color = System.Drawing.Color.Khaki;
            this.btnCancel.ShadowDecoration.Depth = 50;
            this.btnCancel.Size = new System.Drawing.Size(140, 45);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 581);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtRestaurant);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.dtAssignedDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbVolunteer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RestName);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.txtFoodType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDonation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.pnlHeader);
            this.Name = "RequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RequestForm";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDonation;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtFoodType;
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.Label RestName;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cmbVolunteer;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtAssignedDate;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantity;
        private Guna.UI2.WinForms.Guna2TextBox txtRestaurant;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}