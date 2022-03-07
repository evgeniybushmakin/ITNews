namespace ITNews.Domain.Contracts.Entities
{
    public class UserDomainModel
    {
        public string Id { get; set; }

        public bool Blocked { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public int ProfileId { get; set; }

        public string UserName { get; set; }
    }
}
