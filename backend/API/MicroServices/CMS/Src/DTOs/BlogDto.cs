using API.Models;

namespace API.MicroServices.CMS.Src.DTOs
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public Category Category { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}