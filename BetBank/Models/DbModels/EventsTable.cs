using System;
using System.Collections.Generic;

namespace BetBank.Models
{
    public partial class EventsTable
    {

        public EventsTable()
        {
        
        }
        public EventsTable(string event_id, int sport_id, DateTime event_date, string event_status, string homeTeam, int score_home, string awayTeam, int score_away, TimeSpan timeSpan, float moneyline_home, float moneyline_away, float point_spread_home, float point_spread_away, float total_over, float total_under, int line_id, float point_spread_away_money, float point_spread_home_money, float total_over_money, float total_under_money, float totalOver, float totalUnder)
        {
            EventId = event_id;
            SportId = sport_id;
            EventDate = event_date;
            EventStatus = event_status;
            HomeTeam = homeTeam;
            HomeScore = score_home;
            AwayTeam = awayTeam;
            AwayScore = score_away;
            GameClock = timeSpan;
            MoneyLineHome = moneyline_home;
            MoneyLineAway = moneyline_away;
            SpreadHome = point_spread_home;
            SpreadAway = point_spread_away;
            TotalHome = total_over;
            TotalAway = total_under;
            LineId = line_id;
            PointSpreadAwayMoney = point_spread_away_money;
            PointSpreadHomeMoney = point_spread_home_money;
            TotalOverMoney = total_over_money;
            TotalUnderMoney = total_under_money;
            TotalOver = totalOver;
            TotalUnder = totalUnder;
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
        public double PointSpreadAwayMoney { get; set; }
        public double PointSpreadHomeMoney { get; set; }
        public double TotalUnderMoney { get; set; }
        public double TotalOverMoney { get; set; }
        public double TotalOver { get; set; }
        public double TotalUnder { get; set; }
    }
}
