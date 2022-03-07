using ITNews.Data.Contracts.Entities;
using ITNews.Domain.Contracts.Entities;
using Microsoft.AspNetCore.Identity;

namespace ITNews.Infrastructure
{
    public class DomainMapper: AutoMapper.Profile
    {
        public DomainMapper()
        {
            CreateMap<PostDomainModel, Post>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(domainModel => domainModel.Id)).ReverseMap()
                .ForMember(entity => entity.Created, c => c.MapFrom(domainModel => domainModel.Created)).ReverseMap()
                .ForMember(entity => entity.Updated, c => c.MapFrom(domainModel => domainModel.Updated)).ReverseMap()
                .ForMember(entity => entity.Title, c => c.MapFrom(domainModel => domainModel.Title)).ReverseMap()
                .ForMember(entity => entity.Content, c => c.MapFrom(domainModel => domainModel.Content)).ReverseMap()
                .ForMember(entity => entity.CategoryId, c => c.MapFrom(domainModel => domainModel.CategoryId)).ReverseMap()
                .ForMember(entity => entity.ShortDiscription, c => c.MapFrom(domainModel => domainModel.ShortDiscription)).ReverseMap()
                .ForMember(entity => entity.Rating, c => c.MapFrom(domainModel => domainModel.Rating)).ReverseMap()
                .ForMember(entity => entity.Published, c => c.MapFrom(domainModel => domainModel.Published)).ReverseMap()
                .ForMember(entity => entity.ShortDiscription, c => c.MapFrom(domainModel => domainModel.ShortDiscription)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(domainModel => domainModel.UserId)).ReverseMap()
                .ForAllOtherMembers(c => c.Ignore());

            CreateMap<Category, CategoryDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(domainModel => domainModel.Id)).ReverseMap()
                .ForMember(entity => entity.Name, c => c.MapFrom(domainModel => domainModel.Name)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(domainModel => domainModel.UserId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());


            CreateMap<Comment, CommentDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(domainModel => domainModel.Id)).ReverseMap()
                .ForMember(entity => entity.Content, c => c.MapFrom(domainModel => domainModel.Content)).ReverseMap()
                .ForMember(entity => entity.Created, c => c.MapFrom(domainModel => domainModel.Created)).ReverseMap()
                .ForMember(entity => entity.PostId, c => c.MapFrom(domainModel => domainModel.PostId)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(domainModel => domainModel.UserId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore()); 

            CreateMap<Like, LikeDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(domainModel => domainModel.Id)).ReverseMap()
                .ForMember(entity => entity.CommentId, c => c.MapFrom(domainModel => domainModel.CommentId)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(domainModel => domainModel.UserId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<PostTag, PostTagDomainModel>().ReverseMap()
                .ForMember(entity => entity.PostId, c => c.MapFrom(domainModel => domainModel.PostId)).ReverseMap()
                .ForMember(entity => entity.TagId, c => c.MapFrom(domainModel => domainModel.TagId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<PostRating, PostRatingDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(domainModel => domainModel.Id)).ReverseMap()
                .ForMember(entity => entity.Mark, c => c.MapFrom(domainModel => domainModel.Mark)).ReverseMap()
                .ForMember(entity => entity.PostId, c => c.MapFrom(domainModel => domainModel.PostId)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(domainModel => domainModel.UserId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<Profile, ProfileDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(domainModel => domainModel.Id)).ReverseMap()
                .ForMember(entity => entity.Avatar, c => c.MapFrom(domainModel => domainModel.Avatar)).ReverseMap()
                .ForMember(entity => entity.City, c => c.MapFrom(domainModel => domainModel.City)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(domainModel => domainModel.UserId)).ReverseMap()
                .ForMember(entity => entity.Country, c => c.MapFrom(domainModel => domainModel.Country)).ReverseMap()
                .ForMember(entity => entity.FirstName, c => c.MapFrom(domainModel => domainModel.FirstName)).ReverseMap()
                .ForMember(entity => entity.LastName, c => c.MapFrom(domainModel => domainModel.LastName)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<Tag, TagDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(domainModel => domainModel.Id)).ReverseMap()
                .ForMember(entity => entity.Content, c => c.MapFrom(domainModel => domainModel.Content)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<ApplicationUser, UserDomainModel>().ReverseMap()
                .ForMember(x => x.Id, c => c.MapFrom(d => d.Id)).ReverseMap()
                .ForMember(x => x.Blocked, c => c.MapFrom(d => d.Blocked)).ReverseMap()
                .ForMember(x => x.Email, c => c.MapFrom(d => d.Email)).ReverseMap()
                .ForMember (x=> x.UserName, c=> c.MapFrom (d => d.UserName)).ReverseMap()
                .ForMember(x => x.EmailConfirmed, c => c.MapFrom(d => d.EmailConfirmed)).ReverseMap()
                .ForMember(x => x.ProfileId, c => c.MapFrom(d => d.ProfileId)).ReverseMap()
                .ForAllOtherMembers(c => c.Ignore());

            CreateMap<IdentityRole, RoleDomainModel>().ReverseMap()
                .ForMember(x => x.Id, c => c.MapFrom(d => d.Id)).ReverseMap()
                .ForMember(x => x.Name, c => c.MapFrom(d => d.Name)).ReverseMap()
                .ForAllOtherMembers(c => c.Ignore());
               
            
        }

    }
}
