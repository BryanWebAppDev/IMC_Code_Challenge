using IMC_Code_Challenge;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace IMC_Code_Challenge_Tests
{
    public class TaxServiceTests
    {
        private TaxService taxService;
        private Location locationForTaxRateTest;
        private Order orderForCalculateTaxTest;

        [SetUp]
        public void Setup()
        {
            taxService = new TaxService(new TaxJarTaxCalculator());
            locationForTaxRateTest = new Location
            {
                Zip = "90404",
                City = "Santa Monica",
                State = "CA",
                Country = "US",
            };
            orderForCalculateTaxTest = new Order
            {
                FromLocation = new Location
                {
                    Country = "US",
                    Zip = "92093",
                    State = "CA",
                    City = "La Joila",
                    Street = "9500 Gilman Drive",
                },
                ToLocation = new Location
                {
                    Country = "US",
                    Zip = "90002",
                    State = "CA",
                    City = "Los Angeles",
                    Street = "1335 E 103rd St"
                },
                Amount = 15F,
                Shipping = 1.5F,
            };
        }

        [Test]
        public async Task GetTaxRatesForLocation_Test()
        {
            TaxRates result;
            try
            {
                result = await taxService.TaxRatesForLocation(locationForTaxRateTest);
            }
            catch
            {
                Assert.Fail("Should be able to run without errors.");
                return;
            }

            Assert.AreEqual(result.CountryRate, 0.0F);
            Assert.AreEqual(result.StateRate, 0.0F);
            Assert.AreEqual(result.CountyRate, 0.0F);
            Assert.AreEqual(result.CityRate, 0.0F);
            Assert.AreEqual(result.CombinedDistrictRate, 0.0F);
            Assert.AreEqual(result.CombinedRate, 0.0625F);
            Assert.That(!result.FreightTaxable);
        }

        [Test]
        public async Task CalculateTaxesForOrder_Test()
        {
            TaxOnOrder result;
            try
            {
                result = await taxService.SalesTaxForOrder(orderForCalculateTaxTest);
            }
            catch
            {
                Assert.Fail("Should be able to run without errors.");
                return;
            }

            Assert.AreEqual(result.AmountToCollect, 1.43F);
            Assert.AreEqual(result.OrderTotalAmount, 16.5F);
            Assert.AreEqual(result.TaxableAmount, 15F);
            Assert.AreEqual(result.Rate, 0.095F);
            Assert.AreEqual(result.TaxSource,"destination");
            Assert.That(!result.FreightTaxable);
            Assert.AreEqual(result.Jurisdictions.Country, "US");
            Assert.AreEqual(result.Jurisdictions.State, "CA");
            Assert.AreEqual(result.Jurisdictions.County, "LOS ANGELES COUNTY");
            Assert.AreEqual(result.Jurisdictions.City, "LOS ANGELES");
        }

    }
}