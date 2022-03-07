namespace ITNews.Domain.Contracts
{
    public interface IPostRatingService
    {
        bool IsAddedRating(string userId, int postId, int mark);
    }
}
