using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTest.Models
{
    public class Rentals
    {
        [Key]
        public int RentalID { get; set; }
        [ForeignKey(nameof(CustomerID))]
        public int CustomerID { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
