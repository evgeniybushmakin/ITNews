using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITNews.Web1.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IProfilService profileService;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender, IProfilService profileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            this.profileService = profileService;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        public ActionResult OnGet()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = profileService.FindProfile(userId);
            ViewData["profile"] = Mapper.Map<ProfileViewModel>(profile);
             

            //return View(profileViewModel);
            //var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            //}

            //var userName = await _userManager.GetUserNameAsync(user);
            //var email = await _userManager.GetEmailAsync(user);
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            //Username = userName;

            //Input = new InputModel
            //{
            //    Email = email,
            //    PhoneNumber = phoneNumber,
            //};

            //IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();

            //return RedirectToAction("Edit", "Profile");

        }

       // public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    var email = await _userManager.GetEmailAsync(user);
        //    if (Input.Email != email)
        //    {
        //        var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
        //        if (!setEmailResult.Succeeded)
        //        {
        //            var userId = await _userManager.GetUserIdAsync(user);
        //            throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
        //        }
        //    }

        //    var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        //    if (Input.PhoneNumber != phoneNumber)
        //    {
        //        var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
        //        if (!setPhoneResult.Succeeded)
        //        {
        //            var userId = await _userManager.GetUserIdAsync(user);
        //            throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
        //        }
        //    }

        //    await _signInManager.RefreshSignInAsync(user);
        //    StatusMessage = "Your profile has been updated";
        //    return RedirectToPage();
        //}

        //public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }


        //    var userId = await _userManager.GetUserIdAsync(user);
        //    var email = await _userManager.GetEmailAsync(user);
        //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    var callbackUrl = Url.Page(
        //        "/Account/ConfirmEmail",
        //        pageHandler: null,
        //        values: new { userId = userId, code = code },
        //        protocol: Request.Scheme);
        //    await _emailSender.SendEmailAsync(
        //        email,
        //        "Confirm your email",
        //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //    StatusMessage = "Verification email sent. Please check your email.";
        //    return RedirectToPage();
       // }
    }
}
