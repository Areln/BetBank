using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{
    //view model extension class
    public class UserStats
    {
        public Dictionary<string, RecordOfBets> OpenBets { get; set; }
        public int TotalWinsRecord { get; set; }
        public int TotalLossRecord { get; set; }
        public int MlwinsRecord { get; set; }
        public int MllossesRecord { get; set; }
        public int SwinsRecord { get; set; }
        public int StiesRecord { get; set; }
        public int SlosesRecord { get; set; }
        public int TwinsRecord { get; set; }
        public int TlosesRecord { get; set; }
        public double Balance { get; set; }
        public float ReturnOnInvestment { get; set; }
        public LeagueHistoryRecord LeagueHistory { get; set; }
    }
}

