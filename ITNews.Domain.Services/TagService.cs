using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace ITNews.Domain.Services
{
    public class TagService : ITagService
    {
        private ITagRepository tagRepository;
        private IPostTagRepository postTagRepository;
        private IMapper mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper, IPostTagRepository postTagRepository)
        {
            this.tagRepository = tagRepository;
            this.mapper = mapper;
            this.postTagRepository = postTagRepository;
        }
        public void AddTags (string tags, int postId)
        {
            if (tags.Contains(','))
            {
                var words = tags.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in words)
                {                    
                    var tagId = tagRepository.FindTagByContent(item);

                    if (tagId == 0)
                    {
                        var newTag = new Tag { Content = item };

                        tagRepository.CreateTag(newTag);

                        tagRepository.Save();

                        var newTagId = tagRepository.GetNewTagId(newTag);

                        tagRepository.AddToPost(postId, newTagId);

                        tagRepository.Save();
                    }

                    if (postTagRepository.IsExistPostTag(postId, tagId))
                    {
                        continue;
                    }

                    else
                    {                    
                        tagRepository.AddToPost(postId, tagId);

                        tagRepository.Save();                                               
                    }
                    
                }
            }
            else
            {
                var tagId = tagRepository.FindTagByContent(tags);

                if (tagId == 0)
                {
                    var newTag = new Tag { Content = tags };

                    tagRepository.CreateTag(newTag);

                    tagRepository.Save();

                    var newTagId = tagRepository.GetNewTagId(newTag);

                    tagRepository.AddToPost(postId, newTagId);

                    tagRepository.Save();
                }
                else
                {
                    if (postTagRepository.IsExistPostTag(postId, tagId))
                    {
                        return;
                    }
                    else
                    {
                        tagRepository.AddToPost(postId, tagId);

                        tagRepository.Save();
                    }
                }
                
            }
        }


        public IEnumerable<TagDomainModel> GetTags()
        {
            var tags = tagRepository.GetTags();

            var tagsDomainModel = mapper.Map<List<TagDomainModel>>(tags);

            return tagsDomainModel;
        }

        public string FindTagsByPostId(int postId)
        {
            var tags = postTagRepository.GetPostTags(postId);

            string content=null;

            string result = null;

            if (tags.Count != 0)
            {
                foreach (var item in tags)
                {
                    var tag = tagRepository.FindTagById(item);
                    content += tag.Content + "," + " ";
                }
                result = content.Remove(content.Length - 2);
            }
            else
            {
                return null;
            }

            return result;
        }

        public string GetTagNameById(int tagId)
        {
            var tag = tagRepository.FindTagById(tagId);
            return tag.Content;
        }
    }
}
