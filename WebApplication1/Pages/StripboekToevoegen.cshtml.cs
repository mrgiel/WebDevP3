using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class StripboekToevoegen : PageModel
    {
        [BindProperty] public IEnumerable<Categorie> Categories { get; set; } = new StripboekToevoegenRepository().HaalCategorieOp();
        [BindProperty] public IEnumerable<Uitgever> Uitgevers { get; set; } = new StripboekToevoegenRepository().HaalAlleUitgeverOp();
        [BindProperty] public Uitgave Uitgave { get; init; } = new Uitgave();
        [BindProperty] public Versie Versie { get; init; } = new Versie();
        
        public void OnPostSend()
        {
            //kan beter via multi-mapping
            Categories = new StripboekToevoegenRepository().HaalCategorieOp();
            Uitgevers = new StripboekToevoegenRepository().HaalAlleUitgeverOp();
            
            //check
            if (!ModelState.IsValid) return;
            
            //verstuur stripboeken
            new StripboekToevoegenRepository().VerstuurNieuwStripboek(Uitgave,Uitgave.Reeks ,Versie.Uitgever,Versie,Uitgave.Categorie,new GebruikerRepo().HaalIdOp());
        }

    }
}