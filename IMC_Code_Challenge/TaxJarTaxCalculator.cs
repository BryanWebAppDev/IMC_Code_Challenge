using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxJarApi;

namespace IMC_Code_Challenge
{
    public class TaxJarTaxCalculator : ITaxCalculator
    {
        private readonly TaxJarClient taxJarClient;

        public TaxJarTaxCalculator()
        {
            taxJarClient = new TaxJarClient("5da2f821eee4035db4771edab942a4cc"); //Note: in a real solution, this would be pulled from configuration instead of hardcoded
        }

        public async Task<TaxRates> GetTaxRatesForLocation(Location loc)
        {
            var response = await taxJarClient.GetTaxRatesForLocation(loc.Zip, loc.Country, loc.State, loc.City, loc.Street);
            var taxRates = new TaxRates
            {
                Location = loc,
                CityRate = response.rate.city_rate,
                CountyRate = response.rate.county_rate,
                CountryRate = response.rate.country_rate,
                CombinedDistrictRate = response.rate.combined_district_rate,
                CombinedRate = response.rate.combined_rate,
                FreightTaxable = response.rate.freight_taxable,
            };

            return taxRates;
        }

        public async Task<TaxOnOrder> CalculateTaxesForOrder(Order order)
        {
            var response = await taxJarClient.CalculateTaxesForOrder(new OrderToCalculate
            {
                from_country = order.FromLocation.Country,
                from_state = order.FromLocation.State,
                from_city = order.FromLocation.City,
                from_zip = order.FromLocation.Zip,
                from_street = order.FromLocation.Street,
                to_country = order.ToLocation.Country,
                to_state = order.ToLocation.State,
                to_city = order.ToLocation.City,
                to_zip = order.ToLocation.Zip,
                to_street = order.ToLocation.Street,
                amount = order.Amount,
                shipping = order.Shipping,
                customer_id = order.CustomerId,
                exemption_type = order.ExemptionType,
            });
            var taxes = new TaxOnOrder
            {
                Order = order,
                OrderTotalAmount = response.tax.order_total_amount,
                TaxableAmount = response.tax.taxable_amount,
                AmountToCollect = response.tax.amount_to_collect,
                Rate = response.tax.rate,
                FreightTaxable = response.tax.freight_taxable,
                TaxSource = response.tax.tax_source,
                Jurisdictions = new Location
                {
                    Country = response.tax.jurisdictions.country,
                    City = response.tax.jurisdictions.city,
                    State = response.tax.jurisdictions.state,
                    County = response.tax.jurisdictions.county,
                },
            };

            return taxes;

        }

    }
}
