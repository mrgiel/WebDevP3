using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlConnector;
using WebApplication1.Models;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class personalCollection : PageModel
    {
        [FromQuery(Name = "id")] public string gebruikerId { get; set; }
        public List<Bezit> Bezit { get; set; }
        public bool GeenBezittingen { get; set; }
        public string Error { get; set; }

        
        /// <summary>
        /// Haalt de persoonlijke collectie op van ingelogde gebruiker.
        /// </summary>
        public void OnGet()
        {
            ShowPersonalCollection personalCollection = new ShowPersonalCollection();

            try
            {
                // Haal collectie op aan de hand van gebruikeId.
                Bezit = personalCollection.GetCollection(gebruikerId);

                // Gebruiker heeft geen items in collectie.
                if (Bezit.Count == 0)
                {
                    GeenBezittingen = true;
                }
            }
            catch (MySqlException)
            {
                Error = "Fout bij het ophalen van collectie, probeer het later opnieuw";
            }
            catch (Exception)
            {
                Error = "Er is iets mis gegaan probeer het later opnieuw";
            }
        }
    }
}