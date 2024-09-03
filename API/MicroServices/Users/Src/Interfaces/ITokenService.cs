using API.Models;

namespace API.MicroServices.Users.Interfaces
{
    public interface ITokenService
    {
        string Create(AppUser appUser);
    }
}