namespace FinalWindow.View.Manager
{
    partial class ManagerEditInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerEditInformationForm));
            this.pictureBox_image = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.birthday_picker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2CirclePictureBox5 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.textBox_address = new Guna.UI2.WinForms.Guna2TextBox();
            this.comboBox_gender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.textBox_phone = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox_lastName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CirclePictureBox4 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.textBox_email = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.textBox_firstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.button_edit = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_image
            // 
            this.pictureBox_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.pictureBox_image.ImageRotate = 0F;
            this.pictureBox_image.Location = new System.Drawing.Point(329, 71);
            this.pictureBox_image.Name = "pictureBox_image";
            this.pictureBox_image.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureBox_image.Size = new System.Drawing.Size(110, 106);
            this.pictureBox_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_image.TabIndex = 53;
            this.pictureBox_image.TabStop = false;
            this.pictureBox_image.Click += new System.EventHandler(this.pictureBox_image_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.guna2GroupBox1.BorderRadius = 20;
            this.guna2GroupBox1.Controls.Add(this.birthday_picker);
            this.guna2GroupBox1.Controls.Add(this.guna2CirclePictureBox5);
            this.guna2GroupBox1.Controls.Add(this.textBox_address);
            this.guna2GroupBox1.Controls.Add(this.comboBox_gender);
            this.guna2GroupBox1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2GroupBox1.Controls.Add(this.textBox_phone);
            this.guna2GroupBox1.Controls.Add(this.textBox_lastName);
            this.guna2GroupBox1.Controls.Add(this.guna2CirclePictureBox4);
            this.guna2GroupBox1.Controls.Add(this.textBox_email);
            this.guna2GroupBox1.Controls.Add(this.guna2CirclePictureBox3);
            this.guna2GroupBox1.Controls.Add(this.guna2CirclePictureBox2);
            this.guna2GroupBox1.Controls.Add(this.textBox_firstName);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.guna2GroupBox1.Location = new System.Drawing.Point(13, 207);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(559, 390);
            this.guna2GroupBox1.TabIndex = 50;
            // 
            // birthday_picker
            // 
            this.birthday_picker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.birthday_picker.BorderRadius = 20;
            this.birthday_picker.Checked = true;
            this.birthday_picker.CustomFormat = "MM/dd/yyyy";
            this.birthday_picker.FillColor = System.Drawing.Color.White;
            this.birthday_picker.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthday_picker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.birthday_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birthday_picker.Location = new System.Drawing.Point(316, 101);
            this.birthday_picker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.birthday_picker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.birthday_picker.Name = "birthday_picker";
            this.birthday_picker.Size = new System.Drawing.Size(201, 36);
            this.birthday_picker.TabIndex = 39;
            this.birthday_picker.Value = new System.DateTime(2023, 5, 9, 19, 28, 5, 329);
            // 
            // guna2CirclePictureBox5
            // 
            this.guna2CirclePictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CirclePictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox5.Image")));
            this.guna2CirclePictureBox5.ImageRotate = 0F;
            this.guna2CirclePictureBox5.Location = new System.Drawing.Point(28, 304);
            this.guna2CirclePictureBox5.Name = "guna2CirclePictureBox5";
            this.guna2CirclePictureBox5.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox5.Size = new System.Drawing.Size(46, 48);
            this.guna2CirclePictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox5.TabIndex = 38;
            this.guna2CirclePictureBox5.TabStop = false;
            // 
            // textBox_address
            // 
            this.textBox_address.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_address.BorderRadius = 20;
            this.textBox_address.BorderThickness = 0;
            this.textBox_address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_address.DefaultText = "";
            this.textBox_address.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_address.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_address.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_address.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_address.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_address.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.textBox_address.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_address.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_address.Location = new System.Drawing.Point(80, 304);
            this.textBox_address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.PasswordChar = '\0';
            this.textBox_address.PlaceholderText = "Type your Address";
            this.textBox_address.SelectedText = "";
            this.textBox_address.Size = new System.Drawing.Size(437, 48);
            this.textBox_address.TabIndex = 37;
            // 
            // comboBox_gender
            // 
            this.comboBox_gender.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_gender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_gender.BorderRadius = 20;
            this.comboBox_gender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_gender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_gender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_gender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_gender.ItemHeight = 30;
            this.comboBox_gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboBox_gender.Location = new System.Drawing.Point(80, 101);
            this.comboBox_gender.MaxDropDownItems = 2;
            this.comboBox_gender.Name = "comboBox_gender";
            this.comboBox_gender.Size = new System.Drawing.Size(191, 36);
            this.comboBox_gender.TabIndex = 36;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(28, 169);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(46, 48);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 35;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // textBox_phone
            // 
            this.textBox_phone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_phone.BorderRadius = 20;
            this.textBox_phone.BorderThickness = 0;
            this.textBox_phone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_phone.DefaultText = "";
            this.textBox_phone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_phone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_phone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_phone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_phone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_phone.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.textBox_phone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_phone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_phone.Location = new System.Drawing.Point(80, 169);
            this.textBox_phone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.PasswordChar = '\0';
            this.textBox_phone.PlaceholderText = "Type your Phone Number";
            this.textBox_phone.SelectedText = "";
            this.textBox_phone.Size = new System.Drawing.Size(437, 48);
            this.textBox_phone.TabIndex = 34;
            // 
            // textBox_lastName
            // 
            this.textBox_lastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_lastName.BorderRadius = 20;
            this.textBox_lastName.BorderThickness = 0;
            this.textBox_lastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_lastName.DefaultText = "";
            this.textBox_lastName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_lastName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_lastName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_lastName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_lastName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_lastName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.textBox_lastName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_lastName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_lastName.Location = new System.Drawing.Point(316, 32);
            this.textBox_lastName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_lastName.Name = "textBox_lastName";
            this.textBox_lastName.PasswordChar = '\0';
            this.textBox_lastName.PlaceholderText = "Last Name";
            this.textBox_lastName.SelectedText = "";
            this.textBox_lastName.Size = new System.Drawing.Size(201, 48);
            this.textBox_lastName.TabIndex = 2;
            // 
            // guna2CirclePictureBox4
            // 
            this.guna2CirclePictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CirclePictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox4.Image")));
            this.guna2CirclePictureBox4.ImageRotate = 0F;
            this.guna2CirclePictureBox4.Location = new System.Drawing.Point(28, 237);
            this.guna2CirclePictureBox4.Name = "guna2CirclePictureBox4";
            this.guna2CirclePictureBox4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox4.Size = new System.Drawing.Size(46, 48);
            this.guna2CirclePictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox4.TabIndex = 33;
            this.guna2CirclePictureBox4.TabStop = false;
            // 
            // textBox_email
            // 
            this.textBox_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_email.BorderRadius = 20;
            this.textBox_email.BorderThickness = 0;
            this.textBox_email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_email.DefaultText = "";
            this.textBox_email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_email.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.textBox_email.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_email.Location = new System.Drawing.Point(80, 237);
            this.textBox_email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.PasswordChar = '\0';
            this.textBox_email.PlaceholderText = "Type your Email";
            this.textBox_email.SelectedText = "";
            this.textBox_email.Size = new System.Drawing.Size(437, 48);
            this.textBox_email.TabIndex = 5;
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CirclePictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox3.Image")));
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(28, 101);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(46, 48);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox3.TabIndex = 32;
            this.guna2CirclePictureBox3.TabStop = false;
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CirclePictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox2.Image")));
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(28, 32);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(46, 48);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox2.TabIndex = 31;
            this.guna2CirclePictureBox2.TabStop = false;
            // 
            // textBox_firstName
            // 
            this.textBox_firstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_firstName.BorderRadius = 20;
            this.textBox_firstName.BorderThickness = 0;
            this.textBox_firstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_firstName.DefaultText = "";
            this.textBox_firstName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_firstName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_firstName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_firstName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_firstName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_firstName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_firstName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_firstName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_firstName.Location = new System.Drawing.Point(80, 32);
            this.textBox_firstName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_firstName.Name = "textBox_firstName";
            this.textBox_firstName.PasswordChar = '\0';
            this.textBox_firstName.PlaceholderText = "FirstName";
            this.textBox_firstName.SelectedText = "";
            this.textBox_firstName.Size = new System.Drawing.Size(191, 48);
            this.textBox_firstName.TabIndex = 1;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.label_username.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_username.Location = new System.Drawing.Point(166, 113);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(89, 23);
            this.label_username.TabIndex = 54;
            this.label_username.Text = "Username";
            // 
            // button_edit
            // 
            this.button_edit.BorderRadius = 20;
            this.button_edit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_edit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_edit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_edit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_edit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_edit.ForeColor = System.Drawing.Color.White;
            this.button_edit.Location = new System.Drawing.Point(196, 603);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(182, 45);
            this.button_edit.TabIndex = 51;
            this.button_edit.Text = "Edit";
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(128, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 57);
            this.label1.TabIndex = 52;
            this.label1.Text = "Edit Information";
            // 
            // ManagerEditInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(584, 659);
            this.Controls.Add(this.pictureBox_image);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.label1);
            this.Name = "ManagerEditInformationForm";
            this.Text = "ManagerEditInformationForm";
            this.Load += new System.EventHandler(this.ManagerEditInformationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_image)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2CirclePictureBox pictureBox_image;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        public Guna.UI2.WinForms.Guna2DateTimePicker birthday_picker;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox5;
        public Guna.UI2.WinForms.Guna2TextBox textBox_address;
        public Guna.UI2.WinForms.Guna2ComboBox comboBox_gender;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        public Guna.UI2.WinForms.Guna2TextBox textBox_phone;
        public Guna.UI2.WinForms.Guna2TextBox textBox_lastName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox4;
        public Guna.UI2.WinForms.Guna2TextBox textBox_email;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
        public Guna.UI2.WinForms.Guna2TextBox textBox_firstName;
        public System.Windows.Forms.Label label_username;
        private Guna.UI2.WinForms.Guna2Button button_edit;
        private System.Windows.Forms.Label label1;
    }
}