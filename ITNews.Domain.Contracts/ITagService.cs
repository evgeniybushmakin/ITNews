using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace ITNews.Domain.Contracts
{
    public interface ITagService
    {
        IEnumerable<TagDomainModel> GetTags();

        void AddTags(string tags, int postId);

        string FindTagsByPostId(int postId);

        string GetTagNameById(int tagId);
    }
}
