using API.Models;

namespace API.MicroServices.Users.Src.Interfaces
{
    public interface ITokenService
    {
        string Create(AppUser appUser);
    }
}