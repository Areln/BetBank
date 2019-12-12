using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetBank.Controllers
{
    public class TransactionController : Controller
    {

        private readonly BetBankDbContext _context;

        public TransactionController(BetBankDbContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("BankBalanceTransaction");
        }
        public IActionResult ViewTransactions()
        {
            return View(_context.DepositsAndWithdrawls.ToList());
        }
        //[HttpGet]
        //public IActionResult AddTransaction()
        //{
        //    return View();
        //}
        //[HttpPost]
        public IActionResult AddTransaction(DepositsAndWithdrawls transaction)
        {
            if (ModelState.IsValid)
            {
                _context.DepositsAndWithdrawls.Add(transaction);
                UserData currentUserData;
                //update userdata balance
                foreach (UserData item in _context.UserData)
                {
                    if (item.UserId == transaction.UserId)
                    {
                        currentUserData = item;
                    }
                }



                _context.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }
    }
}