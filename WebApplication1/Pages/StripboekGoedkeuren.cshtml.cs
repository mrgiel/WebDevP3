using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages;

public class StripboekGoedkeuren : PageModel
{
    public IEnumerable<Versie> Stripboeken { get; set; }
    
    public IActionResult OnPostGoedkeuren(int id)
    {
        Stripboeken = new StripboekGoedkeurenRepository().Goedkeuren(id);
        return RedirectToPage("AdminPagina");
    } 
    
    public void OnPost(int versie_id)
    {
        Stripboeken = new StripboekenAanpassenRepository().HaalStripboekInformatieOp(versie_id);
    }
    
    
}