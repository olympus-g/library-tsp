using Library.Book_Forms;
using Library.Loan_Forms;
using Library.Visitor_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.ShowDialog();
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            EditBook editBook = new EditBook(); 
            editBook.ShowDialog();
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            DeleteBook deleteBook = new DeleteBook();
            deleteBook.ShowDialog();
        }

        private void btnAddVisitor_Click(object sender, EventArgs e)
        {
            AddVisitor addVisitor = new AddVisitor();
            addVisitor.ShowDialog();
        }

        private void btnEditVisitor_Click(object sender, EventArgs e)
        {
            EditVisitor editVisitor = new EditVisitor();
            editVisitor.ShowDialog();
        }

        private void btnDeleteVisitor_Click(object sender, EventArgs e)
        {
            DeleteVisitor deleteVisitor = new DeleteVisitor();
            deleteVisitor.ShowDialog();
        }

        private void btnAddLoan_Click(object sender, EventArgs e)
        {
            AddLoan addLoan = new AddLoan();
            addLoan.ShowDialog();
        }

        private void btnEditLoan_Click(object sender, EventArgs e)
        {
            EditLoan editLoan = new EditLoan();
            editLoan.ShowDialog();
        }

        private void btnDeleteLoan_Click(object sender, EventArgs e)
        {
            DeleteLoan deleteLoan = new DeleteLoan();
            deleteLoan.ShowDialog();
        }
    }
}
