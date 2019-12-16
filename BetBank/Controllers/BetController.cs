using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BetBank.Models;
using BetBank.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetBank.Controllers
{
    [Authorize]
    public class BetController : Controller
    {
        private readonly BetBankDbContext _context;

        public BetController(BetBankDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //CRUD ACTIONS//

        //READ
        public IActionResult ViewOpenBets()
        {
            //Ivo: Modified Method toview open bets by user
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewOpenBetsModel model = new ViewOpenBetsModel();
            foreach (var item in _context.RecordOfBets.Where(b => b.UserId == id).ToList())
            {
                if (item.BetTeam)
                {
                    model.recordOfBets.Add($"{_context.EventsTable.Find(item.EventId).HomeTeam}:{item.BetId}", item);
                }
                else
                {
                    model.recordOfBets.Add($"{_context.EventsTable.Find(item.EventId).AwayTeam}:{item.BetId}", item);
                }

            }
            return View(model);
        }
        

        public IActionResult CreateBet(string _eventId, string _BetType, string _eventTime, string _betTeam, string _odd) 
        {
            //Ivo: Do we need the id of the user anywhere here?
            BetPlacingModel betPlacingModel = new BetPlacingModel();
            //ticker stuff
            List<TickerGames> tempTickerGames = new List<TickerGames>();
            foreach (EventsTable item in _context.EventsTable.ToList())
            {
                //if (item.EventDate.Date > DateTime.Today.Date)
                //{
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
                tempTickerGames.Add(newTickerGame);
                //}
            }

            betPlacingModel.TickerGames = tempTickerGames;


            //event info
            betPlacingModel.BetType = _BetType;
            betPlacingModel.EventDate = DateTime.Parse(_eventTime);
            betPlacingModel.Event = _context.EventsTable.Find(_eventId);
            betPlacingModel.Odd = _odd;
            betPlacingModel.BetTeam = _betTeam;


            return View("BetPlacement", betPlacingModel);
        }

        //CREATE
        public IActionResult AddBet(RecordOfBets addBet)
        {
            UserData use = new UserData();

            foreach (UserData userOne in _context.UserData.ToList())
            {
                if (userOne.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                {
                    use = userOne;
                }

            }

            if (ModelState.IsValid)
            {
                if (addBet.AmountBet <= use.BetBankBalance)
                {
                    _context.RecordOfBets.Add(addBet);
                    _context.SaveChanges();
                }
                else
                {
                    ViewBag.error = "Not enough money in account to place bet! Enter new amount.";
                    return RedirectToAction("BetPlacement");
                }
              

            }
            // Not sure where to return fully
            return RedirectToAction("ViewOpenBets");

        }

        //UPDATE

        [HttpGet]
        public IActionResult UpdateBet(int id)
        {
            RecordOfBets bet = _context.RecordOfBets.Find(id);
            EventsTable betEvent = _context.EventsTable.Find(bet.EventId);
            
            //gets the points spread and use a random number gen to get winner and set score for the eventstable
            betEvent.EventStatus = "STATUS_FINAL";
            
            //gets base score for both teams, used for all lines
            Random random = new Random();
            var baseScore = random.Next(0, 35);
            betEvent.HomeScore = (int)(baseScore + (MathF.Abs((float)betEvent.PointSpreadHomeMoney) * random.NextDouble()));
            betEvent.AwayScore = (int)(baseScore + (MathF.Abs((float)betEvent.PointSpreadAwayMoney) * random.NextDouble()));
            
            _context.EventsTable.Update(betEvent);
            _context.SaveChanges();            //activate BetPayoutCheck();
            
            return RedirectToAction("PayoutCheck", "Home", new { eventId = betEvent.EventId });
        }

        [HttpPost]
        public IActionResult UpdateBetRecord(RecordOfBets updateBet)
        {
            if (ModelState.IsValid)
            {
                RecordOfBets oldBet = _context.RecordOfBets.Find(updateBet.BetId);
                oldBet.EventId = updateBet.EventId;
                oldBet.BetType = updateBet.BetType;
                oldBet.EventDate = updateBet.EventDate;
                oldBet.AmountBet = updateBet.AmountBet;

                _context.Entry(oldBet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(oldBet);
                _context.SaveChanges();

            }
            // not sure of the view to send to; would prefer to be able to do this on the home page.
            // if we cannot i would assume this would go to a view that shows all bets
            return RedirectToAction("ViewOpenBets");
        }

        //DELETE
        public IActionResult DeleteBet(int id)
        {
            var selectedBet = _context.RecordOfBets.Find(id);
            if(selectedBet != null)
            {
                _context.RecordOfBets.Remove(selectedBet);
                _context.SaveChanges();
            }
            return RedirectToAction("ViewOpenBets");
        }


        public IActionResult Something()
        {
            return View();
        }




    }
}