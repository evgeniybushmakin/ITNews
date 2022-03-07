using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITNews.Data.Contracts.Entities
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public Comment Comment { get; set; }
        public ApplicationUser User { get; set; }
    }
}
