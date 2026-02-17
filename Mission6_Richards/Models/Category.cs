using System.ComponentModel.DataAnnotations;

namespace Mission6_Richards.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; } // primary key
        [Required]
        public string CategoryName { get; set; }

    }
}
