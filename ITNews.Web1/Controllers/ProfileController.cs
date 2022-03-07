using System.Security.Claims;
using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITNews.Web1.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IProfilService profileService;
        private readonly IPostTagService postTagService;

        public ProfileController(IMapper mapper, IUserService userService, IProfilService profileService, IPostTagService postTagService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.profileService = profileService;
            this.postTagService = postTagService;
        }
        // GET: Profile
        public ActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var profile = profileService.FindProfile(userId);
            var profileViewModel = mapper.Map<ProfileViewModel>(profile);
            ViewBag.AmountRating = postTagService.AmountRating(profile.UserId);
            return View(profileViewModel);

        }

        public void ChangeFirstname(string value)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            profileService.SaveChangesFirstName(userId, value);
        }

        public void ChangeLastname(string value)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            profileService.SaveChangesLastName(userId, value);
        }

        public void ChangeCity(string value)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            profileService.SaveChangesCity(userId, value);
        }

        [AllowAnonymous]
        public ActionResult ReadProfile(int profileId)
        {
            var profile = profileService.FindProfileById(profileId);
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (userId == profile.UserId)
                {
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    var profileViewModel = mapper.Map<ProfileViewModel>(profile);
                    return View(profileViewModel);
                }
            }
            catch
            {
                var profileViewModel = mapper.Map<ProfileViewModel>(profile);
                return View(profileViewModel);
            }

        }
    }
}