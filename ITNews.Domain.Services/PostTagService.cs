using AutoMapper;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;
using ITNews.Domain.Contracts.Entities;
using System.Collections.Generic;


namespace ITNews.Domain.Services
{
    public class PostTagService : IPostTagService
    {
        private IPostTagRepository postTagRepository;
        private IMapper mapper;
        private readonly IPostService postService;

        public PostTagService(IMapper mapper, IPostTagRepository postTagRepository, IPostService postService)
        {
            this.mapper = mapper;
            this.postTagRepository = postTagRepository;
            this.postService = postService;
        }
        public IEnumerable<PostTagDomainModel> GetPostsTags()
        {
            var postsTags =postTagRepository.GetPostsTags();
            var postsTagsDomainModel = mapper.Map<List<PostTagDomainModel>>(postsTags);
            return postsTagsDomainModel;
        }

        public IEnumerable<PostTagDomainModel> GetPostsByTagId(int tagId)
        {
            var postsTags = postTagRepository.PostsByTagId(tagId);
            var postsTagsDomainModel = mapper.Map<List<PostTagDomainModel>>(postsTags);
            return postsTagsDomainModel;
        }
        public int AmountRating(string userId)
        {
            var posts = postService.GetPostsByUserId(userId);
            int amount=0;
            foreach (var item in posts)
            {
                amount += item.Rating;
            }
            return amount;
        }
    }
}
