using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    public class NoCanDiscountStrategy : ICanDiscountStrategy
    {
        public bool CanDiscount(Order order) => false;
    }
}
