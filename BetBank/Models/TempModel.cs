using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{

    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public DateTime begin_at { get; set; }
        public bool detailed_stats { get; set; }
        public bool draw { get; set; }
        public DateTime end_at { get; set; }
        public bool forfeit { get; set; }
        public Game[] games { get; set; }
        public int id { get; set; }
        public League league { get; set; }
        public int league_id { get; set; }
        public Live live { get; set; }
        public string live_url { get; set; }
        public string match_type { get; set; }
        public DateTime modified_at { get; set; }
        public string name { get; set; }
        public int number_of_games { get; set; }
        public Opponent[] opponents { get; set; }
        public Result[] results { get; set; }
        public DateTime scheduled_at { get; set; }
        public Serie serie { get; set; }
        public int serie_id { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public Tournament tournament { get; set; }
        public int tournament_id { get; set; }
        public Videogame videogame { get; set; }
        public Videogame_Version videogame_version { get; set; }
        public Winner winner { get; set; }
        public int winner_id { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public string image_url { get; set; }
        public bool live_supported { get; set; }
        public DateTime modified_at { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
    }

    public class Live
    {
        public DateTime opens_at { get; set; }
        public bool supported { get; set; }
        public string url { get; set; }
    }

    public class Serie
    {
        public DateTime begin_at { get; set; }
        public object description { get; set; }
        public object end_at { get; set; }
        public string full_name { get; set; }
        public int id { get; set; }
        public int league_id { get; set; }
        public DateTime modified_at { get; set; }
        public string name { get; set; }
        public string season { get; set; }
        public string slug { get; set; }
        public int winner_id { get; set; }
        public string winner_type { get; set; }
        public int year { get; set; }
    }

    public class Tournament
    {
        public DateTime begin_at { get; set; }
        public DateTime end_at { get; set; }
        public int id { get; set; }
        public int league_id { get; set; }
        public bool live_supported { get; set; }
        public DateTime modified_at { get; set; }
        public string name { get; set; }
        public string prizepool { get; set; }
        public int serie_id { get; set; }
        public string slug { get; set; }
        public int winner_id { get; set; }
        public string winner_type { get; set; }
    }

    public class Videogame
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Videogame_Version
    {
        public bool current { get; set; }
        public string name { get; set; }
    }

    public class Winner
    {
        public string acronym { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Game
    {
        public DateTime begin_at { get; set; }
        public bool detailed_stats { get; set; }
        public DateTime end_at { get; set; }
        public bool finished { get; set; }
        public bool forfeit { get; set; }
        public int id { get; set; }
        public int length { get; set; }
        public int match_id { get; set; }
        public int position { get; set; }
        public string status { get; set; }
        public string video_url { get; set; }
        public Winner1 winner { get; set; }
        public string winner_type { get; set; }
    }

    public class Winner1
    {
        public int id { get; set; }
        public string type { get; set; }
    }

    public class Opponent
    {
        public Opponent1 opponent { get; set; }
        public string type { get; set; }
    }

    public class Opponent1
    {
        public string acronym { get; set; }
        public int id { get; set; }
        public string image_url { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Result
    {
        public int score { get; set; }
        public int team_id { get; set; }
    }

}
