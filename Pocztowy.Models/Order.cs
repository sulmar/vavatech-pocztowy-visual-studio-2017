using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pocztowy.Models
{

    // CTRL+T - przejście do klasy
    public class Order : BaseEntity<long> 
    {
        public Order()
        {
            CreateDate = DateTime.Now;
            details = new List<OrderDetail>();
        }

        public DateTime CreateDate { get; set; }
        public string NumberOrder { get; set; }
        public Customer Rentee { get; set; }

        private List<OrderDetail> details;

        public IReadOnlyCollection<OrderDetail> Details => details;

        public decimal Total => Details.Sum(d => d.Quantity * d.UnitPrice);

        public void Add(Product product, short quantity = 1)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            OrderDetail orderDetail = new OrderDetail
            {
                Product = product,
                Quantity = quantity,
                UnitPrice = product.UnitPrice
            };

            details.Add(orderDetail);
        }

    }
}
