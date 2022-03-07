using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface IProfileRepository: IDisposable
    {
        void EditProfile (Profile profile);

        void CreateProfile(Profile profile, string userId);

        void Save();

        Profile FindProfile(string userId);

        IEnumerable<Profile> GetProfiles();

        void DeleteProfile(string userId);

        Profile FindProfileById(int profileId);

        int GetProfileId(Profile profile);
    }
}
