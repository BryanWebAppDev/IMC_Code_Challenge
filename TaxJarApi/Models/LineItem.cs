using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJarApi
{
    public class LineItem
    {

        public string id { get; set; }
        public int quantity { get; set; }
        public string product_tax_code { get; set; }
        public float unit_price { get; set; }
        public float discount { get; set; }
    }
}
