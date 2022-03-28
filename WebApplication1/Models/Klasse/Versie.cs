using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Klasse
{

    public class Versie
    {
        public int versie_id { get; set; }

        public string isbn { get; set; }

        [Required] public int druk { get; set; }

        public float prijs { get; set; }

        [Required] public string afbeelding_url { get; set; }

        public DateTime datum { get; set; }

        public Uitgave Uitgave { get; set; }

        public Uitgever Uitgever { get; set; }

        public IsGemaaktDoor IsGemaaktDoor { get; set; }

        public Bezit bezit { get; set; }
    }
}