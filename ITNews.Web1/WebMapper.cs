using AutoMapper;
using ITNews.Domain.Contracts.Entities;
using ITNews.Web1.Models;

namespace ITNews.Web1
{
    public class WebMapper: Profile
    {
        public WebMapper()
        {
            CreateMap<PostDomainModel, PostViewModel>().ReverseMap()
               .ForMember(entity => entity.Id, c => c.MapFrom(viewModel => viewModel.Id)).ReverseMap()
               .ForMember(entity => entity.Created, c => c.MapFrom(viewModel => viewModel.Created)).ReverseMap()
               .ForMember(entity => entity.Updated, c => c.MapFrom(viewModel => viewModel.Updated)).ReverseMap()
               .ForMember(entity => entity.Title, c => c.MapFrom(viewModel => viewModel.Title)).ReverseMap()
               .ForMember(entity => entity.Content, c => c.MapFrom(viewModel => viewModel.Content)).ReverseMap()
               .ForMember(entity => entity.CategoryId, c => c.MapFrom(viewModel => viewModel.CategoryId)).ReverseMap()
               .ForMember(entity => entity.ShortDiscription, c => c.MapFrom(viewModel => viewModel.ShortDiscription)).ReverseMap()
               .ForMember(entity => entity.Rating, c => c.MapFrom(viewModel => viewModel.Rating)).ReverseMap()
               .ForMember(entity => entity.Published, c => c.MapFrom(viewModel => viewModel.Published)).ReverseMap()
               .ForMember(entity => entity.ShortDiscription, c => c.MapFrom(viewModel => viewModel.ShortDiscription)).ReverseMap()
               .ForMember(entity => entity.UserId, c => c.MapFrom(viewModel => viewModel.UserId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<CategoryViewModel, CategoryDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(viewModel => viewModel.Id)).ReverseMap()
                .ForMember(entity => entity.Name, c => c.MapFrom(viewModel => viewModel.Name)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(viewModel => viewModel.UserId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());


            CreateMap<CommentViewModel, CommentDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(viewModel => viewModel.Id)).ReverseMap()
                .ForMember(entity => entity.Content, c => c.MapFrom(viewModel => viewModel.Content)).ReverseMap()
                .ForMember(entity => entity.Created, c => c.MapFrom(viewModel => viewModel.Created)).ReverseMap()
                .ForMember(entity => entity.PostId, c => c.MapFrom(viewModel => viewModel.PostId)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(viewModel => viewModel.UserId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<LikeViewModel, LikeDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(viewModel => viewModel.Id)).ReverseMap()
                .ForMember(entity => entity.CommentId, c => c.MapFrom(viewModel => viewModel.CommentId)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(viewModel => viewModel.UserId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<PostTagViewModel, PostTagDomainModel>().ReverseMap()
                .ForMember(entity => entity.PostId, c => c.MapFrom(viewModel => viewModel.PostId)).ReverseMap()
                .ForMember(entity => entity.TagId, c => c.MapFrom(viewModel => viewModel.TagId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<PostRatingViewModel, PostRatingDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(viewModel => viewModel.Id)).ReverseMap()
                .ForMember(entity => entity.Mark, c => c.MapFrom(viewModel => viewModel.Mark)).ReverseMap()
                .ForMember(entity => entity.PostId, c => c.MapFrom(viewModel => viewModel.PostId)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(viewModel => viewModel.UserId)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<ProfileViewModel, ProfileDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(viewModel => viewModel.Id)).ReverseMap()
                .ForMember(entity => entity.Avatar, c => c.MapFrom(viewModel => viewModel.Avatar)).ReverseMap()
                .ForMember(entity => entity.City, c => c.MapFrom(viewModel => viewModel.City)).ReverseMap()
                .ForMember(entity => entity.UserId, c => c.MapFrom(viewModel => viewModel.UserId)).ReverseMap()
                .ForMember(entity => entity.Country, c => c.MapFrom(viewModel => viewModel.Country)).ReverseMap()
                .ForMember(entity => entity.FirstName, c => c.MapFrom(viewModel => viewModel.FirstName)).ReverseMap()
                .ForMember(entity => entity.LastName, c => c.MapFrom(viewModel => viewModel.LastName)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<TagViewModel, TagDomainModel>().ReverseMap()
                .ForMember(entity => entity.Id, c => c.MapFrom(viewModel => viewModel.Id)).ReverseMap()
                .ForMember(entity => entity.Content, c => c.MapFrom(viewModel => viewModel.Content)).ReverseMap()
               .ForAllOtherMembers(c => c.Ignore());

            CreateMap<UserViewModel, UserDomainModel>().ReverseMap()
                .ForMember(x => x.Id, c => c.MapFrom(d => d.Id)).ReverseMap()
                .ForMember(x => x.Blocked, c => c.MapFrom(d => d.Blocked)).ReverseMap()
                .ForMember(x => x.Email, c => c.MapFrom(d => d.Email)).ReverseMap()
                .ForMember(x => x.UserName, c => c.MapFrom(d => d.UserName)).ReverseMap()
                .ForMember(x => x.EmailConfirmed, c => c.MapFrom(d => d.EmailConfirmed)).ReverseMap()
                .ForMember(x => x.ProfileId, c => c.MapFrom(d => d.ProfileId)).ReverseMap()
                .ForAllOtherMembers(c => c.Ignore());

            CreateMap<SearchViewModel, SearchDomainModel>().ReverseMap();

            CreateMap<MainPostViewModel, PostDomainModel>().ReverseMap()
                .ForMember(x => x.Id, c => c.MapFrom(d => d.Id)).ReverseMap()
                .ForMember(x => x.Category, c => c.MapFrom(d => d.Category)).ReverseMap()
                .ForMember(x => x.CategoryId, c => c.MapFrom(d => d.CategoryId)).ReverseMap()
                .ForMember(x => x.Created, c => c.MapFrom(d => d.Created)).ReverseMap()
                .ForMember(x => x.Rating, c => c.MapFrom(d => d.Rating)).ReverseMap()
                .ForMember(x => x.ShortDiscription, c => c.MapFrom(d => d.ShortDiscription)).ReverseMap()
                .ForMember(x => x.Title, c => c.MapFrom(d => d.Title)).ReverseMap()
                .ForMember(x => x.User, c => c.MapFrom(d => d.User)).ReverseMap()
                .ForMember(x => x.UserId, c => c.MapFrom(d => d.UserId)).ReverseMap()
                .ForAllOtherMembers(c => c.Ignore());

            CreateMap<FullNameDomainModel, FullNameViewModel>().ReverseMap();
        }
    }
}
