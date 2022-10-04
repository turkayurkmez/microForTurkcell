namespace MessagesAndEvents
{
    public class AddBookToBasketRequest
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public string UserId { get; set; }

        public int Quantity { get; set; } = 1;
    }

}