using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Richards.Models
{

    // set up the application class with the properties that will be used to create the database and store the information from the form
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required (ErrorMessage ="Please enter a Movie Title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a Year.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Please enter a valid year.")]
        public int ? Year { get; set; }

        public string ? Director { get; set; }
        public string ? Rating { get; set; }
        [Required(ErrorMessage = "Please enter whether the movie was edited.")]
        public bool Edited { get; set; }
        public string ? LentTo { get; set; }
        [Required(ErrorMessage = "Please enter whether the movie was copied to Plex.")]
        public bool CopiedToPlex { get; set; }
        public string ? Notes { get; set; }

    }
}
