namespace WebApplication1.Models.Klasse
{
    public enum RolGebruiker
    {
        admin,
        moderator,
        gebruiker
    }

    public class Gebruiker
    {
        public RolGebruiker rol { get; set; }
        public int Id { get; set; }
    }
}