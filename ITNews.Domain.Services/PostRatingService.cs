using AutoMapper;
using ITNews.Data.Contracts.Entities;
using ITNews.Data.Contracts.Repositories;
using ITNews.Domain.Contracts;

namespace ITNews.Domain.Services
{
    public class PostRatingService : IPostRatingService
    {
        private readonly IPostRatingRepository postRatingRepository;
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public PostRatingService(IPostRatingRepository postRatingRepository, IPostRepository postRepository, IMapper mapper)
        {
            this.postRatingRepository = postRatingRepository;
            this.postRepository = postRepository;
            this.mapper = mapper;
        }

        public bool IsAddedRating(string userId, int postId, int mark)
        {
            var userIsVoted = postRatingRepository.UserIsVoted(userId, postId);

            if (userIsVoted)
            {
                return false;
            }
            else
            {
                postRatingRepository.AddRating(new PostRating { UserId = userId, PostId = postId, Mark = mark });

                postRatingRepository.Save();

                return true;
            }
        }
    }
}
