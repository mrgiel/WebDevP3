using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApplication1.Repositories;

/// <summary>
/// Haal ID van gebruiker op (varchar(255))
/// </summary>
public class GebruikerId
{
    private readonly IActionContextAccessor actionContextAccessor = new ActionContextAccessor();
    /// <summary>
    /// Haal ID op van gebruiker
    /// </summary>
    /// <returns>string</returns>
    public string GetClaims()
    {
        //Zoek in user naar value (value --> het id van gebruiker)
        string claims = actionContextAccessor.ActionContext.HttpContext.User.Claims.First().Value;
        return claims;
    }
}