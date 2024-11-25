using System.ComponentModel.DataAnnotations;

namespace API.MicroServices.Users.Src.DTOs
{
    public class PasswordResetDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public string? EncodedResetToken { get; set; }
        
        [Required]
        public string? NewPassword { get; set; }
    }
}