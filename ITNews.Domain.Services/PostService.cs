using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ITNews.Domain.Services
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;
        private ICategoryRepository categoryRepository;
        private ITagRepository tagRepository;
        private IPostTagRepository postTagRepository;
        private IMapper mapper;

        public PostService(IPostRepository postRepository, IMapper mapper, ICategoryRepository categoryRepository, 
            ITagRepository tagRepository, IPostTagRepository postTagRepository)
        {
            this.postRepository = postRepository;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.tagRepository = tagRepository;
            this.postTagRepository = postTagRepository;
        }
      
        public int CreatePost(PostDomainModel postDomainModel, string userId)
        {
            var post = mapper.Map<Post>(postDomainModel);
            postRepository.CreatePost(post, userId);
            post.Created = DateTime.Now;
            post.Updated = DateTime.Now;
            postRepository.Save();
            var postId = postRepository.GetPostId(post);
            return postId;
        }

        public void DeletePost(int postId)
        {
            var tags = postTagRepository.GetPostTags(postId);

            postRepository.DeletePost(postId);

            postRepository.Save();
          
            foreach (var item in tags)

                if (postTagRepository.FindNotUsedTag(item))
                {
                    tagRepository.DeleteTag(item);

                    tagRepository.Save();
                }
            
        }

        public void DeletePosts (string userId)
        {
            postRepository.DeletePosts(userId);
            postRepository.Save();
        }

        public IEnumerable<PostDomainModel> GetPosts()
        {
            var posts = postRepository.GetPostsOrderByRating();
            var postsDomainModel = mapper.Map<List<PostDomainModel>>(posts);
            return postsDomainModel;
        }

        public IEnumerable<PostDomainModel> GetPostsByUserId(string userId)
        {
            var post = postRepository.GetPostsByUserId(userId);
            var postDomainModel = mapper.Map<List<PostDomainModel>>(post);
            return postDomainModel;
        }

        public IEnumerable<PostDomainModel> GetPublishedPosts()
        {
            var posts = postRepository.GetPublishedPosts();
            var postsDomainModel = mapper.Map<List<PostDomainModel>>(posts);
            return postsDomainModel;
        }

        public PostDomainModel FindPost(int postId)
        {
            var post = postRepository.FindPostByPostId(postId);
            var postDomainModel = mapper.Map<PostDomainModel>(post);
            return postDomainModel;
        }

        public void UpdatePost(PostDomainModel post, string userId)
        {
            var updatePost = mapper.Map<Post>(post);
            postRepository.UpdatePost(updatePost, userId);
            updatePost.Updated = DateTime.Now;
            postRepository.Save();
        }

        public void UpdatePostByAdmin(PostDomainModel post)
        {
            var updatePost = mapper.Map<Post>(post);
            var editPost = postRepository.FindPostByPostId(post.Id);
            updatePost.Updated = DateTime.Now;
            postRepository.UpdatePost(updatePost, editPost.UserId);          
            postRepository.Save();
        }

        public PostDomainModel GetPostById(int postId)
        {
            var post = postRepository.GetPostById(postId);
            var postDomainModel = mapper.Map<PostDomainModel>(post);
            return postDomainModel;
        }

        public IEnumerable<PostDomainModel> GetPopularPosts()
        {
            var posts = postRepository.GetPostsOrderByRating();
            var postsDomainModel = mapper.Map<List<PostDomainModel>>(posts);
            return postsDomainModel;
        }

        public IEnumerable<SearchDomainModel> Search(string search)
        {
            Chilkat.HtmlToText h2t = new Chilkat.HtmlToText();
            bool success = h2t.UnlockComponent("30-day trial");
            if (success != true)
            {
                Debug.WriteLine(h2t.LastErrorText);
                return null;
            }

            var postsTitle = postRepository.SearchByTitle(search);
            var postsContent = postRepository.SearchByContent(search);
            List<SearchDomainModel> result = new List<SearchDomainModel>();
           

            foreach (var item in postsTitle)
            {
                var content = h2t.ToText(item.Content);

                if (content.Length < 80)
                {
                    result.Add(new SearchDomainModel
                    {
                        Id = item.Id,
                        Content = content,
                        Title = item.Title
                    });
                }
                else
                {
                    result.Add(new SearchDomainModel
                    {
                        Id = item.Id,
                        Content = content.Substring(1, 80),
                        Title = item.Title
                    });
                }
            }

            foreach (var item in postsContent)
            {
                var content = h2t.ToText(item.Content);
                var contentLow = content.ToLower();
                var startSub = contentLow.IndexOf(search.ToLower());

                if (content.Length < 80)
                {
                    result.Add(new SearchDomainModel
                    {
                        Id = item.Id,
                        Content = content,
                        Title = item.Title
                    });
                    continue;
                }
                if (content.Length-startSub >= 80)
                {
                    result.Add(new SearchDomainModel
                    {
                        Id = item.Id,
                        Content = content.Substring(startSub, 80),
                        Title = item.Title
                    });
                }
                else
                {
                    result.Add(new SearchDomainModel
                    {
                        Id = item.Id,
                        Content = content.Substring((startSub+search.Length)-80, 80),
                        Title = item.Title
                    });
                }
            }

            return result;
        }

        public void AddRating (int postId, int mark)
        {
            var post = postRepository.FindPostByPostId(postId);

            post.Rating = post.Rating + mark;

            postRepository.EditPost(post);

            postRepository.Save();
        }
    }
}
