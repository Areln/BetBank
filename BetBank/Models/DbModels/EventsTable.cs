using System;
using System.Collections.Generic;

namespace BetBank.Models
{
    public partial class EventsTable
    {
        public string EventId { get; set; }
        public int SportId { get; set; }
        public DateTime EventDate { get; set; }
        public string EventStatus { get; set; }
        public int HomeTeamId { get; set; }
        public int HomeScore { get; set; }
        public int AwayTeamId { get; set; }
        public int AwayScore { get; set; }
        public TimeSpan? GameClock { get; set; }
        public double MoneyLineHome { get; set; }
        public double MoneyLineAway { get; set; }
        public double SpreadHome { get; set; }
        public double SpreadAway { get; set; }
        public double TotalHome { get; set; }
        public double TotalAway { get; set; }
        public int LineId { get; set; }
    }
}
