using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models.ViewModels
{
    //view model class
    public class HomePageModel
    {
        //may need the user signin manager
        public bool IsLoggedIn { get; set; }

        public List<TickerGames> TickerGames { get; set; }
        //left blank
        public string PreviewImagPath { get; set; }
        //Graph
        public UserStats UserStats { get; set; }


    }
}
