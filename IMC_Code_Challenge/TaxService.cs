using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC_Code_Challenge
{
    public class TaxService
    {

        public readonly ITaxCalculator taxCalculator;

        public TaxService(ITaxCalculator taxCalculator)
        {
            this.taxCalculator = taxCalculator;
        }

        public async Task<TaxRates> TaxRatesForLocation(Location location)
        {
            return await taxCalculator.GetTaxRatesForLocation(location);
        }

        public async Task<TaxOnOrder> SalesTaxForOrder(Order order)
        {
            return await taxCalculator.CalculateTaxesForOrder(order);
        }

    }
}
