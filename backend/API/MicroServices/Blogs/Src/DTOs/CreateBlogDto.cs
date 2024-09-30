using API.Models;

namespace API.MicroServices.Blogs.DTOs
{
    public class CreateBlogDto
    {
        public string Author { get; set; } = string.Empty;
        public Category Cat { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn = DateTime.Today;
        public DateTime ModifiedOn = DateTime.Today;
    }
}