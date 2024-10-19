using API.Models;

namespace API.MicroServices.CMS.Src.Queries
{
    public class BlogQuery
    {
        public Category? Cat { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? SortBy { get; set; } = string.Empty;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}