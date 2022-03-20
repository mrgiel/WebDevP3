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
    public class Zoek : PageModel
    { 

        public IEnumerable<Uitgave> Stripboeken { get; set; }

        /// <summary>
        /// Basis zoekfunctie, zoekt alleen op naam.
        /// Haalt gegevens uit de tabellen: uitgever, uitgave en versie
        /// </summary>
        /// <param name="strZoekterm">strZoekterm is de zoekterm die de gebruiker invult in de zoekbalk</param>
        public void OnGet(string strZoekterm)
        {
            Stripboeken = new SearchRepository().Get(strZoekterm);
        }
    /// <summary>
    /// Geavanceerde zoekfunctie. Wordt gebruikt op de /Zoek pagina
    /// Haalt gegevens uit de tabellen: uitgever, uitgave en versie
    /// </summary>
    /// <param name="zoekCategorie">zoekCategorie wordt geselecteerd in een droplist en bepaald in wel tabel van de database gezocht wordt.</param>
    /// <param name="strZoekterm"> strZoekterm is de waarde die wordt ingevuld in de textbalk</param>
    public void OnPostGeavanceerdZoeken(string zoekCategorie, string strZoekterm)
        {
            Stripboeken = new SearchRepository().GeavanceerdZoeken(zoekCategorie, strZoekterm);
        }

    }
    
}
