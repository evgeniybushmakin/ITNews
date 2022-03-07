using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class PostRepository : IPostRepository, IDisposable
    {
        private ApplicationDbContext context;

        public PostRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void DeletePost(int postId)
        {
            var postDeleted = context.Posts.Find(postId);
            context.Remove(postDeleted);
        }

        public IEnumerable<Post> GetPublishedPosts()
        {
            return context.Posts.Include(x=>x.Category).Include(x=>x.User).Where(x => x.Published == true).OrderByDescending(x=>x.Created).ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Post> GetPostsByUserId(string userId)
        {
            return context.Posts.Include(x=>x.Category).ToList().Where(x=>x.UserId==userId);
        }

        public IEnumerable<Post> GetPostsOrderByRating()
        {
            return context.Posts.Where(x=>x.Published == true).Include(x=>x.Category).ToList().OrderByDescending(x => x.Rating).Take(5);
        }

        public Post FindPostByPostId (int postId)
        {
            return context.Posts.Find (postId);
        }

        public Post GetPostById(int postId)
        {
            return context.Posts.Where(x=>x.Id==postId).Include(x=>x.User).Include(x=>x.Category).FirstOrDefault();
        }

        public void CreatePost(Post post, string userId)
        {
            context.Posts.Attach(post);
            post.UserId = userId;
        }

        public int GetPostId(Post post)
        {
            context.Entry(post).GetDatabaseValues();
            return post.Id;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdatePost(Post post, string userId)
        {
            context.Entry(post).State = EntityState.Modified;
            post.UserId = userId;
        }


        public IEnumerable<Post> SearchByTitle(string search)
        {
            var searchLow = search.ToLower();

            return context.Posts.Where(x => x.Published == true && x.Title.ToLower().Contains(searchLow)).ToList();
        }

        public IEnumerable<Post> SearchByContent(string search)
        {
            var searchLow = search.ToLower();

            return context.Posts.Where(x => x.Published == true && x.Content.ToLower().Contains(searchLow)).ToList();
        }

        public void DeletePosts(string userId)
        {
            var posts = context.Posts.Where(x => x.UserId == userId).ToList();

            if (posts != null)
            {
                foreach (var item in posts)
                {
                    context.Posts.Remove(item);
                }
            }
        }

        public void EditPost(Post post)
        {
            context.Entry(post).State = EntityState.Modified;
        }

        public void AttachPost(Post post)
        {
            context.Posts.Attach(post);
        }
    }
}
