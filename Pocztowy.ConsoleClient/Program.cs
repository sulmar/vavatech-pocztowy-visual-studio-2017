using Pocztowy.Calculators;
using Pocztowy.FakeRepositories;
using Pocztowy.IRepositories;
using Pocztowy.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

    
    public interface IReportBuilder
    {
        string Build();
    }

    public class StringReportBuilder : IReportBuilder
    {
        public string Build()
        {
            string report = string.Empty;

            for (int i = 0; i < 100000; i++)
            {
                report += $"A{i}";
            }

            return report;

        }
    }

    public class StringBuilderReportBuilder : IReportBuilder
    {
        public string Build()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 100000; i++)
            {
                stringBuilder.Append($"A{i}");
            }

            return stringBuilder.ToString();
        }
    }

    class Program
    {
        

        static void Main(string[] args)
        {
            IReportBuilder reportBuilder1 = new StringReportBuilder();

            IReportBuilder reportBuilder2 = new StringBuilderReportBuilder();

            Task t1 = Task.Run(() => reportBuilder1.Build());
            Task t2 = Task.Run(() => reportBuilder2.Build());

            Task.WaitAll(t1, t2);

            Console.WriteLine("Completed.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();



            // Test();

        }

        private static void Test()
        {
            Console.WriteLine("Branch aszatkowski");

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
