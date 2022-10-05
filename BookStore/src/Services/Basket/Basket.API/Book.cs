namespace Basket.API
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public int Quantity { get; set; }

    }
}
