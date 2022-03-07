using AutoMapper;
using ITNews.Domain.Contracts;
using ITNews.Web1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ITNews.Web1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IProfilService profileService;

        public AdminController(IUserService userService, IMapper mapper, IProfilService profileService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.profileService = profileService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            Response.Cookies.Delete("userIdAdmin");
            var profilesDomainModel = profileService.GetProfiles();
            var profilesViewModel = mapper.Map<List<ProfileViewModel>>(profilesDomainModel);
            foreach (var item in profilesViewModel)
            {
                var role = userService.FindRoleByUserId(item.UserId);
                item.Role = new RoleViewModel { Id = role.Id, Name = role.Name };
            }
            return View(profilesViewModel);
        }

        public ActionResult SetUserId(string userIdAdmin)
        {
            CookieOptions cookies = new CookieOptions();
            cookies.Expires = DateTime.Now.AddMinutes(5);

            Response.Cookies.Append("userIdAdmin", userIdAdmin, cookies);
            return RedirectToAction("Index","Post");
        }

        [HttpGet]
        public ActionResult Block(int profileId)
        {
            var profile = profileService.FindProfileById(profileId);
            var profileViewModel = mapper.Map<ProfileViewModel>(profile);
            return View(profileViewModel);
        }

        [HttpPost]
        public ActionResult Block (ProfileViewModel profile)
        {
            userService.Block(profile.UserId, profile.User.Blocked);
            return RedirectToAction(nameof(AdminController.Index));
        }

        public ActionResult Delete(string userId)
        {
            if (userId != null)
            {
                userService.DeleteUser(userId);

                return RedirectToAction(nameof(AdminController.Index));
            }
            else
            {
                return RedirectToAction(nameof(AdminController.Index));
            }

        }

        [HttpGet]
        public ActionResult ChangeRole(int profileId, string roleName)
        {
            var profile = profileService.FindProfileById(profileId);
            var profileViewModel = mapper.Map<ProfileViewModel>(profile);
            profileViewModel.Role = new RoleViewModel {  Name = roleName};
            var roles = userService.GetRoles();
            var rolesViewModel = mapper.Map<List<RoleViewModel>>(roles);
            profileViewModel.Roles = new List<RoleViewModel>();
            foreach (var item in rolesViewModel)
            {
                profileViewModel.Roles.Add(item);
            }
            return View(profileViewModel);
        }

        [HttpPost]
        public ActionResult ChangeRole(ProfileViewModel profile)
        {
            userService.ChangeUserRole(profile.UserId, profile.Role.Id);
            return RedirectToAction(nameof(AdminController.Index));
        }

    }
}