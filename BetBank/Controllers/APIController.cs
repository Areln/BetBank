﻿using System;
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
        public async Task<IActionResult> GetSportEvents(int id)
        {
            var response = await _client.GetAsync($"/sports/1/events?include=scores");
            var content = await response.Content.ReadAsAsync<EventsRootobject>();

            PopulateSportEvents(content);

            return View("Index");
        }

        public void PopulateSportEvents(EventsRootobject eventsObject)
        {
            foreach (Event item in eventsObject.events)
            {
                EventsTable tempEventRecord = new EventsTable(item.event_id, item.sport_id, item.event_date, item.score.event_status, item.rotation_number_home, item.score.score_home, item.rotation_number_away, item.score.score_away, TimeSpan.Parse(item.score.game_clock.ToString()), item.lines._1.moneyline.moneyline_home, item.lines._1.moneyline.moneyline_away, item.lines._1.spread.point_spread_home, item.lines._1.spread.point_spread_away, item.lines._1.total.total_over, item.lines._1.total.total_under, item.lines._1.line_id);
                _context.EventsTable.Add(tempEventRecord);
                _context.SaveChanges();
            }
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}