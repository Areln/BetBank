using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{
    public class TickerGames
    {
        public DateTime TimeOfEvent { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public float HomeSpread { get; set; }
        public float AwaySpread { get; set; }
        public float HomeMoneyline { get; set; }
        public float AwayMoneyline { get; set; }
        public float HomeTotal { get; set; }
        public float AwayTotal { get; set; }
        public int FavProbability { get; set; }
        public int GameScore { get; set; }
        public string EventId { get; set; }

    }
}
