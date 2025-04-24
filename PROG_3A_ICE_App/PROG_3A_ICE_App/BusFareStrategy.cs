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

    public class BusFareStrategy : IFareStrategy
    {
        private const decimal FixedFare = 2.50m;
        public decimal CalculateFare(decimal distanceInKm, DateTime travelTime)
            => FixedFare;
    }
}
