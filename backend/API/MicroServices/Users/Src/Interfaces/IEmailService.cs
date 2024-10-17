namespace API.MicroServices.Users.Src.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendResetPasswordEmail(string email, string resetToken);
    }
}