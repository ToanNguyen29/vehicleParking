
namespace FinalWindow.View.Customer
{
    partial class LoanServiceForm
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
            this.dataGridView_listLoanVehicle = new System.Windows.Forms.DataGridView();
            this.label_username = new System.Windows.Forms.Label();
            this.Period = new System.Windows.Forms.Label();
            this.comboBox_vehicle = new Guna.UI2.WinForms.Guna2ComboBox();
            this.button_Find = new Guna.UI2.WinForms.Guna2Button();
            this.textBox_period = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listLoanVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_listLoanVehicle
            // 
            this.dataGridView_listLoanVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listLoanVehicle.Location = new System.Drawing.Point(24, 173);
            this.dataGridView_listLoanVehicle.Name = "dataGridView_listLoanVehicle";
            this.dataGridView_listLoanVehicle.RowHeadersWidth = 51;
            this.dataGridView_listLoanVehicle.RowTemplate.Height = 24;
            this.dataGridView_listLoanVehicle.Size = new System.Drawing.Size(827, 436);
            this.dataGridView_listLoanVehicle.TabIndex = 1;
            this.dataGridView_listLoanVehicle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_listLoanVehicle_CellContentClick);
            this.dataGridView_listLoanVehicle.DoubleClick += new System.EventHandler(this.dataGridView_listLoanVehicle_DoubleClick);
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_username.Location = new System.Drawing.Point(35, 38);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(159, 29);
            this.label_username.TabIndex = 26;
            this.label_username.Text = "Vehicle type:";
            // 
            // Period
            // 
            this.Period.AutoSize = true;
            this.Period.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.Period.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Period.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Period.Location = new System.Drawing.Point(35, 104);
            this.Period.Name = "Period";
            this.Period.Size = new System.Drawing.Size(93, 29);
            this.Period.TabIndex = 27;
            this.Period.Text = "Period:";
            // 
            // comboBox_vehicle
            // 
            this.comboBox_vehicle.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_vehicle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_vehicle.BorderRadius = 20;
            this.comboBox_vehicle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_vehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_vehicle.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_vehicle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_vehicle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.comboBox_vehicle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_vehicle.ItemHeight = 30;
            this.comboBox_vehicle.Items.AddRange(new object[] {
            "Motor",
            "Car",
            "Truck"});
            this.comboBox_vehicle.Location = new System.Drawing.Point(200, 38);
            this.comboBox_vehicle.MaxDropDownItems = 2;
            this.comboBox_vehicle.Name = "comboBox_vehicle";
            this.comboBox_vehicle.Size = new System.Drawing.Size(315, 36);
            this.comboBox_vehicle.TabIndex = 37;
            // 
            // button_Find
            // 
            this.button_Find.BorderRadius = 20;
            this.button_Find.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_Find.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_Find.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_Find.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_Find.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Find.ForeColor = System.Drawing.Color.White;
            this.button_Find.Location = new System.Drawing.Point(638, 63);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(182, 55);
            this.button_Find.TabIndex = 39;
            this.button_Find.Text = "Find";
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // textBox_period
            // 
            this.textBox_period.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.textBox_period.BorderRadius = 20;
            this.textBox_period.BorderThickness = 0;
            this.textBox_period.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_period.DefaultText = "";
            this.textBox_period.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_period.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_period.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_period.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_period.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_period.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.textBox_period.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_period.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_period.Location = new System.Drawing.Point(200, 85);
            this.textBox_period.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_period.Name = "textBox_period";
            this.textBox_period.PasswordChar = '\0';
            this.textBox_period.PlaceholderText = "Type period ";
            this.textBox_period.SelectedText = "";
            this.textBox_period.Size = new System.Drawing.Size(315, 48);
            this.textBox_period.TabIndex = 40;
            // 
            // LoanServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(883, 636);
            this.Controls.Add(this.textBox_period);
            this.Controls.Add(this.button_Find);
            this.Controls.Add(this.comboBox_vehicle);
            this.Controls.Add(this.Period);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.dataGridView_listLoanVehicle);
            this.Name = "LoanServiceForm";
            this.Text = "LoanServiceForm";
            this.Load += new System.EventHandler(this.LoanServiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listLoanVehicle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_listLoanVehicle;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label Period;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_vehicle;
        private Guna.UI2.WinForms.Guna2Button button_Find;
        private Guna.UI2.WinForms.Guna2TextBox textBox_period;
    }
}