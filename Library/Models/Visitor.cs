using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Visitor
    {
        public string Barcode { get; set; } 
        public string EGN { get; set; }
        public string Names { get; set; }

        public int GetAge()
        {
            if (EGN.Length < 2) return 0;
            int year = int.Parse(EGN.Substring(0, 2));
            int fullYear = (year < 25) ? 2000 + year : 1900 + year;
            return DateTime.Now.Year - fullYear;
        }

        public string GetGender()
        {
            if (EGN.Length < 9) return "Unknown";
            int digit = int.Parse(EGN.Substring(8, 1));
            return (digit % 2 == 0) ? "Male" : "Female";
        }

    }
}
