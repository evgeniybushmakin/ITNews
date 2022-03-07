using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITNews.Data.Contracts.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey ("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public List<Post> Posts { get; set; }
    }
}
