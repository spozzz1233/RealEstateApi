using System;
using System.ComponentModel.DataAnnotations;


namespace Web.Models
{
    public class Trades
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int AgentId { get; set; }
        [Required]
        public int EstateID { get; set; }
        [Required]
        public int Price { get; set; }

    }

}
