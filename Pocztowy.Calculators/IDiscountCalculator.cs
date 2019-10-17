using Pocztowy.Models;

namespace Pocztowy.Calculators
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(Order order);

    }
}
