using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITNews.Data.Repositories.Repositories
{
    public class TagRepository : ITagRepository, IDisposable
    {
        private ApplicationDbContext context;

        public TagRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void CreateTag (Tag tag)
        {
            context.Tags.Add(tag);
        }

        public void DeleteTag(int tagId)
        {
            var tag = context.Tags.Where(x => x.Id == tagId).FirstOrDefault();
            context.Tags.Remove(tag);
        }
       
        public int FindTagByContent(string tagContent)
        {
            var existTag = context.Tags.Where(x=> x.Content == tagContent).FirstOrDefault();

            if (existTag == null)
            {
                return 0;
            }
            else
            {
                return existTag.Id;
            }
        }

        public void AddToPost(int postId, int tagId)
        {
            context.PostsTags.Add (new PostTag { PostId = postId, TagId = tagId });
        }

        public int GetNewTagId(Tag tag)
        {
            context.Entry(tag).GetDatabaseValues();
            return tag.Id;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Tag> GetTags()
        {
            return context.Tags.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Tag FindTagById(int tagId)
        {
           return context.Tags.Where(x => x.Id == tagId).FirstOrDefault();
        }
    }
}
