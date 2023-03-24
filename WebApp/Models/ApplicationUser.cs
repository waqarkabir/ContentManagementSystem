using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string City { get; set; }
    }
}
