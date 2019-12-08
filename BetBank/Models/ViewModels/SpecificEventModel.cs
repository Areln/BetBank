using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models.ViewModels
{
    public class SpecificEventModel
    {

        public List<int> AffiliatesToDisplay { get; set; }
        public Event Event { get; set; }
        //not sure how we are going to be getting recommended lines yet.

    }
}
