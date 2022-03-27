using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using WebApplication1.Models;
using WebApplication1.Models.Klasse;
using WebApplication1.Repositories;

namespace WebApplication1.Pages
{
    public class GebruikerPaginaModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GebruikerPaginaModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public IEnumerable<Gebruiker> model { get; set; }

        public  IActionResult OnGet()
        {
            //var users = await _userManager.Users.ToListAsync();
            //foreach (IdentityUser user in users)
            //{
            //    Gebruiker urv = new Gebruiker()
            //    {
            //        Id = user.Id,
            //        Email = user.Email,
            //        UserName = user.UserName,
            //    };
            //    model.Add(urv);
            //}

            model = new GebruikerRepo().Get();
            return Page();
        }

    
        public async Task<IActionResult> OnPostDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            model = new GebruikerRepo().Verwijderen(id);

            await _userManager.DeleteAsync(user);

            return RedirectToPage("GebruikerPagina");
        }
    }
}
