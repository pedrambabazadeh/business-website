using System.ComponentModel.DataAnnotations;

namespace API.MicroServices.Messages.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;

        [Required]
        public string Content { get; set; } = String.Empty;
        
        public DateTime CreatedOn { get; set; }

        [Required]
        public int CustomerID { get; set; }
    }
}