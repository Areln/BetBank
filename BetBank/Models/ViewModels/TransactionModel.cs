using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BetBank.Models.ViewModels
{
    public class TransactionModel
    {

        public List<DepositsAndWithdrawls> Transactions { get; set; }
        public double BetBankBalance { get; set; }
    }
}