namespace RiceTrader.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string PackageSize { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public bool InStock { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
