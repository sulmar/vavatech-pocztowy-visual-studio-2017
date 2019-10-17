using Pocztowy.Models;

namespace Pocztowy.Calculators
{
    public class PercentageCalculateDiscountStrategy
        : ICalculateDiscountStrategy
    {
        private readonly decimal percentage;

        public PercentageCalculateDiscountStrategy(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal CalculateDiscount(Order order)
            => order.Total * percentage;
    }

    
}
