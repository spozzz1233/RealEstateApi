using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Customers
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerSurname { get; set; }
        [Required]
        public string CustomerMidName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Phonenum { get; set; }
        [Required]
        public string Passport { get; set; }
    }
}
