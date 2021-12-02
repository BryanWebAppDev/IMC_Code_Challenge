using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC_Code_Challenge
{
    public class TaxRates
    {

        public float CountryRate { get; set; }
        public float StateRate { get; set; }
        public float CountyRate { get; set; }
        public float CityRate { get; set; }
        public float CombinedDistrictRate { get; set; }
        public float CombinedRate { get; set; }
        public bool FreightTaxable { get; set; }

        public Location Location { get; set; }

    }
}
