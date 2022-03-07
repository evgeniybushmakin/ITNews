using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITNews.Data.Contracts.Entities
{
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
            PostsRating = new List<PostRating>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool Published { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string ShortDiscription { get; set; }
        public int Rating { get; set; }
        public DateTime Updated { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public ApplicationUser User { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostRating> PostsRating { get; set; }
        public List<PostTag> PostTags { get; set; }
      
    }
}
