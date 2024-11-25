namespace API.MicroServices.Messages.Queries
{
    public class MessageQuery
    {
        public DateTime? CreatedOn { get; set; }
        public int? CustomerID { get; set; }
        public string? SortBy { get; set; } = string.Empty;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}