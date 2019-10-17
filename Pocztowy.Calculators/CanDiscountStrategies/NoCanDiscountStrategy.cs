using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    public class NoCanDiscountStrategy : ICanDiscountStrategy
    {
        /// <summary>
        /// brak promocji
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool CanDiscount(Order order) => false;
    }
}
