using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC_Code_Challenge
{
    public class Order
    {
        public Location FromLocation { get; set; }
        public Location ToLocation { get; set; }
        public float Amount { get; set; }
        public float Shipping { get; set; }

        public string CustomerId { get; set; }
        public string ExemptionType { get; set; }

    }
}
