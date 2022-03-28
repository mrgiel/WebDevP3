using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.Klasse;

namespace WebApplication1.Pages.Profiel
{
    public class MijnProfielModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public MijnProfielModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public Gebruiker Gebruiker { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);

            Gebruiker.UserName = userName;
            Gebruiker.Email = email;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            var userName = await _userManager.GetUserNameAsync(user);
            if (Gebruiker.UserName != userName)
            {
                var setUserNameResult = await _userManager.SetUserNameAsync(user, Gebruiker.UserName);
                if (!setUserNameResult.Succeeded)
                {
                   await _userManager.GetUserIdAsync(user);
                }
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Gebruiker.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Gebruiker.Email);
                if (!setEmailResult.Succeeded)
                {
                    await _userManager.GetUserIdAsync(user);
                   
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            return RedirectToPage("MijnProfiel");
        }
    }
}