using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{
    class IReturnOnInvestment : IAlgorithmFunctions
    {
        private readonly BetBankDbContext _context;
        public IReturnOnInvestment(BetBankDbContext context
        {
            _context = context;

        }

        public float CalculateROI()
        {
            throw new NotImplementedException();
        }

        public float CalculateTheProbabilty()
        {
            throw new NotImplementedException();
        }
    }
}
