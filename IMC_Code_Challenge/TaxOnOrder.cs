using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC_Code_Challenge
{
    public class TaxOnOrder
    {
        public Order Order { get; set; }

        public float OrderTotalAmount { get; set; }
        public float TaxableAmount { get; set; }
        public float AmountToCollect { get; set; }
        public float Rate { get; set; }
        public bool FreightTaxable { get; set; }
        public string TaxSource { get; set; }

        public Location Jurisdictions { get; set; }
    }
}
