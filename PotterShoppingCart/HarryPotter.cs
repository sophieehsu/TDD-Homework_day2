using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class HarryPotter
    {
        public int Vol_1 { get; set; }
        public int Vol_2 { get; set; }
        public int Vol_3 { get; set; }
        public int Vol_4 { get; set; }
        public int Vol_5 { get; set; }

        public double BookPrice { get { return 100; } }
    }

    public class DiscountBuy
    {
        public string BookVol { get; set; }
        public double BookCount { get; set; }
    }
}
