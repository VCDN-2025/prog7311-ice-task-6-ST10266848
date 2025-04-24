using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_3A_ICE_App
{

    //Code attribution for below:
    //Author: Open AI
    //AI Chat Model used: ChatGPT
    //AI Chat Link: https://chatgpt.com/share/6809db04-ec4c-8002-a76f-f1afc8f8af77
    //Date Accessed: 24 April 2025

    public class TrainFareStrategy : IFareStrategy
    {
        private const decimal BaseFare = 1.20m;
        private const decimal PerKmRate = 0.60m;
        private const decimal PeakMultiplier = 1.50m;
        private static readonly TimeSpan MorningPeakStart = TimeSpan.FromHours(7);
        private static readonly TimeSpan MorningPeakEnd = TimeSpan.FromHours(9);
        private static readonly TimeSpan EveningPeakStart = TimeSpan.FromHours(17);
        private static readonly TimeSpan EveningPeakEnd = TimeSpan.FromHours(19);

        public decimal CalculateFare(decimal distanceInKm, DateTime travelTime)
        {
            var fare = BaseFare + (PerKmRate * distanceInKm);
            var tod = travelTime.TimeOfDay;
            bool isPeak = (tod >= MorningPeakStart && tod < MorningPeakEnd)
                       || (tod >= EveningPeakStart && tod < EveningPeakEnd);
            return isPeak ? fare * PeakMultiplier : fare;
        }
    }
}
