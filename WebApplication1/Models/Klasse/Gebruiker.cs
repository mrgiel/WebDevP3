namespace WebApplication1.Models.Klasse
{
    // public enum RolGebruiker
    // {
    //     admin,
    //     moderator,
    //     gebruiker
    // }

    public class Gebruiker
    {
        public string rol { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get;  set; }
    }
}