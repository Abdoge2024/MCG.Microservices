using MCG.Author.API.Models;

namespace MCG.Author.API.Repositories.Interface
{
    public interface ITokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
    
}
