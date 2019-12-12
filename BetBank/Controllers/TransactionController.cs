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
        public IActionResult AddTransaction(DepositsAndWithdrawls transaction, bool moneyInOut)
        {
            if (ModelState.IsValid)
            {
                if(moneyInOut != true)
                {
                    transaction.AmountOfTransaction = transaction.AmountOfTransaction * -1;

                }
                _context.DepositsAndWithdrawls.Add(transaction);
                _context.SaveChanges();

                UpdateTransactionHistory(transaction);



               

            }
            return RedirectToAction("Index", "Home");
        }
        public void UpdateTransactionHistory(DepositsAndWithdrawls transaction)
        {
            //update userdata balance
            foreach (UserData item in _context.UserData.ToList())
            {
                if (item.UserId == transaction.UserId)
                {
                    item.BetBankBalance += transaction.AmountOfTransaction;
                    _context.UserData.Update(item);
                    _context.SaveChanges();
                    break;
                }
            }
          
        }
    }
}