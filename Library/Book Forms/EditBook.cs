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
    public partial class EditBook : Form
    {
        private Book _currentBook = null;

        public EditBook()
        {
            InitializeComponent();
        }

        private void EditBook_Load(object sender, EventArgs e)
        {
            cmbSelectBook.SelectedIndexChanged -= cmbSelectBook_SelectedIndexChanged;

            cmbSelectBook.DataSource = null;

            cmbSelectBook.DataSource = GlobalData.AllBooks;
            cmbSelectBook.DisplayMember = "Title";          
            cmbSelectBook.ValueMember = "InventoryNumber";   

            cmbSelectBook.SelectedIndex = -1;

            cmbSelectBook.SelectedIndexChanged += cmbSelectBook_SelectedIndexChanged;

            txtInventory.ReadOnly = true;
            txtInventory.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            txtGenre.Clear();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_currentBook == null)
            {
                MessageBox.Show("Please select a book first.");
                return;
            }

            try
            {
                _currentBook.Title = txtTitle.Text;
                _currentBook.Author = txtAuthor.Text;
                _currentBook.Year = int.Parse(txtYear.Text);
                _currentBook.Genre = txtGenre.Text;

                DatabaseHelper.UpdateBookInDb(_currentBook);

                if (GlobalData.BookCatalog.ContainsKey(_currentBook.InventoryNumber))
                {
                    GlobalData.BookCatalog[_currentBook.InventoryNumber] = _currentBook;
                }

                MessageBox.Show("Book updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message);
            }
        }
    }
}
