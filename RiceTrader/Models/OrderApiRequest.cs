namespace RiceTrader.Models
{
        public class OrderApiRequest
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> Items { get; set; }

        public OrderApiRequest()
        {
            Items = new List<OrderItemDto>();
        }
    }
}
