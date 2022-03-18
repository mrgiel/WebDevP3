using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class Toevoegen : PageModel
    {
        [BindProperty] public IEnumerable<Categorie> Categories { get; set; }

        [BindProperty] public IEnumerable<Uitgever> Uitgevers { get; set; }
        [BindProperty] public Uitgave Uitgave { get; init; } = new Uitgave();
        [BindProperty] public Versie Versie { get; init; } = new Versie();

        public void OnGet()
        {
            //voor nu
            Categories = new ToevoegenRepository().HaalCategorieOp();
            Uitgevers = new ToevoegenRepository().HaalAlleUitgeverOp();
        }

        public void OnPostSend()
        {
            //voor nu
            Categories = new ToevoegenRepository().HaalCategorieOp();
            Uitgevers = new ToevoegenRepository().HaalAlleUitgeverOp();
            
            if (!ModelState.IsValid) return;
            //send stripboeken
            new ToevoegenRepository().VerstuurNieuwStripboek(Uitgave,Uitgave.Reeks ,Versie.Uitgever,Versie,Uitgave.Categorie,new GebruikerId().GetClaims());
        }

    }
}