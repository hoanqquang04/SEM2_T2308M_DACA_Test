using System.ComponentModel.DataAnnotations;

namespace edunext.Models
{
    public class Rental
    {
        [Key]
        public int RentalID { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
