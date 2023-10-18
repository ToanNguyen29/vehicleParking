namespace FinalWindow.View.Manager.ShiftCRUD
{
    partial class AddShiftForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_add = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label_to = new System.Windows.Forms.Label();
            this.label_from = new System.Windows.Forms.Label();
            this.dateTimePicker_To = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dateTimePicker_From = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(94, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 59);
            this.label1.TabIndex = 54;
            this.label1.Text = "Add New Shift";
            // 
            // button_add
            // 
            this.button_add.BorderRadius = 20;
            this.button_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_add.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.ForeColor = System.Drawing.Color.White;
            this.button_add.Location = new System.Drawing.Point(118, 336);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(264, 45);
            this.button_add.TabIndex = 53;
            this.button_add.Text = "Add";
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.guna2GroupBox2.BorderRadius = 20;
            this.guna2GroupBox2.Controls.Add(this.label_to);
            this.guna2GroupBox2.Controls.Add(this.label_from);
            this.guna2GroupBox2.Controls.Add(this.dateTimePicker_To);
            this.guna2GroupBox2.Controls.Add(this.dateTimePicker_From);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.guna2GroupBox2.Location = new System.Drawing.Point(65, 114);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(364, 203);
            this.guna2GroupBox2.TabIndex = 52;
            // 
            // label_to
            // 
            this.label_to.AutoSize = true;
            this.label_to.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label_to.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_to.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_to.Location = new System.Drawing.Point(48, 104);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(38, 28);
            this.label_to.TabIndex = 45;
            this.label_to.Text = "TO";
            // 
            // label_from
            // 
            this.label_from.AutoSize = true;
            this.label_from.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label_from.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_from.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_from.Location = new System.Drawing.Point(17, 41);
            this.label_from.Name = "label_from";
            this.label_from.Size = new System.Drawing.Size(69, 28);
            this.label_from.TabIndex = 44;
            this.label_from.Text = "FROM";
            // 
            // dateTimePicker_To
            // 
            this.dateTimePicker_To.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dateTimePicker_To.BorderRadius = 20;
            this.dateTimePicker_To.Checked = true;
            this.dateTimePicker_To.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_To.FillColor = System.Drawing.Color.White;
            this.dateTimePicker_To.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_To.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_To.Location = new System.Drawing.Point(110, 104);
            this.dateTimePicker_To.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_To.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_To.Name = "dateTimePicker_To";
            this.dateTimePicker_To.ShowUpDown = true;
            this.dateTimePicker_To.Size = new System.Drawing.Size(213, 39);
            this.dateTimePicker_To.TabIndex = 43;
            this.dateTimePicker_To.Value = new System.DateTime(2023, 5, 9, 19, 28, 5, 329);
            // 
            // dateTimePicker_From
            // 
            this.dateTimePicker_From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dateTimePicker_From.BorderRadius = 20;
            this.dateTimePicker_From.Checked = true;
            this.dateTimePicker_From.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_From.FillColor = System.Drawing.Color.White;
            this.dateTimePicker_From.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_From.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_From.Location = new System.Drawing.Point(110, 33);
            this.dateTimePicker_From.MaxDate = new System.DateTime(2023, 5, 14, 0, 0, 0, 0);
            this.dateTimePicker_From.MinDate = new System.DateTime(2023, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_From.Name = "dateTimePicker_From";
            this.dateTimePicker_From.ShowUpDown = true;
            this.dateTimePicker_From.Size = new System.Drawing.Size(213, 36);
            this.dateTimePicker_From.TabIndex = 8;
            this.dateTimePicker_From.Value = new System.DateTime(2023, 5, 9, 19, 28, 5, 329);
            // 
            // AddShiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(489, 408);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.guna2GroupBox2);
            this.Name = "AddShiftForm";
            this.Text = "AddShiftForm";
            this.Load += new System.EventHandler(this.AddShiftForm_Load);
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button button_add;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker_From;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker_To;
        private System.Windows.Forms.Label label_to;
        private System.Windows.Forms.Label label_from;
    }
}