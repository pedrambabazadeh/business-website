using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Customers")]
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        
        [Url]
        public string WebsiteUrl { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}