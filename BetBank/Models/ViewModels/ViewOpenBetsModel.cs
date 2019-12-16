using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models.ViewModels
{
    public class ViewOpenBetsModel
    {
        public Dictionary<string, RecordOfBets> recordOfBets = new Dictionary<string, RecordOfBets>();
    }
}
