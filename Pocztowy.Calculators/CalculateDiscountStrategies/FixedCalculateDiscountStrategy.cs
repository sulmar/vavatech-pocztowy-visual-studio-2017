using Pocztowy.Models;

namespace Pocztowy.Calculators
{

    public class FixedCalculateDiscountStrategy 
        : ICalculateDiscountStrategy
    {
        private readonly decimal fixedAmount;

        public FixedCalculateDiscountStrategy
            (decimal fixedAmount) => this.fixedAmount = fixedAmount;

        public decimal CalculateDiscount(Order order)
            => fixedAmount;
    }

    
}
