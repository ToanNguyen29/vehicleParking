
namespace FinalWindow.View.Manager
{
    partial class ListAttendanceWorker
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
            this.dataGridView_listWorker = new System.Windows.Forms.DataGridView();
            this.label_dayAbsent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_listWorker
            // 
            this.dataGridView_listWorker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_listWorker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_listWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listWorker.Location = new System.Drawing.Point(-1, -2);
            this.dataGridView_listWorker.Name = "dataGridView_listWorker";
            this.dataGridView_listWorker.RowHeadersWidth = 51;
            this.dataGridView_listWorker.RowTemplate.Height = 24;
            this.dataGridView_listWorker.Size = new System.Drawing.Size(1189, 353);
            this.dataGridView_listWorker.TabIndex = 52;
            // 
            // label_dayAbsent
            // 
            this.label_dayAbsent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_dayAbsent.AutoSize = true;
            this.label_dayAbsent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.label_dayAbsent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dayAbsent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_dayAbsent.Location = new System.Drawing.Point(12, 367);
            this.label_dayAbsent.Name = "label_dayAbsent";
            this.label_dayAbsent.Size = new System.Drawing.Size(118, 28);
            this.label_dayAbsent.TabIndex = 58;
            this.label_dayAbsent.Text = "Day absent";
            this.label_dayAbsent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListAttendanceWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(1188, 422);
            this.Controls.Add(this.label_dayAbsent);
            this.Controls.Add(this.dataGridView_listWorker);
            this.Name = "ListAttendanceWorker";
            this.Text = "ListAttendanceWorker";
            this.Load += new System.EventHandler(this.ListAttendanceWorker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listWorker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_listWorker;
        public System.Windows.Forms.Label label_dayAbsent;
    }
}