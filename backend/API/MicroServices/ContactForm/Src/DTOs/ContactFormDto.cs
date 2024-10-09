using System.ComponentModel.DataAnnotations;

namespace API.MicroServices.ContactForm.Src.DTOs
{
    public class ContactFormDto
    {
        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;

        public string CompanyName { get; set; } = String.Empty;
        public string WebsiteUrl { get; set; } = String.Empty;
        
        [Required]
        public string Content { get; set; } = String.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Today;
    }
}