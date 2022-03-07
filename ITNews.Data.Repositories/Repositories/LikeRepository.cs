using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class LikeRepository : ILikeRepository, IDisposable
    {
        private ApplicationDbContext context;

        public LikeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public bool IsExistLike(Like like)
        {
            var findLike = context.Likes.Where(x => x.CommentId == like.CommentId && x.UserId == like.UserId).FirstOrDefault();

            if (findLike == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetLikes(int commentId)
        {
            return context.Likes.Where(x => x.CommentId == commentId).ToList().Count;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Like(Like like)
        {
            context.Likes.Add(like);
        }

        public void UnLike(Like like)
        {
            var removeLike = context.Likes.Where(x => x.CommentId == like.CommentId && x.UserId == like.UserId).FirstOrDefault();
            context.Likes.Remove(removeLike);
        }

        public bool UserLike(int commentId, string userId)
        {
            var userLike = context.Likes.Where(x => x.CommentId == commentId && x.UserId == userId).FirstOrDefault();

            if (userLike != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteLikes(string userId)
        {
            var deleteLikes = context.Likes.Where(x => x.UserId == userId).ToList();
            if (deleteLikes != null)
            {
                foreach (var item in deleteLikes)
                {
                    context.Likes.Remove(item);
                }
            }
            else
            {
                return;
            }
        }
    }
}
