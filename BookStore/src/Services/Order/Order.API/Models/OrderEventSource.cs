namespace Order.API.Models
{
    public class OrderEventSource
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public DateTime EventFireDate { get; set; }
        public string Content { get; set; }
        public string FiredEventName { get; set; }

    }
}
