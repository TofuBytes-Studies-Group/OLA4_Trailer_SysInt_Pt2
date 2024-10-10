using System.Net.Http;
using System.Threading.Tasks;

namespace MyTrailer.Application.Services
{
    public class PaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> FetchInsurancePrice(bool isInsured)
        {
            var response = await _httpClient.GetAsync("http://localhost:5201/Price/GetInsurancePrice?isInsured=" + isInsured);
            response.EnsureSuccessStatusCode();

            var priceString = await response.Content.ReadAsStringAsync();
            if (int.TryParse(priceString, out var price))
            {
                return price;
            }

            throw new InvalidOperationException("Invalid price format received from API.");
        }
    }
}