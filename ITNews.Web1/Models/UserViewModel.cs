
namespace ITNews.Web1.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public bool Blocked { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public int ProfileId { get; set; }

        public string UserName { get; set; }
    }
}
