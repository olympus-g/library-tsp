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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Book newBook = new Book();
                newBook.InventoryNumber = int.Parse(txtInventory.Text);
                newBook.Title = txtTitle.Text;
                newBook.Author = txtAuthor.Text;
                newBook.Year = int.Parse(txtYear.Text);
                newBook.Genre = txtGenre.Text;

                DatabaseHelper.AddBookToDb(newBook);

                GlobalData.AllBooks.Add(newBook);
                GlobalData.BookCatalog.Add(newBook.InventoryNumber, newBook);

                MessageBox.Show("Book added successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
