using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    [Table("Users")]
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Blog> Blogs { get; set; } = new(); // Needed for reference ??
        public Category Category { get; set; }
    }
}