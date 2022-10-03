﻿namespace Catalog.Domains
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

    }
}
