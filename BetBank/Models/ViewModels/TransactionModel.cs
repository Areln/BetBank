using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models.ViewModels
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        public DateTime TimeOfTransaction { get; set; }
        public double AmountOfTransaction { get; set; }
        public bool UserMadeTransAction { get; set; }

        public virtual AspNetUsers User { get; set; }
        public List<DepositsAndWithdrawls> transaction { get; set; }
        public List<UserData> BBbalance { get; set; }
        public double BetBankBalance { get; set; }

    }
}
