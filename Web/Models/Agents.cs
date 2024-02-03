using System;
using System.ComponentModel.DataAnnotations;



namespace Web.Models
{

    public class Agents
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string AgentName { get; set; }
        [Required]
        public string AgentSurName { get; set; }
        [Required]
        public string AgentMidName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Phonenum { get; set; }
        [Required]
        public string Passport { get; set; }
    }
}
