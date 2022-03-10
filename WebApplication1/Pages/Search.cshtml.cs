using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class Search : PageModel
    { 

        public IEnumerable<Uitgave> Stripboeken { get; set; }

        public void OnGet(string searchString)
        {
            Stripboeken = new SearchRepository().Get(searchString);
        }

    }
    
}
