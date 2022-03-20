using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages;

public class StripboekAanpassen : PageModel
{

    [BindProperty]public Versie Versie { get; init; }
    [BindProperty]public IEnumerable<Versie> StripboekInformatie { get; set; }


    public void OnGet([FromQuery(Name = "id")] int id)
    {
        StripboekInformatie = new StripboekenAanpassenRepository().HaalStripboekInformatieOp(id);
    }

    public void OnPostSend()
    {
        if (StripboekInformatie != null)
            new StripboekenAanpassenRepository().StripboekAanpassen(Versie);
    }

}