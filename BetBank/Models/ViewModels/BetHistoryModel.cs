using BetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models.ViewModels
{
    public class BetHistoryModel
    {
        public List<TickerGames> TickerGames { get; set; }
        public List<RecordOfBets> BetRecords { get; set; }
        public LeagueHistoryRecord LeagueHistory { get; set; }


    }
}
