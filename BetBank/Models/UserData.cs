using System;
using System.Collections.Generic;

namespace BetBank.Models
{
    public partial class UserData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double? BetBankBalance { get; set; }
        public int? WinsRecord { get; set; }
        public int? LossesRecord { get; set; }
        public double? ReturnOnInvestment { get; set; }
        public int? AllTimeWins { get; set; }
        public int? AllTimeLosses { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
