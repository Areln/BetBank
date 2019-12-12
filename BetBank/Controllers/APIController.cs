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
        private readonly string _RundownApiKey = "3be7761f78mshf4586a9755b5509p18a564jsnd22310709345";
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

        //initial event data gathering to put into database
        

        public IActionResult Index()
        {
            List<char> vowels = new List<char>() { 'a', 'e'};
            string hello = "hello";

            return View();
        }
    }
}