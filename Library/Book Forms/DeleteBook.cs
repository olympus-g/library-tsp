using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Book_Forms
{
    public partial class DeleteBook : Form
    {
        private Book _currentBook = null;

        public DeleteBook()
        {
            InitializeComponent();
        }

        private void DeleteBook_Load(object sender, EventArgs e)
        {
            txtInventory.ReadOnly = true;
            txtTitle.ReadOnly = true;
            txtAuthor.ReadOnly = true;
            txtYear.ReadOnly = true;
            txtGenre.ReadOnly = true;

            cmbSelectBook.SelectedIndexChanged -= cmbSelectBook_SelectedIndexChanged;

            cmbSelectBook.DataSource = null;
            cmbSelectBook.DataSource = GlobalData.AllBooks;
            cmbSelectBook.DisplayMember = "Title";
            cmbSelectBook.ValueMember = "InventoryNumber";

            cmbSelectBook.SelectedIndex = -1;

            cmbSelectBook.SelectedIndexChanged += cmbSelectBook_SelectedIndexChanged;

            ClearFields();
        }

        private void cmbSelectBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectBook.SelectedIndex == -1) return;

            _currentBook = (Book)cmbSelectBook.SelectedItem;

            if (_currentBook != null)
            {
                txtInventory.Text = _currentBook.InventoryNumber.ToString();
                txtTitle.Text = _currentBook.Title;
                txtAuthor.Text = _currentBook.Author;
                txtYear.Text = _currentBook.Year.ToString();
                txtGenre.Text = _currentBook.Genre;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentBook == null)
            {
                MessageBox.Show("Please select a book first.");
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to delete '{_currentBook.Title}'?\nThis cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeleteBookFromDb(_currentBook.InventoryNumber);

                    GlobalData.AllBooks.Remove(_currentBook);

                    if (GlobalData.BookCatalog.ContainsKey(_currentBook.InventoryNumber))
                    {
                        GlobalData.BookCatalog.Remove(_currentBook.InventoryNumber);
                    }

                    MessageBox.Show("Book deleted successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting book: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            txtInventory.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            txtGenre.Clear();
        }
    }
}
