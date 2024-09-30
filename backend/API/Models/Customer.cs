using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Customers")]
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string CompanyName { get; set; } = String.Empty;
        public DateTime CreatedOn { get; set; }
    }
}