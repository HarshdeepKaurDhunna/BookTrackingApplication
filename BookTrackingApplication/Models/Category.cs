using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookTrackingApplication.Models
{
    public class Category
    {

        [Key]
        public string NameToken { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

       
        public List<Book> Books { get; set; }
        public List<CategoryType> CategoryTypies { get; set; }
    }
}
