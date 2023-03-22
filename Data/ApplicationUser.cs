using Microsoft.AspNetCore.Identity;
namespace NewBTC.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string? BitcoinAddress { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        
    }
}
