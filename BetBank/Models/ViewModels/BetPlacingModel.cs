using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models.ViewModels
{
    public class BetPlacingModel
    {
        public List<TickerGames> TickerGames { get; set; }
        public EventsTable Event { get; set; }
        public string BetType { get; set; }
        public string Odd { get; set; }
        public string BetTeam { get; set; }
        public DateTime EventDate { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public float BetMoneyLine { get; set; }


    }
}
