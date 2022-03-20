using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Klasse;

public class Uitgever
{
    public int uitgever_id { get; set; }
    [Required]public string uitgever_naam { get; set; }
}