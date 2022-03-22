using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Klasse
{
    public class Uitgave
    {
        //nigel
        public int uitgave_id { get; set; }
        [Required] public string naam { get; set; }
        public int hoogte { get; set; }
        
        public bool nsfw { get; set; }
        public string beschrijving { get; set; }

        //multi-mapping
        public Categorie Categorie { get; set; }

        public Reeks Reeks { get; set; }

        public Versie Versie { get; set; }
        
        //hoort NIET in uitgave
        public string isbn { get; set; }
        public int versie_id { get; set; }
        [Required] public DateTime jaar { get; set; }
        public string afbeelding_url { get; set; }
        public string uitgever_naam { get; set; }
        public int reeks_nummer { get; set; }
        public int categorie_nummer { get; set; }
        public float prijs { get; set; }
        public int status { get; set; }
        }
}