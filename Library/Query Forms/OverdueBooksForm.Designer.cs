namespace Library.Query_Forms
{
    partial class OverdueBooksForm
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
            this.dgvOverdue = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOverdue
            // 
            this.dgvOverdue.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvOverdue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdue.GridColor = System.Drawing.Color.DarkGreen;
            this.dgvOverdue.Location = new System.Drawing.Point(12, 38);
            this.dgvOverdue.Name = "dgvOverdue";
            this.dgvOverdue.RowHeadersWidth = 51;
            this.dgvOverdue.RowTemplate.Height = 24;
            this.dgvOverdue.Size = new System.Drawing.Size(777, 371);
            this.dgvOverdue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(330, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Overdue Loans";
            // 
            // OverdueBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(801, 421);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOverdue);
            this.Name = "OverdueBooksForm";
            this.Text = "OverdueBooksForm";
            this.Load += new System.EventHandler(this.OverdueBooksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOverdue;
        private System.Windows.Forms.Label label1;
    }
}