using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Blogs")]
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public Category Category { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; } = string.Empty;
        
        public AppUser? AppUser { get; set; }
    }
}