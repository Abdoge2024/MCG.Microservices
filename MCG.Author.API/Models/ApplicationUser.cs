using Microsoft.AspNetCore.Identity;

namespace MCG.Author.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string   Name { get; set; }
    }
}
