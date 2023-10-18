namespace FinalWindow.View.Manager
{
    partial class AttendanceWorkerForm
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
            this.button_resetPayroll = new Guna.UI2.WinForms.Guna2Button();
            this.comboBox_typeWorker = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dataGridView_listWorker = new System.Windows.Forms.DataGridView();
            this.dateTimePicker_date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.button_refresh = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // button_resetPayroll
            // 
            this.button_resetPayroll.BorderRadius = 10;
            this.button_resetPayroll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_resetPayroll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_resetPayroll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_resetPayroll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_resetPayroll.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_resetPayroll.ForeColor = System.Drawing.Color.White;
            this.button_resetPayroll.Location = new System.Drawing.Point(10, 479);
            this.button_resetPayroll.Name = "button_resetPayroll";
            this.button_resetPayroll.Size = new System.Drawing.Size(191, 65);
            this.button_resetPayroll.TabIndex = 47;
            this.button_resetPayroll.Text = "Select";
            this.button_resetPayroll.Click += new System.EventHandler(this.button_resetPayroll_Click);
            // 
            // comboBox_typeWorker
            // 
            this.comboBox_typeWorker.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_typeWorker.BorderRadius = 20;
            this.comboBox_typeWorker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_typeWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_typeWorker.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_typeWorker.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_typeWorker.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.comboBox_typeWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_typeWorker.ItemHeight = 30;
            this.comboBox_typeWorker.Items.AddRange(new object[] {
            "FixWorker",
            "KeepWorker"});
            this.comboBox_typeWorker.Location = new System.Drawing.Point(10, 414);
            this.comboBox_typeWorker.Name = "comboBox_typeWorker";
            this.comboBox_typeWorker.Size = new System.Drawing.Size(191, 36);
            this.comboBox_typeWorker.TabIndex = 46;
            this.comboBox_typeWorker.SelectedIndexChanged += new System.EventHandler(this.comboBox_typeWorker_SelectedIndexChanged);
            // 
            // dataGridView_listWorker
            // 
            this.dataGridView_listWorker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_listWorker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_listWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listWorker.Location = new System.Drawing.Point(12, 31);
            this.dataGridView_listWorker.Name = "dataGridView_listWorker";
            this.dataGridView_listWorker.RowHeadersWidth = 51;
            this.dataGridView_listWorker.RowTemplate.Height = 24;
            this.dataGridView_listWorker.Size = new System.Drawing.Size(1088, 353);
            this.dataGridView_listWorker.TabIndex = 45;
            this.dataGridView_listWorker.Click += new System.EventHandler(this.dataGridView_listWorker_Click);
            // 
            // dateTimePicker_date
            // 
            this.dateTimePicker_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dateTimePicker_date.BorderRadius = 20;
            this.dateTimePicker_date.Checked = true;
            this.dateTimePicker_date.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker_date.FillColor = System.Drawing.Color.White;
            this.dateTimePicker_date.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker_date.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_date.Location = new System.Drawing.Point(216, 414);
            this.dateTimePicker_date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_date.Name = "dateTimePicker_date";
            this.dateTimePicker_date.Size = new System.Drawing.Size(201, 36);
            this.dateTimePicker_date.TabIndex = 48;
            this.dateTimePicker_date.Value = new System.DateTime(2023, 5, 29, 0, 0, 0, 0);
            // 
            // button_refresh
            // 
            this.button_refresh.BorderRadius = 10;
            this.button_refresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_refresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_refresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_refresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_refresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.ForeColor = System.Drawing.Color.White;
            this.button_refresh.Location = new System.Drawing.Point(226, 479);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(191, 65);
            this.button_refresh.TabIndex = 50;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // AttendanceWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(1112, 596);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.dateTimePicker_date);
            this.Controls.Add(this.button_resetPayroll);
            this.Controls.Add(this.comboBox_typeWorker);
            this.Controls.Add(this.dataGridView_listWorker);
            this.Name = "AttendanceWorkerForm";
            this.Text = "Attendance Form";
            this.Load += new System.EventHandler(this.PayRollWorkerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listWorker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button button_resetPayroll;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_typeWorker;
        private System.Windows.Forms.DataGridView dataGridView_listWorker;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker_date;
        private Guna.UI2.WinForms.Guna2Button button_refresh;
    }
}