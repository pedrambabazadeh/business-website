namespace API.MicroServices.Messages.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedOn { get; set; }
        public int CustomerID { get; set; }
    }
}