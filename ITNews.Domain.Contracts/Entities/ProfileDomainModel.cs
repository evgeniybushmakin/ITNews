namespace ITNews.Domain.Contracts.Entities
{
    public class ProfileDomainModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
     
        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Avatar { get; set; }

        public string UserId { get; set; }

        public UserDomainModel User { get; set; }
    }
}
