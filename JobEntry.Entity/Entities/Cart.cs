using JobEntry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobEntry.Entity.Entities
{
    public class Cart:BaseEntity
    {
        public Guid? UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}
