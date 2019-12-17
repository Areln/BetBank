using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetBank.Models;
using BetBank.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BetBank.Controllers
{
    public class EventController : Controller
    {
        private readonly BetBankDbContext _context;

        public EventController(BetBankDbContext context)
        {
            _context = context;
        }
        public IActionResult ViewEvent(string eventId) 
        {
            EventsTable temp = _context.EventsTable.Find(eventId);
            return View(temp);
        }
        public IActionResult NBAIndex()
        {
            //initialize League model
            LeagueEventsModel leagueModel = new LeagueEventsModel();

            //populate the events table with NBA data
            if (_context.EventsTable.Count() < 1)
            {
                return RedirectToAction("GetSportEvents", "API", 4);
            }

            //populate Events table object with NBA data
            List<EventsTable> tempLeagueEvents = new List<EventsTable>();
            foreach (EventsTable item in _context.EventsTable.ToList())
            {
                //if (item.EventDate.Date > DateTime.Today.Date)
                //{

                if (item.SportId == 4)
                {
                    tempLeagueEvents.Add(item);
                }
                //}
            }

            leagueModel.LeagueName = "NBA";
            leagueModel.LeaguesEvents = tempLeagueEvents;
            return View(leagueModel);
        }

        public IActionResult NFLIndex()
        {
            //initialize League model
            LeagueEventsModel leagueModel = new LeagueEventsModel();

            //populate the events table with NFL data
            if (_context.EventsTable.Count() < 1)
            {
                return RedirectToAction("GetSportEvents", "API", 4);
            }

            //populate Events table object with NFL data
            List<EventsTable> tempLeagueEvents = new List<EventsTable>();
            foreach (EventsTable item in _context.EventsTable.ToList())
            {
                //if (item.EventDate.Date > DateTime.Today.Date)
                //{
                if (item.SportId == 2)
                {
                    tempLeagueEvents.Add(item);
                }
                //}
            }


            leagueModel.LeagueName = "NFL";
            leagueModel.LeaguesEvents = tempLeagueEvents;
            return View(leagueModel);
        }

        public IActionResult ESportsIndex()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}