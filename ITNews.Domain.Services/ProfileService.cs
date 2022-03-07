using AutoMapper;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Services
{
    public class ProfileService :IProfilService
    {
        private IProfileRepository profileRepository;
        private readonly IUserRepository userRepository;
        private IMapper mapper;

        public ProfileService(IProfileRepository profileRepository, IMapper mapper, IUserRepository userRepository)
        {
            this.profileRepository = profileRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public int CreateProfile(string userId)
        {
            var profile = new Data.Contracts.Entities.Profile();
            profileRepository.CreateProfile(profile, userId);
            profileRepository.Save();
            var profileId = profileRepository.GetProfileId(profile);
            return profileId;
        }

        public void DeleteProfile(string userId)
        {
            profileRepository.DeleteProfile(userId);
            profileRepository.Save();
        }

        public List<ProfileDomainModel> GetProfiles()
        {
            var profiles = profileRepository.GetProfiles();
            foreach (var item in profiles)

            {
                item.User.Blocked = userRepository.IsLocked(item.UserId);            
            }
            userRepository.Save();
            var profilesDomainModel = mapper.Map<List<ProfileDomainModel>>(profiles);
            return profilesDomainModel;
        }

        public ProfileDomainModel FindProfileById(int profileId)
        {
            var profile = profileRepository.FindProfileById(profileId);
            var profileDomainModel = mapper.Map<ProfileDomainModel>(profile);
            return profileDomainModel;
        }

        public void EditProfile(ProfileDomainModel profileDomainModel)
        {
            var profile = mapper.Map<Data.Contracts.Entities.Profile>(profileDomainModel);
            profileRepository.EditProfile(profile);
            profileRepository.Save();
        }

        public ProfileDomainModel FindProfile(string userId)
        {
            var profile = profileRepository.FindProfile(userId);
            var profileDomainModel = mapper.Map<ProfileDomainModel>(profile);
            return profileDomainModel;
        }

        public FullNameDomainModel FindFullName(string userId)
        {
            var profile = profileRepository.FindProfile(userId);
            FullNameDomainModel fullName = new FullNameDomainModel();
            fullName.FirstName = profile.FirstName;
            fullName.LastName = profile.LastName;
            return fullName;
        }

        public void SaveChangesFirstName(string userId, string firstname)
        {
            var profile = profileRepository.FindProfile(userId);
            profile.FirstName = firstname;
            profileRepository.Save();
        }

        public void SaveChangesLastName(string userId, string lastname)
        {
            var profile = profileRepository.FindProfile(userId);
            profile.LastName = lastname;
            profileRepository.Save();
        }

        public void SaveChangesCity(string userId, string city)
        {
            var profile = profileRepository.FindProfile(userId);
            profile.City = city;
            profileRepository.Save();
        }
    }
}
