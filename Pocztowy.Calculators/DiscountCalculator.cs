using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    

    public class DiscountCalculator : IDiscountCalculator
    {
        private IDiscountStrategy discountStrategy;

        public DiscountCalculator(IDiscountStrategy discountStrategy)
        {
            this.discountStrategy = discountStrategy ?? throw new ArgumentNullException(nameof(discountStrategy));
        }

        public decimal CalculateDiscount(Order order)
        {
            if (discountStrategy.CanDiscount(order))
            {
                return discountStrategy.CalculateDiscount(order);
            }
            else
                return 0m;
        }
    }
}
