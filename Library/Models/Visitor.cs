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
            if (string.IsNullOrEmpty(EGN) || EGN.Length != 10) return 0;

            int yy;
            int mm;

            if (!int.TryParse(EGN.Substring(0, 2), out yy)) return 0;
            if (!int.TryParse(EGN.Substring(2, 2), out mm)) return 0;

            int fullYear = 0;

            if (mm >= 41 && mm <= 52)
            {
                fullYear = 2000 + yy;
            }
            else if (mm >= 21 && mm <= 32)
            {
                fullYear = 1800 + yy;
            }
            else if (mm >= 1 && mm <= 12)
            {
                fullYear = 1900 + yy;
            }
            else
            {
                return 0;
            }

            int age = DateTime.Now.Year - fullYear;
            return age < 0 ? 0 : age;
        }

        public string GetGender()
        {
            if (string.IsNullOrEmpty(EGN) || EGN.Length != 10) return "Unknown";
            int digit = int.Parse(EGN.Substring(8, 1));
            return (digit % 2 == 0) ? "Male" : "Female";
        }

    }
}
