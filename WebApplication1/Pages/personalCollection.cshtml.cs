using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class personalCollection : PageModel
    {
        public void OnGet()
        {
            var bezit = new Bezit("sjonnie4332");
            ShowPersonalCollection personalCollection = new ShowPersonalCollection();

            List<Bezit> result = personalCollection.GetCollection(bezit);

            foreach (var item in result)
            {
                Console.WriteLine(item.gebruikersnaam);
                Console.WriteLine(item.beschrijving);
                Console.WriteLine(item.hoeveelheid);
                Console.WriteLine(item.isbn);
            }
        }
    }
}