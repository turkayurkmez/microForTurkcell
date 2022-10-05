namespace Order.API.Models
{
    public enum OrderState
    {
        Pending,
        Completed,
        Failed,
        Canceled

    }
    public class Order
    {
        public int Id { get; set; }
        public DateTime? OrderedDate { get; set; } = DateTime.Now;
        public string CustomerId { get; set; }
        public decimal? TotalPrice { get; set; }

        public OrderState OrderState { get; set; } = OrderState.Pending;
    }
}
