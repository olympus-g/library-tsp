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

        public static List<Visitor> LoadVisitors()
        {
            List<Visitor> visitors = new List<Visitor>();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM visitors";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Visitor v = new Visitor();
                            v.Barcode = reader["visitor_barcode"].ToString();
                            v.Names = reader["full_name"].ToString();
                            v.EGN = reader["egn"].ToString();
                            visitors.Add(v);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading visitors: " + ex.Message); }
            return visitors;
        }

        public static List<Loan> LoadLoans()
        {
            List<Loan> loans = new List<Loan>();
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM loans";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Loan l = new Loan();
                            l.BookID = Convert.ToInt32(reader["book_id"]);
                            l.VisitorBarcode = reader["visitor_barcode"].ToString();

                            if (reader["date_borrowed"] != DBNull.Value)
                                l.LoanDate = Convert.ToDateTime(reader["date_borrowed"]);

                            if (reader["date_returned"] != DBNull.Value)
                            {
                                l.ReturnDate = Convert.ToDateTime(reader["date_returned"]);
                            }
                            else
                            {
                                l.ReturnDate = DateTime.MinValue;
                            }

                            loans.Add(l);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading loans: " + ex.Message); }
            return loans;
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

        public static void AddLoanToDb(Loan loan)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                
                string query = "INSERT INTO loans (book_id, visitor_barcode, date_borrowed, date_returned) VALUES (@bid, @vbar, @ldate, @rdate)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("bid", loan.BookID);
                    cmd.Parameters.AddWithValue("vbar", int.Parse(loan.VisitorBarcode));
                    cmd.Parameters.AddWithValue("ldate", loan.LoanDate);
                    cmd.Parameters.AddWithValue("rdate", loan.ReturnDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateLoanInDb(Loan loan)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string query = "UPDATE loans SET date_borrowed = @ldate, date_returned = @rdate " +
                               "WHERE book_id = @bid AND visitor_barcode = @vbar";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("ldate", loan.LoanDate);
                    cmd.Parameters.AddWithValue("rdate", loan.ReturnDate);
                    cmd.Parameters.AddWithValue("bid", loan.BookID);
                    cmd.Parameters.AddWithValue("vbar", int.Parse(loan.VisitorBarcode));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteLoanFromDb(int bookId, string visitorBarcode)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "DELETE FROM loans WHERE book_id = @bid AND visitor_barcode = @vbar";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("bid", bookId);
                    cmd.Parameters.AddWithValue("vbar", int.Parse(visitorBarcode));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddVisitorToDb(Visitor visitor)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO visitors (visitor_barcode, full_name, egn) VALUES (@bar, @name, @egn)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("bar", int.Parse(visitor.Barcode));
                    cmd.Parameters.AddWithValue("name", visitor.Names);
                    cmd.Parameters.AddWithValue("egn", visitor.EGN);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateVisitorInDb(Visitor visitor)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "UPDATE visitors SET full_name = @name, egn = @egn WHERE visitor_barcode = @bar";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("bar", int.Parse(visitor.Barcode));
                    cmd.Parameters.AddWithValue("name", visitor.Names);
                    cmd.Parameters.AddWithValue("egn", visitor.EGN);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteVisitorFromDb(string visitorBarcode)
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string query = "DELETE FROM visitors WHERE visitor_barcode = @bar";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("bar", int.Parse(visitorBarcode));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
