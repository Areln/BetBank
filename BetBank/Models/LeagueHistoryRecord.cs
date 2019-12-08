using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{
    public class LeagueHistoryRecord
    {
        public string NFLSpreadWL { get; set; }
        public string NFLMoneyLineWL { get; set; }
        public string NFLOverUnderWL { get; set; }
        public float NFLROI { get; set; }
        public string NBASpreadWL { get; set; }
        public string NBAMoneyLineWL { get; set; }
        public string NBAOverUnderWL { get; set; }
        public float NBAROI { get; set; }
        public string NCAASpreadWL { get; set; }
        public string NCAAMoneyLineWL { get; set; }
        public string NCAAOverUnderWL { get; set; }
        public float NCAAROI { get; set; }

    }
}
