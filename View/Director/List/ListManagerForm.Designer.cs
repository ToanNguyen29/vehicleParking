namespace FinalWindow.View.Director.List
{
    partial class ListManagerForm
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
            this.dataGridView_listManager = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listManager)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_listManager
            // 
            this.dataGridView_listManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listManager.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_listManager.Name = "dataGridView_listManager";
            this.dataGridView_listManager.RowHeadersWidth = 51;
            this.dataGridView_listManager.RowTemplate.Height = 24;
            this.dataGridView_listManager.Size = new System.Drawing.Size(1490, 415);
            this.dataGridView_listManager.TabIndex = 0;
            this.dataGridView_listManager.Click += new System.EventHandler(this.dataGridView_listManager_Click);
            // 
            // ListManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(210)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(1514, 450);
            this.Controls.Add(this.dataGridView_listManager);
            this.Name = "ListManagerForm";
            this.Text = "ListManagerForm";
            this.Load += new System.EventHandler(this.ListManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_listManager;
    }
}