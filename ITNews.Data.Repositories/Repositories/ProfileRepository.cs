using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class ProfileRepository : IProfileRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ProfileRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateProfile(Profile profile, string userId)
        {
            context.Profiles.Attach(profile);
            profile.UserId = userId;
        }

        public int GetProfileId(Profile profile)
        {
            context.Entry(profile).GetDatabaseValues();
            return profile.Id;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Profile FindProfile(string userId)
        {
            return context.Profiles.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public Profile FindProfileById(int profileId)
        {
            return context.Profiles.Include(x=>x.User).Where(x => x.Id == profileId).FirstOrDefault();
        }

        public void EditProfile(Profile profile)
        {
            context.Entry(profile).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return context.Profiles.Include(x => x.User).ToList();
        }

        public void DeleteProfile (string userId)
        {
            var profile = context.Profiles.Where(x => x.UserId == userId).FirstOrDefault();

            if (profile != null)
            {
                context.Profiles.Remove(profile);
            }
            else
            {
                return;
            }
        }
    }
}
