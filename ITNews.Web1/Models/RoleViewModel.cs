using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITNews.Web1.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [DisplayName("Role")]
        public string Name { get; set; }

    }
}
