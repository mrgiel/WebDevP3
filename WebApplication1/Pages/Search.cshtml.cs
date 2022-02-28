using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class Search : PageModel
    {
        public void OnGet()
        {
            var connection = new MySqlConnection(
                "Server=127.0.0.1;Database=stripboekendb;Uid=root;Pwd=Test123;");
            connection.Open();
            
            Stripboeken = connection.Query<Uitgave>("SELECT * FROM uitgave");
            connection.Close();
        }

        public IEnumerable<Uitgave> Stripboeken { get; set; }
        }
    
}
