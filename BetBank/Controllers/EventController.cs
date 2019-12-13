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
                    EventsTable leagueEvents = new EventsTable();
                    leagueEvents.HomeTeam = item.HomeTeam;
                    leagueEvents.AwayTeam = item.AwayTeam;
                    leagueEvents.SpreadHome = item.SpreadHome;
                    leagueEvents.SpreadAway = item.SpreadAway;
                    leagueEvents.MoneyLineHome = item.MoneyLineHome;
                    leagueEvents.MoneyLineAway = item.MoneyLineAway;
                    leagueEvents.TotalHome = item.TotalHome;
                    leagueEvents.TotalAway = item.TotalAway;
                    leagueEvents.SportId = item.SportId;
                    leagueEvents.EventDate = item.EventDate;
                    leagueEvents.PointSpreadAwayMoney = item.PointSpreadAwayMoney;
                    leagueEvents.PointSpreadHomeMoney = item.PointSpreadHomeMoney;
                    leagueEvents.TotalOverMoney = item.TotalOverMoney;
                    leagueEvents.TotalUnderMoney = item.TotalUnderMoney;
                    tempLeagueEvents.Add(leagueEvents);

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


                    EventsTable leagueEvents = new EventsTable();
                    leagueEvents.HomeTeam = item.HomeTeam;
                    leagueEvents.AwayTeam = item.AwayTeam;
                    leagueEvents.SpreadHome = item.SpreadHome;
                    leagueEvents.SpreadAway = item.SpreadAway;
                    leagueEvents.MoneyLineHome = item.MoneyLineHome;
                    leagueEvents.MoneyLineAway = item.MoneyLineAway;
                    leagueEvents.TotalHome = item.TotalHome;
                    leagueEvents.TotalAway = item.TotalAway;
                    leagueEvents.SportId = item.SportId;
                    leagueEvents.EventDate = item.EventDate;
                    leagueEvents.PointSpreadAwayMoney = item.PointSpreadAwayMoney;
                    leagueEvents.PointSpreadHomeMoney = item.PointSpreadHomeMoney;
                    leagueEvents.TotalOverMoney = item.TotalOverMoney;
                    leagueEvents.TotalUnderMoney = item.TotalUnderMoney;
                    tempLeagueEvents.Add(leagueEvents);

                   
                
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