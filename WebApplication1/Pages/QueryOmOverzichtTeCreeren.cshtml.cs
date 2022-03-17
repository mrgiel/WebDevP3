using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class QueryOmOverzichtTeCreeren : PageModel
    {
        public IEnumerable<Versie> data { get; set; }

        public void OnGet()
        {
            data = new QueryOmOverzichtTeCreerenRepository().HaalCollectieOpRepo();
        }
    }
}