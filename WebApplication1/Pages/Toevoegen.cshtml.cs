using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class Toevoegen : PageModel
    {
        [BindProperty] public IEnumerable<Categorie> Categories { get; set; } = new ToevoegenRepository().HaalCategorieOp();
        [BindProperty] public IEnumerable<Uitgever> Uitgevers { get; set; } = new ToevoegenRepository().HaalAlleUitgeverOp();
        [BindProperty] public Uitgave Uitgave { get; init; } = new Uitgave();
        [BindProperty] public Versie Versie { get; init; } = new Versie();
        
        public void OnPostSend()
        {
            //kan beter
            Categories = new ToevoegenRepository().HaalCategorieOp();
            Uitgevers = new ToevoegenRepository().HaalAlleUitgeverOp();
            
            //check
            if (!ModelState.IsValid) return;
            
            //verstuur stripboeken
            new ToevoegenRepository().VerstuurNieuwStripboek(Uitgave,Uitgave.Reeks ,Versie.Uitgever,Versie,Uitgave.Categorie,new GebruikerId().GetClaims());
        }

    }
}