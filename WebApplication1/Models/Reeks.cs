using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Reeks
    {
        [Required]
        public string reeks_naam { get; set; }
        public int reeks_nr { get; set; }
    }
}