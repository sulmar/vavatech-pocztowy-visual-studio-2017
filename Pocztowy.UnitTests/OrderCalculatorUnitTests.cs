using Pocztowy.Calculators;
using Pocztowy.Models;
using System;
using Xunit;
using FluentAssertions;

namespace Pocztowy.UnitTests
{
    public class OrderCalculatorUnitTests
    {
        

        [Theory(DisplayName = "Weryfikacja promocji 50%")]
        [InlineData(1000, 0.5, 500)]
        [InlineData(0, 0.5, 0)]
        [InlineData(0.1, 0.5, 0.05)]
        public void PercentageDiscountCalculateStrategyTest(
            decimal unitPrice,
            decimal percentage,
            decimal expected)
        {
            // Arrange
            Order order = CreateOrderWith1Product("2019-10-17", unitPrice);

            ICalculateDiscountStrategy calculateDiscountStrategy 
                = new PercentageCalculateDiscountStrategy(percentage);

            // Act

            decimal result = calculateDiscountStrategy.CalculateDiscount(order);
            // Assert
            result.Should().Be(expected, "upust");

            // dotnet add package FluentAssertions
        }

        private static Order CreateOrderWith1Product(string orderDate, decimal unitPrice)
        {
            Product product = new Product
            {
                Name = "Keyboard",
                Color = "Black",
                UnitPrice = unitPrice,
            };

            Order order = new Order
            {
                CreateDate = DateTime.Parse(orderDate),
                NumberOrder = "ZAM 001",
            };

            order.Add(product);
            return order;
        }

        [Fact]
        public void DayOfWeekStrategyCanDiscountTest()
        {
            ICanDiscountStrategy discountStrategy
                = new DayOfWeekCanDiscountStrategy(DayOfWeek.Friday);

            Order order = CreateOrderWith1Product("2019-10-18", 1000);

            bool canDiscount = discountStrategy.CanDiscount(order);
            canDiscount.Should().Be(true);
            
        }

        [Theory]
        [InlineData("2019-10-17", false)]
        [InlineData("2019-10-18", true)]
        public void DayOfWeekStrategyTest(string date, bool expected)
        {
            ICanDiscountStrategy discountStrategy
                = new DayOfWeekCanDiscountStrategy(DayOfWeek.Friday);

            Order order = CreateOrderWith1Product(date, 1000);

            bool result = discountStrategy.CanDiscount(order);

            result.Should().Be(expected);
        }


    }
}
