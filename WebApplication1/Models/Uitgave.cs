﻿namespace WebApplication1.Models
{
    public class Uitgave
    {
        public string isbn { get; set; }
        public string Naam { get; set; }
        public int Versie_nr { get; set; }
        public int Jaar { get; set; }
        public int Hoogte { get; set; }
        public string afbeelding_url { get; set; }
        public string Uitgever { get; set; }
        public int ReeksNummer { get; set; }
        public int CategorieNummer { get; set; }
        public bool Nsfw { get; set; }
        public float Prijs { get; set; }
    }
}