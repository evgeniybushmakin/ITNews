namespace ITNews.Domain.Contracts.Entities
{
    public class PostTagDomainModel
    {
        public int PostId { get; set; }

        public int TagId { get; set; }

        public PostDomainModel Post { get; set; }

        public TagDomainModel Tag { get; set; }
    }
}
