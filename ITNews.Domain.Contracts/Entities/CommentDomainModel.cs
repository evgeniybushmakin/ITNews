using System;

namespace ITNews.Domain.Contracts.Entities
{
    public class CommentDomainModel
    {
        public int Id { get; set; }
   
        public string Content { get; set; }
       
        public DateTime Created { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; }
  
        public PostDomainModel Post { get; set; }

        public UserDomainModel User { get; set; }
    }
}
