using Pocztowy.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pocztowy.Calculators
{
    public class DiscountCalculator : IDiscountCalculator, IDiscountCalculatorAsync
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
        /// <param name="order"></param>
        /// <returns></returns>
        public decimal CalculateDiscount(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (order.Total <= 0)
                throw new ArgumentOutOfRangeException(nameof(order.Total));

            if (canDiscountStrategy.CanDiscount(order))
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                return calculateDiscountStrategy.CalculateDiscount(order);
            }
            else
                return 0m;
        }

        public Task<decimal> CalculateDiscountAsync(Order order)
        {
            return Task.Run(() => CalculateDiscount(order));
        }
    }
}
