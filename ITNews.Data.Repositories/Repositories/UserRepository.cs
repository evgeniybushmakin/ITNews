using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public void DeleteUser(string userId)
        {
            var userDeleted = context.Users.Find(userId);

            if (userDeleted != null)
            {
                context.Remove(userDeleted);
            }
            else
            {
                return;
            }
            
        }

        public ApplicationUser FindUser(string userId)
        {
            return context.Users.Where(x => x.Id == userId).FirstOrDefault();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public string FindUserName(string userId)
        {
            var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();
            return user.UserName;
        }

        public void UpdateUser(ApplicationUser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return context.Users.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void LockUser(string userId, bool block)
        {
            var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

            if (block)
            {     
                user.LockoutEnd = DateTimeOffset.Now.AddMinutes(1);
            }
            else
            {
                user.LockoutEnd = null;
            }
        }
        public bool IsLocked(string userId)
        {
            var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();

            if (user.LockoutEnd == null)
            {
                return false;
            }
            else
            {
                if (DateTimeOffset.Now >= user.LockoutEnd)
                {
                    user.LockoutEnd = null;
                }
                return true;
            }
        }

        public void CreateRole(string nameRole)
        {
            context.Roles.Add(new IdentityRole { Name = nameRole });
        }

        public string FindRoleId (string name)
        {
            var role = context.Roles.Where(x => x.Name == name).FirstOrDefault();

            return role.Id;
        }

        public void AddUserRole(string userId, string roleId)
        {
            context.UserRoles.Add(new IdentityUserRole<string> { UserId = userId, RoleId = roleId });
        }

        public IEnumerable<IdentityRole> GetRoles()
        {
            return context.Roles.ToList();
        }

        public string FindRoleIdByUserId (string userId)
        {
            var userRole = context.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();

            return userRole.RoleId;
        }

        public IdentityRole FindRoleById(string roleId)
        {
            return context.Roles.Where(x => x.Id == roleId).FirstOrDefault();
        }

        public void DeleteUserRole(string userId)
        {
            var userRole = context.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();

            context.UserRoles.Remove(userRole);
        }
    }
}
