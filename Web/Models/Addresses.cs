using System;
using System.ComponentModel.DataAnnotations;


namespace Web.Models
{
    public class Addresses
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public int FlatNumber { get; set; }
    }

}
