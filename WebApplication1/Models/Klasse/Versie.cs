using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Klasse
{

    public class Versie
    {
        public int versie_id { get; init; }

        public int id { get; set; }

        public string isbn { get; init; }

        [Required] public int druk { get; init; }

        public float prijs { get; init; }

        [Required] public string afbeelding_url { get; init; }

        public DateTime datum { get; init; }

        public Uitgave Uitgave { get; set; }

        public Uitgever Uitgever { get; set; }

        public IsGemaaktDoor IsGemaaktDoor { get; set; }
    }
}