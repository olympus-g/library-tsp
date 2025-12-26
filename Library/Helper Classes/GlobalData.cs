using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class GlobalData
    {
        public static List<Book> AllBooks = new List<Book>();
        public static Dictionary<int, Book> BookCatalog = new Dictionary<int, Book>();

        public static List<Visitor> AllVisitors = new List<Visitor>();

        public static List<Loan> AllLoans = new List<Loan>();
    }
}
