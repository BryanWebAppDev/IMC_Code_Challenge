using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJarApi
{
    public class OrderToCalculate
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string from_city { get; set; }
        public string from_street { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public string to_city { get; set; }
        public string to_street { get; set; }
        public float amount { get; set; }
        public float shipping { get; set; }
        public string customer_id { get; set; }
        public string exemption_type { get; set; }

        public List<NexusAddress> nexus_addresses { get; set; }
        public List<LineItem> line_items { get; set; }
    }
}
