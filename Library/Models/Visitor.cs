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
            // Add EGN parsing logic here later
            return 20;
        }
    }
}
