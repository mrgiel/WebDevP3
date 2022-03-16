namespace WebApplication1.Models;

public class Versie
{
    public int versie_id { get; set; }
    
    public int id { get; set; }
    
    public int isbn { get; set; }

    public float prijs { get; set; }
    
    public string afbeelding_url { get; set; }

    public Uitgave Uitgave { get; set; }
    
    public Reeks Reeks { get; set; }
}