using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    public class DayOfWeekCanDiscountStrategy
        : ICanDiscountStrategy
    {
        private readonly DayOfWeek dayOfWeek;

        public DayOfWeekCanDiscountStrategy(DayOfWeek dayOfWeek)
        {
            this.dayOfWeek = dayOfWeek;
        }

        public bool CanDiscount(Order order)
            => order.CreateDate.DayOfWeek == dayOfWeek;
    }

    
}
