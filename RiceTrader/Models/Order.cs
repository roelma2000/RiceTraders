namespace RiceTrader.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int VendorId { get; set; } 
        public string VendorName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductSize { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }

}
