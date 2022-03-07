using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Data.Repositories;
using ITNews.Data.Repositories.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITNews.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return serviceCollection;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            serviceCollection.AddTransient<IPostService, PostService>();
            serviceCollection.AddTransient<IPostRepository, PostRepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<ITagRepository, TagRepository>();
            serviceCollection.AddTransient<ITagService, TagService>();
            serviceCollection.AddTransient<IPostTagRepository, PostTagRepository>();
            serviceCollection.AddTransient<IPostTagService, PostTagService>();
            serviceCollection.AddTransient<IProfileRepository, ProfileRepository>();
            serviceCollection.AddTransient<IProfilService, ProfileService>();
            serviceCollection.AddTransient<ICommentRepository, CommentRepository>();
            serviceCollection.AddTransient<ICommentService, CommentService>();
            serviceCollection.AddTransient<ILikeRepository, LikeRepository>();
            serviceCollection.AddTransient<ILikeService, LikeService>();
            serviceCollection.AddTransient<IPostRatingRepository, PostRatingRepository>();
            serviceCollection.AddTransient<IPostRatingService, PostRatingService>();

            return serviceCollection;
        }       

    }
}
