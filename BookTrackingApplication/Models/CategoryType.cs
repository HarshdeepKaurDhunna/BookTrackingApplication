using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookTrackingApplication.Models
{
    public class CategoryType
    {
        [Key]
        public string Type { get; set; }
        public string Name { get; set; }

        public Category Categories { get; set; }

    }
}
