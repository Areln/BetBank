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
            return View(_context.RecordOfBets.ToList());
        }

        public IActionResult CreateBet(string _eventId, string _BetType, string _eventTime, string _betTeam) 
        {
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
                tempTickerGames.Add(newTickerGame);
                //}
            }

            betPlacingModel.TickerGames = tempTickerGames;


            //event stuff
            betPlacingModel.BetType = _BetType;
            betPlacingModel.EventDate = DateTime.Parse(_eventTime);
            betPlacingModel.EventId = _eventId;
            betPlacingModel.BetTeam = _betTeam;

            return View("BetPlacement", betPlacingModel);
        }

        //CREATE
        public IActionResult AddBet(RecordOfBets addBet)
        {

            if (ModelState.IsValid)
            {
                _context.RecordOfBets.Add(addBet);
                _context.SaveChanges();

            }
            // Not sure where to return fully
            return RedirectToAction("Home", "Index");

        }

        //UPDATE

        [HttpGet]
        public IActionResult UpdateTask(int id)
        {
            return View(_context.RecordOfBets.Find(id));
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
            return RedirectToAction("Home", "Index");
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
            return RedirectToAction("Home", "Index");
        }


        public IActionResult Something()
        {
            return View();
        }




    }
}