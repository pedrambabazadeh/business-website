using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    [Table("Users")]
    public class AppUser : IdentityUser
    {
        public List<Blog> Blogs { get; set; } = new();
    }
}