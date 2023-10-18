namespace FinalWindow.View.Manager.ListWorker
{
    partial class ListKeepWorkerForm
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
            this.dataGridView_listKeepWorker = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listKeepWorker)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_listKeepWorker
            // 
            this.dataGridView_listKeepWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listKeepWorker.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_listKeepWorker.Name = "dataGridView_listKeepWorker";
            this.dataGridView_listKeepWorker.RowHeadersWidth = 51;
            this.dataGridView_listKeepWorker.RowTemplate.Height = 24;
            this.dataGridView_listKeepWorker.Size = new System.Drawing.Size(1556, 363);
            this.dataGridView_listKeepWorker.TabIndex = 0;
            this.dataGridView_listKeepWorker.Click += new System.EventHandler(this.dataGridView_listKeepWorker_Click);
            // 
            // ListKeepWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(1580, 387);
            this.Controls.Add(this.dataGridView_listKeepWorker);
            this.Name = "ListKeepWorkerForm";
            this.Text = "ListKeepWorkerForm";
            this.Load += new System.EventHandler(this.ListKeepWorkerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listKeepWorker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_listKeepWorker;
    }
}