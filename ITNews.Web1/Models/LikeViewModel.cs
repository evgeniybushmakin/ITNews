namespace ITNews.Web1.Models
{
    public class LikeViewModel
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public string UserId { get; set; }
      
        public CommentViewModel Comment { get; set; }

        public UserViewModel User { get; set; }
    }
}
