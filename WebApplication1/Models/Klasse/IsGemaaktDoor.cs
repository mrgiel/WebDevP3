namespace WebApplication1.Models.Klasse;

public enum RolPersoon { auteur, tekenaar }
public class IsGemaaktDoor
{
    public int versie_id { get; set; }
    
    public int persoon_id { get; set; }

    public RolPersoon rol { get; set; }
    public Persoon Persoon { get; set; }


}