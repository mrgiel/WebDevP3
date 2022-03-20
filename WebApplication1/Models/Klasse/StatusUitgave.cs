using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Klasse;

public class StatusUitgave
{
    public bool status { get; set; }
    
    [Required] public DateTime datum_goedkeruing { get; set; }

    public string gebruiker_id { get; set; }
    
    public int versie_id { get; set; }
}