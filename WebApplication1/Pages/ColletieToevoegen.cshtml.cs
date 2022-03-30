using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages;

public class ColletieToevoegen : PageModel
{
    [BindProperty] public Versie data { get; set; }


    public IActionResult OnGet([FromQuery(Name = "id")] int id)
    {
        if (!new CollectieToevoegenRepository().StatusUitgave(id, new GebruikerRepo().HaalIdOp()) || id == 0) return RedirectToPage("index");
        data = new CollectieToevoegenRepository().HaalStripboekInformatieOp(id);
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        return RedirectToPage("ColletieToevoegen", new {id = id});
    }

    public IActionResult OnPostSend()
    {
        data.bezit.gebruiker_id = new GebruikerRepo().HaalIdOp();

        if (data != null) new CollectieToevoegenRepository().VoegToeAanCollectie(data.bezit);
        return RedirectToPage("/personalCollection",new {id= new GebruikerRepo().HaalIdOp()});
    }
}