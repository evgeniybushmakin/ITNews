using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class CommentRepository : ICommentRepository, IDisposable
    {
        private ApplicationDbContext context;

        public CommentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Comment> GetComments(int postId)
        {
            return context.Comments.Include(x=>x.User).Where(x => x.PostId == postId).ToList();
        }

        public int GetCommentsCount(int postId)
        {
            return context.Comments.Where(x => x.PostId == postId).Count();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void CreateComment(Comment comment)
        {
            context.Comments.Add(comment);
        }

        public int GetCommentId(Comment comment)
        {
            context.Entry(comment).GetDatabaseValues();
            return comment.Id;
        }

        public void DeleteComments(string userId)
        {
            var comments = context.Comments.Where(x => x.UserId == userId).ToList();

            if (comments != null)
            {
                foreach (var item in comments)
                {
                    context.Comments.Remove(item);
                }
            }
            else
            {
                return;
            }
        }
    }
}
