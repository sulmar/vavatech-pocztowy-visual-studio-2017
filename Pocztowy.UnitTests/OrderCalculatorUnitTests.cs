using Pocztowy.Calculators;
using Pocztowy.Models;
using System;
using Xunit;
using FluentAssertions;
using FluentAssertions.Extensions;
using System.Threading.Tasks;

namespace Pocztowy.UnitTests
{
    public class OrderCalculatorUnitTests
    {
        
        
        [Theory(DisplayName = "Weryfikacja rabatu procentowego")]
        [InlineData(1000, 0.5, 500)]
        [InlineData(0, 0.5, 0)]
        [InlineData(0.1, 0.5, 0.05)]
        [InlineData(0.2, 0.5, 0.10)]
        [InlineData(0.01, 0.5, 0.00, Skip = "bo tak" )]
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
            result.Should().Be(expected, "jaki upust????");

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

        public void GitHubTest_AL(string date, bool expected)
        {}

        [Fact]
        public void CalculatorExecutionTest()
        {

            // Arrange

            ICanDiscountStrategy canDiscountStrategy
              = new DayOfWeekCanDiscountStrategy(DayOfWeek.Friday);

            ICalculateDiscountStrategy calculateDiscountStrategy
             = new PercentageCalculateDiscountStrategy(0.5m);


            IDiscountCalculator discountCalculator
                = new DiscountCalculator(canDiscountStrategy, calculateDiscountStrategy);

            Order order = CreateOrderWith1Product("2019-10-18", 1000);

            // Act
            Action act = () =>  discountCalculator.CalculateDiscount(order);

            // Asserts
            act
                .ExecutionTime()
                .Should()
                .BeLessOrEqualTo(500.Milliseconds());

        }

        [Fact]
        public void CalculatorExceptionTest()
        {

            // Arrange
            IDiscountCalculator discountCalculator = CreateDiscountCalculator();

            // Act
            Action act = () => discountCalculator.CalculateDiscount(null);

            // Asserts

            act.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void CalculateAsyncTest()
        {
            // Arrange
            IDiscountCalculatorAsync discountCalculator = CreateDiscountCalculator();

            Order order = CreateOrderWith1Product("2019-10-18", 1000);

            // Act
            Func<Task<decimal>> act =
                () => discountCalculator.CalculateDiscountAsync(order);

            // Asserts
            act.Should()
                .CompleteWithin(500.Milliseconds())
                .Which
                .Should()
                .Be(500);
        }

        private static DiscountCalculator CreateDiscountCalculator()
        {
            ICanDiscountStrategy canDiscountStrategy
                          = new DayOfWeekCanDiscountStrategy(DayOfWeek.Friday);

            ICalculateDiscountStrategy calculateDiscountStrategy
             = new PercentageCalculateDiscountStrategy(0.5m);

            var discountCalculator
                = new DiscountCalculator(canDiscountStrategy, calculateDiscountStrategy);

            return discountCalculator;
        }

        [Fact]
        public void ArgumentExceptionAsyncTest()
        {
            IDiscountCalculatorAsync discountCalculator = CreateDiscountCalculator();

            Action actnull = () =>
                discountCalculator.CalculateDiscountAsync(null).Wait();

            actnull.Should().Throw<ArgumentNullException>();

        }

    }
}
