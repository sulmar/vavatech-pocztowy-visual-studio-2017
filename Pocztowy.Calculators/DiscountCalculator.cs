﻿using Pocztowy.Models;
using System;

namespace Pocztowy.Calculators
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private readonly ICanDiscountStrategy canDiscountStrategy;
        private readonly ICalculateDiscountStrategy calculateDiscountStrategy;

        public DiscountCalculator(
            ICanDiscountStrategy canDiscountStrategy, 
            ICalculateDiscountStrategy calculateDiscountStrategy)
        {
            this.canDiscountStrategy = canDiscountStrategy ?? throw new ArgumentNullException(nameof(canDiscountStrategy));
            this.calculateDiscountStrategy = calculateDiscountStrategy ?? throw new ArgumentNullException(nameof(calculateDiscountStrategy));
        }

        public decimal CalculateDiscount(Order order)
        {
            if (canDiscountStrategy.CanDiscount(order))
            {
                return calculateDiscountStrategy.CalculateDiscount(order);
            }
            else
                return 0m;
        }
    }
}
