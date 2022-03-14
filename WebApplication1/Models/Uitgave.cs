<<<<<<< HEAD
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
=======
<<<<<<< HEAD
﻿namespace WebApplication1.Models
>>>>>>> e791a712861f3af4ea0c2193d93d37f8a53ebbe2
{
    public class Uitgave
    {
        //nigel
        public int id { get; set; }
        public int isbn { get; set; }
        [Required] public string naam { get; set; }
        public int versie_nr { get; set; }
        [Required] public DateTime jaar { get; set; }
        public int hoogte { get; set; }
        public string afbeelding_url { get; set; }
        public string uitgever { get; set; }
        public int reeks_nummer { get; set; }
        public int categorie_nummer { get; set; }
        public bool nsfw { get; set; }
        public float prijs { get; set; }

        //giel
        public string Naam { get; set; }
        public float Prijs { get; set; }
=======
﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Uitgave
    {
        public int id { get; set; }
        public int isbn { get; set; }
        [Required] public string naam { get; set; }
        public int versie_nr { get; set; }
        [Required] public DateTime jaar { get; set; }
        public int hoogte { get; set; }
        public string afbeelding_url { get; set; }
        public string uitgever { get; set; }
        public int reeks_nummer { get; set; }
        public int categorie_nummer { get; set; }
        public bool nsfw { get; set; }
        public float prijs { get; set; }
    
>>>>>>> origin/Nigel
    }
}