using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface IPostTagService
    {
        IEnumerable<PostTagDomainModel> GetPostsTags();

        IEnumerable<PostTagDomainModel> GetPostsByTagId(int tagId);

        int AmountRating(string userId);
    }
}
