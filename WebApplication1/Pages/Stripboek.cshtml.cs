using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages;

public class Stripboek : PageModel
{
    [FromQuery]
    public string id { get; set; }
    
    [BindProperty]
    public IEnumerable<Versie> stripboek { get; set; }
    
    public void OnGet()
    {
        StripboekenAanpassenRepository stripboekRepo = new StripboekenAanpassenRepository();
        stripboek = stripboekRepo.HaalStripboekInformatieOp(Convert.ToInt32(id));
    }
}