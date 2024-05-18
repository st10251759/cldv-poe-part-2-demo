﻿namespace Khumalo_Craft_P2.Models
{
    public class OrderRequest
    {
        public int OrderRequestId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string? OrderStatus { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
