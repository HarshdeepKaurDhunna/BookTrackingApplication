using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTrackingApplication.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TypeCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryNum { get; set; }
        public string Name { get; set; }

        public List<CategoryType> CategoryTypies { get; set; }
    }
}
