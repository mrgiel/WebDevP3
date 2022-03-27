using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Engines;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class StripboekToevoegen : PageModel
    {

        [BindProperty] public Uitgave Uitgave { get; init; } = new Uitgave();
        [BindProperty] public Versie Versie { get; init; } = new Versie();

        [BindProperty] public string PersoonArray { get; set; }

        public IActionResult OnPostSend()
        {
            var a = PersoonArray.Split(new Char [] {'/' , ';' });
            var b = string.Join(",",a[0]);
            var c = string.Join(",",a[1]);
            var d = PersoonArray != null ? (PersoonArray.Split(',').Length - 1) / 2 : 1;
            var e = PersoonArray.Split(new Char [] {'/' , ';' })[0];
            e = e;
            
            //check
            if (!ModelState.IsValid) return Page();
            
            //verstuur stripboeken
            //new StripboekToevoegenRepository().VerstuurNieuwStripboek(Uitgave,Uitgave.Reeks ,Versie.Uitgever,Versie,Uitgave.Categorie,b,e,c,d,new GebruikerRepo().HaalIdOp());
            return Page();
        }
    }
}