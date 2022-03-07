namespace ITNews.Domain.Contracts.Entities
{
    public class PostRatingDomainModel
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public int PostId { get; set;}

        public string UserId { get; set; }
        
        public PostDomainModel Post { get; set; }

        public UserDomainModel User { get; set; }
    }
}
