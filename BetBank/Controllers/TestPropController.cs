using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace BetBank.Controllers
{
    public class TestPropController : Controller
    {
        private readonly string _SportsDataApiKey = "28d87edbc0044d1284e37cb63902679f";

        private readonly HttpClient _client;

        public TestPropController(IHttpClientFactory client)
        {
            _client = client.CreateClient();
            _client.BaseAddress = new Uri("https://api.sportsdata.io/v3/nfl/");
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key:", _SportsDataApiKey);


        }
        // what do we do with the data now that we can get it?       
        public IActionResult Index()
        {
            return View();
        }
    }
}