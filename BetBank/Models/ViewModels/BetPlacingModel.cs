using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models.ViewModels
{
    public class BetPlacingModel
    {
        public List<TickerGames> TickerGames { get; set; }
        public List<RecordOfBets> UserBetHistory { get; set; }
        public string EventId { get; set; }
        public string BetType { get; set; }
        public string BetTeam { get; set; }
        public DateTime EventDate { get; set; }
    }
}
