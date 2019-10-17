using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateDiscount(Order order)
        {
            throw new InvalidOperationException();
        }

        public bool CanDiscount(Order order)
        {
            return false;
        }
    }
}
