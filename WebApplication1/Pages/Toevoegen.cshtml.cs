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
        public bool Error { get; set; }
        [Required] [BindProperty] public int ISBN { get; set; }

        [Required, DataType(DataType.Text)]
        [BindProperty]
        public string naam { get; set; }

        [BindProperty] public int versie_nr { get; set; }
        [BindProperty] public int jaar { get; set; }
        [BindProperty] public int hoogte { get; set; }

        [DataType(DataType.Text)]
        [BindProperty]
        public string uitgever { get; set; }

        [BindProperty] public bool NSFW { get; set; }

        [DataType(DataType.Currency)]
        [BindProperty]
        public float prijs { get; set; }

        [Required, DataType(DataType.Text)]
        [BindProperty]
        public string reeksUser { get; set; }


        public void OnGet()
        {
        }

        public void OnPostSend()
        {
            if (!new ToevoegenRepository().VoegToe(reeksUser, ISBN, naam, jaar, hoogte, uitgever, NSFW, prijs))
                Error = true;
        }
    }
}