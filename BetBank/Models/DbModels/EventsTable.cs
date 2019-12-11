using System;
using System.Collections.Generic;

namespace BetBank.Models
{
    public partial class EventsTable
    {
        private string event_id;
        private int sport_id;
        private DateTime event_date;
        private string event_status;
        private int score_home;
        private int score_away;
        private TimeSpan timeSpan;
        private float moneyline_home;
        private float moneyline_away;
        private float point_spread_home;
        private float point_spread_away;
        private float total_over;
        private float total_under;
        private int line_id;
        private float point_spread_away_money;
        private float point_spread_home_money;
        private float total_over_money;
        private float total_under_money;

        public EventsTable()
        {

        }
        public EventsTable(string event_id, int sport_id, DateTime event_date, string event_status, string homeTeam, int score_home, string awayTeam, int score_away, TimeSpan timeSpan, float moneyline_home, float moneyline_away, float point_spread_home, float point_spread_away, float total_over, float total_under, int line_id, float point_spread_away_money, float point_spread_home_money, float total_over_money, float total_under_money)
        {
            this.event_id = event_id;
            this.sport_id = sport_id;
            this.event_date = event_date;
            this.event_status = event_status;
            HomeTeam = homeTeam;
            this.score_home = score_home;
            AwayTeam = awayTeam;
            this.score_away = score_away;
            this.timeSpan = timeSpan;
            this.moneyline_home = moneyline_home;
            this.moneyline_away = moneyline_away;
            this.point_spread_home = point_spread_home;
            this.point_spread_away = point_spread_away;
            this.total_over = total_over;
            this.total_under = total_under;
            this.line_id = line_id;
            this.PointSpreadAwayMoney = point_spread_away_money;
            this.PointSpreadHomeMoney = point_spread_home_money;
            this.TotalOverMoney = total_over_money;
            this.TotalUnderMoney = total_under_money;
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
    }
}
