using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJarApi
{
    public class Breakdown
    {

        public float taxable_amount { get; set; }
        public float tax_collectable { get; set; }
        public float combined_tax_rate { get; set; }
        public float state_taxable_amount { get; set; }
        public float state_tax_rate { get; set; }
        public float state_tax_collectable { get; set; }
        public float county_taxable_amount { get; set; }
        public float county_tax_rate { get; set; }
        public float county_tax_collectable { get; set; }
        public float city_taxable_amount { get; set; }
        public float city_tax_rate { get; set; }
        public float city_tax_collectable { get; set; }
        public float special_district_taxable_amount { get; set; }
        public float special_tax_rate { get; set; }
        public float special_district_tax_collectable { get; set; }
        public float gst_taxable_amount { get; set; }
        public float gst_tax_rate { get; set; }
        public float gst { get; set; }
        public float pst_taxable_amount { get; set; }
        public float pst_tax_rate { get; set; }
        public float pst { get; set; }
        public float qst_taxable_amount { get; set; }
        public float qst_tax_rate { get; set; }
        public float qst { get; set; }
        public float country_taxable_amount { get; set; }
        public float country_tax_rate { get; set; }
        public float country_tax_collectable { get; set; }

        public string id { get; set; } //only used by line items

        public Breakdown shipping { get; set; }
        public List<Breakdown> line_items { get; set; }

    }
}
