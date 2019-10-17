using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    public class HappyHoursCanDiscountStrategy
        : ICanDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private readonly decimal minimumAmount;

        public HappyHoursCanDiscountStrategy
            (TimeSpan from, 
            TimeSpan to, 
            decimal minimumAmount)
        {
            this.from = from;
            this.to = to;
            this.minimumAmount = minimumAmount;
        }

        public bool CanDiscount(Order order) => 
                order.CreateDate.TimeOfDay >= from
                && order.CreateDate.TimeOfDay <= to
                && order.Total >= minimumAmount;
    }

    
}
