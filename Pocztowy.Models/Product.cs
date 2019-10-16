namespace Pocztowy.Models
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
