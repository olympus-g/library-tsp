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
    public partial class DeleteLoan : Form
    {
        private Loan _currentLoan = null;

        public DeleteLoan()
        {
            InitializeComponent();
        }

        private void DeleteLoan_Load(object sender, EventArgs e)
        {
            LoadLoansIntoDropdown();
        }

        private void LoadLoansIntoDropdown()
        {
            cmbSelectLoan.SelectedIndexChanged -= cmbSelectLoan_SelectedIndexChanged;

            var displayList = GlobalData.AllLoans.Select(l => new
            {
                DisplayText = GetLoanDisplayText(l),
                Value = l
            }).ToList();

            cmbSelectLoan.DataSource = displayList;
            cmbSelectLoan.DisplayMember = "DisplayText";
            cmbSelectLoan.ValueMember = "Value";
            cmbSelectLoan.SelectedIndex = -1;

            cmbSelectLoan.SelectedIndexChanged += cmbSelectLoan_SelectedIndexChanged;

            txtBook.ReadOnly = true;
            txtVisitor.ReadOnly = true;
            txtBook.Clear();
            txtVisitor.Clear();
        }

        private string GetLoanDisplayText(Loan l)
        {
            string bookTitle = GlobalData.BookCatalog.ContainsKey(l.BookID)
                ? GlobalData.BookCatalog[l.BookID].Title
                : "Book #" + l.BookID;

            string visitorName = GlobalData.AllVisitors.FirstOrDefault(v => v.Barcode == l.VisitorBarcode)?.Names
                                 ?? "Visitor " + l.VisitorBarcode;

            return $"{bookTitle} -> {visitorName}";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentLoan == null) return;

            var result = MessageBox.Show("Confirm return of this book?", "Return Book", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeleteLoanFromDb(_currentLoan.BookID, _currentLoan.VisitorBarcode);

                    GlobalData.AllLoans.Remove(_currentLoan);

                    MessageBox.Show("Book returned successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void cmbSelectLoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectLoan.SelectedIndex == -1) return;

            _currentLoan = (Loan)cmbSelectLoan.SelectedValue;

            if (_currentLoan != null)
            {
                if (GlobalData.BookCatalog.ContainsKey(_currentLoan.BookID))
                {
                    txtBook.Text = GlobalData.BookCatalog[_currentLoan.BookID].Title;
                }

                var visitor = GlobalData.AllVisitors.FirstOrDefault(v => v.Barcode == _currentLoan.VisitorBarcode);
                if (visitor != null)
                {
                    txtVisitor.Text = visitor.Names;
                }
            }
        }
    }
}
