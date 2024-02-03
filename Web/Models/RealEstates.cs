using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class RealEstates
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public string TypeOfEstate { get; set; }
        [Required]
        public int EstateQuantity { get; set; }
    }

}
