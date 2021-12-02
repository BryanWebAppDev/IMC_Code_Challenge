using System;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;

namespace TaxJarApi
{
    public class TaxJarClient
    {

        private readonly RestClient restClient = new RestClient();

        static readonly string TaxRatesGetEndpoint = "https://api.taxjar.com/v2/rates/:zip";
        static readonly string SalesTaxPostEndpoint = "https://api.taxjar.com/v2/taxes";

        private readonly string apiKey;

        public TaxJarClient(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<TaxRatesForLocationResponse> GetTaxRatesForLocation(string zip, string country = "US", string state = null, string city = null, string street = null)
        {

            var request = new RestRequest(TaxRatesGetEndpoint, Method.GET);

            request.AddHeader("Authorization", "Bearer " + apiKey);

            request.AddQueryParameter("zip", zip);
            request.AddQueryParameter("country", country);
            request.AddQueryParameter("state", state);
            request.AddQueryParameter("city", city);
            request.AddQueryParameter("street", street);

            IRestResponse response = new RestResponse();
            try
            {
                response = await restClient.ExecuteAsync(request);

                if (response.ResponseStatus == ResponseStatus.Error)
                {

                }
                else if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.Content);
                }

            }
            catch (Exception e)
            {

            }

            return JsonConvert.DeserializeObject<TaxRatesForLocationResponse>(response.Content);
        }

        public async Task<SalesTaxForOrderResponse> CalculateTaxesForOrder(OrderToCalculate orderToCalculate)
        {

            var request = new RestRequest(SalesTaxPostEndpoint, Method.POST);

            request.AddHeader("Authorization", "Bearer " + apiKey);

            var jsonPayload = JsonConvert.SerializeObject(orderToCalculate,
                            Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });

            request.AddParameter("application/json; charset=utf-8", jsonPayload, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = new RestResponse();
            try
            {
                response = await restClient.ExecuteAsync(request);

                if (response.ResponseStatus == ResponseStatus.Error)
                {

                }
                else if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.Content);
                }

            }
            catch (Exception e)
            {

            }

            return JsonConvert.DeserializeObject<SalesTaxForOrderResponse>(response.Content);
        }

    }
}
