using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Klasse
{

    public class Categorie
    {
        public int cat_id { get; set; }

        [Required] public string cat_naam { get; set; }

    }
}