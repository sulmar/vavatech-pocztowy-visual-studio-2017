namespace Pocztowy.Models
{
    public class OrderDetail : BaseEntity<int>
    {
        public Product Product { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total => Quantity * UnitPrice;
    }
}
