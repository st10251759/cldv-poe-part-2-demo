﻿namespace Khumalo_Craft_P2.Models
{
    public class OrderHistoryViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
