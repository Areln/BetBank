﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{
    //view model extension class
    public class UserStats
    {
        public Dictionary<string, RecordOfBets> OpenBets { get; set; }
        public string AllTimeWLRecord { get; set; }
        public string YesterdayWLRecord { get; set; }
        public string TodayWLRecord { get; set; }
        public double Balance { get; set; }
        public float ReturnOnInvestment { get; set; }
        public LeagueHistoryRecord LeagueHistory { get; set; }
    }
}

