using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Bezit
    {
        public int rating { get; }
        
        [Required]
        public string staat { get; set; }

        public string beschrijving { get; set; }

        public int hoeveelheid { get; set; }
        
        [DataType(DataType.Currency)]
        public float prijs_betaald { get; set; }
        
        public string gebruikersnaam { get; set; }

        public int id { get; set; }

    }
}