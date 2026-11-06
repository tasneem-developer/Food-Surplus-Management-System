namespace FSMS.Forms
{
    partial class DonationForm
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
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.cardDonation = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtExpiryTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDonationDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.Quantity = new System.Windows.Forms.Label();
            this.txtFoodType = new Guna.UI2.WinForms.Guna2TextBox();
            this.FoodType = new System.Windows.Forms.Label();
            this.cmbRestaurant = new Guna.UI2.WinForms.Guna2ComboBox();
            this.RestName = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.cardDonation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.lblTitle.Location = new System.Drawing.Point(22, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit Donation";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(40, 42);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(178, 17);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Update donation information";
            // 
            // cardDonation
            // 
            this.cardDonation.BackColor = System.Drawing.Color.Transparent;
            this.cardDonation.Controls.Add(this.label8);
            this.cardDonation.Controls.Add(this.label7);
            this.cardDonation.Controls.Add(this.label6);
            this.cardDonation.Controls.Add(this.label5);
            this.cardDonation.Controls.Add(this.label4);
            this.cardDonation.Controls.Add(this.label10);
            this.cardDonation.Controls.Add(this.dtExpiryTime);
            this.cardDonation.Controls.Add(this.label3);
            this.cardDonation.Controls.Add(this.dtDonationDate);
            this.cardDonation.Controls.Add(this.label1);
            this.cardDonation.Controls.Add(this.cmbStatus);
            this.cardDonation.Controls.Add(this.label2);
            this.cardDonation.Controls.Add(this.numQuantity);
            this.cardDonation.Controls.Add(this.Quantity);
            this.cardDonation.Controls.Add(this.txtFoodType);
            this.cardDonation.Controls.Add(this.FoodType);
            this.cardDonation.Controls.Add(this.cmbRestaurant);
            this.cardDonation.Controls.Add(this.RestName);
            this.cardDonation.FillColor = System.Drawing.Color.WhiteSmoke;
            this.cardDonation.Location = new System.Drawing.Point(12, 95);
            this.cardDonation.Name = "cardDonation";
            this.cardDonation.Radius = 15;
            this.cardDonation.ShadowColor = System.Drawing.Color.Silver;
            this.cardDonation.ShadowDepth = 30;
            this.cardDonation.Size = new System.Drawing.Size(753, 420);
            this.cardDonation.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(479, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 17);
            this.label8.TabIndex = 53;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(136, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 17);
            this.label7.TabIndex = 52;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(431, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 51;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(104, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 17);
            this.label5.TabIndex = 50;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(468, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 17);
            this.label4.TabIndex = 49;
            this.label4.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(136, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 17);
            this.label10.TabIndex = 48;
            this.label10.Text = "*";
            // 
            // dtExpiryTime
            // 
            this.dtExpiryTime.BorderRadius = 10;
            this.dtExpiryTime.Checked = true;
            this.dtExpiryTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtExpiryTime.FillColor = System.Drawing.Color.White;
            this.dtExpiryTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExpiryTime.ForeColor = System.Drawing.Color.Black;
            this.dtExpiryTime.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtExpiryTime.Location = new System.Drawing.Point(390, 300);
            this.dtExpiryTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtExpiryTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtExpiryTime.Name = "dtExpiryTime";
            this.dtExpiryTime.Size = new System.Drawing.Size(300, 40);
            this.dtExpiryTime.TabIndex = 45;
            this.dtExpiryTime.Value = new System.DateTime(2026, 8, 7, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label3.Location = new System.Drawing.Point(400, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Expiry Time";
            // 
            // dtDonationDate
            // 
            this.dtDonationDate.BorderRadius = 10;
            this.dtDonationDate.Checked = true;
            this.dtDonationDate.CustomFormat = "dd/MM/yyyy";
            this.dtDonationDate.FillColor = System.Drawing.Color.White;
            this.dtDonationDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDonationDate.ForeColor = System.Drawing.Color.Black;
            this.dtDonationDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtDonationDate.Location = new System.Drawing.Point(35, 300);
            this.dtDonationDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDonationDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDonationDate.Name = "dtDonationDate";
            this.dtDonationDate.Size = new System.Drawing.Size(300, 40);
            this.dtDonationDate.TabIndex = 43;
            this.dtDonationDate.Value = new System.DateTime(2026, 8, 7, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label1.Location = new System.Drawing.Point(38, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Donation Date";
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
            "Available",
            "Completed",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(390, 195);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.cmbStatus.ShadowDecoration.Depth = 100;
            this.cmbStatus.Size = new System.Drawing.Size(300, 36);
            this.cmbStatus.StartIndex = 0;
            this.cmbStatus.TabIndex = 41;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.label2.Location = new System.Drawing.Point(387, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Status ";
            // 
            // numQuantity
            // 
            this.numQuantity.BackColor = System.Drawing.Color.Transparent;
            this.numQuantity.BorderRadius = 10;
            this.numQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numQuantity.Location = new System.Drawing.Point(35, 190);
            this.numQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.ShadowDecoration.BorderRadius = 10;
            this.numQuantity.Size = new System.Drawing.Size(300, 40);
            this.numQuantity.TabIndex = 39;
            this.numQuantity.UpDownButtonFillColor = System.Drawing.Color.Teal;
            this.numQuantity.UpDownButtonForeColor = System.Drawing.Color.White;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.Quantity.Location = new System.Drawing.Point(45, 170);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(62, 17);
            this.Quantity.TabIndex = 38;
            this.Quantity.Text = "Quantity";
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
            this.txtFoodType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFoodType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(166)))), ((int)(((byte)(154)))));
            this.txtFoodType.Location = new System.Drawing.Point(390, 93);
            this.txtFoodType.Name = "txtFoodType";
            this.txtFoodType.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFoodType.PlaceholderText = "Enter  food type....";
            this.txtFoodType.SelectedText = "";
            this.txtFoodType.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.txtFoodType.ShadowDecoration.Depth = 100;
            this.txtFoodType.Size = new System.Drawing.Size(300, 40);
            this.txtFoodType.TabIndex = 37;
            // 
            // FoodType
            // 
            this.FoodType.AutoSize = true;
            this.FoodType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoodType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.FoodType.Location = new System.Drawing.Point(399, 68);
            this.FoodType.Name = "FoodType";
            this.FoodType.Size = new System.Drawing.Size(72, 17);
            this.FoodType.TabIndex = 36;
            this.FoodType.Text = "Food Type";
            // 
            // cmbRestaurant
            // 
            this.cmbRestaurant.BackColor = System.Drawing.Color.Transparent;
            this.cmbRestaurant.BorderRadius = 10;
            this.cmbRestaurant.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRestaurant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRestaurant.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRestaurant.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRestaurant.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRestaurant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbRestaurant.ItemHeight = 30;
            this.cmbRestaurant.Location = new System.Drawing.Point(35, 97);
            this.cmbRestaurant.Name = "cmbRestaurant";
            this.cmbRestaurant.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.cmbRestaurant.ShadowDecoration.Depth = 100;
            this.cmbRestaurant.Size = new System.Drawing.Size(300, 36);
            this.cmbRestaurant.TabIndex = 35;
            // 
            // RestName
            // 
            this.RestName.AutoSize = true;
            this.RestName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.RestName.Location = new System.Drawing.Point(23, 68);
            this.RestName.Name = "RestName";
            this.RestName.Size = new System.Drawing.Size(118, 17);
            this.RestName.TabIndex = 29;
            this.RestName.Text = "Restaurant Name ";
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
            this.btnSave.Location = new System.Drawing.Point(199, 535);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Color = System.Drawing.Color.Khaki;
            this.btnSave.ShadowDecoration.Depth = 50;
            this.btnSave.Size = new System.Drawing.Size(140, 45);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Update";
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
            this.btnCancel.Location = new System.Drawing.Point(428, 535);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Color = System.Drawing.Color.Khaki;
            this.btnCancel.ShadowDecoration.Depth = 50;
            this.btnCancel.Size = new System.Drawing.Size(140, 45);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lblTitle);
            this.guna2ShadowPanel1.Controls.Add(this.lblSubTitle);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(47, 8);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 15;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Silver;
            this.guna2ShadowPanel1.ShadowDepth = 200;
            this.guna2ShadowPanel1.ShadowShift = 2;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(482, 81);
            this.guna2ShadowPanel1.TabIndex = 61;
            // 
            // DonationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(835, 561);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cardDonation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DonationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Load += new System.EventHandler(this.DonationForm_Load);
            this.cardDonation.ResumeLayout(false);
            this.cardDonation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private Guna.UI2.WinForms.Guna2ShadowPanel cardDonation;
        private System.Windows.Forms.Label RestName;
        private System.Windows.Forms.Label FoodType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRestaurant;
        private Guna.UI2.WinForms.Guna2NumericUpDown numQuantity;
        private System.Windows.Forms.Label Quantity;
        private Guna.UI2.WinForms.Guna2TextBox txtFoodType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtDonationDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtExpiryTime;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
    }
}