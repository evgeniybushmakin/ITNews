using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using System.Collections.Generic;

namespace ITNews.Domain.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            this.likeRepository = likeRepository;
        } 

        public bool IsAddedLike(int commentId, string userId)
        {
            var like = new Like { CommentId = commentId, UserId = userId };

            var findlike = likeRepository.IsExistLike(like);

            if (findlike)
            {
                likeRepository.UnLike(like);
                likeRepository.Save();
                return false;
            }
            else
            {
                likeRepository.Like(like);
                likeRepository.Save();
                return true;
            }           
        }
        public int GetCountLikes(int commentId)
        {
            return likeRepository.GetLikes(commentId);
        }

        public bool UserLike(int commentId, string userId)
        {
            return likeRepository.UserLike(commentId, userId);
        }

        public void DeleteLikes(string userId)
        {
            likeRepository.DeleteLikes(userId);
            likeRepository.Save();
        }
    }
}
