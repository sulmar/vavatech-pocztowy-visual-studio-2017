using Pocztowy.Calculators;
using Pocztowy.FakeRepositories;
using Pocztowy.IRepositories;
using Pocztowy.Models;
using System;
using System.Collections.Generic;

namespace Pocztowy.ConsoleClient
{
    public abstract class Person
    {
        public virtual void DoWork()
        {
            Console.WriteLine("working...");
        }
    }

    public class Man : Person
    {
        public override void DoWork()
        {
            Console.WriteLine("sleeping...");
        }
    }

    public class Woman : Person
    {

    }

    

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello Marcin");

            byte x = 255;

            checked
            {
                x++;
                x++;
            }

            Console.WriteLine(x);

            // ICustomerRepository customerRepository = new FakeCustomerRepository();

            // var customers = customerRepository.GetByPesel("64645645");

            Product product = new Product
            {
                Name = "Keyboard",
                Color = "Black",
                UnitPrice = 1000,
            };

            Order order = new Order
            {
                NumberOrder = "ZAM 001",
            };

            order.Add(product);

            ICanDiscountStrategy canDiscountStrategy = new HappyHoursCanDiscountStrategy(
                from: TimeSpan.Parse("09:30"),
                to: TimeSpan.Parse("17:00"),
                minimumAmount: 100m
                );

            ICalculateDiscountStrategy calculateDiscountStrategy = new FixedCalculateDiscountStrategy(10);
    
            IDiscountCalculator orderCalculator
                = new DiscountCalculator(canDiscountStrategy, calculateDiscountStrategy);

            decimal discount = orderCalculator.CalculateDiscount(order);

            Console.WriteLine(discount);

        }

        private static decimal Calculate(int qty, int unitprice)
        {
            throw new NotImplementedException();
        }

        private static void Send(string message)
        {
            throw new NotImplementedException();
        }
    }
}
