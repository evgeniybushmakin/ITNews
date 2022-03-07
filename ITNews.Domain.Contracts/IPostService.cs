using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface IPostService
    {
        IEnumerable<PostDomainModel> GetPostsByUserId(string userId);

        IEnumerable<PostDomainModel> GetPosts();

        void UpdatePost(PostDomainModel post, string userId);

        void DeletePost(int postId);

        int CreatePost(PostDomainModel post, string userId);

        PostDomainModel FindPost(int postId);

        IEnumerable<PostDomainModel> GetPublishedPosts();

        PostDomainModel GetPostById(int postId);

        IEnumerable<PostDomainModel> GetPopularPosts();

        IEnumerable<SearchDomainModel> Search(string search);

        void DeletePosts(string userId);

        void AddRating(int postId, int mark);

        void UpdatePostByAdmin(PostDomainModel post);
    }
}
