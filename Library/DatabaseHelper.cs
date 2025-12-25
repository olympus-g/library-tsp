using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Library
{
    public static class DatabaseHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;
        
        public static List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM books"; 

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book b = new Book();
                            b.InventoryNumber = Convert.ToInt32(reader["inventory_number"]);
                            b.Title = reader["title"].ToString();
                            b.Author = reader["author"].ToString();
                            b.Year = Convert.ToInt32(reader["publication_year"]);
                            b.Genre = reader["genre"].ToString();

                            books.Add(b);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }

            return books;
        }

        public static void AddBookToDb(Book book)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO books (inventory_number, title, author, publication_year, genre) VALUES (@inv, @title, @auth, @yr, @gen)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("inv", book.InventoryNumber);
                    cmd.Parameters.AddWithValue("title", book.Title);
                    cmd.Parameters.AddWithValue("auth", book.Author);
                    cmd.Parameters.AddWithValue("yr", book.Year);
                    cmd.Parameters.AddWithValue("gen", book.Genre);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateBookInDb(Book book)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "UPDATE books SET title = @title, author = @auth, publication_year = @yr, genre = @gen WHERE inventory_number = @inv";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("inv", book.InventoryNumber);

                    cmd.Parameters.AddWithValue("title", book.Title);
                    cmd.Parameters.AddWithValue("auth", book.Author);
                    cmd.Parameters.AddWithValue("yr", book.Year);
                    cmd.Parameters.AddWithValue("gen", book.Genre);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteBookFromDb(int inventoryNumber)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "DELETE FROM books WHERE inventory_number = @inv";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("inv", inventoryNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
