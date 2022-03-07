using ITNews.Data.Contracts.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<ApplicationUser> GetUsers();

        void UpdateUser(ApplicationUser user);

        void DeleteUser(string userId);

        void Save();

        string FindUserName(string userId);

        ApplicationUser FindUser(string userId);

        void LockUser(string userId, bool block);

        bool IsLocked(string userId);

        void CreateRole(string nameRole);

        void AddUserRole(string userId, string roleId);

        string FindRoleId(string name);

        IEnumerable<IdentityRole> GetRoles();

        string FindRoleIdByUserId(string userId);

        IdentityRole FindRoleById(string roleId);

        void DeleteUserRole(string userId);
    }
}
