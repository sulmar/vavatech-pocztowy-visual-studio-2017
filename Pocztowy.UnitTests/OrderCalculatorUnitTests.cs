using Pocztowy.Calculators;
using Pocztowy.Models;
using System;
using Xunit;
using FluentAssertions;

namespace Pocztowy.UnitTests
{
    public class OrderCalculatorUnitTests
    {
        [Fact(DisplayName = "Weryfikacja promocji 50% w pi¹tek")]
        public void DiscountCalculateTest()
        {
            // Arrange
            Product product = new Product
            {
                Name = "Keyboard",
                Color = "Black",
                UnitPrice = 1000,
            };

            Order order = new Order
            {
                CreateDate = DateTime.Parse("2019-10-18"),
                NumberOrder = "ZAM 001",
            };

            order.Add(product);

            var orderCalculator = new FridayDiscountCalculator();

            // Act

            decimal result = orderCalculator.CalculateDiscount(order);


            // Assert

            //  Assert.Equal(500, result);

            result.Should().Be(500, "50% upustu");

            // dotnet add package FluentAssertions
        }

        [Theory(DisplayName = "Weryfikacja promocji 50%")]
        [InlineData("2019-10-18", 1000, 500)]
        [InlineData("2019-10-17", 1000, 0)]
        public void DiscountCalculateTests(
            string orderDate,
            decimal unitPrice,
            decimal expected)
        {
            // Arrange
            Order order = CreateOrderWith1Product(orderDate, unitPrice);

            var orderCalculator = new FridayDiscountCalculator();

            // Act

            decimal result = orderCalculator.CalculateDiscount(order);


            // Assert
            result.Should().Be(expected, "50% upustu");

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
            IDiscountStrategy discountStrategy
                = new DayOfWeekDiscountStrategy(DayOfWeek.Friday, 0.5m);

            Order order = CreateOrderWith1Product("2019-10-18", 1000);

            bool canDiscount = discountStrategy.CanDiscount(order);
            canDiscount.Should().Be(true);
            
        }

        [Fact]
        public void DayOfWeekStrategyCalculateDiscountTest()
        {
            IDiscountStrategy discountStrategy
                = new DayOfWeekDiscountStrategy(DayOfWeek.Friday, 0.5m);

            Order order = CreateOrderWith1Product("2019-10-18", 1000);

            decimal discount = discountStrategy.CalculateDiscount(order);

            discount.Should().Be(500);
        }


    }
}
