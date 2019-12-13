using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BetBank.Models;
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
        public async Task<IActionResult> GetNFLSeasonStats(int id)
        {

            var response = await _client.GetAsync($"scores/json/TeamSeasonStats/{id}");
            var content = await response.Content.ReadAsAsync<NFLSeasonStatsRoot>();
            return View(content);

        }
        // what do we do with the data now that we can get it?       
        public IActionResult Index()
        {
            return View();
        }
    }
    // what do we do with the data now that we can get it?       
   
    
}