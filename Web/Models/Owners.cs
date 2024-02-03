using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Owners
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string OwnerSurName { get; set; }
        [Required]
        public string OwnerMidName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Phonenum { get; set; }
        [Required]
        public string Passport { get; set; }
    }

}



