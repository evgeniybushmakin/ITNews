using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITNews.Web1.Models
{
    public class MainPostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DisplayName("Short Discription")]
        public string ShortDiscription { get; set; }

        public int Rating { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public UserViewModel User { get; set; }

        public CategoryViewModel Category { get; set; }

        public int CommentsCount { get; set; }

        public FullNameViewModel FullName { get; set;}
    }
}
