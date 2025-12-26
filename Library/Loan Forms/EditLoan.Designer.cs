namespace Library.Loan_Forms
{
    partial class EditLoan
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtVisitor = new System.Windows.Forms.TextBox();
            this.txtBook = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSelectLoan = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpLoanDate = new System.Windows.Forms.DateTimePicker();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(54, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 22);
            this.label4.TabIndex = 23;
            this.label4.Text = "Return Date:";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(202, 305);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(303, 51);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtVisitor
            // 
            this.txtVisitor.BackColor = System.Drawing.Color.White;
            this.txtVisitor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisitor.Location = new System.Drawing.Point(202, 148);
            this.txtVisitor.Name = "txtVisitor";
            this.txtVisitor.Size = new System.Drawing.Size(303, 30);
            this.txtVisitor.TabIndex = 20;
            // 
            // txtBook
            // 
            this.txtBook.BackColor = System.Drawing.Color.White;
            this.txtBook.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBook.Location = new System.Drawing.Point(202, 104);
            this.txtBook.Name = "txtBook";
            this.txtBook.Size = new System.Drawing.Size(303, 30);
            this.txtBook.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(54, 195);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "Loan Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(54, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "Visitor Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(54, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Book Taken:";
            // 
            // cmbSelectLoan
            // 
            this.cmbSelectLoan.FormattingEnabled = true;
            this.cmbSelectLoan.Location = new System.Drawing.Point(202, 66);
            this.cmbSelectLoan.Name = "cmbSelectLoan";
            this.cmbSelectLoan.Size = new System.Drawing.Size(303, 24);
            this.cmbSelectLoan.TabIndex = 37;
            this.cmbSelectLoan.SelectedIndexChanged += new System.EventHandler(this.cmbSelectLoan_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(54, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 22);
            this.label5.TabIndex = 36;
            this.label5.Text = "Choose a loan:";
            // 
            // dtpLoanDate
            // 
            this.dtpLoanDate.Location = new System.Drawing.Point(202, 194);
            this.dtpLoanDate.Name = "dtpLoanDate";
            this.dtpLoanDate.Size = new System.Drawing.Size(303, 22);
            this.dtpLoanDate.TabIndex = 38;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Location = new System.Drawing.Point(202, 238);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(303, 22);
            this.dtpReturnDate.TabIndex = 39;
            // 
            // EditLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(559, 421);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.dtpLoanDate);
            this.Controls.Add(this.cmbSelectLoan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtVisitor);
            this.Controls.Add(this.txtBook);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditLoan";
            this.Text = "EditLoan";
            this.Load += new System.EventHandler(this.EditLoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtVisitor;
        private System.Windows.Forms.TextBox txtBook;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSelectLoan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpLoanDate;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
    }
}