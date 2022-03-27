using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class GebruikersAanpassen : PageModel {

        [BindProperty] public Gebruiker Gebruiker { get; init; }
        [BindProperty] public IEnumerable<Gebruiker> GebruikerInformatie { get; set; }


        public void OnGet([FromQuery(Name = "id")] string id)
        {
            GebruikerInformatie = new GebruikerRepo(id).Get();
        }
        
        public IActionResult OnPost(string id)
        {
            return RedirectToPage("GebruikersAanpassen", new {id = id});
        }
        
        public IActionResult OnPostSend()
        {
            if (GebruikerInformatie != null)
            {
                new GebruikerRepo().GebruikerAanpassen(Gebruiker);
                return RedirectToPage("GebruikerPagina");
            }
            return Page();
        }
    }
}
