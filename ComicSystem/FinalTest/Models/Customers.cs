using System.ComponentModel.DataAnnotations;

namespace FinalTest.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Registration { get; set; }
    }
}
