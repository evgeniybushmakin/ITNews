using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITNews.Data.Contracts.Entities
{
    public class Tag
    {     
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
