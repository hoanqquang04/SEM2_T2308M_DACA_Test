using System.ComponentModel.DataAnnotations;

namespace edunext.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
