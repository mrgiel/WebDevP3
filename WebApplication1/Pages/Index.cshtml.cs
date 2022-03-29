using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Versie> data { get; set; }

        public void OnGet()
        {
            data = new QueryOmOverzichtTeCreerenRepository().HaalCollectieOpRepo();
        }
    }
}