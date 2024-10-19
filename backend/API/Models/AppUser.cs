using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    [Table("Users")]
    public class AppUser : IdentityUser
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public List<Blog> Blogs { get; set; } = [];
        [Required]
        public Category Category { get; set; }
    }
}