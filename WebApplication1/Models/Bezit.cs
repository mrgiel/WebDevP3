<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;

=======
<<<<<<< HEAD
>>>>>>> e791a712861f3af4ea0c2193d93d37f8a53ebbe2
namespace WebApplication1.Models

    //voornamelijk giel zn bezit class

{
    /// <summary>
    /// Geeft een exacte weergave van de Bezit tafel
    /// in de database weer.
    /// </summary>
    public class Bezit
    {
        public int rating { get; }
        public string staat { get; }
        public string beschrijving { get; }
        public int hoeveelheid { get; }
        [DataType(DataType.Currency)]
        public float prijs_betaald { get; }
        public string gebruikersnaam { get; }
        public string isbn { get; }

        //nigel
        public int id { get; set; }


        /// <summary>
        /// Deze constructor haalt de persoonlijke collectie
        /// op aan de hand van de gebruikersnaam.
        /// </summary>
        /// <param name="gebruikersnaam"></param>
        public Bezit(string gebruikersnaam)
        {
            this.gebruikersnaam = gebruikersnaam;
        }
        
        // deze constructor moet nog aangepast worden
        // daarom gebruik ik eerst onderaan een lege default constructor
        // om de data in op te slaan
        public Bezit(
            int rating, string staat, string beschrijving, int hoeveelheid, float prijs_betaald,
            string gebruikersnaam, string isbn)
        {
            this.rating = rating;
            this.staat = staat;
            this.beschrijving = beschrijving;
            this.hoeveelheid = hoeveelheid;
            this.prijs_betaald = prijs_betaald;
            this.gebruikersnaam = gebruikersnaam;
            this.isbn = isbn;
        }
<<<<<<< HEAD
=======

        public Bezit()
        {
            
        }
=======
﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Bezit
    {
        public int rating { get; }
        
        [Required]
        public string staat { get; set; }

        public string beschrijving { get; set; }

        public int hoeveelheid { get; set; }
        
        [DataType(DataType.Currency)]
        public float prijs_betaald { get; set; }
        
        public string gebruikersnaam { get; set; }

        public int id { get; set; }

>>>>>>> origin/Nigel
>>>>>>> e791a712861f3af4ea0c2193d93d37f8a53ebbe2
    }
}