namespace ITNews.Domain.Contracts.Entities
{
    public class LikeDomainModel
    {
        public int Id { get; set; }
       
        public int CommentId { get; set; }

        public string UserId { get; set; }

        public CommentDomainModel Comment { get; set; }

        public UserDomainModel User { get; set; }
    }
}
