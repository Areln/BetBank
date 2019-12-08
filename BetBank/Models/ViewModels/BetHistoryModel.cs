using BetBank.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models.ViewModels
{
    public class BetHistoryModel
    {
        public List<TickerGames> TickerGames { get; set; }
        public List<TempBetRecord> BetRecords { get; set; }
        public LeagueHistoryRecord LeagueHistory { get; set; }


    }
}
