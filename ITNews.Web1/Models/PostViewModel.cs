using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITNews.Web1.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

     //   [Required]
        public string Title { get; set; }
     //   [Required]
        public string Content { get; set; }

        public bool Published { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        // [Required]
     
        [DisplayName("Short Discription")]
        public string ShortDiscription { get; set; }

        public int Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public UserViewModel User { get; set; }

        public CategoryViewModel Category { get; set; }

        public TagViewModel Tag { get; set; }

        public FullNameViewModel FullName { get; set; }
    }
}
