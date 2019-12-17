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

            //populate the events table with NBA data
            if (_context.EventsTable.Count() < 1)
            {
                return RedirectToAction("GetSportEvents", "API", 4);
            }

            List<TickerGames> tempTickerGames = new List<TickerGames>();

            //ticker games we have bets on
            foreach (RecordOfBets bets in _context.RecordOfBets.Where(b => b.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList())
            {
                TickerGames newTickerGame = new TickerGames();
                EventsTable item = _context.EventsTable.Find(bets.EventId);

                if (bets.EventId == item.EventId)
                {
                    newTickerGame.FavoritedEvent = true;
                }
                
                newTickerGame.HomeTeam = item.HomeTeam;
                newTickerGame.AwayTeam = item.AwayTeam;
                newTickerGame.TimeOfEvent = item.EventDate;
                newTickerGame.EventId = item.EventId;
                newTickerGame.HomeSpread = (float)item.SpreadHome;
                newTickerGame.AwaySpread = (float)item.SpreadAway;
                newTickerGame.HomeMoneyline = (float)item.MoneyLineHome;
                newTickerGame.AwayMoneyline = (float)item.MoneyLineAway;
                newTickerGame.HomeTotal = (float)item.TotalHome;
                newTickerGame.AwayTotal = (float)item.TotalAway;
                newTickerGame.HomeSpreadMoneyLine = (float)item.PointSpreadHomeMoney;
                newTickerGame.AwaySpreadMoneyLine = (float)item.PointSpreadAwayMoney;
                newTickerGame.HomeTotalMoneyLine = (float)item.TotalUnderMoney;
                newTickerGame.AwayTotalMoneyLine = (float)item.TotalUnderMoney;
                if (!tempTickerGames.Contains(newTickerGame))
                {
                    tempTickerGames.Add(newTickerGame);
                }
            }

            foreach (EventsTable item in _context.EventsTable.ToList())
            {
                if (item.SportId == 4)
                {
                    TickerGames newTickerGame = new TickerGames();
                    newTickerGame.HomeTeam = item.HomeTeam;
                    newTickerGame.AwayTeam = item.AwayTeam;

                    newTickerGame.TimeOfEvent = item.EventDate;
                    newTickerGame.EventId = item.EventId;

                    newTickerGame.HomeSpread = (float)item.SpreadHome;
                    newTickerGame.AwaySpread = (float)item.SpreadAway;
                    newTickerGame.HomeMoneyline = (float)item.MoneyLineHome;
                    newTickerGame.AwayMoneyline = (float)item.MoneyLineAway;
                    newTickerGame.HomeTotal = (float)item.TotalHome;
                    newTickerGame.AwayTotal = (float)item.TotalAway;
                    newTickerGame.HomeSpreadMoneyLine = (float)item.PointSpreadHomeMoney;
                    newTickerGame.AwaySpreadMoneyLine = (float)item.PointSpreadAwayMoney;
                    newTickerGame.HomeTotalMoneyLine = (float)item.TotalUnderMoney;
                    newTickerGame.AwayTotalMoneyLine = (float)item.TotalUnderMoney;

                    if (!tempTickerGames.Contains(newTickerGame))
                    {
                        tempTickerGames.Add(newTickerGame);
                    }
                }
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
            leagueModel.tickerGames = tempTickerGames;
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

            List<TickerGames> tempTickerGames = new List<TickerGames>();

            //ticker games we have bets on
            foreach (RecordOfBets bets in _context.RecordOfBets.Where(b => b.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList())
            {
                TickerGames newTickerGame = new TickerGames();
                EventsTable item = _context.EventsTable.Find(bets.EventId);

                if (bets.EventId == item.EventId)
                {
                    newTickerGame.FavoritedEvent = true;
                }

                newTickerGame.HomeTeam = item.HomeTeam;
                newTickerGame.AwayTeam = item.AwayTeam;
                newTickerGame.TimeOfEvent = item.EventDate;
                newTickerGame.EventId = item.EventId;
                newTickerGame.HomeSpread = (float)item.SpreadHome;
                newTickerGame.AwaySpread = (float)item.SpreadAway;
                newTickerGame.HomeMoneyline = (float)item.MoneyLineHome;
                newTickerGame.AwayMoneyline = (float)item.MoneyLineAway;
                newTickerGame.HomeTotal = (float)item.TotalHome;
                newTickerGame.AwayTotal = (float)item.TotalAway;
                newTickerGame.HomeSpreadMoneyLine = (float)item.PointSpreadHomeMoney;
                newTickerGame.AwaySpreadMoneyLine = (float)item.PointSpreadAwayMoney;
                newTickerGame.HomeTotalMoneyLine = (float)item.TotalUnderMoney;
                newTickerGame.AwayTotalMoneyLine = (float)item.TotalUnderMoney;
                if (!tempTickerGames.Contains(newTickerGame))
                {
                    tempTickerGames.Add(newTickerGame);
                }
            }

            foreach (EventsTable item in _context.EventsTable.ToList())
            {
                if (item.SportId == 2)
                {
                    TickerGames newTickerGame = new TickerGames();
                    newTickerGame.HomeTeam = item.HomeTeam;
                    newTickerGame.AwayTeam = item.AwayTeam;

                    newTickerGame.TimeOfEvent = item.EventDate;
                    newTickerGame.EventId = item.EventId;

                    newTickerGame.HomeSpread = (float)item.SpreadHome;
                    newTickerGame.AwaySpread = (float)item.SpreadAway;
                    newTickerGame.HomeMoneyline = (float)item.MoneyLineHome;
                    newTickerGame.AwayMoneyline = (float)item.MoneyLineAway;
                    newTickerGame.HomeTotal = (float)item.TotalHome;
                    newTickerGame.AwayTotal = (float)item.TotalAway;
                    newTickerGame.HomeSpreadMoneyLine = (float)item.PointSpreadHomeMoney;
                    newTickerGame.AwaySpreadMoneyLine = (float)item.PointSpreadAwayMoney;
                    newTickerGame.HomeTotalMoneyLine = (float)item.TotalUnderMoney;
                    newTickerGame.AwayTotalMoneyLine = (float)item.TotalUnderMoney;

                    if (!tempTickerGames.Contains(newTickerGame))
                    {
                        tempTickerGames.Add(newTickerGame);
                    }
                }
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
            leagueModel.tickerGames = tempTickerGames;
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