using System;

namespace ITNews.Domain.Contracts.Entities
{
    public class PostDomainModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
  
        public string Content { get; set; }
     
        public bool Published { get; set; }
      
        public DateTime Created { get; set; }
      
        public string ShortDiscription { get; set; }

        public int Rating { get; set; }

        public DateTime Updated { get; set; }

        public UserDomainModel User { get; set; }

        public CategoryDomainModel Category { get; set; }    
        
        public int CategoryId { get; set; }

        public string UserId { get; set; }
    }
}
