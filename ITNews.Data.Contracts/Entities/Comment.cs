using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITNews.Data.Contracts.Entities
{
    public class Comment
    {
        public Comment()
        {
            Likes = new List<Like>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public Post Post { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
