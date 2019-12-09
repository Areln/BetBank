using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BetBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetBank.Controllers
{
    public class APIController : Controller
    {
        private readonly string _RundownApiKey = "83f9dc75d7mshc58319d83f8c5d3p1ed869jsn8db302c839eb";
        private readonly HttpClient _client;
        private readonly BetBankDbContext _context;

        public APIController(IHttpClientFactory httpClientFactory, BetBankDbContext context)
        {
            _context = context;
            _client = httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri("https://therundown-therundown-v1.p.rapidapi.com");
            _client.DefaultRequestHeaders.Add("x-rapidapi-host", "therundown-therundown-v1.p.rapidapi.com");
            _client.DefaultRequestHeaders.Add("x-rapidapi-key", _RundownApiKey);
        }


        public async Task<ActionResult> GetSportEvents(int id)
        {

            var response = await _client.GetAsync($"/sports/{id}/events");
            var content = await response.Content.ReadAsAsync<EventsRootobject>();
            return View(content);
        }

        public void PopulateSportEvents()
        {

        }




        public IActionResult Index()
        {
            return View();
        }
    }
}