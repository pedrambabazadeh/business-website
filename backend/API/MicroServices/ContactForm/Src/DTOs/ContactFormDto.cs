using System.ComponentModel.DataAnnotations;

namespace API.MicroServices.ContactForm.Src.DTOs
{
    public class ContactFormDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        
        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Today;
    }
}