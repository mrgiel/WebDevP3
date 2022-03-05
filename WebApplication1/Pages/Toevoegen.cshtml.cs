using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class Toevoegen : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty] public Uitgave Uitgaves { get; set; } = new Uitgave();
        [BindProperty] public Reeks Reeks { get; set; } = new Reeks();

        public void OnPostSend()
        {
            if (!ModelState.IsValid) return;
            var reeksNr = new ToevoegenRepository().ZoekReeksNummer(Reeks);
            if (reeksNr != null)
                new ToevoegenRepository().VoegToe(Uitgaves, reeksNr);
        }
    }
}