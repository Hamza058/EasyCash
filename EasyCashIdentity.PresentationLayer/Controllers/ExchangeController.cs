using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "4fb34c8938mshb6c50b30bf4d2b9p13ea64jsne874dacfdea5" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.UsdToTry = body.Substring(0, 5);
            }
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=TRY&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "4fb34c8938mshb6c50b30bf4d2b9p13ea64jsne874dacfdea5" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request2))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.EurToTry = body.Substring(0, 5);
            }
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=TRY&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "4fb34c8938mshb6c50b30bf4d2b9p13ea64jsne874dacfdea5" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request3))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.GbpToTry = body.Substring(0,5);
            }
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=EUR&q=1.0"),
                Headers =
                {
                    { "X-RapidAPI-Key", "4fb34c8938mshb6c50b30bf4d2b9p13ea64jsne874dacfdea5" },
                    { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request4))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.UsdToEur = body.Substring(0, 5);
            }

            return View();
        }
    }
}
