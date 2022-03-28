using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Klasse
{
    /// <summary>
    /// Geeft een exacte weergave van de Bezit tafel
    /// in de database weer.
    /// </summary>
    public class Bezit
    {
        public int rating { get; set; }
        public string staat { get; set; }
        public string beschrijving { get; set; }
        public int hoeveelheid { get; set; }
        [DataType(DataType.Currency)]
        public float prijs_betaald { get; set; }

        public int Versie_id { get; set; }
        public int uitgave_id { get; set; }
        public Versie Versie { get; set; }
        public Uitgave Uitgave { get; set; }
    }
}