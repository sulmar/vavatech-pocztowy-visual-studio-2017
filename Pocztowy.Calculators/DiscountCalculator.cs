using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private readonly ICanDiscountStrategy canDiscountStrategy;
        private readonly ICalculateDiscountStrategy calculateDiscountStrategy;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="canDiscountStrategy">implementacja interfejsu can</param>
        /// <param name="calculateDiscountStrategy">implementacja interfejsu caculate</param>
        public DiscountCalculator(
            ICanDiscountStrategy canDiscountStrategy, 
            ICalculateDiscountStrategy calculateDiscountStrategy)
        {
            this.canDiscountStrategy = canDiscountStrategy ?? throw new ArgumentNullException(nameof(canDiscountStrategy));
            this.calculateDiscountStrategy = calculateDiscountStrategy ?? throw new ArgumentNullException(nameof(calculateDiscountStrategy));
        }
        /// <summary>
        /// oblicza rabat dla danej strategii
        /// </summary>
        /// <param name="order">szczegóły zamówienia</param>
        /// <returns></returns>
        public decimal CalculateDiscount(Order order)
        {
            if (canDiscountStrategy.CanDiscount(order))
            {
                return calculateDiscountStrategy.CalculateDiscount(order);
            }
            else
                return 0m;
        }
    }
}
