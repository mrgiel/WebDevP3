using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Pages.Shared
{
    public class Stripboeken_Toevoegen : PageModel
    {

        public void OnGet()
        {
        }

        [Required, BindProperty]
        public Uitgave Uitgaves { get; set; } = new Uitgave();
        [Required, BindProperty]
        public Reeks Reeks { get; set; } = new Reeks();

        public void OnPostSend()
        {
            if (ModelState.IsValid)
            {
                new ToevoegenRepository().VoegToe(Reeks,Uitgaves);
            }
            
        }
    }
}