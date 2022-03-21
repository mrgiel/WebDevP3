using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]

        public Inloggen Model { get; set; }

        //signin manager aanroepen
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        //als er een returnUrl is redirect gebruiker dan naar returnUrl
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //roep sign in manager
            if (!ModelState.IsValid) return Page();
            var identityResult = await signInManager.PasswordSignInAsync(Model.UserName, Model.Password, Model.RememberMe, false);

            //kijk of wachtwoord en gebruikersnaam is correct
            if (identityResult.Succeeded)
                return RedirectToPage(returnUrl is null or "/" ? "Index" : returnUrl);

            // error
            ModelState.AddModelError("", "Username or password inccorect");
            return Page();
        }
    }
}
