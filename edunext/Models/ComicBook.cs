using System.ComponentModel.DataAnnotations;

namespace edunext.Models
{
    public class ComicBook
    {
        [Key]
        public int ComicBookID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Author { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }
    }
}
