using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Pages;

public class AdminPagina : PageModel
{
    public IEnumerable<Uitgave> Stripboeken { get; set; }

    public IActionResult OnPostVerwijderen(int id)
    {
        Stripboeken = new AdminRepository().Verwijderen(id);
        return RedirectToPage("AdminPagina");
    }
    public void OnGet()
    {
        Stripboeken = new AdminRepository().Get();
    }


}