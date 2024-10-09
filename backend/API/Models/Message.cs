using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Messages")]
    public class Message
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedOn { get; set; }
        public int CustomerID { get; set; }
    }
}