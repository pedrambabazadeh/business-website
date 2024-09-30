using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Blogs")]
    public class Blog
    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public Category Cat { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string AppUserId { get; set; } = string.Empty;
        public AppUser? AppUser { get; set; }
    }

    public enum Category
    {
        frontend,
        backend,
        design,
        marketing
    }
}