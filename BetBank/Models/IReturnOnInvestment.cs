using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{
    class IReturnOnInvestment : IAlgorithmFunctions
    {
        private readonly BetBankDbContext _context;
        public IReturnOnInvestment(BetBankDbContext context)
        {
            _context = context;

        }

        public UserData GetUserData(string userId)
        {
            foreach (UserData entry in _context.UserData)
            {
                if (entry.UserId == userId)
                {
                    return entry;

                }
            }
            return null;
        }

        public double GetIntitialInvestment(UserData currentUserData)
        {
            if (currentUserData != null)
            {
                var currentBetBankBalance = currentUserData.BetBankBalance;
                foreach (DepositsAndWithdrawls entry in _context.DepositsAndWithdrawls)
                {
                    //narrow down record 
                    if (entry.UserId == currentUserData.UserId && entry.UserMadeTransAction == false)
                    {
                        currentBetBankBalance -= entry.AmountOfTransaction;
                    }
                }
                return currentBetBankBalance;
            }
            return 0;
        }


        public double CalculateROI(UserData currentUserData)
        {
            
            return currentUserData.BetBankBalance - GetIntitialInvestment(currentUserData) / GetIntitialInvestment(currentUserData) * .1;
        }

        //public UserData GetUserData(string userId)
        //{

        //}


        public double CalculateTheProbabilty()
        {
            throw new NotImplementedException();
        }


    }
}
    

