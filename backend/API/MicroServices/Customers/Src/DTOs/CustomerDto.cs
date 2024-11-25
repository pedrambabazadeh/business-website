using System.ComponentModel.DataAnnotations;

namespace API.MicroServices.Customers.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string CompanyName { get; set; } = String.Empty;
        [Url]
        public string WebsiteUrl { get; set; } = String.Empty;
    }
}