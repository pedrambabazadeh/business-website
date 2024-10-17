using System.ComponentModel.DataAnnotations;

namespace API.MicroServices.Users.Src.DTOs
{
    public class SendPasswordResetLinkDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}