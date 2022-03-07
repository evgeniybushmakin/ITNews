using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface ICommentService
    {
        int Create(string message, int postId, string userId);

        List<CommentDomainModel> GetComments(int postId);

        int GetCommentsCount(int postId);

        void DeleteComments(string userId);
    }
}
