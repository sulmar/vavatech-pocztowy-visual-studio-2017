using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    public class FridayDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(Order order)
        {
            if (order.CreateDate.DayOfWeek == DayOfWeek.Friday)
            {
                decimal discount = order.Total * 0.5m;

                return discount;
            }
            else
            {
                return 0m;
            }
        }
    }
}
