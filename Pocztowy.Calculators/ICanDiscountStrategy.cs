using Pocztowy.Models;

namespace Pocztowy.Calculators
{
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }

  
}
