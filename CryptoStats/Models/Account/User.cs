using Microsoft.AspNetCore.Identity;

namespace CryptoStats.Models.Account
{
    public class User : IdentityUser
    {
        public DateTime DateTimeCreated { get; set; }
    }
}
