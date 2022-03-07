namespace ITNews.Web1.Models
{
    public class PostRatingViewModel
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; }

        public PostViewModel Post { get; set; }

        public UserViewModel User { get; set; }
    }
}
