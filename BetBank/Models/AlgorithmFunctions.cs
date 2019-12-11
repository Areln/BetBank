using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetBank.Models
{
    interface IAlgorithmFunctions
    {
        double CalculateTheProbabilty();

        double CalculateROI(UserData CurrentUserData);


    }
}
