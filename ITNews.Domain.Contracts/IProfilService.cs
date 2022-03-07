using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface IProfilService
    {
        int CreateProfile(string userId);

        void EditProfile(ProfileDomainModel profileDomainModel);

        ProfileDomainModel FindProfile(string userId);

        void SaveChangesFirstName(string userId, string firstname);

        void SaveChangesLastName(string userId, string lastname);

        void SaveChangesCity(string userId, string city);

        FullNameDomainModel FindFullName(string userId);

        List<ProfileDomainModel> GetProfiles();

        void DeleteProfile(string userId);

        ProfileDomainModel FindProfileById(int profileId);
    }
}
