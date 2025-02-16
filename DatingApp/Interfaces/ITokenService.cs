using DatingApp.Entites;

namespace DatingApp.Interfaces
{
    public interface ITokenService
    {
        string CreateJWTToken(AppUser user);
    }
}
