using API.Models;

namespace API.MicroServices.Blogs.DTOs
{
    public class UpdateBlogDto
    {
        public Category Cat { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }
    }
}