using System.Collections.Generic;
using System.ComponentModel;

namespace ITNews.Web1.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }
        
        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Avatar")]
        public string Avatar { get; set; }

        public string UserId { get; set; }
        [DisplayName("Role")]
        public RoleViewModel Role { get; set; }
        [DisplayName("User")]
        public UserViewModel User { get; set; }
        [DisplayName("Roles")]
        public List<RoleViewModel> Roles { get; set; }
    }
}
