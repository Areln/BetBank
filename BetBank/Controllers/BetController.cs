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
        public BetPlacingModel betPlacingModel = new BetPlacingModel();

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
        

        public IActionResult CreateBet(string _eventId, string _BetType, string _eventTime, string _betTeam, string _odd, float _moneyline) 
        {
            //Ivo: Do we need the id of the user anywhere here?

            //ticker stuff
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
            betPlacingModel.TickerGames = tempTickerGames;


            //event info
            betPlacingModel.BetType = _BetType;
            betPlacingModel.EventDate = DateTime.Parse(_eventTime);
            betPlacingModel.Event = _context.EventsTable.Find(_eventId);
            betPlacingModel.Odd = _odd;
            betPlacingModel.BetTeam = _betTeam;
            betPlacingModel.BetMoneyLine = _moneyline;
            betPlacingModel.Event = _context.EventsTable.Find(_eventId);
            return View("BetPlacement", betPlacingModel);
        }




        //CREATE
        public IActionResult AddBet(RecordOfBets addBet)
        {
            UserData user = new UserData();

            foreach (UserData userOne in _context.UserData.ToList())
            {
                if (userOne.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                {
                    user = userOne;
                }

            }

            if (ModelState.IsValid)
            {
                //validation to see if amount bet is less than or equal to Bet Bank amount
                if (addBet.AmountBet <= user.BetBankBalance)
                {
                    DepositsAndWithdrawls newTransaction = new DepositsAndWithdrawls();
                    newTransaction.AmountOfTransaction = addBet.AmountBet * -1;
                    newTransaction.TimeOfTransaction = DateTime.Now;
                    newTransaction.UserId = user.UserId;
                    newTransaction.UserMadeTransAction = true;
                    AddPayout(newTransaction, true, user);
                    user.BetBankBalance -= addBet.AmountBet;

                    _context.UserData.Update(user);
                    _context.SaveChanges();
                    _context.RecordOfBets.Add(addBet);
                    _context.SaveChanges();
                }
                else
                {

                    ViewBag.error = "Not enough money in account to place bet! Enter new amount.";
                    

                   
                    return View("Error");

                }
              

            }
            // Not sure where to return fully
            return RedirectToAction("ViewOpenBets");

        }

        //UPDATE
        int GenScore(int sportId) 
        {
            Random random = new Random();
            int baseScore = 0;
            int scoreDiff;
            //if nfl game
            switch (sportId)
            {

                case 2:
                    baseScore = random.Next(0, 32);
                    scoreDiff = random.Next(3, 7);
                    if (random.NextDouble() > 0.5)
                    {
                        baseScore += scoreDiff;
                    }
                    else
                    {
                        baseScore -= scoreDiff;
                    }
                    break;
                case 4:
                    baseScore = random.Next(75, 125);
                    scoreDiff = random.Next(5, 12);
                    if (random.NextDouble() > 0.5)
                    {
                        baseScore += scoreDiff;
                    }
                    else
                    {
                        baseScore -= scoreDiff;
                    }
                    break;
                default:
                    break;
            }
                return baseScore;
        }
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
            //sportid: 2 = NFL, 4 = NBA

            betEvent.HomeScore = GenScore(betEvent.SportId);
            betEvent.AwayScore = GenScore(betEvent.SportId);


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

        
        public IActionResult DeleteBet(int id)
        {
            var selectedBet = _context.RecordOfBets.Find(id);
            if(selectedBet != null)
            {
                var tempuser = _context.UserData.Where(b => b.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
                DepositsAndWithdrawls newTransaction = new DepositsAndWithdrawls();
                newTransaction.AmountOfTransaction = selectedBet.AmountBet;
                newTransaction.TimeOfTransaction = DateTime.Now;
                newTransaction.UserId = tempuser[0].UserId;
                newTransaction.UserMadeTransAction = true;
                
                AddPayout(newTransaction, true, tempuser[0]);
                UpdateBalance(tempuser[0], newTransaction);
                

                _context.RecordOfBets.Remove(selectedBet);
                _context.SaveChanges();
            }
            return RedirectToAction("ViewOpenBets");
        }
        public void UpdateBalance(UserData userData, DepositsAndWithdrawls transaction)
        {
            //updates user bank balance
            userData.BetBankBalance += transaction.AmountOfTransaction;
            _context.UserData.Update(userData);
            _context.SaveChanges();
        }
        public void AddPayout(DepositsAndWithdrawls transaction, bool moneyInOut, UserData userOfBet)
        {
            if (moneyInOut != true)
            {
                transaction.AmountOfTransaction = transaction.AmountOfTransaction * -1;
            }

            //adds the record to the table
            _context.DepositsAndWithdrawls.Add(transaction);
            _context.SaveChanges();

        }
        public IActionResult Error()
        {

            return View();
        }


      




    }
}