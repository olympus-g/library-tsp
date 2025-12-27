using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Query_Forms
{
    public partial class OverdueBooksForm : Form
    {
        public OverdueBooksForm()
        {
            InitializeComponent();
        }

        private void OverdueBooksForm_Load(object sender, EventArgs e)
        {
            LoadOverdueData();
        }

        private void LoadOverdueData()
        {
            var overdueList = GlobalData.AllLoans
                .Where(loan => loan.ReturnDate.Date < DateTime.Now.Date)
                .Select(loan => new
                {
                    VisitorName = GetVisitorName(loan.VisitorBarcode),
                    BookTitle = GetBookTitle(loan.BookID),
                    DueDate = loan.ReturnDate.ToShortDateString(),
                    DaysLate = (DateTime.Now.Date - loan.ReturnDate.Date).Days
                })
                .OrderByDescending(x => x.DaysLate)
                .ToList();

            dgvOverdue.DataSource = overdueList;

            if (dgvOverdue.Columns.Count > 0)
            {
                dgvOverdue.Columns["VisitorName"].HeaderText = "Visitor Name";
                dgvOverdue.Columns["BookTitle"].HeaderText = "Book Title";
                dgvOverdue.Columns["DueDate"].HeaderText = "Due Date";
                dgvOverdue.Columns["DaysLate"].HeaderText = "Days Overdue";
            }

            if (overdueList.Count == 0)
            {
                MessageBox.Show("Good news! No overdue books found.");
            }
        }

        private string GetVisitorName(string barcode)
        {
            var visitor = GlobalData.AllVisitors.FirstOrDefault(v => v.Barcode == barcode);
            return visitor != null ? visitor.Names : $"Unknown ({barcode})";
        }

        private string GetBookTitle(int id)
        {
            if (GlobalData.BookCatalog.ContainsKey(id))
            {
                return GlobalData.BookCatalog[id].Title;
            }
            return $"Unknown Book ({id})";
        }
    }
}
