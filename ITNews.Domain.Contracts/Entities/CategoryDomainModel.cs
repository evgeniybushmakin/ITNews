namespace ITNews.Domain.Contracts.Entities
{
    public class CategoryDomainModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UserDomainModel User { get; set; }

        public string UserId { get; set; }
    }
}
