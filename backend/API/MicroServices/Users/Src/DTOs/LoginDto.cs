using System.ComponentModel.DataAnnotations;

namespace API.MicroServices.Users.DTOs
{
    public class LoginDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}