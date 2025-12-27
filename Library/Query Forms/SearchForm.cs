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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            cmbSearchBy.Items.Clear();
            cmbSearchBy.Items.Add("Genre"); 
            cmbSearchBy.Items.Add("Author"); 
            cmbSearchBy.Items.Add("Year"); 

            cmbSearchBy.SelectedIndex = 0;

            DisplayBooks(GlobalData.AllBooks);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSearchBy.SelectedItem == null) return;

            string searchType = cmbSearchBy.SelectedItem.ToString();
            string searchTerm = txtSearch.Text.ToLower().Trim();

            List<Book> foundBooks = new List<Book>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                foundBooks = GlobalData.AllBooks;
            }
            else
            {
                if (searchType == "Genre")
                {
                    foundBooks = GlobalData.AllBooks
                        .Where(b => b.Genre.ToLower().Contains(searchTerm))
                        .ToList();
                }
                else if (searchType == "Author")
                {
                    foundBooks = GlobalData.AllBooks
                        .Where(b => b.Author.ToLower().Contains(searchTerm))
                        .ToList();
                }
                else if (searchType == "Year")
                {
                    foundBooks = GlobalData.AllBooks
                        .Where(b => b.Year.ToString().Contains(searchTerm))
                        .ToList();
                }
            }

            DisplayBooks(foundBooks);

            if (foundBooks.Count == 0)
            {
                MessageBox.Show("No books found matching your criteria.");
            }
        }

        private void DisplayBooks(List<Book> books)
        {
            dgvBooks.Rows.Clear();

            foreach (var book in books)
            {
                dgvBooks.Rows.Add(
                    book.InventoryNumber,
                    book.Title,
                    book.Author,
                    book.Year,
                    book.Genre
                );
            }
        }

    }
}
