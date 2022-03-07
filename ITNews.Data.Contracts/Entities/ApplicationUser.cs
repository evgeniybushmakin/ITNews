using ITNews.Domain.Contracts.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ITNews.Data.Contracts.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool Blocked
        {
            get;
            set;
        }

        public virtual ICollection<Comment> Comments
        {
            get;
            set;
        }

        public virtual ICollection<Like> Likes
        {
            get;
            set;
        }

        public virtual ICollection<Post> Posts
        {
            get;
            set;
        }

        public virtual ICollection<Category> Categories
        {
            get;
            set;
        }

        public virtual ICollection<PostRatingDomainModel> PostsRating
        {
            get;
            set;
        }

        public int ProfileId
        {
            get;
            set;
        }

        public virtual Profile Profile
        {
            get;
            set;
        }

    }
}
