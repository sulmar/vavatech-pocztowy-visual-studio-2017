using Pocztowy.Models;

namespace Pocztowy.Calculators
{

    public interface ICalculateDiscountStrategy
    {
        decimal CalculateDiscount(Order order);
    }

  
}
