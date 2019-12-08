
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{
    public class TickerBets : TickerGames
    {
        public float TotalAmountBet { get; set; }
        public float ProbabilityOfWinning { get; set; }
        public DateTime CurrentGameClock { get; set; }

    }
}
