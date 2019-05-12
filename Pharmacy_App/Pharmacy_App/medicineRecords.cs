using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_App
{
    class medicineRecords
    {
        public string name { get; set; }
        public string category { get; set; }
        public double mg { get; set; }
        public string experationDate { get; set; }
        public int amount { get; set; }
        public double cost { get; set; }
        public double price { get; set; }
        public string status { get; set; }
        public string updatedDate { get; set; }
        public string imagePath { get; set; }
        public ulong barcodeNo { get; set; }
    }
}
