using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Loan_Forms
{
    public partial class AddLoan : Form
    {
        public AddLoan()
        {
            InitializeComponent();
        }

        private void AddLoan_Load(object sender, EventArgs e)
        {
            cmbVisitor.DataSource = GlobalData.AllVisitors;
            cmbVisitor.DisplayMember = "Names";  
            cmbVisitor.ValueMember = "Barcode";  
            cmbVisitor.SelectedIndex = -1;

            //maybe add filter to show only available books
            cmbBook.DataSource = GlobalData.AllBooks;
            cmbBook.DisplayMember = "Title";
            cmbBook.ValueMember = "InventoryNumber";
            cmbBook.SelectedIndex = -1;

            dtpLoanDate.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now.AddDays(14);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbVisitor.SelectedIndex == -1 || cmbBook.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both a visitor and a book.");
                return;
            }

            if (dtpReturnDate.Value < dtpLoanDate.Value)
            {
                MessageBox.Show("Return date cannot be earlier than loan date.");
                return;
            }

            try
            {
                Loan newLoan = new Loan();

                newLoan.VisitorBarcode = cmbVisitor.SelectedValue.ToString();
                newLoan.BookID = (int)cmbBook.SelectedValue;

                newLoan.LoanDate = dtpLoanDate.Value;
                newLoan.ReturnDate = dtpReturnDate.Value;

                bool isAlreadyLent = GlobalData.AllLoans.Any(l => l.BookID == newLoan.BookID);
                if (isAlreadyLent)
                {
                    MessageBox.Show("This book is currently lent out to someone else!");
                    return;
                }

                DatabaseHelper.AddLoanToDb(newLoan);

                GlobalData.AllLoans.Add(newLoan);

                MessageBox.Show("Loan registered successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
