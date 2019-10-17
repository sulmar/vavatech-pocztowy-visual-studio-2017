using Pocztowy.Models;

namespace Pocztowy.Calculators
{
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }

    public interface ICalculateDiscountStrategy
    {
        decimal CalculateDiscount(Order order);
    }

    public interface IDiscountStrategy
    {
        bool CanDiscount(Order order);
        decimal CalculateDiscount(Order order);
    }
}
