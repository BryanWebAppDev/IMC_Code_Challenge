using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC_Code_Challenge
{
    public interface ITaxCalculator
    {
        public Task<TaxRates> GetTaxRatesForLocation(Location location);

        public Task<TaxOnOrder> CalculateTaxesForOrder(Order order);
    }
}
