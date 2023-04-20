using Microsoft.AspNetCore.Mvc;
using NewBTC.Areas.Investment;
using System.Text.Json;


namespace NewBTC.Pages.Shared
{
    public class CryptopricesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CryptopricesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Get the prices of Bitcoin, Ethereum, and Binance Coin
            var bitcoinResponse = await client.GetAsync("https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd");
            var bitcoinPrice = await bitcoinResponse.Content.ReadFromJsonAsync<JsonElement>();

            var ethereumResponse = await client.GetAsync("https://api.coingecko.com/api/v3/simple/price?ids=ethereum&vs_currencies=usd");
            var ethereumPrice = await ethereumResponse.Content.ReadFromJsonAsync<JsonElement>();

            var binanceCoinResponse = await client.GetAsync("https://api.coingecko.com/api/v3/simple/price?ids=binancecoin&vs_currencies=usd");
            var binanceCoinPrice = await binanceCoinResponse.Content.ReadFromJsonAsync<JsonElement>();

            // Create CryptoPrice objects with the prices
            var bitcoin = new CryptoPrices
            {
                Name = "Bitcoin",
                PriceUSD = bitcoinPrice.GetProperty("bitcoin").GetProperty("usd").GetDecimal()
            };

            var ethereum = new CryptoPrices
            {
                Name = "Ethereum",
                PriceUSD = ethereumPrice.GetProperty("ethereum").GetProperty("usd").GetDecimal()
            };

            var binanceCoin = new CryptoPrices
            {
                Name = "Binance Coin",
                PriceUSD = binanceCoinPrice.GetProperty("binancecoin").GetProperty("usd").GetDecimal()
            };

            // Pass the CryptoPrice objects to the view
            var cryptoPrices = new CryptoPrices[] { bitcoin, ethereum, binanceCoin };
            return View(cryptoPrices);
        }
    }
}
    