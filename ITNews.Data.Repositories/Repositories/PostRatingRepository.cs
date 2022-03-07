using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using System;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class PostRatingRepository : IPostRatingRepository, IDisposable
    {
        private ApplicationDbContext context;

        public PostRatingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void AddRating(PostRating rating)
        {
            context.PostsRating.Add(rating);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool UserIsVoted(string userId, int postId)
        {
            var isVoted = context.PostsRating.Where(x => x.PostId == postId && x.UserId == userId).FirstOrDefault();

            if (isVoted == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
