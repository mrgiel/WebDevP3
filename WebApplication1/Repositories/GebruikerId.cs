using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApplication1.Repositories;

public class GebruikerId
{
    private readonly IActionContextAccessor actionContextAccessor = new ActionContextAccessor();
    public string GetClaims()
    {
        string claims = actionContextAccessor.ActionContext.HttpContext.User.Claims.First().Value;
        return claims;
    }
}