using Pocztowy.Models;
using System.Threading.Tasks;

namespace Pocztowy.Calculators
{
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(Order order);
    }

    public interface IDiscountCalculatorAsync
    {
        Task<decimal> CalculateDiscountAsync(Order order);
    }
}
