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

        public TheLogin Model { get; set; }

        //call this to use it function. assign property
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        //Redirect to the return url
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //call sign in manager
            if (!ModelState.IsValid) return Page();
            var identityResult = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);

            //check if password username correct
            if (identityResult.Succeeded)
                return RedirectToPage(returnUrl is null or "/" ? "Index" : returnUrl);

            //if no success
            ModelState.AddModelError("", "Username or password inccorect");
            return Page();
        }
    }
}
