using ITNews.Data.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Repositories
{
    public interface ITagRepository : IDisposable
    {
        IEnumerable<Tag> GetTags();

        void CreateTag(Tag tag);

        void Save();

        void AddToPost(int postId, int tagId);

        // bool IsExistTag(int tagId);

        int FindTagByContent(string tagContent);

        int GetNewTagId(Tag tag);

        void DeleteTag(int tagId);

        Tag FindTagById(int tagId);
    }
}
