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
        public float HomeOdds { get; set; }
        public float AwayOdds { get; set; }
        public int FavProbability { get; set; }
        public int GameScore { get; set; }

    }
}
