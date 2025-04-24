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

    /// <summary>
    /// Decorator strategy to apply a percentage discount.
    /// </summary>
    public class DiscountedFareStrategy : IFareStrategy
    {
        private readonly IFareStrategy _inner;
        private readonly decimal _discountRate;

        public DiscountedFareStrategy(IFareStrategy innerStrategy, decimal discountRate)
        {
            _inner = innerStrategy ?? throw new ArgumentNullException(nameof(innerStrategy));
            _discountRate = discountRate;
        }

        public decimal CalculateFare(decimal distanceInKm, DateTime travelTime)
        {
            var baseFare = _inner.CalculateFare(distanceInKm, travelTime);
            return baseFare * (1 - _discountRate);
        }
    }
}
