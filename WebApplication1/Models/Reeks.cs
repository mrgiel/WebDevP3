using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    [BindProperties]
    public class Reeks
    {
        [Required]
        public string reeks_naam { get; set; }
        public int reeks_nummer { get; set; }
    }
}