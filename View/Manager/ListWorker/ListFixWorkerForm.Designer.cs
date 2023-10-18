namespace FinalWindow.View.Manager.ListWorker
{
    partial class ListFixWorkerForm
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
            this.dataGridView_listFixWorker = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listFixWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_listFixWorker
            // 
            this.dataGridView_listFixWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listFixWorker.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_listFixWorker.Name = "dataGridView_listFixWorker";
            this.dataGridView_listFixWorker.RowHeadersWidth = 51;
            this.dataGridView_listFixWorker.RowTemplate.Height = 24;
            this.dataGridView_listFixWorker.Size = new System.Drawing.Size(1556, 363);
            this.dataGridView_listFixWorker.TabIndex = 0;
            this.dataGridView_listFixWorker.Click += new System.EventHandler(this.dataGridView_listFixWorker_Click);
            // 
            // ListFixWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(1580, 387);
            this.Controls.Add(this.dataGridView_listFixWorker);
            this.Name = "ListFixWorkerForm";
            this.Text = "ListFixWorkerForm";
            this.Load += new System.EventHandler(this.ListFixWorkerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listFixWorker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_listFixWorker;
    }
}