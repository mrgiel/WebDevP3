namespace WebApplication1.Models
{
    public class Uitgave
    {
        public int ISBN { get; set; }
        public string naam { get; set; }
        public int versie_nr { get; set; }
        public int jaar { get; set; }
        public int hoogte { get; set; }
        public string afbeeldingURL { get; set; }
        public string uitgever { get; set; }
        public int reeks_nummer { get; set; }
        public bool NSFW { get; set; }
        public float prijs { get; set; }
        public int categorie_nummer { get; set; }
    }
}