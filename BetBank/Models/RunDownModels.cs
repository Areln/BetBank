using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{

    public class EventsRootobject
    {
        public Meta meta { get; set; }
        public Event[] events { get; set; }
    }

    public class Meta
    {
        public string delta_last_id { get; set; }
    }

    public class Event
    {
        public string event_id { get; set; }
        public int sport_id { get; set; }
        public DateTime event_date { get; set; }
        public int rotation_number_away { get; set; }
        public int rotation_number_home { get; set; }
        public Team[] teams { get; set; }
        public Teams_Normalized[] teams_normalized { get; set; }
        public Lines lines { get; set; }
    }

    public class Lines
    {
        [JsonProperty("1")]
        public BookKeeper _1 { get; set; }
        [JsonProperty("10")]
        public BookKeeper _10 { get; set; }
        [JsonProperty("12")]
        public BookKeeper _12 { get; set; }
        [JsonProperty("14")]
        public BookKeeper _14 { get; set; }
        [JsonProperty("15")]
        public BookKeeper _15 { get; set; }
        [JsonProperty("16")]
        public BookKeeper _16 { get; set; }
        [JsonProperty("17")]
        public BookKeeper _17 { get; set; }
        [JsonProperty("18")]
        public BookKeeper _18 { get; set; }
        [JsonProperty("2")]
        public BookKeeper _2 { get; set; }
        [JsonProperty("3")]
        public BookKeeper _3 { get; set; }
        [JsonProperty("4")]
        public BookKeeper _4 { get; set; }
        [JsonProperty("6")]
        public BookKeeper _6 { get; set; }
        [JsonProperty("7")]
        public BookKeeper _7 { get; set; }
        [JsonProperty("9")]
        public BookKeeper _9 { get; set; }
    }
    //this book class will replace all the _{number} classes
    public class BookKeeper 
    {
        public int line_id { get; set; }
        public Moneyline moneyline { get; set; }
        public Spread spread { get; set; }
        public Total total { get; set; }
        public Affiliate affiliate { get; set; }
    }

    public class Affiliate
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class Moneyline
    {
        public int line_id { get; set; }
        public float moneyline_away { get; set; }
        public float moneyline_away_delta { get; set; }
        public float moneyline_home { get; set; }
        public float moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public float moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread
    {
        public int line_id { get; set; }
        public float point_spread_away { get; set; }
        public float point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public float point_spread_home_delta { get; set; }
        public float point_spread_away_money { get; set; }
        public float point_spread_away_money_delta { get; set; }
        public float point_spread_home_money { get; set; }
        public float point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total
    {
        public int line_id { get; set; }
        public float total_over { get; set; }
        public float total_over_delta { get; set; }
        public float total_under { get; set; }
        public float total_under_delta { get; set; }
        public float total_over_money { get; set; }
        public float total_over_money_delta { get; set; }
        public float total_under_money { get; set; }
        public float total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Team
    {
        public int team_id { get; set; }
        public int team_normalized_id { get; set; }
        public bool is_away { get; set; }
        public bool is_home { get; set; }
        public string name { get; set; }
    }

    public class Teams_Normalized
    {
        public int team_id { get; set; }
        public string name { get; set; }
        public string mascot { get; set; }
        public string abbreviation { get; set; }
        public bool is_away { get; set; }
        public bool is_home { get; set; }
        public string ranking { get; set; }
        public string record { get; set; }
    }

}
