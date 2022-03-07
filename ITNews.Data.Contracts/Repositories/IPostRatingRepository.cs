using ITNews.Data.Contracts.Entities;
using System;

namespace ITNews.Data.Contracts.Repositories
{
    public interface IPostRatingRepository:IDisposable
    {
        void AddRating(PostRating rating);

        void Save();

        bool UserIsVoted(string userId, int postId);
    }
}
