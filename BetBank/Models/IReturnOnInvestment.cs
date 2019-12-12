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

        public EventsTable GetEventData(string eventId)
        {
            foreach (EventsTable entry in _context.EventsTable)
            {
                if (entry.EventId == eventId)
                {
                    return entry;

                }
            }
            return null;


        }

        public double GetBetType(EventsTable betType)
        {
            if (betType != null)
            {
                var currentGameBetSpreadAway = betType.PointSpreadAwayMoney;
                var currentGameBetSpreadHome = betType.PointSpreadHomeMoney;
                var currentGameBetTotalOver = betType.TotalOverMoney;
                var currentGameBetTotalUnder = betType.TotalUnderMoney;

                foreach (EventsTable entry in _context.EventsTable)
                {
                    //narrow down record 
                    if (entry.EventId == betType.EventId && entry.PointSpreadAwayMoney == betType.PointSpreadAwayMoney)
                    {
                        currentGameBetSpreadAway += entry.PointSpreadAwayMoney;
                        return currentGameBetSpreadAway;

                    }
                    else if(entry.EventId == betType.EventId && entry.PointSpreadHomeMoney == betType.PointSpreadHomeMoney)
                    {
                        currentGameBetSpreadHome += entry.PointSpreadHomeMoney;
                        return currentGameBetSpreadHome;
                    }
                    else if (entry.EventId == betType.EventId && entry.TotalOverMoney == betType.TotalOverMoney)
                    {
                        currentGameBetTotalOver += entry.TotalOverMoney;
                        return currentGameBetTotalOver;
                    }
                    else if (entry.EventId == betType.EventId && entry.TotalUnderMoney == betType.TotalUnderMoney)
                    {
                        currentGameBetTotalUnder += entry.TotalUnderMoney;
                        return currentGameBetTotalUnder;
                    }
                }
            }
            return 0;
        }


        public double CalculateTheProbabilty(EventsTable betType)
        {
            
            return GetBetType(betType) / (GetBetType(betType) + 100) * 100;

            //return 100 / (GetBetType(betType) + 100) * 100;

        }

    }
}
    

