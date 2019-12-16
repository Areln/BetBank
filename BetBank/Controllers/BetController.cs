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
            BetPlacingModel ViewHistory = new BetPlacingModel();
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var betHistoy = _context.RecordOfBets.Where(b => b.UserId == id).ToList();
            ViewHistory.UserBetHistory = betHistoy;
            return View();
        }
        //CRUD ACTIONS//

        //READ
        public IActionResult ViewOpenBets()
        {
            //Ivo: Modified Method toview open bets by user
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(_context.RecordOfBets.Where(b => b.UserId == id).ToList());
        }
        
        public IActionResult CreateBet(string _eventId, string _BetType, string _eventTime, string _betTeam) 
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
                tempTickerGames.Add(newTickerGame);
                //}
            }

            betPlacingModel.TickerGames = tempTickerGames;


            //event info
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
            return RedirectToAction("ViewOpenBets");

        }

        //UPDATE

        [HttpGet]
        public IActionResult UpdateBet(int id)
        {
            //Ivo: added code for userId
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Id = userId;
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