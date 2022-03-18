using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Versie
{
    public int versie_id { get; set; }

    public int id { get; set; }

    public string isbn { get; set; }

    [Required] public int druk { get; set; }

    public float prijs { get; set; }

    [Required] public string afbeelding_url { get; set; }

    public DateTime? datum { get; set; }

    public Uitgave Uitgave { get; set; }

    public Uitgever Uitgever { get; set; }

    //wss ergens anders
    public Reeks Reeks { get; set; }
} 