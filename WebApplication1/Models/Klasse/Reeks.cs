using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Klasse
{
    public class Reeks
    { 
        [Required]public string reeks_naam { get; init; }
        public int reeks_nr { get; set; }
    }
}