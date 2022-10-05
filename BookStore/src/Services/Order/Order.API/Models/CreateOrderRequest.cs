namespace Order.API.Models
{
    public class CreateOrderRequest
    {
        public string CustomerID { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int BookId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
