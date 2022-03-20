using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using WebApplication1.Models;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class Search : PageModel
    { 

        public IEnumerable<Uitgave> Stripboeken { get; set; }

        //Basic search function, used in the navbar
        public void OnGet(string searchString)
        {
            Stripboeken = new SearchRepository().Get(searchString);
        }
    
        //Advanced search function, used on the webpage /Search
        public void OnPostAdvSearch(string advSearch, string searchString)
        {
            Stripboeken = new SearchRepository().AdvSearch(advSearch, searchString);
        }

    }
    
}
