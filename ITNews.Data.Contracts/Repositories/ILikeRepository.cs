using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface ILikeRepository: IDisposable
    {
        int GetLikes(int commentId);

        void Like(Like like);

        void UnLike(Like like);

        bool IsExistLike(Like like);

        bool UserLike(int commentId, string userId);

        void Save();

        void DeleteLikes(string userId);
    }
}
