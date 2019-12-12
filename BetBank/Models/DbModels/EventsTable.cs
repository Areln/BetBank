using System;
using System.Collections.Generic;

namespace BetBank.Models
{
    public partial class EventsTable
    {


        public EventsTable()
        {

        }
        public EventsTable(string _EventId, int _SportId, DateTime _EventDate, string _EventStatus, string _HomeTeam, int _HomeScore, string _AwayTeam, int _AwayScore, TimeSpan _GameClock, double _MoneyLineHome, double _MoneyLineAway, double _SpreadHome, double _SpreadAway, double _TotalHome, double _TotalAway, int _LineId)
        {
            EventId = _EventId;
            SportId = _SportId;
            EventDate = _EventDate;
            EventStatus = _EventStatus;
            HomeTeam = _HomeTeam;
            HomeScore = _HomeScore;
            AwayTeam = _AwayTeam;
            AwayScore = _AwayScore;
            GameClock = _GameClock;
            MoneyLineHome = _MoneyLineHome;
            MoneyLineAway = _MoneyLineAway;
            SpreadAway = _SpreadAway;
            SpreadHome = _SpreadHome;
            TotalAway = _TotalAway;
            TotalHome = _TotalHome;
            LineId = _LineId;
        }

        public string EventId { get; set; }
        public int SportId { get; set; }
        public DateTime EventDate { get; set; }
        public string EventStatus { get; set; }
        public string HomeTeam { get; set; }
        public int HomeScore { get; set; }
        public string AwayTeam { get; set; }
        public int AwayScore { get; set; }
        public TimeSpan GameClock { get; set; }
        public double MoneyLineHome { get; set; }
        public double MoneyLineAway { get; set; }
        public double SpreadHome { get; set; }
        public double SpreadAway { get; set; }
        public double TotalHome { get; set; }
        public double TotalAway { get; set; }
        public int LineId { get; set; }
    }
}
