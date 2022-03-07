using System.ComponentModel;

namespace ITNews.Web1.Models
{
    public class TagViewModel
    {     
        public int Id { get; set; }

        [DisplayName("Tags")]
        public string Content { get; set; }

    }
}
