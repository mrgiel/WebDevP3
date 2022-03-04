using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace WebApplication1.Models
{
    public class Uitgave
    {
        public int id { get; set; }
        public int isbn { get; set; }
        [Required]
        public string naam { get; set; }
        public int versie_nr { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime jaar { get; set; }
        public int hoogte { get; set; }
        public string afbeelding_url { get; set; }
        public string uitgever { get; set; }
        public int reeks_nummer { get; set; }
        public int categorie_nummer { get; set; }
        public bool nsfw { get; set; }
        public float prijs { get; set; }
    
    }
}