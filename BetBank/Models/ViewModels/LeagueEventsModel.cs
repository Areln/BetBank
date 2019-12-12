using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models.ViewModels
{
    public class LeagueEventsModel
    {
        public string LeagueName { get; set; }
        //users fav book, next cheapest books: dynamic book display
        public List<int> AffiliatesToDisplay { get; set; }
        public List<EventsTable> LeaguesEvents { get; set; }

    }
}
