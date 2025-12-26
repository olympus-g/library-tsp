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
    public partial class EditLoan : Form
    {
        private Loan _currentLoan = null;

        public EditLoan()
        {
            InitializeComponent();
        }

        private void EditLoan_Load(object sender, EventArgs e)
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_currentLoan == null)
            {
                MessageBox.Show("Please select a loan first.");
                return;
            }

            if (dtpReturnDate.Value < dtpLoanDate.Value)
            {
                MessageBox.Show("Return date cannot be earlier than the loan date.");
                return;
            }

            try
            {
                _currentLoan.LoanDate = dtpLoanDate.Value;
                _currentLoan.ReturnDate = dtpReturnDate.Value;

                DatabaseHelper.UpdateLoanInDb(_currentLoan);

                MessageBox.Show("Loan updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating loan: " + ex.Message);
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
                else
                {
                    txtBook.Text = "Unknown Book (ID: " + _currentLoan.BookID + ")";
                }

                var visitor = GlobalData.AllVisitors.FirstOrDefault(v => v.Barcode == _currentLoan.VisitorBarcode);
                if (visitor != null)
                {
                    txtVisitor.Text = visitor.Names;
                }
                else
                {
                    txtVisitor.Text = "Unknown Visitor";
                }

                dtpLoanDate.Value = _currentLoan.LoanDate;

                if (_currentLoan.ReturnDate > DateTime.MinValue)
                    dtpReturnDate.Value = _currentLoan.ReturnDate;
                else
                    dtpReturnDate.Value = DateTime.Now;
            }
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
    }
}
