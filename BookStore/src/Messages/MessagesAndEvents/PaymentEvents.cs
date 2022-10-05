namespace MessagesAndEvents
{
	public class PaymentCompletedEvent
	{
		public int OrderId { get; set; }
	}

	public class PaymentFailedEvent
	{
		public int OrderId { get; set; }
		public string Message { get; set; }

	}
}
