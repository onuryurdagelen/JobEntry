using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class Review:IBaseEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public float Rating { get; set; }
        public DateTime Date { get; set; }

        public Guid? ParentReviewId { get; set; }
        public Review? ParentReview { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<Review> SubReviews { get; set; } = new HashSet<Review>();
    }
}
