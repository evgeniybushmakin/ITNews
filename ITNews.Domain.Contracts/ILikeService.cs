namespace ITNews.Domain.Contracts
{
    public interface ILikeService
    {
        bool IsAddedLike(int commentId, string userId);

        bool UserLike(int commentId, string userId);

        int GetCountLikes(int commentId);

        void DeleteLikes(string userId);
    }
}
