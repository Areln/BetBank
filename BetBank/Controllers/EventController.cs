using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            List<TickerGames> temptickergames = new List<TickerGames>();
            //populate the events table with NBA data
            if (_context.EventsTable.Count() < 1)
            {
                return RedirectToAction("GetSportEvents", "API", 4);
            }

            //populate Events table object with NBA data
            List<EventsTable> tempLeagueEvents = new List<EventsTable>();
            foreach (EventsTable item in _context.EventsTable.ToList())
            {
                if (item.SportId == 4)
                {
                    tempLeagueEvents.Add(item);
                }
            }
            List<string> beteventids = new List<string>();
            foreach (RecordOfBets item in _context.RecordOfBets.Where(b => b.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList())
            {
                beteventids.Add(item.EventId);
            }
            //tickergames
            foreach (EventsTable events in _context.EventsTable.ToList())
            {
                if (events.SportId == 2)
                {
                    continue;
                }
                TickerGames newTickerGame = new TickerGames();
                if (beteventids.Contains(events.EventId))
                {
                    newTickerGame.FavoritedEvent = true;
                }
                else
                {
                    newTickerGame.FavoritedEvent = false;
                }

                newTickerGame.HomeTeam = events.HomeTeam;
                newTickerGame.AwayTeam = events.AwayTeam;
                newTickerGame.TimeOfEvent = events.EventDate;
                newTickerGame.EventId = events.EventId;
                newTickerGame.HomeSpread = (float)events.SpreadHome;
                newTickerGame.AwaySpread = (float)events.SpreadAway;
                newTickerGame.HomeMoneyline = (float)events.MoneyLineHome;
                newTickerGame.AwayMoneyline = (float)events.MoneyLineAway;
                newTickerGame.HomeTotal = (float)events.TotalHome;
                newTickerGame.AwayTotal = (float)events.TotalAway;
                newTickerGame.HomeSpreadMoneyLine = (float)events.PointSpreadHomeMoney;
                newTickerGame.AwaySpreadMoneyLine = (float)events.PointSpreadAwayMoney;
                newTickerGame.HomeTotalMoneyLine = (float)events.TotalUnderMoney;
                newTickerGame.AwayTotalMoneyLine = (float)events.TotalUnderMoney;
                if (!temptickergames.Contains(newTickerGame))
                {
                    temptickergames.Add(newTickerGame);
                }
            }

            leagueModel.tickerGames = temptickergames;

            leagueModel.LeagueName = "NBA";
            leagueModel.LeaguesEvents = tempLeagueEvents;
            return View(leagueModel);
        }

        public IActionResult NFLIndex()
        {
            //initialize League model
            LeagueEventsModel leagueModel = new LeagueEventsModel();
            List<TickerGames> temptickergames = new List<TickerGames>();
            //populate the events table with NFL data
            if (_context.EventsTable.Count() < 1)
            {
                return RedirectToAction("GetSportEvents", "API", 4);
            }

            //populate Events table object with NFL data
            List<EventsTable> tempLeagueEvents = new List<EventsTable>();
            foreach (EventsTable item in _context.EventsTable.ToList())
            {
                if (item.SportId == 2)
                {
                    tempLeagueEvents.Add(item);
                }
            }
            List<string> beteventids = new List<string>();
            foreach (RecordOfBets item in _context.RecordOfBets.Where(b => b.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList())
            {
                beteventids.Add(item.EventId);
            }
            //tickergames
            foreach (EventsTable events in _context.EventsTable.ToList())
            {
                if (events.SportId == 4)
                {
                    continue;
                }
                TickerGames newTickerGame = new TickerGames();
                if (beteventids.Contains(events.EventId))
                {
                    newTickerGame.FavoritedEvent = true;
                }
                else 
                {
                    newTickerGame.FavoritedEvent = false;
                }

                newTickerGame.HomeTeam = events.HomeTeam;
                newTickerGame.AwayTeam = events.AwayTeam;
                newTickerGame.TimeOfEvent = events.EventDate;
                newTickerGame.EventId = events.EventId;
                newTickerGame.HomeSpread = (float)events.SpreadHome;
                newTickerGame.AwaySpread = (float)events.SpreadAway;
                newTickerGame.HomeMoneyline = (float)events.MoneyLineHome;
                newTickerGame.AwayMoneyline = (float)events.MoneyLineAway;
                newTickerGame.HomeTotal = (float)events.TotalHome;
                newTickerGame.AwayTotal = (float)events.TotalAway;
                newTickerGame.HomeSpreadMoneyLine = (float)events.PointSpreadHomeMoney;
                newTickerGame.AwaySpreadMoneyLine = (float)events.PointSpreadAwayMoney;
                newTickerGame.HomeTotalMoneyLine = (float)events.TotalUnderMoney;
                newTickerGame.AwayTotalMoneyLine = (float)events.TotalUnderMoney;
                if (!temptickergames.Contains(newTickerGame))
                {
                    temptickergames.Add(newTickerGame);
                }
            }

            leagueModel.tickerGames = temptickergames;
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