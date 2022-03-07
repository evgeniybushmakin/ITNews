using System.ComponentModel;

namespace ITNews.Web1.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Категория")]
        public string Name { get; set; }

        public string UserId { get; set; }

        public UserViewModel User { get; set; }
    }
}
