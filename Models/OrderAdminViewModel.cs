namespace Khumalo_Craft_P2.Models
{
    public class OrderAdminViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserEmail { get; set; }
        public string? Status { get; set; }
    }
}
