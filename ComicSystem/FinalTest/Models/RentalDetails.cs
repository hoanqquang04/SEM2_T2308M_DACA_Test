using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTest.Models
{
    public class RentalDetails
    {
        [Key]
        public int RentalDetailID { get; set; }
        [ForeignKey(nameof(RentalID))]
        public int RentalID { get; set; }
        [ForeignKey(nameof(ComicBookID))]
        public int ComicBookID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
