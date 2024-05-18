using Microsoft.AspNetCore.Identity;

namespace Khumalo_Craft_P2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
