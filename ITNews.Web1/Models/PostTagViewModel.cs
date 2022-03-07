namespace ITNews.Web1.Models
{
    public class PostTagViewModel
    {
        public int PostId { get; set; }

        public int TagId { get; set; }

        public PostViewModel Post { get; set; }

        public TagViewModel Tag { get; set; }
    }
}
