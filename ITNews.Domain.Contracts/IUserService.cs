using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;


namespace ITNews.Domain.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDomainModel> GetUsers();

        void UpdateUser(UserDomainModel user);

        void DeleteUser(string userId);

        string FindUsername(string userId);

        UserDomainModel FindUserById(string userId);

        void Block(string userId, bool block);

        void CreateRole(string name);

        void AddRole(string userId, string nameRole);

        IEnumerable<RoleDomainModel> GetRoles();

        RoleDomainModel FindRoleByUserId(string userId);

        void AddUserRole(string userId, string roleId);

        void ChangeUserRole(string userId, string roleId);

    }
}
