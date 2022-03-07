using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITNews.Data.Contracts.Entities
{
    public class PostRating
    {
        [Key]
        public int Id { get; set; }
        public int Mark { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public Post Post { get; set; }
        public ApplicationUser User { get; set; }
    }
}
