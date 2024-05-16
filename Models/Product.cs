﻿namespace Khumalo_Craft_P2.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string? ProductDescription { get; set; }

        public decimal? Price { get; set; }

        public string? Category { get; set; }

        public bool? Availability { get; set; }

        public string? ImageUrlpath { get; set; }
    }
}
