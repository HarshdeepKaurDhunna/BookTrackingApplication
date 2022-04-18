using System.ComponentModel.DataAnnotations;

namespace BookTrackingApplication.Models
{
    public class Book
    {
        [Key]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public string Category { get; set; }
        public Category Categories { get; set; }
    }
}
