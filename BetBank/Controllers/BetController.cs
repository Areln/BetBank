using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BetBank.Models;
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
            //Ivo: Modified Method toview open bets by user
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(_context.RecordOfBets.Where(b => b.UserId == id).ToList());
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






    }
}