using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Pages
{
    public class RegisterModel : PageModel
    {
        // Usermanager : Managed the user. Deze class creëert , update , verwijdert de gebruikers
        private readonly UserManager<IdentityUser> userManager;

        //Sign in manager: Is verantwoordelijk voor verifiëren van een gebruiker
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Registreren Model { get; set; }
        
        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //kijk of modelstate is valid
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.UserName,
                    Email = Model.Email
                };

                //kijk of registratie van succesvol
                var result = await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                    //wanneer er sucecesvol is ingelogd. return home
                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return Page();
        }
    }
}
