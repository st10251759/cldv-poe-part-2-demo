namespace Khumalo_Craft_P2.Models
{
    public class OrderHistoryViewModel
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
