using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    public class HappyHoursDiscountStrategy
        : IDiscountStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;
        private readonly decimal threshold;
        private readonly decimal fixedAmount;

        public HappyHoursDiscountStrategy(TimeSpan from, TimeSpan to, decimal threshold, decimal fixedAmount)
        {
            this.from = from;
            this.to = to;
            this.threshold = threshold;
            this.fixedAmount = fixedAmount;
        }

        public decimal CalculateDiscount(Order order)
            => fixedAmount;

        public bool CanDiscount(Order order) => 
                order.CreateDate.TimeOfDay >= from
                && order.CreateDate.TimeOfDay <= to
                && order.Total >= threshold;
    }

    public class DayOfWeekDiscountStrategy : IDiscountStrategy
    {
        private readonly DayOfWeek dayOfWeek;
        private readonly decimal percentage;

        public DayOfWeekDiscountStrategy(
            DayOfWeek dayOfWeek, 
            decimal percentage)
        {
            this.dayOfWeek = dayOfWeek;
            this.percentage = percentage;
        }

        public decimal Discount => percentage;

        public decimal CalculateDiscount(Order order)
        {
            return order.Total * percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.CreateDate.DayOfWeek == dayOfWeek;
        }
    }
}
