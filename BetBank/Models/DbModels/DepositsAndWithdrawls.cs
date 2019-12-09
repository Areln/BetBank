using System;
using System.Collections.Generic;

namespace BetBank.Models
{
    public partial class DepositsAndWithdrawls
    {
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        public DateTime TimeOfTransaction { get; set; }
        public double AmountOfTransaction { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
