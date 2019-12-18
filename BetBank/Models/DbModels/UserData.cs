using System;
using System.Collections.Generic;

namespace BetBank.Models
{
    public partial class UserData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double BetBankBalance { get; set; }
        public double ReturnOnInvestment { get; set; }
        public int MlwinsRecord { get; set; }
        public int MllossesRecord { get; set; }
        public int SwinsRecord { get; set; }
        public int StiesRecord { get; set; }
        public int SlosesRecord { get; set; }
        public int TwinsRecord { get; set; }
        public int TlosesRecord { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
