#nullable enable
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Models.Klasse;

namespace WebApplication1.Repositories;

/// <summary>
/// Data van de gebruiker kan je hier ophalen
/// </summary>
public class GebruikerRepo : DbConnection
{
    private readonly IActionContextAccessor actionContextAccessor = new ActionContextAccessor();

    /// <summary>
    /// Haal ID op van gebruiker
    /// </summary>
    /// <returns>string</returns>
    public string? HaalIdOp()
    {
        //id
        var id = actionContextAccessor.ActionContext.HttpContext.User.Claims.ToList();

        //Zoek in user naar value (value --> het id van gebruiker), return null als gebruiker niet bestaat
        return id.Any() ? id.First().Value : null;
    }

    /// <summary>
    /// Haal rol van gebruiker op, als gebruiker niet is ingelogd --> null
    /// </summary>
    /// <returns>nullable string</returns>
    public string? HaalRolOp()
    {
        //haal rol op van gebruiker
        const string sql = @"SELECT rol FROM gebruiker WHERE Id = @id";

        //param
        var param = new {id = HaalIdOp()};

        //connect to database
        using var connection = Connect();

        //haalt de rol op van gebruiker, als er geen gebruiker is --> null
        var rol = connection.QuerySingleOrDefault<Gebruiker>(sql, param);
        return rol?.rol.ToString();
    }
}