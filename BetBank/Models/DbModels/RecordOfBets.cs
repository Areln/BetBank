using System;
using System.Collections.Generic;

namespace BetBank.Models
{
    public partial class RecordOfBets
    {
        public int BetId { get; set; }
        public string UserId { get; set; }
        public string EventId { get; set; }
        public string BetType { get; set; }
        public DateTime EventDate { get; set; }
        public double AmountBet { get; set; }
        public bool BetTeam { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
