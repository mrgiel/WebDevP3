using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.Klasse;
using WebApplication1.Service;

namespace WebApplication1.Pages.wwVergeten
{
    public class BevestigModel : PageModel
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly IEmailSender _emailSender;

        //public BevestigModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        //{
        //    _userManager = userManager;
        //    _emailSender = emailSender;
        //}

        //[BindProperty]
        //public Gebruiker Gebruiker { get; set; }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(Gebruiker.Email);
        //        if (user == null)
        //        {
        //            return RedirectToPage("./checkEmail");
        //        }

        //        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        //        var callbackUrl = Url.Page(
        //            "/wwVergeten/ResetWachtwoord",
        //            pageHandler: null,
        //            values: new { code },
        //            protocol: Request.Scheme);

        //        await _emailSender.SendEmailAsync(Gebruiker.Email, "Reset Password", $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //        return RedirectToPage("./checkEmail");
        //    }

        //    return Page();
        }
    }



