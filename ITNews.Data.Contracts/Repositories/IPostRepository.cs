using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface IPostRepository: IDisposable
    {
        IEnumerable<Post> GetPostsByUserId(string userId);

        IEnumerable<Post> GetPostsOrderByRating();

        void UpdatePost (Post post, string userId);

        void DeletePost(int postId);

        void CreatePost(Post post, string userId);

        Post FindPostByPostId(int postId);

        void Save();

        int GetPostId(Post post);

        IEnumerable<Post> GetPublishedPosts();

        Post GetPostById(int postId);

        IEnumerable<Post> SearchByTitle(string search);

        IEnumerable<Post> SearchByContent(string search);

        void DeletePosts(string userId);

        void EditPost(Post post);

        void AttachPost(Post post);
    }
}
