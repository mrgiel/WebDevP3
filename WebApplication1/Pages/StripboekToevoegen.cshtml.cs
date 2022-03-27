using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class StripboekToevoegen : PageModel
    {

        [BindProperty] public Uitgave Uitgave { get; init; } = new Uitgave();
        [BindProperty] public Versie Versie { get; init; } = new Versie();

        [BindProperty] public string PersoonArray { get; set; }
        [BindProperty] public string RolArray { get; set; }
        [BindProperty] public string AuteurArray { get; set; }

        public IActionResult OnPostSend()
        {
            //check
            if (!ModelState.IsValid) return Page();
            
            var persoonArray = PersoonArray.Split('/');
            var auteurArray = AuteurArray.Split('/');
            var length = PersoonArray != null ? (PersoonArray.Split(',').Length - 1 + AuteurArray.Split(',').Length - 1) / 2 : 0;
            
            //verstuur stripboeken
            new StripboekToevoegenRepository().VerstuurNieuwStripboek(Uitgave,Uitgave.Reeks ,Versie.Uitgever,Versie,Uitgave.Categorie,persoonArray.First() + auteurArray.First(),RolArray,persoonArray.Last() + auteurArray.Last(),length,new GebruikerRepo().HaalIdOp());
            return Page();
        }
    }
}